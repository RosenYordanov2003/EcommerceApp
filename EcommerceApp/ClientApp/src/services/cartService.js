﻿const baseUrl = "https://localhost:7122/api/cart"

export async function addToCartProduct(productId, userId, categoryName, quantity, size) {

    const bodyObject = {
        productId,
        userId,
        categoryName,
        quantity,
        size
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
    return request.json();

}
export async function removeProductFromUserCart(productObject) {

    const request = await fetch(`${baseUrl}/RemoveProduct`, {
        method: 'POST',
        credentials: 'include',
        headers: {
            "Content-type": "application/json"
        },
        body: JSON.stringify(productObject)
    });

    if (!request.ok) {
        throw Error(request.Error)
    }
    return request.ok;

}
export async function modifyProductCartQuantity(productObject) {
    const request = await fetch(`${baseUrl}/ModifyProducCarttQuantity`, {
        method: 'POST',
        credentials: 'include',
        headers: {
            "Content-type": "application/json"
        },
        body: JSON.stringify(productObject)
    })
    if (!request.ok) {
        throw Error(request.Error)
    }
    return request.json();
}
export async function finishOrder(orderModel) {

    console.log(orderModel);

    const request = await fetch(`${baseUrl}/FinishOrder`, {
        method: 'POST',
        credentials: 'include',
        headers: {
            "Content-type": "application/json"
        },
        body: JSON.stringify(orderModel)
    })
    if (!request.ok) {
        throw Error(request.Error)
    }
    return request.ok;
}