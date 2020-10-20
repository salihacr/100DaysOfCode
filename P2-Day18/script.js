/*
   The function that whether the given numbers is prime.
*/
function isPrime(num) {
    var flag = true;
    for (let i = 2; i < (num / 2) + 1; i++) {
        if (num % i == 0) {
            flag = false;
        }
    }
    return flag;
}
/*
    Sum of digits from given number.
*/
function sumOfDigits(num) {
    var i = 0, total = 0;
    while (num > 0) {
        var digit = num % 10;
        total += parseInt(digit);
        num = parseInt(num / 10);
        i++;
    }
    return total;
}
/*
    This function sums the prime divisors of the given number.
*/
function findDivisors(num) {
    var divisor = 2;
    var divisors = [];
    while (num > 1) {
        if (isPrime(divisor)) {
            if (num % divisor === 0) {
                num = num / divisor;
                divisors.push(divisor);
            }
            else {
                divisor++;
            }
        }
        else {
            divisor++;
        }
    }
    var total = 0;
    divisors.forEach(element => {
        total += sumOfDigits(element);
    });
    return total;
}
/*
    This function checks if the given number is the smith number.
*/
const smithNumbers = (num) => {
    var digitsTotal = sumOfDigits(num);
    var divisorsTotal = findDivisors(num);
    return divisorsTotal === digitsTotal`${num} is smith number.`;
}
/*
    Prints all smith numbers 1 to 10000.
*/
var i = 1;
while (i < 100) {
    console.log(smithNumbers(i));
    i++;
}


/*
    This function prints the given second in hours, minutes and seconds.
*/
const displayDuration = (sec) => {
    var hours = 0, minutes = 0, seconds = 0;

    // minutes
    minutes = parseInt(sec / 60);
    // seconds
    seconds = sec % 60;
    // hours
    hours = parseInt(minutes / 60);
    // result Minute 
    var resultMinute = parseInt(minutes % 60);

    // hours
    if (hours !== 0 && resultMinute === 0 && seconds === 0) {
        console.log(`${hours} hours`);
    }
    // minutes 
    if (resultMinute !== 0 && resultMinute < 60 && hours === 0 && seconds === 0) {
        console.log(`${resultMinute} minutes`);
    }
    // seconds 
    if (seconds !== 0 && seconds < 60 && hours === 0 && resultMinute === 0) {
        console.log(`${seconds} seconds`);
    }
    // hours and minutes
    if (hours !== 0 && resultMinute !== 0 && seconds === 0) {
        console.log(`${hours} hours ${resultMinute} minutes`);
    }
    // hours and seconds
    if (hours !== 0 && resultMinute === 0 && seconds !== 0) {
        console.log(`${hours} hours ${seconds} seconds`);
    }
    // minutes & seconds
    if (hours === 0 && resultMinute !== 0 && seconds !== 0) {
        console.log(`${resultMinute} minutes ${seconds} seconds`);
    }
    // all
    if (hours !== 0 && resultMinute !== 0 && seconds !== 0) {
        console.log(`${hours} hours ${resultMinute} minutes ${seconds} seconds`);
    }
}

displayDuration(3600);
displayDuration(240);
displayDuration(310);
displayDuration(7205);
displayDuration(14520);
displayDuration(4212);