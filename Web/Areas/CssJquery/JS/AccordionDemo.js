/// <reference path="../../../../Scripts/jquery-1.10.2.min.js" />
$(function () {
    $(".li").click(function () {
        $(this).siblings(".li").stop(true, true);
        $(this).siblings(".li").animate({ 'width': '100px' }, 500);
        $(this).animate({ 'width': '740px' }, 1000);
    })
})