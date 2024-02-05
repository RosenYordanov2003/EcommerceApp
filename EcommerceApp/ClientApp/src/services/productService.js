const baseUrl = "https://localhost:7122/api/products"

export async function loadFeaturedShoes(userId) {
    let result = userId === undefined ? "" : userId;
    const request = await fetch(`${baseUrl}/GetFeaturedShoes?userId=${result}`, { credentials: 'include', });

    const responseAsJson = await request.json();

    return responseAsJson;
}
export async function loadFeaturedClothes(userId) {

    let result = userId === undefined ? "" : userId;

    const request = await fetch(`${baseUrl}/GetFeaturedClothes?userId=${result}`, { credentials: 'include', });

    const responseAsJson = await request.json();

    return responseAsJson;
}
export async function loadProductsByGender(gender, userId) {

    const result = userId == undefined ? "" : userId;
    const request = await fetch(`${baseUrl}/GetProductsByGender?gender=${gender}&&userId=${result}`, { credentials: 'include' });

    if (!request.ok) {
        throw Error(request.Error);
    }
    const response = await request.json();

    return response;
    
}
export async function loadProductById(id, categoryName, userId) {
    let result = userId === undefined ? "" : userId;

    const request = await fetch(`${baseUrl}/AboutProduct?productid=${id}&categoryName=${categoryName}&&userId=${result}`, { credentials: 'include',  });

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
export function createProductObject(productName, productId, imgUrl, categoryName) {

    return {
        productName,
        productId,
        imgUrl,
        categoryName
    }
}
export function filterUserFavoriteProducts(userFavoriteProducts, productId, categoryName) {
    const result = userFavoriteProducts.map((product) => {
        if (product.productId != productId) {
            return product;
        }
        else {
            if (product.categoryName !== categoryName) {
                return product;
            }
        }
    })
    const filteredProducts = result.filter((product) => product !== undefined);

    return filteredProducts;
}
export async function getUserFavoriteProducts(userId) {
    const request = await fetch(`${baseUrl}/FavoriteProducts?userId=${userId}`, { credentials: 'include' })

    if (!request.ok) {
        throw Error(request.Error);
    }
    const response = await request.json();

    return response;
}
export async function loadAllProducts() {
    const request = await fetch(`${baseUrl}/LoadAllClothes`, { credentials: 'include' });

    const response = request.json();

    return response;
}