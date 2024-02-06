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
export async function editProduct(productObject) {
    const request = await fetch(`${baseUrl}/EditProduct`, {
        credentials: 'include',
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body:JSON.stringify(productObject)
    })

    if (!request.ok) {
        throw new Error(request.Error);
    }
    //const response = request.json();

    //return response;

    return request.ok;
}