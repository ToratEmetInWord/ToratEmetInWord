using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Lucene.Net.Store.Lock;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace ToratEmet.BookParsingModels
{
    public static class HtmlHead
    {
        public static string htmlHead(string title)
        {
            return $@"<!DOCTYPE html>
                <html lang=""he"">
                    <head>
                    <meta charset=""UTF-8"">
                    <title>{title}</title>

                  <style>

                html, body {{
                text-align: right;
                text-align: justify;
                direction: rtl;
                
                  height: 100%;
                  margin: 0;
                  padding: 0;
                  background-color: whitesmoke;
                }}

* {{
box-sizing: border-box;
}}

                h2,h3,h4,h5,h6{{
                color: #4169E1;}}

                .inlineHeader {{
                font-weight: bold;
                color: #4169E1;}}
.booklinks:hover
{{
background-color: whitesmoke;
cursor: pointer;
}}

  {BookStylingCss()}             
{TreeViewAndContentBoxCss()}            
{ComboViewCss()}

                </style>
                </head>
                <body dir='rtl'>
";
        }

        public static string HtmlEnd(string elementId, double scrollPosition)
        {
            return $@"
<script>
        var originalText = document.body.innerHTML;
        var isVowelsReversed = false;
        var isCantillationReversed = false;

// JavaScript to handle page intial scrollPosition
        var element = document.getElementById(""{elementId}"");
        if (element !== null) {{ element.scrollIntoView(); }}
        else{{document.getElementById(""contentBox"").scrollTop = {scrollPosition};}}

// JavaScript to handle tab switching and interaction with C#
 function openComboContent(event) {{
        var tabName = event.target.value;
        window.chrome.webview.postMessage('openComboContent=' + tabName);
    }}


function sendBookLink(item) {{
    window.chrome.webview.postMessage('bookLink=' + item.innerHTML);
}}

function setBookLinkTitle(item) {{
  if (item.title.trim().length < 1) {{
    window.chrome.webview.postMessage('setBookLinkTitle=' + item.innerHTML);
  }}
}}


{TreeViewJS()}
{CurrentChapterJs()}

    </script>

                     </body>
                </html>";
        }
        static string TreeViewAndContentBoxCss()
        {
            return $@"

.container {{display: flex;
  height: 100%;
}}
 
.textContentBox {{
background-color: white;
  flex: 1;
font-family:{Properties.Settings.Default.HtmlFontFamily} ;
font-size: {Properties.Settings.Default.HtmlFontSize}%;
  height: 100%;
  padding-right: 10px;
padding-left: 10px;
  overflow-y: auto;
}}

.treeView-container {{display: flex;
font-size: initial;
  flex-direction: column;
  height: 100%;
  max-width:0px;
user-select: none;
}}

#treeView-SearchInput {{margin: 10px;
  height:25px;
  border: 1px solid #ccc;
}}
 
#treeView-SearchInput:focus {{outline: none;
}}
 
.treeView {{
height:100%;
  overflow: auto;
  margin-top: 5px;
  white-space: nowrap;
  text-indent: -10px;
}}
 
.treeView details {{
margin-right:2px;
margin-left:2px;
border-top: 1px solid  #eaeaea;
  border-bottom: 1px solid  #eaeaea;
}}
 
.treeView summary::-webkit-details-marker {{display: none;

            }}
 
.treeView summary {{
transition: background-color 0.3s ease;
    list-style: none;
}}
 
.treeView summary:hover {{background-color: #eaeaea;
}}
 
.treeView Button {{
padding:0px;
margin: auto;
  background: none;
  border: none;
  cursor: pointer;
  font-weight: 500;
  transition: background-color 0.3s ease;
}}
 
.treeView button:hover {{
background-color: white;
}}";
        }
        static string ComboViewCss()
        {
            return $@"
.comboView_container {{
    display: flex;
    width 100%
    margin-top: 10px;
    margin-bottom: 10px;
    max-height: 175px;
    border: 2px solid whitesmoke; 
}}

.comboView_ContentBox {{
    background-color: #f7f7f7; /* Light bubbly gray background */
    overflow-y: scroll;
    flex: 1;
    padding: 5px;
    font-size: 90%;
}}

.listBox-container {{background-color: white; 
display: flex;
    width: 15px;
 -moz-user-select: none; /* Firefox */
    -ms-user-select: none; /* Internet Explorer/Edge */
    user-select: none; /* Non-prefixed version, currently supported by Chrome and Opera */
     transition: width 0.3s ease; /* Apply transition to width */
}}

.listBox-container:hover{{width:100px;
}}

.listBox{{overflow-y: scroll;
}}

.listBox button {{border: none;
    background-color: transparent;
    display: block;
    width: 100%;
    padding: 5px;
font-size:14px
}}

.listBox button:hover {{background-color: whitesmoke; 
}}

listBox_Label{{
    writing-mode:vertical-rl;
    text-align:center;
    font-size:14px;
}}
";
        }
        static string BookStylingCss()
        {
            return $@" 
                .noteHeader{{
                color:gray;
                text-align:center;
                padding-bottom:5px;
                }}

                .note {{
                padding: 5px;
                font-size: 80%;
                border-right: 2px solid  lightgray;
                background-color:whitesmoke;
                }}
          

                .note2 {{
                padding: 5px;
                font-size: 80%;
                font-style: italic;
                }}
                

                .refrence{{
                font-size: 80%;
                cursor: pointer;
                color:#ff6347;
                }}";
        }
        static string TreeViewJS()
        {
            return $@"

function treeViewSelection(id) {{
  // Scroll the corresponding heading into view
  const heading = document.getElementById(id);
  if (heading) {{
    heading.scrollIntoView({{ behavior: 'smooth', block: 'start' }});
  }} else {{
var element = document.getElementById(""contentBox"");
element.innerHTML = ""טוען עמוד..."";
    window.chrome.webview.postMessage('navigateTo=' + id);
  }}
}}


function expandTreeView() {{
  var element = document.getElementById(""treeView-container"");
    element.style.maxWidth = ""50%"";
}}

var allowCollapse = true;
function collapseTreeView() {{
  var element = document.getElementById(""treeView-container"");
if (allowCollapse === true){{
 element.style.maxWidth = ""0px""
}}
}}

function toggleTreeview(){{
 var element = document.getElementById(""treeView-container"");
if (element.style.maxWidth === ""0px"")
{{ element.style.maxWidth = ""50%"";}}
else{{ element.style.maxWidth = ""0px""; allowCollapse = true}} 
}}


function findAndSelectItem() {{
    var input = document.getElementById(""treeView-SearchInput"");
    var filter = input.value.trim().toUpperCase().replace(/,/g, '');
    var details = document.querySelectorAll(""details"");
    var firstMatchFound = false;
    
    // Collapse all details if filter is empty
    if (filter === """") {{
         for (var i = 0; i < details.length; i++) {{
        details[i].open = false;
        var summary = details[i].querySelector(""summary"");
        details[i].style.display = """";
    }}
        return; // Exit function
    }}
    
    for (var i = 0; i < details.length; i++) {{
        var summary = details[i].querySelector(""summary"");
        if (summary) {{
            var parentPath = getParentText(details[i]).toUpperCase();
            var summaryPath = summary.textContent.toUpperCase();
            var fullPath = parentPath + summaryPath;
            fullPath = fullPath.replace(/👁/g, '').replace(/\n/g, ' ').replace(/ +/g, ' ').trim()

            // Highlight matching summaries
            if (fullPath.includes(filter)) {{
                 details[i].open = true;
                 details[i].style.display = """";
                 
                  if (!firstMatchFound) {{
                    summary.scrollIntoView({{ behavior: 'smooth', block: 'center' }});
                    firstMatchFound = true;
                }}
                 
                 // Open parent details elements recursively
                var parentDetails = details[i].parentNode;
                while (parentDetails.tagName === 'DETAILS') {{
                    parentDetails.open = true;
                    parentDetails.style.display = """";
                    parentDetails = parentDetails.parentNode;
                }}
                
            }} else {{
                 details[i].open = false;
                   details[i].style.display = ""none"";
            }}
        }}
    }}
}}
 
function getParentText(element) {{
    var result = """";
    var parent = element.parentNode;
    while (parent && parent.tagName.toLowerCase() === 'details') {{
        var summary = parent.querySelector(""summary"");
        if (summary) {{
            result = summary.textContent + result;
        }}
        parent = parent.parentNode;
    }}
    return result;
}}";
        }
        static string CurrentChapterJs()
        {
            return $@"
// JavaScript to keeptrack of currentchapter
var observer = new IntersectionObserver(function(entries) {{
    let alerted = false;
    entries.some(entry => {{
        if (entry.isIntersecting && entry.intersectionRatio > 0 && entry.target.tagName.startsWith('H')) {{
            if (!alerted) {{
                alerted = true;
                 window.chrome.webview.postMessage('currentId=' + entry.target.id);
                return true; // Stop iterating after the first match
            }}
        }}
        return false;
    }});
}}, {{ threshold: [0] }});

document.querySelectorAll(""h1, h2, h3, h4, h5, h6"").forEach(h => {{
    observer.observe(h);
}});

;";
        }


        public static string HtmlResultsHead(string title)
        {
            return $@"<!DOCTYPE html>
                <html lang=""he"">
                    <head>
                    <meta charset=""UTF-8"">
                    <title>{title}</title>

                  <style>

                body {{
                text-align: right;
                text-align: justify;
                direction: rtl;
                font-family:{Properties.Settings.Default.HtmlFontFamily} ;
                font-size: {Properties.Settings.Default.HtmlFontSize}%;

}}

                a {{
                text-decoration: none;
                color:#ff6347;
                }}
                
                 a:active {{color: #ff6347;  }}

                .footNoteSeparator{{
                text-align: center;
                font-size: 80%;
                }}

                </style>
                </head>
                <body dir='rtl'>
";
        }
        public static string HtmlResultsEnd()
        {
            return $@"
                     </body>
                        <script>
                       function sendMessage(tag) {{  window.chrome.webview.postMessage(tag.id);  }}
                                var isDetailsCollapsed = true;
                    </script>
                </html>";
        }
    }

}
