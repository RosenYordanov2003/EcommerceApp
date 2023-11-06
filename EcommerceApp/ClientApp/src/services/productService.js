const baseUrl = "https://localhost:7122/api/products"

export async function loadFeaturedShoes() {
    const request = await fetch(`${baseUrl}/GetFeaturedShoes`);

    const responseAsJson = await request.json();

    return responseAsJson;
}
export async function loadFeaturedClothes() {

    const request = await fetch(`${baseUrl}/GetFeaturedClothes`);

    const responseAsJson = await request.json();

    return responseAsJson;
}