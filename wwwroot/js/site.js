const uri_datos = "api/Datos";
const uri_cancelaciones = "api/Datos";


function getCancelaciones() {
    fetch(uri_cancelaciones)
        .then(response => response.json())
        .then(data_cancelacion => _vercancelacion(data_cancelacion))
        .catch(error => console.error('No se pudo obtener datos', error));
}

function _vercancelacion(data) {
    const tbody = document.getElementById('resultados');
    tbody.innerHTML = '';
    let buscar = document.getElementById('buscar').value;

    data.forEach(r => {
        if(r.f12 == buscar || r.cc == buscar){
            let tr1 = document.createElement('tr');
            tbody.appendChild(tr1);

            let td1 = document.createElement('td');
            td1.textContent = r.cc;
            tr1.appendChild(td1);

            let td2 = document.createElement('td');
            td2.textContent = r.oc;
            tr1.appendChild(td2);

            let td3 = document.createElement('td');
            td3.textContent = r.f12;
            tr1.appendChild(td3);

            let td4 = document.createElement('td');
            td4.textContent = r.sku;
            tr1.appendChild(td4);

            let td5 = document.createElement('td');
            td5.textContent = r.n_entrega;
            tr1.appendChild(td5);

            let td6 = document.createElement('td');
            td6.textContent = r.comentario;
            tr1.appendChild(td6);

            let td7 = document.createElement('td');
            td7.textContent = r.estadof12;
            tr1.appendChild(td7);
        } 
    });
}
