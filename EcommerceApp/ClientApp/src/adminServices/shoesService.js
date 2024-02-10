const baseUrl = "https://localhost:7122/api/shoes";

export async function loadAllShoes() {
    const request = await fetch(`${baseUrl}/LoadAllShoes`, { credentials: 'include' });

    const response = await request.json();

    return response;
}
export async function getShoesToModify(shoesId) {
    const request = await fetch(`${baseUrl}/LoadShoesToEdit?shoesId=${shoesId}`, { credentials: 'include' });

    const response = await request.json();

    return response;
}