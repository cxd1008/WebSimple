function str1 ()
{
    var str = "aBcDeFg";
    alert(str.toUpperCase());
    alert(str.toLowerCase());
}
function str2() {
    var box = '123456789';
    alert(box)
    alert("box[1]"+box[1]);
    alert("box.concat('0')"+box.concat('0')); //参数字符串连接
    
    alert("box.slice(4, 6)"+box.slice(4, 6));				//Le
    alert("box.substring(4, 6)"+box.substring(4, 6));		//Le
    alert("box.substr(4,6)" + box.substr(4, 6));				//从第四个开始，选6个
    alert("box.substr(4,2)"+box.substr(4,2));				//Le
    alert("box.slice(4)"+box.slice(4));
    alert("box.substring(4)"+box.substring(4));
    alert("box.substr(4)"+box.substr(4));					//三个都是Lee

}
function str3() {
    var box = 'Mr. Lee is Lee a Lee a Lee';
    alert(box.indexOf('L'));				//返回从初始位置搜索L第一次出现的位置，4
    alert(box.lastIndexOf('L'));		//返回从末尾位置搜索L第一次出现的位置，11
    alert(box.indexOf('L', 5));			//从第5个位置开始搜索L第一次出现的位置，11
    alert(box.lastIndexOf('L', 5));		//从第5个位置开始向前搜索L第一次出现的位置，4
    alert(box.indexOf(','));				//找不到，返回-1
}