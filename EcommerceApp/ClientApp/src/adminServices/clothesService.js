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

    return request.ok;
}
export async function addProductStock(productStockObject) {
    const request = await fetch(`${baseUrl}/AddProductStock`,
        {
            credentials: 'include',
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(productStockObject)
        }
    )

    if (!request.ok) {
        throw new Error(request.Error);
    }
    return request.ok;
}