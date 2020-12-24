/* If you're run this, Install Typescript Global npm install -g typescript
run step =>
    tsc day31.ts
    node day31.js
*/

// This function returns random value from min to max.
function randomInteger(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}
// This function returns random array given size..
function generateRandomArray(from: Number, to: Number, size: Number) {
    var array: Array<Number> = [];
    for (let i = 0; i < size; i++) {
        array.push(randomInteger(from, to));
    }
    return array;
}
// This function finds mode and frequence of given array.
function getMode(array: Array<Number>) {
    var mode: Number = 0, frequence: Number = 0;
    for (let i = 0; i < array.length; i++) {
        var counter = 0;
        for (let j = 0; j < array.length; j++) {
            if (array[i] === array[j]) {
                counter++;
            }
        }
        if (counter > frequence) {
            frequence = counter;
            mode = array[i];
        }
    }
    return { "mode": mode, "frequence": frequence };
}

/* Test Case */
var myTestArray = generateRandomArray(1, 20, 30);
console.log(myTestArray);
const result = getMode(myTestArray);

console.log(`Mode : ${result.mode}, Frequence : ${result.frequence}`);

console.log("----------------------")

var nums = [5, 2, 7, 2, 4, 7, 5, 7, 8, 2, 7, 3, 4, 5, 6, 7, 8, 8, 1, 3];
const result2 = getMode(nums);

console.log(`Mode : ${result2.mode}, Frequence : ${result2.frequence}`);