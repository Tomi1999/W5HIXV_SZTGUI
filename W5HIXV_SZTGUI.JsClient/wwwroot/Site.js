let sites = [];
let connection = null;
let sitesnoncrud = [];
getData();
setupSignalR();
siteIdToUpdate = -1;


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:55762/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("SiteCreated", (user, message) => {
        getdata();
    });

    connection.on("SiteDeleted", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();

}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};
async function getData() {
    await fetch('http://localhost:55762/Site')
        .then(x => x.json())
        .then(y => {
            sites = y;
            console.log(y);
            display();
        });

}

function remove(id) {
    fetch('http://localhost:55762/Site/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getData();
        })
        .catch((error) => { console.error('Error:', error); });
}
function display() {
    document.getElementById("resultarea").innerHTML = "";
    sites.forEach(t => {
        document.getElementById("resultarea").innerHTML +=
            "<tr><td>" + t.id + "</td><td>" + t.size + "</td><td>" + t.address + "</td></tr>"
    })
}
function update() {
    let size = document.getElementById("sizenew").value;
    let id = document.getElementById("id_update").value;
    let address = document.getElementById("addressnew").value;
    let city = document.getElementById("citynew").value;

    fetch('http://localhost:55762/Site/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getData();
        })
        .catch((error) => { console.error('Error:', error); });
    getData();
    fetch('http://localhost:55762/Site', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { size: size, address : address, city: city, id:id })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}
function create() {
    let size = document.getElementById("size").value;
    let address = document.getElementById("address").value;
    let city = document.getElementById("city").value;
    fetch('http://localhost:55762/Site', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { size: size, address: address, city: city })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}
