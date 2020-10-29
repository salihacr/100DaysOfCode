/**
 * Luhn makes it possible to check numbers (credit card, SIRET, etc.) via a control key
 *  (called checksum, it is a number of the number which makes it possible
 *  to check the others). If a character is misread or badly written,
 *  then Luhn's algorithm will detect this error.
 * @param {Number} cardNumber Number to check if it's a valid card number.
 * @returns {String} Returns whether the card number is valid or not.
 */
const luhnAlgorithm = (cardNumber) => {
    var numSum = 0;
    var value;
    for (var i = 0; i < cardNumber.length; i++) {
        if (i % 2 == 0) {
            value = 2 * cardNumber[i];
            if (value >= 10) {
                value = (Math.floor(value / 10) + value % 10);
            }
        } else {
            value = +cardNumber[i];
        }
        numSum += value;
    }
    return (numSum % 10 == 0) === true ? "Card Number is valid." : "Card Number is not valid.";
}

console.log(luhnAlgorithm('4111111111111111'));
console.log(luhnAlgorithm('4485275742308327'));