let cars = [];

async function getCarsByBrand() {
    const inputValue = document.getElementById("inputValue").value;
    const url = `http://localhost:55762/CarNon/GetBrands?brand=${inputValue}`;

    try {
        const response = await fetch(url);
        const data = await response.json();
        cars = data;
        display();
    } catch (error) {
        console.error('Error fetching data:', error);
    }
}

async function getCarsOverTW() {
    const inputValue = document.getElementById("inputValue").value;
    const url = `http://localhost:55762/CarNon/CarsOverTW?weith=${inputValue}`;

    try {
        const response = await fetch(url);
        const data = await response.json();
        cars = data;
        display();
    } catch (error) {
        console.error('Error fetching data:', error);
    }
}

function display() {
    const resultArea = document.getElementById("resultarea");
    resultArea.innerHTML = "";

    cars.forEach(car => {
        resultArea.innerHTML += `
            <tr>
                <td>${car.id}</td>
                <td>${car.plate}</td>
                <td>${car.brand}</td>
                <td>${car.total_Weith}</td>
            </tr>
        `;
    });
}
