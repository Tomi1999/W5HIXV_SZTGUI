let sites = [];

async function getSitesInCity() {
    const inputValueCity = document.getElementById("inputValueCity").value;
    const url = `http://localhost:55762/SiteNon/SiteInCity?city=${inputValueCity}`;

    try {
        const response = await fetch(url);
        const data = await response.json();
        sites = data;
        display();
    } catch (error) {
        console.error('Error fetching data:', error);
    }
}

async function getSitesBySize() {
    const inputValueSize = document.getElementById("inputValueSize").value;
    const url = `http://localhost:55762/SiteNon/SitesSize?size=${inputValueSize}`;

    try {
        const response = await fetch(url);
        const data = await response.json();
        sites = data;
        display();
    } catch (error) {
        console.error('Error fetching data:', error);
    }
}

function display() {
    const resultArea = document.getElementById("resultarea");
    resultArea.innerHTML = "";

    sites.forEach(site => {
        resultArea.innerHTML += `
            <tr>
                <td>${site.id}</td>
                <td>${site.size}</td>
                <td>${site.address}</td>
                <td>${site.city}</td>
            </tr>
        `;
    });
}
