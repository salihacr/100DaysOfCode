let answer = '';
let maxWrong = 6;
let mistakes = 0;
let guessed = [];

let word = "";
let classOfWord = "";

let wordStatus = null;
var xhr = new XMLHttpRequest();
xhr.onreadystatechange = test;
xhr.open("GET", "./words.json", true);
xhr.send();

function test() {
    if (xhr.readyState == 4) {
        var arr = JSON.parse(xhr.responseText);
        var randomClassNum = Math.floor(Math.random() * arr.hangmanWords.length);
        var randomWordNum = Math.floor(Math.random() * arr.hangmanWords[randomClassNum].words.length);
        classOfWord = arr.hangmanWords[randomClassNum].class;
        word = arr.hangmanWords[randomClassNum].words[randomWordNum];
        console.log("class : " + classOfWord + " word : " + word);
        randomWord();
        generateButtons();
        guessedWord();
    }
}
function randomWord() {
    answer = word;
    document.getElementById('class').innerHTML = classOfWord;
}
function generateButtons() {
    let buttonsHTML = 'abcdefghijklmnopqrstuvwxyz'.split('').map(letter =>
        `
        <button
          class="btn btn-lg btn-primary m-2"
          id='` + letter + `'
          onClick="handleGuess('` + letter + `')"
        >
          ` + letter + `
        </button>
      `).join('');

    document.getElementById('keyboard').innerHTML = buttonsHTML;
}
function guessedWord() {
    wordStatus = answer.split('').map(letter => (guessed.indexOf(letter) >= 0 ? letter : " _ ")).join('');
    document.getElementById('wordSpotlight').innerHTML = wordStatus;
}
function handleGuess(chosenLetter) {
    guessed.indexOf(chosenLetter) === -1 ? guessed.push(chosenLetter) : null;
    document.getElementById(chosenLetter).setAttribute('disabled', true);
    if (answer.indexOf(chosenLetter) >= 0) {
        guessedWord();
        checkIfGameWon();
    }
    else if (answer.indexOf(chosenLetter) === -1) {
        mistakes++;
        updateMistakes();
        updateHangmanPicture();
        checkIfGameLost();
    }
}
function updateMistakes() {
    document.getElementById('mistakes').innerHTML = mistakes;
}
function checkIfGameWon() {
    if (wordStatus === answer) {
        document.getElementById('keyboard').innerHTML = "You Won!";
    }
}
function checkIfGameLost() {
    if (mistakes === maxWrong) {
        document.getElementById('wordSpotlight').innerHTML = 'The answer was :' + answer;
        document.getElementById('keyboard').innerHTML = "You Lost!";
    }
}
function updateHangmanPicture() {
    document.getElementById('hangmanPic').src = './img/' + mistakes + '.jpg';
}
function reset() {
    mistakes = 0;
    guessed = [];
    document.getElementById('hangmanPic').src = './img/0.jpg';
    randomWord();
    guessedWord();
    updateMistakes();
    generateButtons();
    test();
}
document.getElementById('maxWrong').innerHTML = maxWrong;