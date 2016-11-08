/// <reference path="../../../Scripts/jquery-1.10.2.min.js" />


$(function () {
    $(" #ul1 li").hover(function () {
        $(this).addClass("lihover");
    }, function () {
        $(this).removeClass("lihover");
    });

    //$(" #ul1 li").click(function () {
    //    $(this).addClass("liActive");
    //    $(this).siblings("#ul1 li").removeClass("liActive");
    //});


    $(".divbody").mousewheel(function (event, delta, deltaX, deltaY) {
        //document.title = "delta=" + delta + "deltaX=" + deltaX + "deltaY=" + deltaY;
        //console.log(delta, deltaX, deltaY);
        //向上        
        if (delta > 0) {
            //console.log("向上");

            iIndex = iIndex - 1;
            if (iIndex <= 0) {
                iIndex = 1;
            }
            document.title = iIndex;
            liclick(iIndex);
        }
        //向下
        if (delta < 0) {
            //console.log("向下");
            iIndex = iIndex + 1;
            if (iIndex >= 10) {
                iIndex = 10;
            }
            document.title = iIndex;
            liclick(iIndex);
        }

    });
});




var iIndex = 0;
function liclick(vindex) {
    iIndex = vindex;
    $("#ul1 li").eq(vindex - 1).addClass("liActive");
    $("#ul1 li").eq(vindex - 1).siblings("#ul1 li").removeClass("liActive");
    $("body,html").stop(true, true);
    var vtop = $("#divLayer" + vindex).offset().top;
    //-------------------图片加载完成之后转动-----------------------
    $("body,html").animate({ "scrollTop": vtop - 51 }, 500, function () {
        $("img").eq(vindex - 1).addClass("img1");
    });

    if ($("img").eq(vindex - 1).hasClass("img1")) {
        $("img").eq(vindex - 1).removeClass("img1");
    }
    //$("img").eq(vindex - 1).removeClass("img1");
}