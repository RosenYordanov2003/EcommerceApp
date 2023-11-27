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