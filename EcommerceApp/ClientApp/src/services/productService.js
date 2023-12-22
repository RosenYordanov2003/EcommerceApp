const baseUrl = "https://localhost:7122/api/products"

export async function loadFeaturedShoes() {
    const request = await fetch(`${baseUrl}/GetFeaturedShoes`, { credentials: 'include', });

    const responseAsJson = await request.json();

    return responseAsJson;
}
export async function loadFeaturedClothes() {

    const request = await fetch(`${baseUrl}/GetFeaturedClothes`, { credentials: 'include', });

    const responseAsJson = await request.json();

    return responseAsJson;
}
export async function loadProductsByGender(gender) {
    const request = await fetch(`${baseUrl}/GetProductsByGender?gender=${gender}`, { credentials: 'include' });

    if (!request.ok) {
        throw Error(request.Error);
    }
    const response = await request.json();

    return response;
    
}
export async function loadProductById(id, categoryName, userId) {
    const request = await fetch(`${baseUrl}/AboutProduct?productid=${id}&categoryName=${categoryName}&&userId=${userId}`, { credentials: 'include',  });

    if (!request.ok) {
        throw Error(request.Error);
    }
    const response = await request.json();

    return response;
}
export async function addProductToUserFavoriteProductsList(userId, productId, categoryName) {

    const bodyObject = {
        userId,
        productId,
        categoryName
    }

    const request = await fetch(`${baseUrl}/AddToFavoriteProducts`, {
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
export async function removeProductFromUserFavoriteList(userId, productId, categoryName) {

    const bodyObject = {
        userId,
        productId,
        categoryName
    }

    const request = await fetch(`${baseUrl}/RemoveFromUserFavoriteLists`, {
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