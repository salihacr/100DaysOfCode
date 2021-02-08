// Selectors
const btnGetJson = document.querySelector('#getJson');
const btnGetApi = document.querySelector('#getApi');
const tableRows = document.getElementById('persons');
const loader = document.getElementById('loader');
const output = document.getElementById('output');

// listeners
//btnGetText.addEventListener('click', getTextFile);
btnGetJson.addEventListener('click', getJson);
btnGetApi.addEventListener('click', getApi);



function getJson() {
    loader.style.display = 'block';
    const xhr = new XMLHttpRequest();
    xhr.open('GET', './data.json', true);
    setTimeout(() => {
        loader.style.display = 'none';
        xhr.onload = function () {
            if (this.status === 200) {
                let persons = JSON.parse(this.responseText);
                console.log(persons);
                let html = "";
                persons.person.forEach(person => {
                    console.log(person);
                    html += `
                    <tr>
                        <td>${person.name}</td>
                        <td>${person.age}</td>
                    </tr>
                    `;
                });
                tableRows.innerHTML = html;
            }
        }
        xhr.send();
    }, 1500);
}


function getApi() {
    loader.style.display = 'block';
    const xhr = new XMLHttpRequest();
    xhr.open('GET', 'https://api.github.com/users', true);
    setTimeout(() => {
        loader.style.display = 'none';
        xhr.onload = function () {
            if (this.status === 200) {
                let users = JSON.parse(this.responseText);

                let html = "";
                users.forEach(user => {
                    html += `
                        <li>User : ${user.login}</li>
                    `;
                });
                output.innerHTML = html;
            } else {
                console.log(this.status);
            }
        }
        xhr.send();
    }, 1500);
}