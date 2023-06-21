import { upsert } from './api.module.js';

const btn = document.querySelector('#btnSave');
btn.addEventListener('click', saveMe);

async function saveMe(event) {
    event.preventDefault();
    //debugger;
    const item = {};
    item.name = document.querySelector('#name').value;
    item.price = Number(document.querySelector('#price').value);

    const saved = await upsert(item);

    if (saved) {
        //alert('Saved');
        location.href = '/';
    }
}

