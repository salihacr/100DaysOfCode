/* If you're run this, Install Typescript Global npm install -g typescript
run step =>
    tsc day33.ts
    node day33.js
*/

// This function returns whether the number is perfect or not.
function isPerfectNumber(num: number) {
    var total = 0;
    for (let i = 0; i < num; i++) {
        if (num % i === 0) {
            total += i;
        }
    }
    return total === num;
}


/* Test Case */

for (let i = 1; i < 10000; i++) {
    if (isPerfectNumber(i)) {
        console.log(`${i} is perfect`);
    }
}
console.log("----------------------")