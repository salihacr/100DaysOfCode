/*
    This function plays the "coin flipping" game.
*/
const coinFlippingGame = () => {

    var player2WinCount = 0;

    var coinState = 0;
    var frontFaceCounter = 0, backFaceCounter = 0;

    var player1Asset = 100000, player2Asset = 100000;

    var frontFlag, backFlag;
    var loopCount = 0;
    while (true) {
        console.log("*****************************************************************");
        frontFlag = false;
        backFlag = false;
        player1Asset += 10000;
        player2Asset -= 10000;
        console.log(`**Inital State**: Player1 earned 10k dollars. =>
        Player1 Total Money : ${player1Asset} dollars.
        Player2 Total Money : ${player2Asset} dollars.`);
        coinState = Math.round(Math.random() * 1) + 1;

        if (coinState === 1) {
            frontFlag = true;
            if (backFlag === true) {
                frontFaceCounter = 0;
            } else {
                frontFaceCounter += 1;
                backFaceCounter = 0;
            }
            backFlag = false;
            console.log("**FRONT => The front of the money came.");

        } if (coinState !== 1) {
            backFlag = true;
            if (frontFlag === true) {
                backFaceCounter = 0;
            } else {
                backFaceCounter += 1;
                frontFaceCounter = 0;
            }
            frontFlag = false;
            console.log("**BACK => The back of the money came.");
        }
        if (frontFaceCounter === 3) {
            console.log(`Came the front face of the money 3 times. =>
                The Player1 lost 60k dollars.
                The Player2 earned 60k dollars.`);
            player1Asset -= 60000;
            player2Asset += 60000;
            player2WinCount += 1;
            frontFaceCounter = 0, backFaceCounter = 0;

        }
        if (backFaceCounter === 2) {
            console.log(`Came the back face of the money 2 times. =>
                The Player1 lost 35k dollars.
                The Player2 earned 35k dollars.`);
            player1Asset -= 35000;
            player2Asset += 35000;
            player2WinCount += 1;
            frontFaceCounter = 0, backFaceCounter = 0;
        }
        console.log(`Come Front Face ${frontFaceCounter} times.
Come Back Face ${backFaceCounter} times.`);

        console.log(`Final State => 
            Player1 Money : ${player1Asset}
            Player2 Money : ${player2Asset}`);
        if (player1Asset <= 0 || player2Asset <= 0) {
            if (player1Asset > player2Asset) {
                console.log("Player1 won.")
            } else {
                console.log("Player2 won.");
            }
            break;
        }
        loopCount++;
    }
    console.log(`Player2 won in ${player2WinCount} out of ${loopCount} loops.
Player1 won in ${loopCount - player2WinCount} out of ${loopCount} loops`);
    return player2WinCount / loopCount;
}
// Total Loop Size
var total = 3, ratio = 0;

/*
    Calculating win rate.
*/
var player2WinProbability = 0;
for (let index = 0; index < total; index++) {
    player2WinProbability += coinFlippingGame();
}
console.log("********************************Calculating win rate********************************");
ratio = 1 - (player2WinProbability / total);
console.log("Win Rate : " + ratio)
