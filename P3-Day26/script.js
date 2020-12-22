/**
 * This function checks whether the digits of the given number are unique.
 * @param {Number} num Number to check if it has Unique digits of number.
 * @returns {Boolean} Returns whether the number of digits are unique or not.
 */
function isValid(num) {
    var temp = 0;
    for (let i = 0; i < 10; i++) {
        temp = num;
        var j = 0;
        while (temp > 1) {
            if (temp % 10 == i) {
                j++;
                if (j > 1) {
                    return false;
                }
                temp = temp / 10;
            }
        }
    }
    return true;
}
/*
    Generate random numbers 1000 to 9000
*/
const randNumber = () => {
    return Math.round(Math.random() * 9000) + 1000;
}

/*
    Test Case
*/
var arr = [];
arr.length = 1;
for (let i = 0; i < arr.length; i++) {
    if (isValid(randNumber())) {
        arr[i] = randNumber();
    }
}
arr.forEach(element => {
    console.log(element);
});
