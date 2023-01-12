﻿using Kbg.NppPluginNET.PluginInfrastructure;
using SHDocVw;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NppMarkdownPanel.Forms
{
    public partial class MarkdownPreviewForm : Form
    {
        const string DEFAULT_HTML_BASE =
         @"<!DOCTYPE html>
            <html>
                <head>                    
                    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
                    <meta http-equiv=""content-type"" content=""text/html; charset=utf-8"">
                    <title>{0}</title>
                    <style type=""text/css"">
                    {1}
                    </style>
                </head>
                <body style=""{2}"">
                {3}
                </body>
            </html>
            ";

        const string MSG_NO_SUPPORTED_FILE_EXT = "<h3>The current file <u>{0}</u> has no valid Markdown file extension.</h3><div>Valid file extensions:{1}</div>";

        private Task<RenderResult> renderTask;
        private readonly Action toolWindowCloseAction;
        private int lastVerticalScroll = 0;
        private string htmlContentForExport;
        private bool showToolbar;
        private bool showStatusbar;

        public string CssFileName { get; set; }

        public string CssDarkModeFileName { get; set; }

        public int ZoomLevel { get; set; }
        public string HtmlFileName { get; set; }

        public string CurrentFilePath { get; set; }

        public string SupportedFileExt { get; set; }

        private bool isDarkModeEnabled;
        public bool IsDarkModeEnabled
        {
            get { return isDarkModeEnabled; }
            set
            {
                isDarkModeEnabled = value;
                if (isDarkModeEnabled)
                {
                    tbPreview.BackColor = Color.Black;
                    btnSaveHtml.ForeColor = Color.White;
                    statusStrip2.BackColor = Color.Black;
                    toolStripStatusLabel1.ForeColor = Color.White;

                }
                else
                {
                    tbPreview.BackColor = SystemColors.Control;
                    btnSaveHtml.ForeColor = SystemColors.ControlText;
                    statusStrip2.BackColor = SystemColors.Control;
                    toolStripStatusLabel1.ForeColor = SystemColors.ControlText;

                }
            }
        }

        public bool ShowToolbar
        {
            get => showToolbar;
            set
            {
                showToolbar = value;
                tbPreview.Visible = value;
            }
        }

        public bool ShowStatusbar
        {
            get => showStatusbar;
            set
            {
                showStatusbar = value;
                statusStrip2.Visible = value;
            }
        }

        public bool UseRegExp { get; set; }
        public string RegExpFileName { get; set; }
        public string[] RegExp3lines { get; set; } //(re)read it from RegExpFileName if null
            //multiply 3-strings: Comment, Pattern, ReplacementPattern

        private IMarkdownGenerator markdownGenerator;

        public MarkdownPreviewForm(Action toolWindowCloseAction)
        {
            this.toolWindowCloseAction = toolWindowCloseAction;
            InitializeComponent();
            markdownGenerator = MarkdownPanelController.GetMarkdownGeneratorImpl();
        }

        private RenderResult RenderHtmlInternal(string currentText, string filepath)
        {

            //multipl. 1+2 rows of RegExp: Comment (ignored) + Pattern, ReplacementPattern
            if (UseRegExp)
            {
                if (RegExp3lines is null)
                {//re-read it
                    RegExp3lines = GetRegExp3lines();
                }
                if (RegExp3lines is null)
                {
                    RegExp3lines = new string[0]; //!= null - don't re-read RegExpFile if not exists
                }
                else
                {
                    currentText = RegExp3replace(currentText, RegExp3lines);
                }
            }

            var defaultBodyStyle = "";
            var markdownStyleContent = GetCssContent(filepath);

            if (!isValidFileExtension(CurrentFilePath))
            {
                var invalidExtensionMessage = string.Format(MSG_NO_SUPPORTED_FILE_EXT, Path.GetFileName(filepath), SupportedFileExt);
                invalidExtensionMessage = string.Format(DEFAULT_HTML_BASE, Path.GetFileName(filepath), markdownStyleContent, defaultBodyStyle, invalidExtensionMessage);

                return new RenderResult(invalidExtensionMessage, invalidExtensionMessage);
            }

            var resultForBrowser = markdownGenerator.ConvertToHtml(currentText, filepath, true);
            var resultForExport = markdownGenerator.ConvertToHtml(currentText, null, false);

            var markdownHtmlBrowser = string.Format(DEFAULT_HTML_BASE, Path.GetFileName(filepath), markdownStyleContent, defaultBodyStyle, resultForBrowser);
            var markdownHtmlFileExport = string.Format(DEFAULT_HTML_BASE, Path.GetFileName(filepath), markdownStyleContent, defaultBodyStyle, resultForExport);
            return new RenderResult(markdownHtmlBrowser, markdownHtmlFileExport);
        }

        /// <summary>
        /// Loop - convert inputStr according to regExp3lines
        /// </summary>
        /// <param name="inputStr">Text to replace</param>
        /// <param name="regExp3str">multipl. 1+2 rows of RegExp: Comment (ignored) + Pattern, ReplacementPattern
        /// https://docs.microsoft.com/dotnet/standard/base-types/regular-expression-language-quick-reference
        /// </param>
        /// <returns>modified string</returns>
        private string RegExp3replace(string inputStr, string[] regExp3lines)
        {
            if (regExp3lines.Length > 0)
            {
                string[] s123 = new String[3];
                for (int i = 0; i < regExp3lines.Length; i += 3)
                {
                    Array.Copy(regExp3lines, i, s123, 0, 3);
                    inputStr = System.Text.RegularExpressions.Regex.Replace(inputStr, s123[1], s123[2]);//comment in s123[0])

                }

            }
            return inputStr;
        }

        /// <summary>
        /// GetRegExp3lines
        /// </summary>
        /// <param>Txt with multipl. 1+2 rows of RegExp: Comment (ignored) + Pattern, ReplacementPattern</param>
        /// <returns>regExp3lines - string[], Length = 3*n</returns>
        /// 
        private string[] GetRegExp3lines()
        {
            string[] regExp3lines = null;
            // Path of plugin directory
            var assemblyPath = Path.GetDirectoryName(Assembly.GetAssembly(GetType()).Location);

            if (Utils.FileNameExists(RegExpFileName, assemblyPath + "\\" + RegExpFileName, out string finalRegExpFName))
            {
              string regExp3str = File.ReadAllText(finalRegExpFName, Encoding.UTF8);//Utf8 with or w/o BOM 
  
              regExp3lines = regExp3str.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
  
              if ((regExp3lines.Length % 3 != 0)
                  && (regExp3lines[regExp3lines.Length - 1] == ""))
              { //remove last empty elem.
                  Array.Resize(ref regExp3lines, regExp3lines.Length - 1);
              }
              int addSize = regExp3lines.Length % 3;
              if (addSize > 0)
              {
                  addSize = 3 - addSize;
                  Array.Resize(ref regExp3lines, regExp3lines.Length + addSize);
                  while (addSize > 0)
                  {
                      regExp3lines[regExp3lines.Length - addSize--] = "";
                  }
              }
              for (int i = 2; i < regExp3lines.Length; i += 3)
              {
                  regExp3lines[i] = regExp3lines[i]
                                      .Replace("\\n", "\n")
                                      .Replace("\\r", "\r")
                                      .Replace("\\t", "\t");
              }
            }
            return regExp3lines;
        }

        private string GetCssContent(string filepath)
        {
            // Path of plugin directory
            var cssContent = "";

            var assemblyPath = Path.GetDirectoryName(Assembly.GetAssembly(GetType()).Location);

            var defaultCss = IsDarkModeEnabled ? MainResources.DefaultDarkModeCssFile : MainResources.DefaultCssFile;
            var customCssFile = IsDarkModeEnabled ? CssDarkModeFileName : CssFileName;
            if (File.Exists(customCssFile))
            {
                cssContent = File.ReadAllText(customCssFile);
            }
            else
            {
                cssContent = File.ReadAllText(assemblyPath + "\\" + defaultCss);
            }

            return cssContent;
        }

        public void RenderMarkdown(string currentText, string filepath, bool preserveVerticalScrollPosition = true)
        {
            if (renderTask == null || renderTask.IsCompleted)
            {
                if (preserveVerticalScrollPosition)
                {
                    SaveLastVerticalScrollPosition();
                }
                else
                {
                    lastVerticalScroll = 0;
                }

                MakeAndDisplayScreenShot();

                var context = TaskScheduler.FromCurrentSynchronizationContext();
                renderTask = new Task<RenderResult>(() => RenderHtmlInternal(currentText, filepath));
                renderTask.ContinueWith((renderedText) =>
                {
                    webBrowserPreview.DocumentText = renderedText.Result.ResultForBrowser;
                    htmlContentForExport = renderedText.Result.ResultForExport;
                    if (!String.IsNullOrWhiteSpace(HtmlFileName))
                    {
                        bool valid = Utils.ValidateFileSelection(HtmlFileName, out string fullPath, out string error, "HTML Output");
                        if (valid)
                        {
                            HtmlFileName = fullPath; // the validation was run against this path, so we want to make sure the state of the preview matches that
                            writeHtmlContentToFile(HtmlFileName);
                        }
                    }
                    AdjustZoomLevel();
                }, context);
                renderTask.Start();
            }
        }
        /// <summary>
        /// Makes and displays a screenshot of the current browser content to prevent it from flickering 
        /// while loading updated content
        /// </summary>
        private void MakeAndDisplayScreenShot()
        {
            Bitmap screenshot = new Bitmap(webBrowserPreview.Width, webBrowserPreview.Height);
            ActiveXScreenShotMaker.GetImage(webBrowserPreview.ActiveXInstance, screenshot, Color.White);
            pictureBoxScreenshot.Image = screenshot;
            pictureBoxScreenshot.Visible = true;
        }

        /// <summary>
        /// Saves the last vertical scrollpositions, after reloading the position will be 0
        /// </summary>
        private void SaveLastVerticalScrollPosition()
        {
            if (webBrowserPreview.Document != null)
            {
                try
                {
                    lastVerticalScroll = webBrowserPreview.Document.GetElementsByTagName("HTML")[0].ScrollTop;
                }
                catch { }
            }
        }

        private void webBrowserPreview_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Cursor.Current = Cursors.IBeam;
            GoToLastVerticalScrollPosition();
            HideScreenshotAndShowBrowser();
        }

        private void GoToLastVerticalScrollPosition()
        {
            webBrowserPreview.Document.Window.ScrollTo(0, lastVerticalScroll);
            Application.DoEvents();
        }


        private void HideScreenshotAndShowBrowser()
        {
            pictureBoxScreenshot.Visible = false;
            pictureBoxScreenshot.Image = null;
        }

        public void ScrollToElementWithLineNo(int lineNo)
        {
            Application.DoEvents();
            if (webBrowserPreview.Document != null)
            {
                HtmlElement child = null;

                for (int i = lineNo; i >= 0; i--)
                {
                    var htmlElement = webBrowserPreview.Document.GetElementById(i.ToString());
                    if (htmlElement != null)
                    {
                        child = htmlElement;
                        break;
                    }
                }

                if (child != null)
                    webBrowserPreview.Document.Window.ScrollTo(0, CalculateAbsoluteYOffset(child) - 20);
            }
        }

        private int CalculateAbsoluteYOffset(HtmlElement currentElement)
        {
            int baseY = currentElement.OffsetRectangle.Top;
            var offsetParent = currentElement.OffsetParent;
            while (offsetParent != null)
            {
                baseY += offsetParent.OffsetRectangle.Top;
                offsetParent = offsetParent.OffsetParent;
            }

            return baseY;
        }

        /// <summary>
        /// Increase Zoomlevel in case of higher DPI settings
        /// </summary>
        private void AdjustZoomLevel()
        {
            Application.DoEvents();

            var browserInst = ((SHDocVw.IWebBrowser2)(webBrowserPreview.ActiveXInstance));
            browserInst.ExecWB(OLECMDID.OLECMDID_OPTICAL_ZOOM, OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER, ZoomLevel, IntPtr.Zero);
            //   webBrowserPreview.Document.Window.ScrollTo(0, 0);

        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NMHDR
        {
            public IntPtr hwndFrom;
            public IntPtr idFrom;
            public int code;
        }

        public enum WindowsMessage
        {
            WM_NOTIFY = 0x004E
        }

        protected override void WndProc(ref Message m)
        {
            //Listen for the closing of the dockable panel to toggle the toolbar icon
            switch (m.Msg)
            {
                case (int)WindowsMessage.WM_NOTIFY:
                    var notify = (NMHDR)Marshal.PtrToStructure(m.LParam, typeof(NMHDR));
                    if (notify.code == (int)DockMgrMsg.DMN_CLOSE)
                    {
                        toolWindowCloseAction();
                    }
                    break;
            }
            //Continue the processing, as we only toggle
            base.WndProc(ref m);
        }

        private void webBrowserPreview_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (!e.Url.ToString().StartsWith("about:blank"))
            {
                e.Cancel = true;
                var p = new Process();
                p.StartInfo = new ProcessStartInfo(e.Url.ToString());
                p.Start();
            }
            else
            {
                // Jump to correct anchor on the page
                if (e.Url.ToString().Contains("#"))
                {
                    var urlParts = e.Url.ToString().Split('#');
                    e.Cancel = true;
                    var element = webBrowserPreview.Document.GetElementById(urlParts[1]);
                    if (element != null)
                    {
                        element.Focus();
                        element.ScrollIntoView(true);
                    }
                }
            }
        }

        private void webBrowserPreview_StatusTextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = webBrowserPreview.StatusText;
        }

        private void btnSaveHtml_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "html files (*.html, *.htm)|*.html;*.htm|All files (*.*)|*.*";
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.InitialDirectory = Path.GetDirectoryName(CurrentFilePath);
                saveFileDialog.FileName = Path.GetFileNameWithoutExtension(CurrentFilePath);
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    writeHtmlContentToFile(saveFileDialog.FileName);
                }
            }
        }

        private void writeHtmlContentToFile(string filename)
        {
            if (!string.IsNullOrEmpty(filename))
            {
                File.WriteAllText(filename, htmlContentForExport);
            }
        }


        public bool isValidFileExtension(string filename)
        {
            var currentExtension = Path.GetExtension(filename).ToLower();
            var matchExtensionList = false;
            try
            {
                matchExtensionList = SupportedFileExt.Split(',').Any(ext => ext != null && currentExtension.Equals("." + ext.Trim().ToLower()));
            }
            catch (Exception)
            {
            }

            return matchExtensionList;
        }

    }
}
