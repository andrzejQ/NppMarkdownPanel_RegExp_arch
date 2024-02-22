## Wordle

**Wordcloud for data in list: `*` count `\s+` phrase `\n+` comment for the entry 
  with the most weight**

* 3 HDMI+audio  
    And if anything to add?
* 8 USB-C DP  
    Comments will appear,  
    for the entry  
    with the most weight.
* 2 VGA  
    Words = the text after the `\d+` to the nearest `\n` or `\r`.
* 1 Miracast
* 1 Chromecast
* 2 DLNA
* 5 other

<style> 
ul li:first-line {font-size: 21px; text-decoration: underline}
h2:first-child {font-size: 18px; text-align: center; color:DarkBlue;}
.blue {color:blue;}
</style>

<!--div class="box"> <canvas id="my_canvas" class="canvas" width="500" height="350"></canvas> </div-->
<style> 
#my_canvas { pointer-events: none; cursor: pointer; margin: 10px; box-shadow: 0 0 7px 7px rgba(0, 0, 155, 0.3); background-color: aqua; border-radius: 100px;} 
ul li {/*display:inline;*/ display:none;}
</style>
<div class="box" id="my_canvas" style="width:360px; height:300px; float:left; margin-right:20px;"> </div>
<p id="rem"></p>

<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/wordcloud2.js/1.1.0/wordcloud2.min.js"></script>
<script type="text/javascript">
  //  https://github.com/timdream/wordcloud2.js/blob/gh-pages/API.md - API document for available options.
  //  V. 1.1.0 wordcloud2.js works in Notepad++ - Markdown Panel (JScript 11.0.16384)
  const MIN = 2, FACTOR = 2; PLUS = 7 //min. font size and scale
  options = { drawOutOfBound:true, backgroundColor:'#F0FFFF', color:'random-dark', shuffle:0, minRotation:-0.7, maxRotation:0.7, };
    //fontFamily minRotation maxRotation shuffle rotateRatio
    //, minRotation:-0.5, maxRotation:0.5,        , rotateRatio:0

  let list = []; //[ [word,count], ...]
  let ul_0 = document.getElementsByTagName('ul')[0].innerHTML; 
  //for the first list on the page, search for a number + words in <li>
  //                      1       2            3    4 (second+ line in <li>)
  const re = /<li[^>]*>[ \t]*(\d+)[ \t]+(.+?)([\r\n]([\s\S]*?))?<\/li>/gi //[\s\S]: missing dotAll in IE
  let n_max = -1
  while ( (m = re.exec(ul_0)) !== null ) { //alert(m[1]+"->"+m[2]+" @ "+m[3]);//test
    let n = parseInt(m[1])
    list.push( [ m[2].replace(/<br[^>]*>/i,''), PLUS + FACTOR * Math.max( MIN, n ) ] );
    if (n > n_max) {n_max = n; document.getElementById('rem').innerHTML = m[4] || '- - -'}
  } //see. https://bugzilla.mozilla.org/show_bug.cgi?id=1776381
  options['list'] = list;
  WordCloud(document.getElementById('my_canvas'), options );
</script>
<!-- -->