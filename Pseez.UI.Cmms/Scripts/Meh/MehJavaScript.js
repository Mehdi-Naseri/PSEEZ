﻿////////////////////////////////////////////////////////////////
//               Scripts by Mehdi Naseri                      //
////////////////////////////////////////////////////////////////

////////////////////////////////////////////////////////////////
/// <reference path="../jquery-1.10.2.min.js" />
////////////////////////////////////////////////////////////////


////////////////////////////////////////////////////////////////
//      (Script) Automatic Dropdown Menu                      //
//           باز شدن انوماتیک منوها                        //
////////////////////////////////////////////////////////////////
$(function() {
    $("ul.nav li.dropdown").hover(
        function() { $(".dropdown-menu", this).slideDown(); },
        function() { $(".dropdown-menu", this).slideUp("fast"); });
    //function () { $('.dropdown-menu',this).fadeOut('fast');});
})