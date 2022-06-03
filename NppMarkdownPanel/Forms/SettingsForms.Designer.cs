﻿namespace NppMarkdownPanel.Forms
{
    partial class SettingsForms
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForms));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCssFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.lblZoomValue = new System.Windows.Forms.Label();
            this.btnChooseCss = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnResetHtml = new System.Windows.Forms.Button();
            this.btnChooseHtml = new System.Windows.Forms.Button();
            this.tbHtmlFile = new System.Windows.Forms.TextBox();
            this.lblHtmlFile = new System.Windows.Forms.Label();
            this.cbShowToolbar = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sblInvalidHtmlPath = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbUseRegExp = new System.Windows.Forms.CheckBox();
            this.btnResetRegExp = new System.Windows.Forms.Button();
            this.btnChooseRegExp = new System.Windows.Forms.Button();
            this.tbRegExpFile = new System.Windows.Forms.TextBox();
            this.lblRegExpFile = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(697, 61);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Markdown Panel Settings";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NppMarkdownPanel.Properties.Resources.markdown_16x16_solid;
            this.pictureBox1.Location = new System.Drawing.Point(10, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 20);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(472, 408);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 36);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(583, 408);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 36);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "CSS File:";
            // 
            // tbCssFile
            // 
            this.tbCssFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCssFile.Location = new System.Drawing.Point(138, 97);
            this.tbCssFile.Name = "tbCssFile";
            this.tbCssFile.Size = new System.Drawing.Size(422, 24);
            this.tbCssFile.TabIndex = 4;
            this.tbCssFile.TextChanged += new System.EventHandler(this.tbCssFile_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Zoom Level:";
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(130, 146);
            this.trackBar1.Maximum = 400;
            this.trackBar1.Minimum = 40;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(512, 53);
            this.trackBar1.TabIndex = 6;
            this.trackBar1.TickFrequency = 5;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Value = 90;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // lblZoomValue
            // 
            this.lblZoomValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblZoomValue.AutoSize = true;
            this.lblZoomValue.Location = new System.Drawing.Point(648, 161);
            this.lblZoomValue.Name = "lblZoomValue";
            this.lblZoomValue.Size = new System.Drawing.Size(33, 17);
            this.lblZoomValue.TabIndex = 7;
            this.lblZoomValue.Text = "90%";
            // 
            // btnChooseCss
            // 
            this.btnChooseCss.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseCss.Location = new System.Drawing.Point(566, 95);
            this.btnChooseCss.Name = "btnChooseCss";
            this.btnChooseCss.Size = new System.Drawing.Size(39, 25);
            this.btnChooseCss.TabIndex = 8;
            this.btnChooseCss.Text = "...";
            this.btnChooseCss.UseVisualStyleBackColor = true;
            this.btnChooseCss.Click += new System.EventHandler(this.btnChooseCss_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(611, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 26);
            this.button1.TabIndex = 9;
            this.button1.Text = "Default";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnResetHtml
            // 
            this.btnResetHtml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetHtml.Location = new System.Drawing.Point(611, 215);
            this.btnResetHtml.Name = "btnResetHtml";
            this.btnResetHtml.Size = new System.Drawing.Size(73, 26);
            this.btnResetHtml.TabIndex = 13;
            this.btnResetHtml.Text = "Default";
            this.btnResetHtml.UseVisualStyleBackColor = true;
            this.btnResetHtml.Click += new System.EventHandler(this.btnResetHtml_Click);
            // 
            // btnChooseHtml
            // 
            this.btnChooseHtml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseHtml.Location = new System.Drawing.Point(566, 215);
            this.btnChooseHtml.Name = "btnChooseHtml";
            this.btnChooseHtml.Size = new System.Drawing.Size(39, 25);
            this.btnChooseHtml.TabIndex = 12;
            this.btnChooseHtml.Text = "...";
            this.btnChooseHtml.UseVisualStyleBackColor = true;
            this.btnChooseHtml.Click += new System.EventHandler(this.btnChooseHtml_Click);
            // 
            // tbHtmlFile
            // 
            this.tbHtmlFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHtmlFile.Location = new System.Drawing.Point(138, 217);
            this.tbHtmlFile.Name = "tbHtmlFile";
            this.tbHtmlFile.Size = new System.Drawing.Size(422, 24);
            this.tbHtmlFile.TabIndex = 11;
            this.tbHtmlFile.TextChanged += new System.EventHandler(this.tbHtmlFile_TextChanged);
            this.tbHtmlFile.Leave += new System.EventHandler(this.tbHtmlFile_Leave);
            // 
            // lblHtmlFile
            // 
            this.lblHtmlFile.AutoSize = true;
            this.lblHtmlFile.Location = new System.Drawing.Point(12, 189);
            this.lblHtmlFile.Name = "lblHtmlFile";
            this.lblHtmlFile.Size = new System.Drawing.Size(125, 68);
            this.lblHtmlFile.TabIndex = 10;
            this.lblHtmlFile.Text = "Automatically Save \r\nHTML from Current \r\nPreview to this File:\r\n(\".\" = auto-name)" +
    "";
            // 
            // cbShowToolbar
            // 
            this.cbShowToolbar.AutoSize = true;
            this.cbShowToolbar.Location = new System.Drawing.Point(138, 277);
            this.cbShowToolbar.Name = "cbShowToolbar";
            this.cbShowToolbar.Size = new System.Drawing.Size(220, 21);
            this.cbShowToolbar.TabIndex = 15;
            this.cbShowToolbar.Text = "Show Toolbar in Preview Window";
            this.cbShowToolbar.UseVisualStyleBackColor = true;
            this.cbShowToolbar.CheckedChanged += new System.EventHandler(this.cbShowToolbar_Changed);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sblInvalidHtmlPath});
            this.statusStrip1.Location = new System.Drawing.Point(0, 456);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(700, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sblInvalidHtmlPath
            // 
            this.sblInvalidHtmlPath.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sblInvalidHtmlPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.sblInvalidHtmlPath.ForeColor = System.Drawing.Color.Red;
            this.sblInvalidHtmlPath.Name = "sblInvalidHtmlPath";
            this.sblInvalidHtmlPath.Size = new System.Drawing.Size(685, 16);
            this.sblInvalidHtmlPath.Spring = true;
            // 
            // cbUseRegExp
            // 
            this.cbUseRegExp.AutoSize = true;
            this.cbUseRegExp.Location = new System.Drawing.Point(138, 330);
            this.cbUseRegExp.Name = "cbUseRegExp";
            this.cbUseRegExp.Size = new System.Drawing.Size(41, 21);
            this.cbUseRegExp.TabIndex = 21;
            this.cbUseRegExp.Text = "->";
            this.cbUseRegExp.UseVisualStyleBackColor = true;
            this.cbUseRegExp.CheckedChanged += new System.EventHandler(this.cbUseRegExp_CheckedChanged);
            // 
            // btnResetRegExp
            // 
            this.btnResetRegExp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetRegExp.Enabled = false;
            this.btnResetRegExp.Location = new System.Drawing.Point(611, 326);
            this.btnResetRegExp.Name = "btnResetRegExp";
            this.btnResetRegExp.Size = new System.Drawing.Size(73, 26);
            this.btnResetRegExp.TabIndex = 20;
            this.btnResetRegExp.Text = "Default";
            this.btnResetRegExp.UseVisualStyleBackColor = true;
            this.btnResetRegExp.Click += new System.EventHandler(this.btnResetRegExp_Click);
            // 
            // btnChooseRegExp
            // 
            this.btnChooseRegExp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseRegExp.Enabled = false;
            this.btnChooseRegExp.Location = new System.Drawing.Point(566, 326);
            this.btnChooseRegExp.Name = "btnChooseRegExp";
            this.btnChooseRegExp.Size = new System.Drawing.Size(39, 25);
            this.btnChooseRegExp.TabIndex = 19;
            this.btnChooseRegExp.Text = "...";
            this.btnChooseRegExp.UseVisualStyleBackColor = true;
            this.btnChooseRegExp.Click += new System.EventHandler(this.btnChooseRegExp_Click);
            // 
            // tbRegExpFile
            // 
            this.tbRegExpFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRegExpFile.Enabled = false;
            this.tbRegExpFile.Location = new System.Drawing.Point(189, 328);
            this.tbRegExpFile.Name = "tbRegExpFile";
            this.tbRegExpFile.Size = new System.Drawing.Size(371, 24);
            this.tbRegExpFile.TabIndex = 18;
            this.tbRegExpFile.TextChanged += new System.EventHandler(this.tbRegExpFile_TextChanged);
            // 
            // lblRegExpFile
            // 
            this.lblRegExpFile.AutoSize = true;
            this.lblRegExpFile.Location = new System.Drawing.Point(12, 332);
            this.lblRegExpFile.Name = "lblRegExpFile";
            this.lblRegExpFile.Size = new System.Drawing.Size(78, 17);
            this.lblRegExpFile.TabIndex = 17;
            this.lblRegExpFile.Text = "Use RegExp";
            // 
            // SettingsForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 478);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cbShowToolbar);
            this.Controls.Add(this.cbUseRegExp);
            this.Controls.Add(this.btnResetRegExp);
            this.Controls.Add(this.btnChooseRegExp);
            this.Controls.Add(this.tbRegExpFile);
            this.Controls.Add(this.lblRegExpFile);
            this.Controls.Add(this.btnResetHtml);
            this.Controls.Add(this.btnChooseHtml);
            this.Controls.Add(this.tbHtmlFile);
            this.Controls.Add(this.lblHtmlFile);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnChooseCss);
            this.Controls.Add(this.lblZoomValue);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbCssFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingsForms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCssFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lblZoomValue;
        private System.Windows.Forms.Button btnChooseCss;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnResetHtml;
        private System.Windows.Forms.Button btnChooseHtml;
        private System.Windows.Forms.TextBox tbHtmlFile;
        private System.Windows.Forms.Label lblHtmlFile;
        private System.Windows.Forms.CheckBox cbShowToolbar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sblInvalidHtmlPath;
        private System.Windows.Forms.CheckBox cbUseRegExp;
        private System.Windows.Forms.Button btnResetRegExp;
        private System.Windows.Forms.Button btnChooseRegExp;
        private System.Windows.Forms.TextBox tbRegExpFile;
        private System.Windows.Forms.Label lblRegExpFile;
    }
}