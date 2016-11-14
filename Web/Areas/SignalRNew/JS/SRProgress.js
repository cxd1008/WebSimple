/// <reference path="D:\WebMVCSimple\Web\Scripts/jquery-1.10.2.js" />
/// <reference path="D:\WebMVCSimple\Web\Scripts/jquery.signalR-2.2.1.js" />
$(function () {

    var bookingHub = $.connection.bookingHub;
    //服务返回
    bookingHub.client.updatecount = function (sCount) {
        $("#lbCount").text(sCount + "%");

        //设置进度条
        $(".progress-bar").attr({
            "style": "width:" + sCount + "%"
        });
    };
    //因为这是长联接，如果用完可以关了就更好了，尝试
    //$.connection.hub.start().done(function () {
    //    $("#btCount").click(function () {
    //        bookingHub.server.processcount("1");
    //    });
    //});
    $.connection.hub.start();
    //客户端提交
    $("#btCount").click(function () {
        bookingHub.server.processcount("1");
    });

})