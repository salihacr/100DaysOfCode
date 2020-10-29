/**
 * In math, prime numbers are whole numbers greater than 1, that have only two factors – 1 and the number itself.
    Prime numbers are divisible only by the number 1 or itself.  
 * @param {Number} num Number to check if it's a Prime number.
 * @returns {Boolean} Returns whether the number is prime or not.
 */
function isPrime(num) {
    for (let i = 2; i < (num / 2) + 1; i++) {
        if (num % i === 0) {
            return false;
        }
    }
    return true;
}
/*
    Cullen number formula
*/
const cullenNumber = (pow) => {
    return Math.round(Math.pow(2, pow) * pow) + 1;
}
/*
    Test Case
*/
var i = 1;
while (i < 150) {
    if (isPrime(cullenNumber(i))) {
        console.log(i + " => " + i);
    }
    i++;
}