const baseUrl = "https://localhost:7122/api/clothes"

export async function loadAllProducts() {
    const request = await fetch(`${baseUrl}/LoadAllClothes`, { credentials: 'include' });

    const response = request.json();

    return response;
}
export async function getProductToModify(protductId) {
    const request = await fetch(`${baseUrl}/GetProductToModify?productId=${protductId}`, { credentials: 'include' });

    const response = request.json();

    return response;
}