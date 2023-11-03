const baseUrl = "https://localhost:7122/api/shoes"

export async function loadFeaturedShoes() {
    const request = await fetch(baseUrl);

    const responseAsJson = await request.json();

    return responseAsJson;
}