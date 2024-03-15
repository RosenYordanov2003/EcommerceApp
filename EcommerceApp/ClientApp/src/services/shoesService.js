const baseUrl = "https://localhost:7122/shoes";


export async function loadFeaturedShoes(userId) {
    let result = userId === undefined ? "" : userId;
    const request = await fetch(`${baseUrl}/GetFeatured?userId=${result}`, { credentials: 'include', });

    const response = await request.json();

    return response;
}
export async function addShoesToUserFavoriteProducts(userId, shoesId) {
    const bodyObject = {
        userId,
        productId:shoesId,
    }
    const request = await fetch(`${baseUrl}/AddToFavorite`, {
        credentials: "include",
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(bodyObject)
    })

    if (!request.ok) {
        throw Error(request.Error);
    }

    const response = await request.ok;

    return response;
}
export async function removeShoesFromUserFavorite(userId, shoesId) {

    const bodyObject = {
        userId,
        productId: shoesId
    }

    const request = await fetch(`${baseUrl}/RemoveFromFavorite`, {
        credentials: 'include',
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(bodyObject)
    })
    if (!request.ok) {
        throw Error(request.Error);
    }
    const response = await request.ok;

    return response;
}
export async function loadShoesById(id, userId) {
    let result = userId === undefined ? "" : userId;

    const request = await fetch(`${baseUrl}/About?productid=${id}&userId=${result}`, { credentials: 'include', });

    if (!request.ok) {
        throw Error(request.Error);
    }
    const response = await request.json();

    return response;
}