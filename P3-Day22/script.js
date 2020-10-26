/**
 * Find all possible sum of cubes for a particular number
 * @param {Number} num to find all sum of cube pairs
 * @return {Array} Array of sum of cubes
 */
function findAllPossiblePairs(num) {

    var firstNum = 1;
    var arr = [];

    var secondNum = Math.floor(Math.pow(num, 1 / 3));

    while (firstNum <= secondNum) {
        var sum = Math.pow(firstNum, 3) + Math.pow(secondNum, 3);

        if (sum === num) {
            arr.push([firstNum, secondNum]);
            secondNum--;
            firstNum++;
        }

        else if (sum > num) {
            secondNum--;
        }

        else {
            firstNum++;
        }
    }
    return arr;
}

/**
 * A Ramanujan number has exactly two sum of cube pairs.
 * @param {Number} x Number to check if it's a Ramanujan number
 */
function isRamanujan(x) {
    return findAllPossiblePairs(x).length === 2;
}
var i = 0;
while (i < 50000) {
    i++;
    if (isRamanujan(i)) {
        console.log(i + " => " + findAllPossiblePairs(i));
    }
}