const baseUrl = "https://localhost:7122/api/order/"

export async function getOrderById(id) {
    const request = await fetch(`${baseUrl}Details?id=${id}`, { credentials: 'include' });

    const response = await request.json();

    return response;
}