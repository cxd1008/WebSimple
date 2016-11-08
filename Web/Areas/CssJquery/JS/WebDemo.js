/// <reference path="../../../../Scripts/jquery-1.10.2.min.js" />

var i = 0;
var varsetI;
var vSetInterBot;
$(function () {

    //菜单列表
    $(".head1-1-2menu").hover(

        function () {
            //$(this).children().eq(0).css({ "color": "red", "font-size": "25px", "cursor": "pointer" ,"background-color":"#ffffff"});
            $(this).children().eq(0).addClass("head1-1-2menuPointer");//加入一个样式文件
            funshow($(this).attr("accesskey"));
        },
        function () {
            //$(this).children(":first").removeAttr("style");
            $(this).children(":first").removeClass("head1-1-2menuPointer");//去除一个样式文件
            funhide($(this).attr("accesskey"));
        });

    varsetI = setInterval("setlunbo()", 2000);
    //轮播图移入左右图标停止
    $(".lunboDivLR").hover(
        function () {
            clearInterval(varsetI);
            $(this).css({ "opacity": "0.6" });
        },
        function () {
            varsetI = setInterval("setlunbo()", 2000);
            $(this).css({ "opacity": "0.2" });
        });

    $("#lunboNum div").hover(function () {
        $(this).css({ "background-color": "orange", "font-weight": "700" });
        clearInterval(varsetI);
    }, function () {
        varsetI = setInterval("setlunbo()", 2000);
        if (i != $(this).text() - 1) {
            $(this).css({ "background-color": "#808080", "font-weight": "400" });
        }
    })
    $("#lunboNum div").click(function () {
        i = $(this).text() - 1;
        setlunbo2(i);
    });

    $(".bodymiddle3-1").hover(function () {
        $(this).children(".bodymiddle3B").stop(true, true).slideDown(100);
    }, function () {
        $(this).children(".bodymiddle3B").stop(true, true).slideUp(100);
    });

    //底图的轮播
    vSetInterBot = setInterval("bodymiddle5BTRc()", 2000);
    $(".bodymiddle5BT").hover(function () {
        clearInterval(vSetInterBot);
    }, function () {
        vSetInterBot = setInterval("bodymiddle5BTRc()", 2000);
    });

    //左右的广告 :
    $(document).scroll(function () {
        //document.title = $(document).scrollTop();
        var NumscrollTop = $(document).scrollTop() + 150;
        $("#adLeft").stop(true).animate({ "top": NumscrollTop }, 1000);
        $("#btnLshow").stop(true).animate({ "top": NumscrollTop }, 1000);
        
    })
})

//轮播图
function setlunbo() {
    setlunbo2(i);
    i++;
    if (i >= 10) {
        i = 0;
    }
}

function setlunbo2(i2) {
    $(".lunboImg").eq(i2).fadeIn(500).siblings(".lunboImg").fadeOut(300);
    $("#lunboNum div").eq(i2).css({ "background-color": "orange", "font-weight": "700" }).siblings("#lunboNum div").css({ "background-color": "#808080", "font-weight": "400" });
}
function lunboDivR() {
    i--;
    if (i <= -1) {
        i = 9;
    }
    setlunbo2(i);
}
function lunboDivL() {
    i++;
    if (i >= 10) {
        i = 0;
    }
    setlunbo2(i);
}

function funshow(eqcount) {
    $(".head1-1-2menu2").eq(eqcount).stop(true, true);
    $(".head1-1-2menu2").eq(eqcount).slideDown(300);//.css({ "visibility": "visible" });
}

function funhide(eqcount) {
    $(".head1-1-2menu2").eq(eqcount).stop(true, true);
    $(".head1-1-2menu2").eq(eqcount).slideUp(300);//.css({ "visibility": "hidden" });
}

var ibot = 0;
//底部轮播左
function bodymiddle5BTLc() {
    ibot--;
    if (ibot <= -1) {
        ibot = 15;
    }
    $("#bodymiddle5-1").stop(true, true).animate({ left: -218 * ibot }, 400);
}
//底部轮播右
function bodymiddle5BTRc() {
    ibot++;
    if (ibot >= 16) {
        ibot = 0;
    }
    $("#bodymiddle5-1").stop(true, true).animate({ left: -218 * ibot }, 400);
}

//广告隐藏
function adLeftHide() {
    $("#adLeft").stop(true,true).hide(400, function () {
        $("#btnLshow").show(300);
    });
}
//广告显示
function adLeftShow() {
    $("#adLeft").show(400);
    $("#btnLshow").hide();
}