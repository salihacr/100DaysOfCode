/*
    This function reverse the given number.
*/
function reverseNum(num) {
    var temp = num.toString();
    var arr = temp.split('');
    var result = "";
    for (let i = arr.length - 1; i >= 0; i--) {
        result += arr[i];
    }
    return parseInt(result);
}
console.log(reverseNum(1234));


/*
    This function convert decimal to binary.
*/
const numToBinary = (num) => {
    var result = "";
    while (num > 0) {
        result += parseInt(num % 2);
        num = parseInt(num / 2);
    }
    var temp = "";
    for (let i = result.length - 1; i >= 0; i--) {
        temp += result[i];
    }
    var binary = parseInt(temp);
    return binary;
}
console.log("10 =>", numToBinary(10));
/*
    Convert number to binary.
*/
var i = 17800;
while (i < 17820) {
    console.log(numToBinary(i));
    i++;
}
