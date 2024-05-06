let drivers = [];

async function getData() {
    const inputValue = document.getElementById("inputValue").value;
    const url = `http://localhost:55762/DriverNon/DriversOverValue?value=${inputValue}`;

    try {
        const response = await fetch(url);
        const data = await response.json();
        drivers = data;
        display();
    } catch (error) {
        console.error('Error fetching data:', error);
    }
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
