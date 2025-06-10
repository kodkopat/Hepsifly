async function loadProducts() {
    const res = await fetch('/api/product');
    const products = await res.json();
    const select = document.getElementById('product');
    products.forEach(p => {
        const option = document.createElement('option');
        option.value = p.id;
        option.textContent = p.name;
        select.appendChild(option);
    });
}
async function loadReservations() {
    const res = await fetch('/api/reservation');
    const reservations = await res.json();
    const list = document.getElementById('reservation-list');
    list.innerHTML = '';
    reservations.forEach(r => {
        const li = document.createElement('li');
        li.textContent = `${r.customerName} reserved ${r.product.name} on ${new Date(r.date).toLocaleDateString()}`;
        list.appendChild(li);
    });
}
async function saveReservation(e) {
    e.preventDefault();
    const form = e.target;
    const data = {
        productId: form.productId.value,
        customerName: form.customerName.value,
        date: form.date.value
    };
    await fetch('/api/reservation', {
        method: 'POST',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify(data)
    });
    form.reset();
    loadReservations();
}
document.getElementById('reservation-form').addEventListener('submit', saveReservation);
loadProducts();
loadReservations();
