/// <reference path="D:\WebMVCSimple\Web\Scripts/jquery-1.10.2.js" />
/// <reference path="D:\WebMVCSimple\Web\Scripts/jquery.signalR-2.2.1.js" />
$(function () {
    //chatHub这个名子很坑，自己写的基本都挂了，开不不明白有大小写之分。后来才知道Hub的开头字母一定要为小写。
    var chat = $.connection.chatHub;
    //hello 这个是ChatHub里的一个方法 用$.connection.chatHub读出来的，命名空间随便写。
    //全体聊天
    chat.client.helloBack = function (name, message) {
        $('#discussion').append('<li><strong>' + name + '</strong>对全体说: ' + message + '</li>');
    };
    //单聊
    chat.client.helloSingleBack = function (sid, name, message) {
        $('#discussion').append('<li><strong>' + name + '</strong>私聊说: ' + message + '</li>');
    };
    //组聊
    chat.client.helloGroupBack = function (sGroupName, name, message) {
        $('#discussion').append('<li><strong>' + name + '</strong>在' + sGroupName + '组说: ' + message + '</li>');
    };
    //返回取得用户ID
    chat.client.getUserIDBack = function (sid) {
        $("#sid").val(sid);
    };
    //当相于开始主线程
    $.connection.hub.start().done(function () {
        //chat.server.getUserID("a");//取得当前用户唯一ID
        //可以使用public override Task OnConnected() 代替
    });
    //提交开始一个server程序 群聊
    $('#sendALL').click(function () {
        chat.server.hello($('#displayname').val(), $('#message').val());
        $('#message').val('').focus();
    });
    //单聊
    $('#sendSingle').click(function () {
        chat.server.helloSingle($("#pid").val(), $('#displayname').val(), $('#message').val());
        $('#message').val('').focus();
    });
    //加入组
    $("#addgroup").click(function () {
        chat.server.addGroup($("#sid").val(), $("#groupname").val());
        alert("成功加入" + $("#groupname").val() + "组");
    });
    //组聊
    $("#sendgroup").click(function () {
        chat.server.helloGroup($("#groupname").val(), $('#displayname').val(), $('#message').val());
    });
});
