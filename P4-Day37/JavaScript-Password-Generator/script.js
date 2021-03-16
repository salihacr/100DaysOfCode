// DOM elements
const resultElement = document.getElementById('result');
const lengthElement = document.getElementById('length');
const upperCaseElement = document.getElementById('uppercase');
const lowerCaseElement = document.getElementById('lowercase');
const numberstElement = document.getElementById('numbers');
const symbolsElement = document.getElementById('symbols');
const generateElement = document.getElementById('generate');
const clipboardElement = document.getElementById('clipboard');

const alertElement = document.getElementById('alert');

const randomFunc = {
    lower: getRandomLower,
    upper: getRandomUpper,
    number: getRandomNumber,
    symbol: getRandomSymbol
};

// Generate button, event listener (click event)
generateElement.addEventListener('click', () => {
    const length = parseInt(lengthElement.value);
    const hasLower = lowerCaseElement.checked;
    const hasUpper = upperCaseElement.checked;
    const hasNumber = numberstElement.checked;
    const hasSymbol = symbolsElement.checked;

    resultElement.innerText = generatePassword(hasLower, hasUpper, hasNumber, hasSymbol, length);
});

// Copy password to clipboard
clipboardElement.addEventListener('click', () => {
    const textarea = document.createElement('textarea');
    const password = resultElement.innerText;

    if (!password) {
        return;
    }
    textarea.value = password;
    document.body.appendChild(textarea);
    textarea.select();
    document.execCommand('copy');
    textarea.remove();
    createAlert(alertElement, 'password to copied to clipboard !');
});

// Generate password function
function generatePassword(lower, upper, number, symbol, length) {
    // 1. Initialize password var
    // 2. Filter out unchecked types
    // 3. Loop over length call generator function for each type
    // 4. Add final password to the password and return

    let generatedPassword = '';

    const typesCount = lower + upper + number + symbol;
    console.log(typesCount);

    const typesArray = [{ lower }, { upper }, { number }, { symbol }]
        .filter(item => Object.values(item)[0]);

    console.log(typesArray);

    if (typesCount === 0) {
        return '';
    }
    for (let i = 0; i < length; i += typesCount) {
        typesArray.forEach(type => {
            const funcName = Object.keys(type)[0];
            generatedPassword += randomFunc[funcName]();
        });
    }
    generatedPassword = generatedPassword.slice(0, length);

    console.log("original password : " + generatedPassword);

    const finalPassword = generatedPassword.shuffle();

    console.log("final password : " + finalPassword);

    return finalPassword;
}

// helper functions
function generateRandomNumber(from, to) {
    return Math.floor(Math.random() * (to - from + 1)) + from;
}

//shuffles text string 
//usage: "mystring".shuffle();  
String.prototype.shuffle = function () {
    var text = this.split(''), n = text.length;

    for (var i = n - 1; i > 0; i--) {
        var j = Math.floor(Math.random() * (i + 1));
        var tmp = text[i];
        text[i] = text[j];
        text[j] = tmp;
    }
    return text.join('');
}

function createAlert(alertElement, text) {
    alertElement.innerText= text;
    alertElement.style.display = 'block';
    setTimeout(() => {
        alertElement.style.display = 'none';
    }, 1500);  
}

// Generator functions

function getRandomLower() {
    var lowerCharacterCodeRange = generateRandomNumber(97, 122);
    return String.fromCharCode(lowerCharacterCodeRange);
}

function getRandomUpper() {
    var upperCharacterCodeRange = generateRandomNumber(65, 90);
    return String.fromCharCode(upperCharacterCodeRange);
}

function getRandomNumber() {
    var numberCharacterCodeRange = generateRandomNumber(48, 57);
    return String.fromCharCode(numberCharacterCodeRange);
}
function getRandomSymbol() {
    const symbols = '!@#$%^&*(){}[]=<>/,._-/+';
    return symbols[generateRandomNumber(0, symbols.length)];
}

for (let i = 0; i < 5; i++) {
    console.log(getRandomSymbol());
}