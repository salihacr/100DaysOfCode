// State Object
const stateObject = {
    states: [
        { stateId: 'q0 (Durum 0)', northLight: 3, westLight: 1, delay: 0 },
        { stateId: 'q1 (Durum 1)', northLight: 2, westLight: 1, delay: 5000 },
        { stateId: 'q2 (Durum 2)', northLight: 1, westLight: 2, delay: 7000 },
        { stateId: 'q3 (Durum 3)', northLight: 1, westLight: 3, delay: 9000 },
        { stateId: 'q4 (Durum 4)', northLight: 1, westLight: 2, delay: 14000 },
        { stateId: 'q5 (Durum 5)', northLight: 2, westLight: 1, delay: 16000 }
    ]
};

const definition = {
    inputs: [
        { inputId: '00 Trafik Yok', north: false, east: false },
        { inputId: '01 Kuzeye Trafik', north: true, east: false },
        { inputId: '10 Batıya Trafik', north: false, east: true },
        { inputId: '11 Her Yöne Trafik', north: true, east: true },
    ]
};

// Dom Elements
const lamps = document.querySelectorAll('.lamp');
const lampsEast = document.querySelectorAll('.lamp2');
const stateText = document.getElementById('state');
const button = document.getElementById('simulate');
const alertElement = document.getElementById('alert');

const eastTraffic = document.getElementById('eastTraffic')
const northTraffic = document.getElementById('northTraffic')

const colorNames = ['red', 'yellow', 'green'];
const colors = ['#c0392b', '#f1c40f', '#2ecc71'];

const len = stateObject.states.length;
console.log(len);

// Set off times
const offTimes = [];
stateObject.states.forEach(state => {
    offTimes.push(state.delay);
});
offTimes[offTimes.length] = offTimes[offTimes.length - 1] + 2001;
console.log(offTimes);

const stateArr = stateObject.states;
console.log(stateArr);

// Helper functions
function createAlert(alertElement, text, ms) {
    alertElement.innerText = text;
    alertElement.style.display = 'block';
    setTimeout(() => {
        alertElement.style.display = 'none';
    }, ms);
}

let onLights = function (states, index) {
    lamps[states[index].northLight - 1].style.backgroundColor = colors[states[index].northLight - 1];
    lamps[states[index].northLight - 1].style.boxShadow = `0 0 10px 5px ${colors[states[index].northLight - 1]}`;

    console.log(`On : ${states[index].stateId}`);
    stateText.innerText = 'Şuanki Durum : ' + states[index].stateId;

    lampsEast[states[index].westLight - 1].style.backgroundColor = colors[states[index].westLight - 1];
    lampsEast[states[index].westLight - 1].style.boxShadow = `0 0 10px 5px ${colors[states[index].westLight - 1]}`;
}

let offLights = function (states, index) {
    lamps[states[index].northLight - 1].style.backgroundColor = '#121212';
    lamps[states[index].northLight - 1].style.boxShadow = ``;

    console.log(`Off : ${states[index].stateId}`);

    lampsEast[states[index].westLight - 1].style.backgroundColor = '#121212';
    lampsEast[states[index].westLight - 1].style.boxShadow = ``;
}

var northTrafficState = false;
northTraffic.addEventListener('change', function () {
    if (northTraffic.checked) {
        northTrafficState = true;
    }
    else {
        northTrafficState = false;
    }
    runn(eastTrafficState, northTrafficState);
    console.log("kuzey " + northTrafficState + "batı " + eastTrafficState);
})

var eastTrafficState = false;
eastTraffic.addEventListener('change', function () {
    if (eastTraffic.checked) {
        eastTrafficState = true;
    }
    else {
        eastTrafficState = false;
    }
    runn(eastTrafficState, northTrafficState);
    console.log("kuzey " + northTrafficState + "batı " + eastTrafficState);
})
onLights(stateArr, 0);
function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}
var currentState = stateArr[0];
async function runn(east, north) {

    if ((currentState === stateArr[0])
        && ((north === false && east === false)
            || north === true)) {
        offLights(stateArr, 5);
        onLights(stateArr, 0);
    }
    if ((currentState === stateArr[0])
        && ((north === true && east === true)
            || (east === true))) {
        offLights(stateArr, 5);
        onLights(stateArr, 0);
        await sleep(5000);
        currentState = stateArr[1];
        if (currentState === stateArr[1]) {
            offLights(stateArr, 0);
            onLights(stateArr, 1);
            await sleep(2000);
            currentState = stateArr[2];
            if (currentState === stateArr[2]) {
                offLights(stateArr, 1);
                onLights(stateArr, 2);
                await sleep(2000);
                currentState = stateArr[3];
                if ((currentState === stateArr[3])
                    && (north === false && east === true)) {
                    offLights(stateArr, 2);
                    onLights(stateArr, 3);
                }
                if ((currentState === stateArr[3])
                    && ((north === true && east === true)
                        || (north === true)
                        || (north === false && east === false))) {
                    offLights(stateArr, 2);
                    onLights(stateArr, 3);
                    await sleep(5000);
                    currentState = stateArr[4];
                    if ((currentState === stateArr[4])) {
                        offLights(stateArr, 3);
                        onLights(stateArr, 4);
                        await sleep(2000);
                        currentState = stateArr[5];
                        if (currentState === stateArr[5]) {
                            offLights(stateArr, 4);
                            onLights(stateArr, 5);
                            await sleep(2000);
                            currentState = stateArr[0];
                            if ((currentState === stateArr[0])
                                && ((north === false && east === false)
                                    || north === true)) {
                                offLights(stateArr, 5);
                                onLights(stateArr, 0);
                            }
                        }
                    }
                }
            }
        }
    }
    if ((currentState === stateArr[3])
        && (north === false && east === true)) {
        offLights(stateArr, 2);
        onLights(stateArr, 3);
    }
    if ((currentState === stateArr[3])
        && ((north === true && east === true)
            || (north === true)
            || (north === false && east === false))) {
        offLights(stateArr, 2);
        onLights(stateArr, 3);
        await sleep(5000);
        currentState = stateArr[4];
        if ((currentState === stateArr[4])) {
            offLights(stateArr, 3);
            onLights(stateArr, 4);
            await sleep(2000);
            currentState = stateArr[5];
            if (currentState === stateArr[5]) {
                offLights(stateArr, 4);
                onLights(stateArr, 5);
                await sleep(2000);
                currentState = stateArr[0];
                if ((currentState === stateArr[0])
                    && ((north === false && east === false)
                        || north === true)) {
                    offLights(stateArr, 5);
                    onLights(stateArr, 0);
                }
            }
        }
    }
    // await icra edilen iş bitirdikten sonra çalıştırılmasını sağlar
    while ((northTrafficState === true && eastTrafficState === true)
        || (currentState === stateArr[0]
            && northTrafficState === false
            && eastTrafficState === true)) {
        await runn(eastTrafficState, northTrafficState);
    }
}