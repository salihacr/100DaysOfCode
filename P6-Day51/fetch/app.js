// Selectors
const btnGetText = document.querySelector('#getText');
const btnGetJson = document.querySelector('#getJson');
const btnGetApi = document.querySelector('#getApi');
const output = document.getElementById('output');

// listeners
btnGetText.addEventListener('click', getTextFile);
btnGetJson.addEventListener('click', getJson);
btnGetApi.addEventListener('click', getApi);

// Functions
function getTextFile2() {
    fetch("./text.txt").then(function (response) {

        return response.text();
    }).then(function (data) {
        output.innerHTML += data;
    }).catch(function (error) {
        console.log(error);
    });
}
// ES6 Arrow Function
function getTextFile() {
    fetch("./text.txt").then(response => response.text()).then(data => {
        output.innerHTML += data;
    }).catch(error => console.log(error));
}
// ES6 Arrow Function
function getJson() {
    fetch("./data.json")
        .then(response => response.json())
        .then(data => {
            console.log(data.person);
            let list = "<ul>";
            data.person.forEach(person => {
                list += `<li> Name : ${person.name}, Age : ${person.age} </li>`;
            });
            list += "</ul>";
            output.innerHTML += list;
        }).catch(error => console.log(error));
}

function getJson2() {
    fetch("./data.json").then(function (response) {
        return response.json();
    }).then(function (data) {
        console.log(data.person);
        let list = "<ul>";
        data.person.forEach(person => {
            list += `<li> Name : ${person.name}, Age : ${person.age} </li>`;
        });
        list += "</ul>";

        output.innerHTML += list;
    }).catch(function (error) {
        console.log(error);
    });
}

function getApi2() {
    fetch("https://api.github.com/users").then(function (response) {
        return response.json();
    }).then(function (users) {
        console.log(users);
        let list = "<ul>";
        users.forEach(user => {
            list += `<li> Username : ${user.login}</li>`;
        });
        list += "</ul>";

        output.innerHTML += list;
    }).catch(function (error) {
        console.log(error);
    });
}
// ES6 Arrow Function
function getApi() {
    fetch("https://api.github.com/users")
        .then(response => response.json())
        .then(function (users) {
            let list = "<ul>";
            users.forEach(user => {
                list += `<li> Username : ${user.login}</li>`;
            });
            list += "</ul>";
            output.innerHTML += list;
        }).catch(error => console.log(error));
}