let drivers = [];
let connection = null;
let driversNonCrud = [];
getData();
setupSignalR();
driverIdToUpdate = -1;

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:55762/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("DriverCreated", (user, message) => {
        getData();
    });

    connection.on("DriverDeleted", (user, message) => {
        getData();
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
}

async function getData() {
    await fetch('http://localhost:55762/Driver')
        .then(response => response.json())
        .then(data => {
            drivers = data;
            console.log(data);
            display();
        })
        .catch(error => {
            console.error('Error fetching data:', error);
        });
}

function remove(id) {
    fetch('http://localhost:55762/Driver/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' }
    })
        .then(response => {
            console.log('Driver deleted successfully:', response);
            getData();
        })
        .catch(error => {
            console.error('Error deleting driver:', error);
        });
}

function display() {
    const resultArea = document.getElementById("resultarea");
    resultArea.innerHTML = "";
    drivers.forEach(driver => {
        resultArea.innerHTML += `
            <tr>
                <td>${driver.id}</td>
                <td>${driver.name}</td>
                <td>${driver.distance}</td>
            </tr>
        `;
    });
}

function update() {
    const id = document.getElementById("id_update").value;
    const name = document.getElementById("name_update").value;
    const distance = document.getElementById("distance_update").value;

    fetch('http://localhost:55762/Driver/' + id, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ name: name, distance: distance })
    })
        .then(response => {
            console.log('Driver updated successfully:', response);
            getData();
        })
        .catch(error => {
            console.error('Error updating driver:', error);
        });
}

function create() {
    const name = document.getElementById("name").value;
    const distance = document.getElementById("distance").value;

    fetch('http://localhost:55762/Driver', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ name: name, distance: distance })
    })
        .then(response => {
            console.log('Driver created successfully:', response);
            getData();
        })
        .catch(error => {
            console.error('Error creating driver:', error);
        });
}
