/// <reference path="../../../../Scripts/jquery-1.10.2.min.js" />


$(function () {
    var d1left = $("#d1").offset().left;
    var d2left = $("#d2").offset().left;
    var d3left = $("#d3").offset().left;
    var d4left = $("#d4").offset().left;
    var longSleft = $("#longS").offset().left;
    var longTleft = $("#longT").offset().left;
    var longTtop = $("#longT").offset().top;
    var longFireleft = $("#longFire").offset().left;
    var longFiretop = $("#longFire").offset().top;

    $("#divbody").mousemove(function (e) {
        var xbfb = (e.pageX / $("body").width() * 200 - 100) * 0.01;//屏幕宽百分比
        var xbfbh = (e.pageY / $("body").height() * 200 - 100) * 0.01;//屏幕宽百分比
       
        $("#d1").css("left", d1left + (50 * xbfb));
        $("#d2").css("left", d2left + (100 * xbfb));
        $("#d3").css("left", d3left + (80 * xbfb));
        $("#d4").css("left", d4left + (40 * xbfb));
        $("#longS").css("left", longSleft + (45 * xbfb));        

        $("#longT").css("left", longTleft + (25 * xbfb));
        $("#longT").css("top", longTtop + (25 * xbfbh));

        $("#longFire").css("left", longFireleft + (90 * xbfb));
        $("#longFire").css("top", longFiretop + (90 * xbfbh));
    });  
})