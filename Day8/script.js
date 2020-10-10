const calculate = (n) => {
    let e = 0;
    for (let index = 0; index < n; index++) {
        e += 1 / factorial(index);
        console.log(e);
    }
    console.log(e);
}
/*
    This function calculate factorial given number.
*/
const factorial = (num) => {
    let total = 1;
    for (let index = 1; index <= num; index++) {
        total *= index;
    }
    return total;
}
const factorial2 = (num) => {
    if (num <= 1)
        return 1;
    return num * factorial2(num - 1);
}
calculate(8);

/*
    This function that checks whether the given numbers are friends or not ?
*/
const areFriends = (num1, num2) => {
    var sumFactorsOfNum1 = sumFactors(num1);
    var sumFactorsOfNum2 = sumFactors(num2);
    if (sumFactorsOfNum1 === num2 && sumFactorsOfNum2 === num1) {
        console.log(`${num1} and ${num2} are friends...`);
        return true;
    }
    else {
        //console.log("not friends...")
        return false;
    }
}
/*
    Sum factors function is a helper function for areFriends function.
*/
const sumFactors = (num) => {
    let total = 0;
    for (let index = 0; index < num; index++) {
        if (num % index === 0) {
            total += index;
        }
    }
    return total;
}

/*
    Test Cases
*/
areFriends(1184, 1210);
areFriends(17296, 18416);