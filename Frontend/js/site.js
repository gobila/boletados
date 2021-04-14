const uri = 'https://localhost:5001/api/boletados';
let todos = [];

function getItems() {
  fetch(uri)
    .then(response => response.json())
    .then(data => _displayItems(data))
    .catch(error => console.error('Unable to get items.', error));
}

function addItem() {
  const addNameTextbox = document.getElementById('add-name');
  const addCpfTextbox = document.getElementById('add-cpf');
  const addUfTextbox = document.getElementById('add-uf');
  const addBithdayTextbox = document.getElementById('add-bithday');

  const item = {
    isComplete: false,
    name: addNameTextbox.value.trim(),
    cpf: addCpfTextbox.value.trim(),
    uf: addUfTextbox.value.trim(),
    bithday: addBithdayTextbox.value.trim(),
  };

  fetch(`${uri}/cadastro`, {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(item)
  })
    .then(response => response.json())
    .then(() => {
      getItems();
      addNameTextbox.value = '';
    })
    .catch(error => console.error('Unable to add item.', error));
}

function deleteItem(id) {
  fetch(`${uri}/delete/${id}`, {
    method: 'DELETE'
  })
  .then(() => getItems())
  .catch(error => console.error('Unable to delete item.', error));
}

function displayEditForm(id) {
  const item = todos.find(item => item.id === id);
  
  document.getElementById('edit-name').value = item.name;
  document.getElementById('edit-id').value = item.id;
  document.getElementById('edit-isComplete').checked = item.isComplete;
  document.getElementById('editForm').style.display = 'block';
}

function updateItem() {
  const itemId = document.getElementById('edit-id').value;
  const item = {
    id: parseInt(itemId, 10),
    isComplete: document.getElementById('edit-isComplete').checked,
    name: document.getElementById('edit-name').value.trim()
  };

  fetch(`${uri}/update/${itemId}`, {
    method: 'PUT',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(item)
  })
  .then(() => getItems())
  .catch(error => console.error('Unable to update item.', error));

  closeInput();

  return false;
}

function closeInput() {
  document.getElementById('editForm').style.display = 'none';
}

function _displayCount(itemCount) {
  const name = (itemCount === 1) ? 'pessoa' : 'pessoas';

  document.getElementById('counter').innerText = `${itemCount} ${name}`;
}

function _displayItems(data) {
  const tBody = document.getElementById('todos');
  tBody.innerHTML = '';

  _displayCount(data.length);

  const button = document.createElement('button');

  data.forEach(item => {
    let isCompleteCheckbox = document.createElement('input');
    isCompleteCheckbox.type = 'checkbox';
    isCompleteCheckbox.disabled = true;
    isCompleteCheckbox.checked = item.isComplete;

    let editButton = button.cloneNode(false);
    editButton.innerText = 'Edit';
    editButton.setAttribute('onclick', `displayEditForm(${item.id})`);

    let deleteButton = button.cloneNode(false);
    deleteButton.innerText = 'Delete';
    deleteButton.setAttribute('onclick', `deleteItem(${item.id})`);

    let tr = tBody.insertRow();
    
    let td1 = tr.insertCell(0);
    let idNode = document.createTextNode(item.id);
    td1.appendChild(idNode);

    let td2 = tr.insertCell(1);
    let nameNode = document.createTextNode(item.name);
    td2.appendChild(nameNode);

    let td3 = tr.insertCell(2);
    let cpfNode = document.createTextNode(item.cpf);
    td3.appendChild(cpfNode);

    let td4 = tr.insertCell(3);
    let ufNode = document.createTextNode(item.uf);
    td4.appendChild(ufNode);

    let td5 = tr.insertCell(4);
    let bithdayNode = document.createTextNode(item.bithday);
    td5.appendChild(bithdayNode);

    let td6 = tr.insertCell(5);
    td6.appendChild(editButton);

    let td7 = tr.insertCell(6);
    td7.appendChild(deleteButton);
  });

  todos = data;
}