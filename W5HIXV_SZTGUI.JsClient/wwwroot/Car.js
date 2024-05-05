let cars = [];
let connection = null;
getData();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:55762/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ActorCreated", (user, message) => {
        getdata();
    });

    connection.on("ActorDeleted", (user, message) => {
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
    await fetch('http://localhost:55762/Car')
        .then(x => x.json())
        .then(y => {
            cars = y;
            console.log(y);
            display();
        });

}

function remove(id) {
    fetch('http://localhost:55762/Car/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            getData();
        })
        .catch((error) => { console.error('Error:', error); });
}
function display() {
    document.getElementById("resultarea").innerHTML = "";
    cars.forEach(t => {
        document.getElementById("resultarea").innerHTML +=
            "<tr><td>" + t.id + "</td><td>" + t.plate + "</td><td>" + t.brand + "</td><td>" + t.total_Weith + "</td></tr>"
    })
}
function create() {
    let plate = document.getElementById("plate").value; 
    let brand = document.getElementById("brand").value; 
    let total_Weith = document.getElementById("total_Weith").value; 
    fetch('http://localhost:55762/Car', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {plate: plate, brand: brand, total_Weith: total_Weith })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}