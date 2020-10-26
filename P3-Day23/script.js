/**
 * Mersenne numbers are integers of the form Mn = 2n-1.
 * @param {Number} pow Exponential value of mersenne number.
 * @returns {Number} Returns the number of mersenne.
 */
function findMersenneNumber(pow) {
    return Math.round(Math.pow(2, pow)) - 1;
}

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
    Test Case
*/
var i = 2;
while (i < 100) {
    if (isPrime(i)) {
        console.log(i + " => " + findMersenneNumber(i));
    }
    i++;
}