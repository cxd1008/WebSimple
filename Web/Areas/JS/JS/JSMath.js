/// <reference path="../../../../Scripts/jquery-1.10.2.min.js" />
function Math1() {
    //向上舍入
    alert(Math.ceil(25.9));
    alert(Math.ceil(25.5));
    alert(Math.ceil(25.1));

}
function Math2() {

    //向下舍入
    alert(Math.floor(25.9));
    alert(Math.floor(25.5));
    alert(Math.floor(25.1));
}
function Math3() {
    //四舍五入
    alert(Math.round(25.9));
    alert(Math.round(25.5));
    alert(Math.round(25.1));
}
//从多少到多少的随机数
function Math4(start, end) {
    var total = end - start + 1;
    $("#math4").val(Math.floor(Math.random() * total + start));
    
}