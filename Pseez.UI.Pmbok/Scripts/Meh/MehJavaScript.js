////////////////////////////////////////////////////////////////
//               Scripts by Mehdi Naseri                      //
////////////////////////////////////////////////////////////////

////////////////////////////////////////////////////////////////
//      (Script) Work with cookie              //
////////////////////////////////////////////////////////////////

function setCookie(cname, cvalue, exdays, path) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + "; " + expires + "; path=/" + path;
}

function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1);
        if (c.indexOf(name) == 0) return c.substring(name.length, c.length);
    }
    return "";
}

function checkCookie() {
    var user = getCookie("username");
    if (user != "") {
        alert("Welcome again " + user);
    } else {
        user = prompt("Please enter your name:", "");
        if (user != "" && user != null) {
            setCookie("username", user, 365);
        }
    }
}

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
    $("#secondNavbar").css("margin-top", $("#firstNavbar .container").height());
    $(".body-content").css("margin-top", parseInt($("#firstNavbar .container").height()) + parseInt($("#secondNavbar").height()) - 40);

    $(window).resize(function () {
        $("#secondNavbar").css("margin-top", $("#firstNavbar .container").height());
        $(".body-content").css("margin-top", parseInt($("#firstNavbar .container").height()) + parseInt($("#secondNavbar").height()) - 40);
    });
})



////////////////////////////////////////////////////////////////
//      (Script) Fill Default Project Name                    //
////////////////////////////////////////////////////////////////
$(function () {
    $("input#DefaultProjectName").val(getCookie("DefaultProjectName"));
    //localStorage["DefaultProjectName"]
});


////////////////////////////////////////////////////////////////
//      (Script) Change TextArea  Theme                 //
////////////////////////////////////////////////////////////////
$(function () {
    //$("textarea").css("max-width", "600px");
    $("textarea").attr("rows", "5");
    //$("textarea").attr("disabled","disabled");
    $("textarea").addClass("form-control");

    $("#tab-inputs textarea").attr("disabled", "disabled");
});


////////////////////////////////////////////////////////////////
//      (Script) Enable Popover                               //
////////////////////////////////////////////////////////////////
$(function () {
    $('[data-toggle="popover"]').popover();
})

////////////////////////////////////////////////////////////////
//      (Script) فعال سازی ویرایش در صفحات مستندات         //
////////////////////////////////////////////////////////////////
//تغییر حالت ویرایش
$(function () {
    $('#documentsIndexPage input:radio[name="EditMode"]').change(function () {
        if ($(this).val() === "Disable") {
            $("textarea").attr("disabled", "disabled");
            $(".panel button").remove();
            $(".meh-ToggleHidden").attr("hidden", "hidden");
            $(".meh-buttonDeleteFile").remove();
        } else if ($(this).val() === "Enable") {
            if ($("textarea").attr("disabled") == "disabled") {
                $("textarea").removeAttr("disabled");
                $("textarea").after('<button class="btn btn-success meh-buttonSaveDocumentValue">Save</button>');
                $(".meh-ToggleHidden").removeAttr("hidden");
                $(".meh-downloadLink").before('<span class="btn-danger glyphicon glyphicon-remove meh-buttonDeleteFile" style="cursor:pointer;margin-right:5px;""></span>');
            }
        };
    });
    //تغییر حالت نمایش اطلاعات حذف شده
    $('#documentsIndexPage input:radio[name="HistoryMode"]').change(function () {
        if ($(this).val() === "Disable") {
            $(".historyButtons").remove();
        } else if ($(this).val() === "Enable") {
            var element = '<div class="historyButtons" style="margin-top:5px"><button class="btn btn-warning deletedFiles">Deleted files</button>&nbsp;<button class="btn btn-warning changedValues">Changes text</button></div>';
            $(".meh-documentGroup").append(element);
        }
    });
});


////////////////////////////////////////////////////////////////
//      اضافه کردن دکمه ذخیره بعد از textarea صفحات output  //
////////////////////////////////////////////////////////////////
$("#tab-outputs textarea").after('<button class="btn btn-success meh-buttonSaveDocumentValue">Save</button>');


////////////////////////////////////////////////////////////////
//      (Script) ذخیره مقدارهای جدید برای اسناد پروژه      //
////////////////////////////////////////////////////////////////
//دکمه ذخیره مقدارهای جدید برای اسناد پروژه
$(function () {
    $("#documentsIndexPage,#processIndexPage").on("click", ".panel-group button.meh-buttonSaveDocumentValue", function () {
        document.body.style.cursor = "wait";
        var data2Send = {
            "projectName": getCookie("DefaultProjectName"),
            "projectDocumentName": $(this).prev().attr("name"),
            "newProjectDocumentValue": $(this).prev().val()
        };
        $.ajax({
            //url: '@Url.Action("SaveDocumentValue")',
            url: saveDocumentValueUrl,
            type: "Post",
            data: data2Send,
            success: function (result) {
                $(".modal-title").html("Save");
                if (result == "Success") {
                    $(".modal-header").removeClass("alert-danger");
                    $(".modal-header").addClass("alert-success");
                    $("#modalBodyContent").html("Saved Successfully.");
                } else if (result == "Exist") {
                    $(".modal-header").removeClass("alert-success");
                    $(".modal-header").addClass("alert-danger");
                    $("#modalBodyContent").html("This value already exist.");
                } else if (result == "EmptyValue") {
                    $(".modal-header").removeClass("alert-success");
                    $(".modal-header").addClass("alert-danger");
                    $("#modalBodyContent").html("Value can not be empty.");
                }
                $("#myModal").modal('show');
                document.body.style.cursor = "default";
            },
            error: function () {
                $(".modal-title").html("Save");
                $(".modal-header").removeClass("alert-success");
                $(".modal-header").addClass("alert-danger");
                $("#modalBodyContent").html("Unable to save new value.");
                $("#myModal").modal('show');
                document.body.style.cursor = "default";
            }
        });
    });
});

// باتن حذف فایلهای پروژه
$(function () {
    $("body").on("click", ".meh-buttonDeleteFile", function () {
        document.body.style.cursor = "wait";
        var data2Send = {
            "id": $(this).siblings("a").attr("href").split("/")[4],
        };
        var vonfirmResult = confirm("Are you sure you want to permanently delete this file?");
        if (vonfirmResult) {
            var jqueryElement = $(this).parent();
            $.ajax({
                //url: '@Url.Action("SaveDocumentValue")',
                url: deleteDocumentFileUrl,
                type: "Post",
                data: data2Send,
                success: function (result) {
                    if (result == "Success") {
                        jqueryElement.remove();
                        $(".modal-header").removeClass("alert-danger");
                        $(".modal-header").addClass("alert-success");
                        $(".modal-title").html("Delete File");
                        $("#modalBodyContent").html("File deleted successfully.");
                    } else if (result == "Exist") {
                        $(".modal-header").removeClass("alert-success");
                        $(".modal-header").addClass("alert-danger");
                        $(".modal-title").html("Delete File");
                        $("#modalBodyContent").html("This file already exist.");
                    }
                    $("#myModal").modal('show');
                    document.body.style.cursor = "default";
                },
                error: function () {
                    document.body.style.cursor = "default";
                    $(".modal-header").removeClass("alert-success");
                    $(".modal-header").addClass("alert-danger");
                    $(".modal-title").html("Delete File");
                    $("#modalBodyContent").html("Unable upload file.");
                    $("#myModal").modal('show');
                }
            });
        }
    });
});
////////////////////////////////////////////////////////////////
//      (Script) ساخت Kendo ui upload                         //
////////////////////////////////////////////////////////////////


//insert Kendo ui upload placeholder after 
$(function () {
    $("#documentsIndexPage .meh-kendouiUpload").after('<div class="k-content meh-ToggleHidden" style="margin-top:5px" hidden="hidden"><input name="files" type="file" class="fileUpload" /></div>');

    $("#processIndexPage .meh-kendouiUpload").after('<div class="k-content style="margin-top:5px" ><input name="files" type="file" class="fileUpload" /></div>');
    $("#processIndexPage #tab-outputs .meh-downloadLink").before('<span class="btn-danger glyphicon glyphicon-remove meh-buttonDeleteFile" style="cursor:pointer;margin-right:5px;""></span>');
});


$(function () {
    $(".fileUpload").kendoUpload({
        async: {
            saveUrl: uploadDocumentFileUrl,
            removeUrl: deleteDocumentFileUrl,
            autoUpload: false
        },
        upload: function (e) {
            var projectDocumentName1 = this.element.closest(".meh-documentGroup").children(".form-group:first-child").children("textarea").attr("id");
            e.data = {
                projectName: getCookie("DefaultProjectName"),
                projectDocumentName: projectDocumentName1,
            };
        }
    });
});


////////////////////////////////////////////////////////////////
//  نمایش مقادیر هیستوری با کلیک بر روی دکه های مربوطه    //
////////////////////////////////////////////////////////////////
$("#documentsIndexPage").on("click", ".changedValues", function () {
    document.body.style.cursor = "wait";
    var data2Send = {
        "projectName": getCookie("DefaultProjectName"),
        "projectDocumentName": $(this).closest(".meh-documentGroup").find("textarea:first-child").attr("name")
    };
    $.ajax({
        url: getChangedValuesUrl,
        type: "Post",
        data: data2Send,
        success: function (result) {
            $(".modal-header").removeClass("alert-danger");
            $(".modal-header").addClass("alert-success");
            $(".modal-title").html("Changed Values");
            $("#modalBodyContent").html(result);
            $("#myModal").modal('show');
            document.body.style.cursor = "default";
        },
        error: function () {
            $(".modal-header").removeClass("alert-success");
            $(".modal-header").addClass("alert-danger");
            $(".modal-title").html("Error");
            $("#modalBodyContent").html("Unable to recieve data from server.");
            $("#myModal").modal('show');
            document.body.style.cursor = "default";
        }
    });
});
$("#documentsIndexPage").on("click", ".deletedFiles", function () {
    document.body.style.cursor = "wait";
    var data2Send = {
        "projectName": getCookie("DefaultProjectName"),
        "projectDocumentName": $(this).closest(".meh-documentGroup").find("textarea:first-child").attr("name")
    };
    $.ajax({
        url: getDeletedFilesUrl,
        type: "Post",
        data: data2Send,
        success: function (result) {
            $(".modal-header").removeClass("alert-danger");
            $(".modal-header").addClass("alert-success");
            $(".modal-title").html("Deleted Files");
            $("#modalBodyContent").html(result);
            $("#myModal").modal('show');
            document.body.style.cursor = "default";
        },
        error: function () {
            $(".modal-header").removeClass("alert-success");
            $(".modal-header").addClass("alert-danger");
            $(".modal-title").html("Error");
            $("#modalBodyContent").html("Unable to recieve data from server.");
            $("#myModal").modal('show');
            document.body.style.cursor = "default";
        }
    });
});








