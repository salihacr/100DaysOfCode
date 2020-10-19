/*
    This function create a column for the lotto coupons with numbers 1 to 49.
*/
function lottoCoupon() {
    var temp = 0, counter = 0, randNum = 0;
    var numArray = [];
    for (let i = 0; i < 49; i++) {
        numArray[i] = i + 1;
    }
    // Shuffle Array
    numArray.sort((a, b) => 0.5 - Math.random());
    var column = [];
    while (counter < 6) {
        randNum = numArray[counter];
        column.push(randNum);
        temp = randNum;
        counter++;
    }
    return column.sort((a, b) => a - b);
}
/*
    Prints eight lotto coupon columns on the console.
*/
var i = 0;
while (i < 8) {
    console.log(`Column ${i + 1}`, lottoCoupon())
    i++;
}


/*
    This function does a leap year check.
*/
function isLeap(year) {
    return year % 4 == 0 && year % 100 != 0 || year % 400 == 0;
}
/*
    This function generates a random date between 1900 and 2000.
*/
const printRandomDate = (from, to) => {
    var day, month, year;
    var result = "";


    day = Math.round(Math.random() * 31) + 1;
    month = Math.round(Math.random() * 12) + 1;
    year = Math.round(Math.random() * (to - from)) + from;

    if (month === 2 && isLeap(year) === false) {
        day = Math.round(Math.random() * 28) + 1;
    }
    if (month === 2 && isLeap(year) === true) {
        day = Math.round(Math.random() * 29) + 1;
    }

    switch (day) {
        case 1: case 21: case 31:
            result = "st";
            break;
        case 2: case 22:
            result = "nd";
            break;
        case 3: case 23:
            result = "rd";
            break;
        default:
            result = "th";
            break;
    }
    var monthArray = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
    var nMonth = monthArray[month - 1] + "";
    console.log(` '${day} ${month} ${year}' => ${day}${result} ${nMonth.slice(0, 3)} ${year}`);
}

printRandomDate(1900, 2000);