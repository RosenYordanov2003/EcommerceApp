const baseUrl = "https://localhost:7122/api/clothes"

export async function loadAllProducts(pageNumber) {
    const request = await fetch(`${baseUrl}/LoadAllClothes?pageNumber=${pageNumber}`, { credentials: 'include' });

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
export async function archiveProduct(productId, category) {

    const object = {
        productId,
        productCategory: category
    }

    const request = await fetch(`${baseUrl}/Archive`,
        {
            credentials: 'include',
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(object)
        }
    )

    if (!request.ok) {
        throw new Error(request.Error);
    }
    return request.ok;
}
export async function restoreProduct(productId, category) {

    const object = {
        productId,
        productCategory: category
    }

    const request = await fetch(`${baseUrl}/Restore`,
        {
            credentials: 'include',
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(object)
        }
    )

    if (!request.ok) {
        throw new Error(request.Error);
    }
    return request.ok;
}
export async function getCreateProductModel() {
    const request = await fetch(`${baseUrl}/LoadCreateProductModel`, { credentials: 'include' });

    const response = request.json();

    return response;
}

export async function createProduct(formObject) {
    const request = await fetch(`${baseUrl}/Create`, {
        credentials: 'include',
        method: 'POST',
        body: formObject,
    })

    if (!request.ok) {
        throw new Error(request.Error);
    }

    return request.ok;
}
export async function setProductToBeFeatured(productId) {
    const request = await fetch(`${baseUrl}/SetFeature`, {
        credentials: 'include',
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(productId),
    })

    if (!request.ok) {
        throw new Error(request.Error);
    }

    return request.ok;
}
export async function removeProductToBeFeatured(productId) {
    const request = await fetch(`${baseUrl}/RemoveFeature`, {
        credentials: 'include',
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(productId),
    })

    if (!request.ok) {
        throw new Error(request.Error);
    }

    return request.ok;
}

