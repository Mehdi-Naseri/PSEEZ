////////////////////////////////////////////////////////////////
//               Scripts by Mehdi Naseri                      //
////////////////////////////////////////////////////////////////

////////////////////////////////////////////////////////////////
/// <reference path="../jquery-1.10.2.min.js" />
////////////////////////////////////////////////////////////////



////////////////////////////////////////////////////////////////
//      (Script) Automatic Dropdown Menu                      //
//           باز شدن انوماتیک منوها                        //
////////////////////////////////////////////////////////////////
$(function () {
    $('ul.nav li.dropdown').hover(
        function () { $('.dropdown-menu', this).slideDown(); },
        function () { $('.dropdown-menu', this).slideUp('fast'); });
    //function () { $('.dropdown-menu',this).fadeOut('fast');});
})


////////////////////////////////////////////////////////////////
//      (Script) Fix Content distance from second menu        //
////////////////////////////////////////////////////////////////
$(function () {
    $(".body-content").css("margin-top", $("#SecondNavbar").height() + 10);
    $(window).resize(function () {
        $(".body-content").css("margin-top", $("#SecondNavbar").height() + 10);
        //alert($("#SecondNavbar").height());
    });
})



////////////////////////////////////////////////////////////////
//      (Script) Fill Default Project Name                    //
////////////////////////////////////////////////////////////////
$(function () {
    $("input#DefaultProjectName").val(localStorage["DefaultProjectName"]);
    //localStorage["DefaultProjectName"]
});



    $(function () {
        $(".Meh-datePicker").datepicker
    });
