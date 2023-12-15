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
export async function loadProductById(id) {
    const request = await fetch(`${baseUrl}/AboutProduct?productid=${id}`, { credentials = 'include' });

    if (!request.ok) {
        throw Error(request.Error);
    }
    const response = await request.json();

    return response;
}