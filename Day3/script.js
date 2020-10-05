/*
    This function calculate angle between hour and minutes hand.
*/
function hourAndMinutesHand(hour) {
    const splited = hour.split(":");
    var hours = parseInt(splited[0]);
    var minutes = parseInt(splited[1]);

    /*
        Another Method
    */
    var hourAngle = (0.5 * (hours * 60 + minutes));
    var minuteAngle = (6 * minutes);
    var angle = Math.abs(parseInt(hourAngle) - parseInt(minuteAngle));
    angle = Math.min(360 - angle, angle);
    console.log("Angle : " + angle);


    if (hours < 0 || minutes < 0 || hours > 12 || minutes > 60) {
        alert("Wrong input...");
    } else {
        console.log(`hour : ${hours}, minutes : ${minutes}`);
        return Math.abs((11 * minutes - 60 * hours) / 2);
    }
}
/**
 * Test Cases
 */
console.log(" Angle : " + hourAndMinutesHand("00:01"));
console.log(" Angle : " + hourAndMinutesHand("10:50"));
console.log(" Angle : " + hourAndMinutesHand("11:50"));
/*
    12 saat = 360 derece, ardışık her saat dilimi arası 30 derecedir,
    ardışık iki dakika arası ise 360/60 = 6 derecedir
    akrep 60 dakikada 1 saat yani 30 derece gidiyor yani 1 dakikada 1/2 derece yapar
    yelkovan 60 dakikada tam tur(360) derece gidiyor yani 1 dakikada 6 derece yapar
    bir dakikada yelkovan akrepten 6 - (1/2) = 11/2 fazla yol alır
*/
/*
--------------------------------------------------------------------------------------------------
*/

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
areFriends(220, 284);
areFriends(1184, 1210);
areFriends(17296, 18416);
areFriends(25, 58);


const stepCount = 30; // 1250 
for (let i = 1; i < stepCount; i++) {
    for (let j = 1; j < stepCount; j++) {
        if (areFriends(i, j)) {
            console.log(`${i} and ${j} are friends`);
        }
    }
}