let cars = [];
fetch('http://localhost:55762/Car')
    .then(x => x.json())
    .then(y => {
        cars = y;
        console.log(y);
        display();
    });

function display() {
    cars.forEach(t => {
        document.getElementById("resultarea").innerHTML +=
            "<tr><td>" + t.id + "</td><td>" + t.plate + "</td><td>" + t.brand + "</td><td>" + t.total_Weith + "</td></tr>"
        console.log(t.plate)
    })
}
function create() {
    let plate = document.getElementById("plate").value; 
    let brand = document.getElementById("brand").value; 
    let total_Weith = document.getElementById("total_Weith").value; 
    let id = document.getElementById("id").value; 
    fetch('http://localhost:55762/Car', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {id:id plate: plate, brand: brand, total_Weith: total_Weith })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}