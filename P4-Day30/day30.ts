/* If you're run this, Install Typescript Global npm install -g typescript
run step =>
    tsc day30.ts
    node day30.js
*/

// This function returns random value from min to max.
function randomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}
// This function returns random array given size..
function generateArray(from: Number, to: Number, size: Number) {
    var arr = [];
    for (let i = 0; i < size; i++) {
        arr.push(randomInt(from, to));
    }
    return arr;
}
// This function finds unique elements of given array.
function getUniques(array: Array<Number>) {
    for (let i = 0; i < array.length; i++) {
        var isDistinct: Boolean = false;
        for (let j = 0; j < i; j++) {
            if (array[i] === array[j]) {
                isDistinct = true;
                break;
            }
        }
        if (isDistinct === false) {
            console.log(`${array[i]}`);
        }
    }
}

/* Test Case */
var arr = generateArray(1, 20, 30);
console.log(arr);
getUniques(arr);

console.log("----------------------")

var nums = [5, 2, 7, 2, 4, 7, 8, 2, 3];
getUniques(nums);