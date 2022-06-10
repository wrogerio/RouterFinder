const selectFrom = document.querySelector('#selectFrom');
const selectTo = document.querySelector('#selectTo');
const btnFind = document.querySelector('#btnFind');
const spanCost = document.querySelector('#spanCost');
const listRoutes = document.querySelector('#listRoutes');
let rotasDb = [];
let result = [];
let analyzing = []; // array to test the results
let startPoint = "";
let stopPoint = "";
let costValue = 0;

// Select change of selectFrom object
selectFrom.addEventListener('change', () => {
    const from = selectFrom.value;
    const to = selectTo.value;
    const url = `https://localhost:44305/api/routerFinder/byfrom/${from}`;
    fetch(url)
        .then(res => res.json())
        .then(data => {
            // remove first option
            selectTo.innerHTML = '';

            const option = document.createElement('option');
            option.value = '';
            option.textContent = 'Select one';
            selectTo.appendChild(option);

            data.forEach(element => {
                const option = document.createElement('option');
                option.value = element.routeTo;
                option.textContent = element.routeTo;
                selectTo.appendChild(option);
            })
        });
});

btnFind.addEventListener('click', async () => {

    rotasDb = [];
    result = [];
    analyzing = [];
    startPoint = "";
    stopPoint = "";
    costValue = 0;
    
    // start - get start and stop points
    startPoint = selectFrom.value;
    stopPoint = selectTo.value;

    rotasDb = await getRoutesDB()

    // start - get all the routes from the start point
    let routesFrom = getRoutesFrom(startPoint);

    // start - loop to get all destinations
    while (routesFrom.length > 0) {
        // start - get the analyzed route
        let routeAnalyzed = routesFrom.shift();

        // start - using recoursivity to get all results
        stepsToRoutes(routeAnalyzed);
    }

    // start - separate the mimimum cost route
    let minimumCost = getMinimumCost(result);

    // start - show the result
    spanCost.innerHTML = `R$ ${costValue.toFixed(2)}`;
    listRoutes.innerHTML = '';
    let i = 0;
    minimumCost.forEach((step) => {
        i += 1;
        const li = document.createElement('li');
        li.classList.add('list-group-item');
        li.textContent = `#${i} - ${step.routeFrom} to ${step.routeTo} - R$ ${step.routeValue.toFixed(2)}`;
        listRoutes.appendChild(li);
    })
})

function getRoutesDB() {
    return new Promise((resolve, reject) => {
        const url = `https://localhost:44305/api/routerFinder`;
        fetch(url)
            .then(res => res.json())
            .then(data => {
                if (data.length > 0) {
                    resolve(data);
                }
                else {
                    reject('No data');
                }
            });
    })
}

// start - function to get all the routes from the start point
function getRoutesFrom(started) {
    return rotasDb.filter((route) => route.routeFrom === started);
}

// start - function to get all the routes to the stop point
function getRoutesTo(stopped) {
    return rotasDb.filter((route) => route.routeTo === stopped);
}

// start - function to findo all destinations inside the route (recursivity)
function stepsToRoutes(routeAnalyzed) {
    // start - add the analyzed route to be tested
    analyzing.push(routeAnalyzed);

    if (!verifyMoreRoutesTo()) {
        result.push(analyzing);
        analyzing = [];
        return;
    }

    // start - get all the destinations from the analyzed route
    let routesAlternatives = getRoutesFrom(routeAnalyzed.routeTo);

    // start - if there is no alternatives, add the analyzed route to the result
    if (routesAlternatives.length === 0) {
        result.push(analyzing);
        analyzing = [];
        return;
    }

    // start - loop to get all alternatives
    routesAlternatives.forEach((step) => {
        if (step.routeTo == stopPoint) {
            analyzing.push(step);
            result.push(analyzing);
            analyzing = [];
            return;
        }
        stepsToRoutes(step); // the recoursivity starts here
    });
}

// start - function to get the minimum cost
function getMinimumCost(routesArray) {
    let totalCost = Infinity;
    let stepCost = 0;
    minimumResult = [];

    // start - loop to get the minimum cost
    routesArray.forEach((alternatives) => {
        alternatives.forEach((step) => {
            stepCost += step.routeValue;
        });
        if (stepCost < totalCost) {
            totalCost = stepCost;
            costValue = totalCost;
            minimumResult = alternatives;
        }
        stepCost = 0;
    });

    return minimumResult;
}

// start - function to verify if there is more routes to the stop point
function verifyMoreRoutesTo() {
    // get all routes with the same end point
    let routesTo = getRoutesTo(stopPoint);

    // remove all routes with the from likes startPoint
    routesTo = routesTo.filter((route) => route.routeFrom !== startPoint);

    if (routesTo.length === 0) {
        return false;
    }

    return true;
}
