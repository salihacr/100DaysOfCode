/*
    This function create a column for the lotto coupons with numbers 1 to 49.
*/
function findUniqueLetterCount(text = "") {
    var counter = 0;
    var flag = false;
    var arr = [];
    var alphabet = 'abcdefghijklmnopqrtsuvwxyz';
    for (const i in alphabet) {
        for (const j in text.toLowerCase().trim()) {
            if (alphabet[i] === text[j]) {
                console.log(`${alphabet[i]} - ${text[j]}`)
                counter++;
                arr.push(alphabet[i]);
                flag = true;
            }
        }
        if (flag && counter > 0) {
            arr.push(counter);
        }
        counter = 0;
    }
    for (let i = 0; i < arr.length; i++) {
        console.log(arr[i]);
    }
    return arr;
}
findUniqueLetterCount("salihacur say hi")


/*
    This function removes leading and trailing spaces.
*/
const trim2 = (text = "") => {
    var counter = 0;
    var arr = [];
    var test = 0;
    for (const j in text) {
        if (text[j] === " ") {
            counter++;
        }
        else if (counter > 0) {
            arr.push(counter);
            counter = 0;
        }

        else {
            test = j;
        }
    }

    var spaceCountOfHead = arr[0];
    var lastLetterIndex = parseInt(test) + 1;

    var newText = "";
    var start = arr[0] > 0 ? spaceCountOfHead -= 1 : spaceCountOfHead += 1;
    
    for (i = start; i < lastLetterIndex; i++) {
        newText += text[i];
    }
    return `(${newText})`;
}


console.log(trim2("Iyi bir C programcisi olmak için çok çalismak gerekir "));


