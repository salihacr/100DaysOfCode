/* If you're run this, Install Typescript Global npm install -g typescript
run step =>
    tsc day32.ts
    node day32.js
*/

// This function find factorial iteratively.
function factorial(num: Number) {
    var result = 1;
    for (let i = 1; i <= num; i++) {
        result *= i;
    }
    return result;
}
// This function find factorial recursively.
function calculateFactorialRecursive(num) {
    if (num === 1 || num === 0) {
        return 1;
    }
    return num * calculateFactorialRecursive(num - 1);
}
// This function find combination. C(n,r) = (n)! / (r! * (n - r)!)
function combination(n, r) {
    return factorial(n) / (factorial(r) * factorial(n - r));
}
// This function find permutation. P(n,r) = (n)! / (n - r)! 
function permutation(n, r) {
    return factorial(n) / factorial(n - r);
}
/* Test Case */

// Combination
for (let i = 5; i <= 10; i++) {
    for (let j = 1; j <= i; j++) {
        console.log(`C(${i}, ${j}) = ${combination(i, j)}`);
    }
}
console.log("----------------------")
// Permutation
for (let i = 5; i <= 10; i++) {
    for (let j = 1; j <= i; j++) {
        console.log(`P(${i}, ${j}) = ${permutation(i, j)}`);
    }
}