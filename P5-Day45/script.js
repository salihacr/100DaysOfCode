// State Object
const stateObject = {
    states: [
        { stateId: "q0 (Durum 0)", northLight: 3, westLight: 1, delay: 0 },
        { stateId: "q1 (Durum 1)", northLight: 2, westLight: 1, delay: 5000 },
        { stateId: "q2 (Durum 2)", northLight: 1, westLight: 2, delay: 7000 },
        { stateId: "q3 (Durum 3)", northLight: 1, westLight: 3, delay: 9000 },
        { stateId: "q4 (Durum 4)", northLight: 1, westLight: 2, delay: 14000 },
        { stateId: "q5 (Durum 5)", northLight: 2, westLight: 1, delay: 16000 }
    ]
};

// Dom Elements
const lamps = document.querySelectorAll('.lamp');
const lampsEast = document.querySelectorAll('.lamp2');
const stateText = document.getElementById('state');
const button = document.getElementById('simulate');

const colors2 = ['red', 'yellow', 'green'];
const colors = ['#c0392b', '#f1c40f', '#2ecc71'];

// Simulation Button Click Event
button.addEventListener('click', () => {
    startSimulate();
    setInterval(() => {
        startSimulate();
    }, 18001);
});

const offTimes = [0, 5000, 7000, 9000, 14000, 16000, 18001];

// startSimulate simulate
let startSimulate = function() {
    const len = stateObject.states.length;
    console.log(len);
    for (let i = 0; i < len; i++) {
        setTimeout(function () {

            lamps[stateObject.states[i].northLight - 1].style.backgroundColor = colors[stateObject.states[i].northLight - 1];
            lamps[stateObject.states[i].northLight - 1].style.boxShadow = `0 0 10px 5px ${colors[stateObject.states[i].northLight - 1]}`;

            console.log("on", stateObject.states[i]);
            stateText.innerText = "Şuanki Durum : " + stateObject.states[i].stateId;
            lampsEast[stateObject.states[i].westLight - 1].style.backgroundColor = colors[stateObject.states[i].westLight - 1];
            lampsEast[stateObject.states[i].westLight - 1].style.boxShadow = `0 0 10px 5px ${colors[stateObject.states[i].westLight - 1]}`;

        }, offTimes[i]);//stateObject.states[i].delay);

        setTimeout(() => {

            lamps[stateObject.states[i].northLight - 1].style.backgroundColor = '#121212';
            lamps[stateObject.states[i].northLight - 1].style.boxShadow = ``;

            console.log("off", stateObject.states[i]);

            lampsEast[stateObject.states[i].westLight - 1].style.backgroundColor = '#121212';
            lampsEast[stateObject.states[i].westLight - 1].style.boxShadow = ``;

        }, offTimes[i + 1]);//stateObject.states[i + 1].delay);
    }
}