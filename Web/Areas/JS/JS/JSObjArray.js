/// <reference path="../../../../Scripts/jquery-1.10.2.min.js" />
$(function () {
    var box = [];
});

function obj1() {
    var obj = Object();
    obj.a = "a1";
    obj.b = "b1";
    obj.c = 10;
    alert(obj.a + "|" + obj.b + "|" + obj.c);
}

function obj2() {
    var obj = {
        a: 'a1',
        b: 'b1',
        c: 10
    }
    alert(obj.a + "|" + obj.b + "|" + obj.c);
}
function array1() {
    var box = [];
    box[0] = "a1";
    box[1] = "b1";
    box.push("c1");
    alert(box);
}

function array2() {
    var box = [];
    box[0] = "a1";
    box[1] = "b1";
    box.push("c1");
    alert(box.join(""));
    alert(box.join("!"));
}

function array3() {
    var box = ["a", "a1", "a2", "a3"];
    box[0] = "a1";
    box[1] = "b1";
    box.push("c1");
    alert(box);
    box.pop();
    alert(box);
    box.shift();
    alert(box);
    box.unshift("a0");
    alert(box);
}

function array4() {
    var box = ["a", "a1", "a2", "a3", "a4", "a5"];
    alert(box+"所有数");
    alert(box.slice(1) + "取从1后面的数");
    alert(box.slice(2, 4) + "取从2到4的数,不包括4");
    alert(box.splice(1, 3) + "取从1开始3个数");
}