/// <reference path="../../../../Scripts/jquery-1.10.2.min.js" />

$(function () {
    //上菜单
    $("#ListTopUL li").hover(function () {
        //$(this).addClass("ListTopULhover");
        //$(this).siblings(this).removeClass("ListTopULhover");
        var i = $(this).index();
        document.title = i;
        $(".ListTopRight1").eq(i).show();
        $(".ListTopRight1").eq(i).siblings(".ListTopRight1").hide();
        
        
    });

    //左菜单
    $(".ListBodyLeftDiv").hover(function () {

        var a = $(this).children("a");
        a.addClass("ListBodyLeftDivAhover");
        var i = $(this).index();
        $(".listbodyRDiv1").eq(i).show();
        $(".listbodyRDiv1").eq(i).siblings(".listbodyRDiv1").hide();
        
        $("#listbodyRDiv").addClass("listbodyRDivborder");//增加一个边框样式

    }, function () {
        $(this).children("a").removeClass("ListBodyLeftDivAhover");
    });
    //中间内容
    $(".listbodyRDiv1").hover(function () {
        var i = $(this).index();
        $(".ListBodyLeftDiv").eq(i).addClass("ListBodyLeftDivhover");
        $(".ListBodyLeftDiv a").eq(i).addClass("ListBodyLeftDivAhover");
        $(this).show();//非常重要.上级隐藏自己在显示一下!!
        $("#listbodyRDiv").addClass("listbodyRDivborder");//增加一个边框样式
    }, function () {
        var i = $(this).index();
        $(".ListBodyLeftDiv").eq(i).removeClass("ListBodyLeftDivhover");
        $(".ListBodyLeftDiv a").eq(i).removeClass("ListBodyLeftDivAhover");
        $(this).hide();
        $("#listbodyRDiv").removeClass("listbodyRDivborder");//增加一个边框样式
    });
    //leftdiv整体
    $("#ListBodyLeft").hover(function () {
    }, function () {
        $(".ListBodyLeftDiv").removeClass("ListBodyLeftDivhover");
        $(".listbodyRDiv1").hide();
        $("#listbodyRDiv").removeClass("listbodyRDivborder");//增加一个边框样式
    });

})