/// <reference path="../../../Scripts/jquery-1.10.2.min.js" />


var creatShow = $('<div class="div1">❄</div>');
var setI;
function downSnowClick() {
    $("#downSnow").attr("disabled",true);
    //❉❅❆✻✼❇❈❊✥✺
    setI = setInterval(function () {
        var cloneShow = creatShow.clone(true);
        var winwidth = Math.floor($(document).width() * Math.random() + 1)
        var winOutWidth = Math.floor($(document).width() * Math.random() + 1)
        cloneShow.css({ "top": "-10px", "left": winwidth - 40, "font-size": Math.floor(35 * Math.random()) + 5 });
        $("body").append(cloneShow);
        cloneShow.animate({ "top": $(window).height() - 55, "left": winOutWidth - 40, "opacity": "0.0" }, 3000, function () {
            cloneShow.remove();
        });
    }, 300);

}
function stopSnowClick() {
    clearInterval(setI);
    //$("#downSnow").removeAttr("disabled");
    $("#downSnow").attr("disabled", false);
}