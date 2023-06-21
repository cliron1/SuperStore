import { getProds } from './api.module.js';

const items = await getProds();

let trs = '';
for (const item of items) {
    trs += `<tr>
    <td>${item.name}</td>
    <td>${item.price}</td>
    </tr>`
}

const tbody = document.querySelector('tbody');
tbody.innerHTML = trs;

