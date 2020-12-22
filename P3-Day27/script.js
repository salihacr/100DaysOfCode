/**
 * This function calculate win probability in chips 60 game. 
 * @param {Number} total game tour count
 * @returns {Number} Returns win probability in total tour. 
 */
function chip60(total) {
    var chips = [];
    chips.length = 91;
    var nums = [];
    nums.length = 5;

    var flag = true;
    var ratio = 0, win = 0, count, num;

    for (let i = 0; i < total; i++) {
        for (let j = 0; j < chips.length; j++) {
            chips[j] = 0;
        }
        count = 0;
        while (count != 60) {
            num = Math.round(Math.random() * 60) + 1;
            if (chips[num] == 0) {
                chips[num] = 1;
                count++;
            }
        }
        sum = 0, count = 0;
        while (count != nums.length) {
            num = Math.round(Math.random() * 90) + 1;
            flag = false;
            if (flag == false) {
                nums[count] = num;
                count++;
                sum += chips[num];
            }
        }
        if (sum == 5) {
            win += 1;
        }
    }
    return ratio = win / total;
}
console.log("Win Probability : " + chip60(100000));
