function crapsGame() {
    var flag = true;
    var probability = 0;
    var dice1 = Math.floor(Math.random() * 6) + 1;
    var dice2 = Math.floor(Math.random() * 6) + 1;
    var total = dice1 + dice2;
    console.log(`Dice1 : ${dice1}, Dice2 : ${dice2}, Total : ${total}`);

    if (total === 7 || total === 11) {
        console.log("You win, perfect...");
        flag = false;
        probability = 8 / 36;
    }
    if (total === 2 || total === 3 || total === 12) {
        console.log("You lost...");
        flag = false;
    } else {
        var tempTotal = total;
        while (flag) {
            probability = 24 / 36;
            dice1 = Math.floor(Math.random() * 6) + 1;
            dice2 = Math.floor(Math.random() * 6) + 1;
            var newTotal = dice1 + dice2;
            console.log(`Dice1 : ${dice1}, Dice2 : ${dice2}, New Total : ${newTotal}`);
            if (newTotal === 7) {
                console.log("You lost...");
                flag = false;
            }
            if (newTotal === tempTotal) {
                if (newTotal === 4 || newTotal === 10) {
                    probability = (2) * (3 / 36) * (1 / 3);
                }
                if (newTotal === 5 || newTotal === 9) {
                    probability = (2) * (4 / 36) * (2 / 5);
                }
                if (newTotal === 6 || newTotal === 8) {
                    probability = (2) * (5 / 36) * (5 / 11);
                }
                console.log("You win, perfect...");
                flag = false;
            }
        }
    }
    console.log(probability);
    console.log("-----------------------");
    return probability;

}
var i = 0;
var step = 100;
var averageProbability = 0;
while (i < step) {
    averageProbability += crapsGame();
    i++;
}
console.log("Average Probability : " + (averageProbability / step));