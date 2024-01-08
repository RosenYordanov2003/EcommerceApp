﻿const baseUrl = "https://localhost:7122/api/cart"

export async function addToCartProduct(productId, userId, categoryName, quantity) {

    const bodyObject = {
        productId,
        userId,
        categoryName,
        quantity
    };
    const request = await fetch(`${baseUrl}/AddProduct`, {
        method: 'POST',
        credentials: 'include',
        headers: {
            "Content-type": "application/json"
        },
        body: JSON.stringify(bodyObject)
    });

    if (!request.ok) {
        throw Error(request.Error)
    }
    return request.ok;

}