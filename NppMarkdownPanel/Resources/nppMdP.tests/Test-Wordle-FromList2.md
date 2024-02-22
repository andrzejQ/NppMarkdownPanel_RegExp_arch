## Wordle

**Wordcloud for data in list: `*` count `\s+` phrase `sub-<ul>` comment for the entry 
  with the most weight**

<div id="main">

* 3 HDMI+audio 
    * And if anything to add
* 18 USB-C DP 
    * Comments will appear, 
       * sub-li
       * subli
    * for the entry 
    * with the most weight.

</div>

<style>
p, blockquote, ul, ol, dl, li, table, pre {
  margin: 0; /*7px 0; */
  padding-top: 5px; padding-bottom: 5px;
}
ul :first-child, ol :first-child { margin-top: 0; }
ul :last-child, ol :last-child { margin-bottom: 0; }
#main > ul > li {list-style-type: none; margin-top:22px;}
#main > ul > li:first-line {font-size: 21px; text-decoration: underline;}
h2:first-child {font-size: 166%; text-align: center; color:DarkBlue;}
.blue {color:blue;}
#main > ul > li > ul > li:hover, #rem > ul > li:hover {
  background-color: aqua; /*padding-bottom:12px;*/
}
</style>

<!--div class="box" style="float:left;"> <canvas id="my_canvas" class="canvas" width="360" height="300"></canvas> </div-->
<!--div class="box"> <canvas id="my_canvas" class="canvas" width="500" height="350"></canvas> </div-->
<style> 
#my_canvas { pointer-events: none; cursor: pointer; margin: 10px; box-shadow: 0 0 7px 7px rgba(0, 0, 155, 0.3); background-color: aqua; border-radius: 80px;} 
#main {display:none;}
#rem > ul {margin-top: 30px}
/*IE 11 - problem with float:left:*/
#rem li {list-style-type: none; }
#rem > ul > li:before {content: "● " }
#rem > ul > li li:before {content: "  ⇒ " }
</style>
<div class="box" id="my_canvas" style="width:360px; height:300px; float:left; margin-right:20px;"> </div>
<div id="rem" style="float:none; min-width: 250px;"></div>

<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/wordcloud2.js/1.1.0/wordcloud2.min.js"></script>
<script type="text/javascript">
  //  https://github.com/timdream/wordcloud2.js/blob/gh-pages/API.md - API document for available options.
  //  V. 1.1.0 wordcloud2.js works in Notepad++ - Markdown Panel (JScript 11.0.16384)
  const MIN = 2, FACTOR = 2; PLUS = 7 //min. font size and scale
  let options = { drawOutOfBound:true, backgroundColor:'#F0FFFF', color:'random-dark', shuffle:0, minRotation:-0.7, maxRotation:0.7, };
    //fontFamily minRotation maxRotation shuffle rotateRatio
    //, minRotation:-0.5, maxRotation:0.5,        , rotateRatio:0

  let list = []; //[ [word,count], ...]
  //let ul_0 = document.getElementsByTagName('ul')[0]; 
  //let li_all = ul_0.querySelectorAll('li:first-child'); //alert(li_all[1].innerHTML)
  let li_all = document.querySelectorAll('#main > ul > li'); //alert(li_all[1].innerHTML)
  let li_1 = null; //alert(li_1 ? li_1.innerHTML ||'x' : 'y')
  //                 1          2           3 (second+ line in <li>)
  const re = /^[ \t]*(\d+)[ \t]+(.+?)([\r\n]([\s\S]*))?$/ //[\s\S]: missing dotAll in IE
      //zakładam, że potencjalne wewn. <ul> jest po łamaniu wiersza
  let n_max = -1

  //for the first list on the page, search for a number + words in <li>
  for (let i = 0; i < li_all.length; i++) {
    let li_html = li_all[i].innerHTML || '' ; //alert(''+i+' '+li_html)
    if ( (m = re.exec(li_html)) !== null ) { //alert(m[1]+"->"+m[2]+" @ "+m[3]);//test
      let n = parseInt(m[1])
      list.push( [ m[2].replace(/<br[^>]*>/i,''), PLUS + FACTOR * Math.max( MIN, n ) ] );
      if (n > n_max) {n_max = n; document.getElementById('rem').innerHTML = m[3] || '- - -'}
    } //see. https://bugzilla.mozilla.org/show_bug.cgi?id=1776381
  }

  options.list = list;
  WordCloud(document.getElementById('my_canvas'), options );
</script>
<!-- -->