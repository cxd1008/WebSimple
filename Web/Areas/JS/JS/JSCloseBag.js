var bag = box();
function JSCloseBag1() {
    alert(bag());
    alert(box()());
}

function JSCloseBag2() {
    bag = null;
}

function box() {
    var age = 1;
    return function () {
        age++;
        return age;
    }
}