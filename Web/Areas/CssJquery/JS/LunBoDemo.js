/// <reference path="../../../../Scripts/jquery-1.10.2.min.js" />

var i = 0;
var varsetI;
var imgwidth = 1200;
var imgheight = 450;
var vbool = false;
var vHeight, vWidth, cHeight, cWdith;
$(function () {

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

    $("#showTitle").mousedown(function (e) {
        vbool = true;
        vHeight = e.pageY;
        vWidth = e.pageX;
        cHeight = vHeight - $("#show").offset().top;
        cWdith = vWidth - $("#show").offset().left;
        //alert("divshow" + $("#show").offset().top + " divvHeight" + vHeight);
        //alert("高" + cHeight + " 宽" + cWdith);
    })
    $(document).mouseup(function () {
        vbool = false;
    })
    var showWidth = $("#show").width();
    var showHeight = $("#show").height();
    var documentWidth = $(document).width();
    var documentHeight = $(document).height();
    $(document).mousemove(function (e) {
        if (vbool) {
            var divheight = e.pageY - cHeight;//窗口要移动到的位置
            var divwidth = e.pageX - cWdith;//窗口要移动到的位置
            $("#la1").text(divheight + "w" + divwidth + "win" + showWidth + " x " + documentWidth + "" + showWidth);
            if (divwidth < 0) {
                divwidth = 0;
            }
            if (divheight < 50) {
                divheight = 50;
            }
            if (divwidth > documentWidth - showWidth) {
                divwidth = documentWidth - showWidth - 5;
            }
            if (divheight > documentHeight - showHeight) {
                divheight = documentHeight - showHeight - 5;
            }
            $("#show").css({ "left": divwidth, "top": divheight });
        }
    })
})

//轮播图
function setlunbo() {
    i++;
    if (i >= 10) {
        i = 0;
    }
    setlunbo2(i);
}

function setlunbo2(i2) {

    var lunboImgvisible = $(".lunboImg:visible");
    document.title = i2;


    switch (i2) {
        case 0:
        case 4:
        case 8:
            //从上往下轮播Start*************************************************************
            //第一张图片移出
            lunboImgvisible.animate({ "margin-top": "+" + imgheight }, 300, function () {
                lunboImgvisible.hide();
            });
            //第二张图片移入
            //设置第二张图片的位置            
            $(".lunboImg").eq(i2).show();
            $(".lunboImg").eq(i2).css({ "margin-top": -imgheight, "margin-left": "0px" });
            $(".lunboImg").eq(i2).animate({ "margin-top": "0px" }, 300);
            //从上往下轮播End*************************************************************
            break;
        case 1:
        case 5:
        case 9:
            //从左往右轮播Start*************************************************************
            //第一张图片移出
            lunboImgvisible.animate({ "margin-left": "+" + imgwidth }, 300, function () {
                lunboImgvisible.hide();
            });
            //第二张图片移入
            //设置第二张图片的位置
            $(".lunboImg").eq(i2).show();
            $(".lunboImg").eq(i2).css({ "margin-left": -imgwidth, "margin-top": "0px" });
            $(".lunboImg").eq(i2).animate({ "margin-left": "0px" }, 300);
            //从左往右End*************************************************************
            break;
        case 2:
        case 6:
            //从下往上轮播Start*************************************************************
            //第一张图片移出
            lunboImgvisible.animate({ "margin-top": "-" + imgheight }, 300, function () {
                lunboImgvisible.hide();
            });
            //第二张图片移入
            //设置第二张图片的位置
            $(".lunboImg").eq(i2).show();
            $(".lunboImg").eq(i2).css({ "margin-top": imgheight, "margin-left": "0px" });
            $(".lunboImg").eq(i2).animate({ "margin-top": "0px" }, 300);
            //上下轮播End*************************************************************
            break;
        case 3:
        case 7:
            //从右往左轮播Start*************************************************************
            //第一张图片移出            
            lunboImgvisible.animate({ "margin-left": "-" + imgwidth }, 300, function () {
                lunboImgvisible.hide();
            });
            //第二张图片移入
            //设置第二张图片的位置
            $(".lunboImg").eq(i2).show();
            $(".lunboImg").eq(i2).css({ "margin-left": imgwidth, "margin-top": "0px" });
            $(".lunboImg").eq(i2).animate({ "margin-left": "0px" }, 300);
            //左右轮播End*************************************************************      
            break;
    }
    //下面的数字变选中
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


function showdiv() {
    $("#bg,#show").fadeIn(300);
}
function hidediv() {
    $("#bg,#show").fadeOut(200);
}

//function mousemoveShowTitle() {
//    if (vbool) {
//        $("#show").css({})
//    }
//}

//function mouseDownShowTitle() {


//}
//function mouseUpShowTitle()
//{
//    vbool = false;
//}