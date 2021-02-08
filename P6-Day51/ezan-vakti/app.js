const city = document.querySelector('#konum');
const tableRows = document.querySelector('#vakitler');
const btnGet = document.querySelector('#btnGet');

// listeners
btnGet.addEventListener('click', getPrayTimes);

var xhr = new XMLHttpRequest();
getPrayTimes();
function getPrayTimes() {

    var data = null;
    let url = `https://api.collectapi.com/pray/all?data.city=${city.value.toLowerCase()}`;
    console.log("getir");
    xhr.addEventListener("readystatechange", function () {
        if (this.readyState === this.DONE) {
            let prayTimes = JSON.parse(this.responseText);
            let html = "";
            let data = prayTimes.result;
            data.forEach(prayTime => {
                html += `
                <td>
                    ${prayTime.saat}
                </td>
                `;
            });
            tableRows.innerHTML = html;
        }
    });

    xhr.open("GET", url);
    xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
    xhr.setRequestHeader("Access-Control-Allow-Credentials", "true");
    xhr.setRequestHeader("Access-Control-Allow-Methods", "GET,HEAD,OPTIONS,POST,PUT");
    xhr.setRequestHeader("Access-Control-Allow-Headers", "Access-Control-Allow-Headers, Origin,Accept, X-Requested-With, Content-Type, Access-Control-Request-Method, Access-Control-Request-Headers");
    xhr.setRequestHeader("content-type", "application/json");
    xhr.setRequestHeader("authorization", "apikey 7uu2gQMiU4tu46HX6B7dNV:3ovNB9nkhfEnB69eGdsHnR");

    xhr.send(data);
}