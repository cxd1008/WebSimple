/// <reference path="../../../../Scripts/jquery-1.10.2.min.js" />

//基本setInterval的使用
//function btnclick() {
//    var i = 0;
//    var vInterval = setInterval(function () {
//        i++;
//        $("#la").text(i);
//        if (i > 10) {
//            clearInterval(vInterval);
//            $("#la").text("执行完毕!");
//            alert("执行完毕!");
//        }
//    }, 500);
//}

var setiv;
$(function () {
     setiv = setInterval("div2setInterval()", 5001);
    $("#div2").hover(
        function () {
            $("#div2").stop(true);
            clearInterval(setiv);
        },
        function () {
            setiv=setInterval("div2setInterval()", 5001)
        }
        );    
});

function div2setInterval()
{
    if ($("#div2").is(':hidden')) {
        clearInterval(setiv);
        $("#div2").remove();
        return;
    }
    //if ($('#div2').css('display') == 'none') {

    //    clearInterval(setiv);
    //    return;
    //}
    var vheight = $(document).height() * Math.random() - 50;
    var vwidth = $(document).width() * Math.random();
    if (vheight < 50) {
        vheight = 50
    }
    $("#div2").animate({ "top": vheight, "left": vwidth - 50 }, 5000);
}

//隐藏广告栏
function btnMoveHide() {
    $("#div2").fadeOut(1000);
}

//进度条GUID
function guid() {
    function S4() {
        return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
    }
    return (S4() + S4() + "-" + S4() + "-" + S4() + "-" + S4() + "-" + S4() + S4() + S4());
}
//进度条
function btnClick() {
    var vguid = guid();
    $.post("setProgressDemoMain", { "myGuid": vguid }, function (data) {
        if (data == "a") {
            //alert("a");
        }
    });//主运行程序
    var vInterval = setInterval(function () {
        $.post("getTimer", { "myGuid": vguid }, function (data) {
            $("#la").text(data);
            if (data >= 100) {
                clearInterval(vInterval);
                $("#la").text("执行完毕!");
                //alert("执行完毕!");
            }
        });

    }, 1000);
}
//点击DIV移动
function btnMoveClick() {
    $("#div1").stop(true, true);
    var vleft = $("#div1").position().left;
    var vtop = $("#div1").position().top;
    var vwidth = $("#div1").width;
    var vheight = $("#div1").height;
    $("#div1").animate({ "top": "25px", "left": "200px", "height": "20px", "width": "20px", "border-radius": "10px" }, 2000, function () {
        $("#div1").animate({ "top": "25px", "left": "0px" }, 2000, function () {
            $("#div1").animate({ "top": "50px", "left": "400px", "height": "50px", "width": "50px", "border-radius": "0px" }, 2000, function () {
                $("#div1").css({
                    "top": vtop,
                    "left": vleft,
                    "height": vheight,
                    "width": vwidth
                })
            });
        })
    });

    //$(this).animate({ "top": "200px", "left": "200px" }, 2000, function () {
    //    $(this).animate({ "top": "0px", "left": "400px" }, 2000);
    //});
}

//function setIntervalPost() {
//    $.post("Create", $("#from1").serializeArray(), function (data) {
//        return data;

//    });
//}
