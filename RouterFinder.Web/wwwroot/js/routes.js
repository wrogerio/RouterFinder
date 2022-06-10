// variabels
const btAdd = document.querySelector('#btAdd');
const from = document.querySelector('#from');
const to = document.querySelector('#to');
const cost = document.querySelector('#cost');
const btShowModal = document.querySelector('#btShowModal');
const btRemove = document.querySelector('#btRemove');
const modalRemoveClose = document.querySelector('#modalRemoveClose');
const frmAdd = document.querySelector('#frmAdd');
const urlBase = 'https://localhost:44305'

// modal config
const modalAdd = new bootstrap.Modal('#modalAdd')
const modalRemove = new bootstrap.Modal('#modalRemove')

// show modal
btShowModal.addEventListener('click', () => {
    frmAdd.reset();
    modalAdd.show();
    localStorage.setItem('op', 'create');
    localStorage.removeItem('idRoute');

    // focus to from
    setTimeout(() => {
        from.focus();
    }, 500);
})

// close modal
modalRemoveClose.addEventListener('click', () => {
    modalRemove.hide();
})

// create new route or edit route
btAdd.addEventListener('click', () => {
    if (validateForm()) {
        const data = JSON.stringify({
            routeFrom: from.value,
            routeTo: to.value,
            routeValue: cost.value,
            routeDescription: ''
        })

        var url = `${urlBase}/api/routerFinder`;
        const op = localStorage.getItem('op');

        if (op === 'create') {
            fetch(url, {
                method: 'POST',
                body: data,
                headers: {
                    'Content-Type': 'application/json'
                }
            })
                .then(response => {
                    if (response.ok) {
                        alert('Successfully added');
                        modalAdd.hide();
                        window.location.reload();
                        frmAdd.reset();
                    }
                })
                .catch(error => {
                    alert('Error');
                    console.log(error);
                })
        }
        else {
            const id = localStorage.getItem('idRoute');
            url = `${urlBase}/api/routerFinder/${id}`;
            fetch(url, {
                method: 'PUT',
                body: data,
                headers: {
                    'Content-Type': 'application/json'
                }
            })
                .then(response => {
                    if (response.ok) {
                        alert('Successfully edited');
                        modalAdd.hide();
                        window.location.reload();
                        frmAdd.reset();
                    }
                })
                .catch(error => {
                    alert('Error');
                    console.log(error);
                })
        }
    }
})

// valid form
function validateForm() {
    if (from.value === '' || to.value === '' || cost.value === '') {
        alert('Please fill all fields');
        return false;
    }
    return true;
}

// remove Route
btRemove.addEventListener('click', (e) => {
    const id = localStorage.getItem('idRoute');
    var url = `${urlBase}/api/routerFinder/${id}`;

    fetch(url, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => {
            if (response.ok) {
                alert('Successfully removed');
                location.reload();
            }
        })
        .catch(error => {
            alert('Error');
            console.log(error);
        })
})
