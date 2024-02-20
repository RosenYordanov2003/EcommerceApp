const baseUrl = "https://localhost:7122/api/shoes";

export async function loadAllShoes(pageNumber) {
    const request = await fetch(`${baseUrl}/LoadAllShoes?pageNumber=${pageNumber}`, { credentials: 'include' });

    const response = await request.json();

    return response;
}
export async function getShoesToModify(shoesId) {
    const request = await fetch(`${baseUrl}/LoadShoesToEdit?shoesId=${shoesId}`, { credentials: 'include' });

    const response = await request.json();

    return response;
}
export async function editShoes(object) {
    const request = await fetch(`${baseUrl}/editShoes`, {
        credentials: 'include',
        method: 'POST',
        headers: {
            'Content-Type' : 'application/json'
        },
        body: JSON.stringify(object)
    });

    return request.ok;
}
export async function addShoesStcok(object) {
    const request = await fetch(`${baseUrl}/addStock`, {
        credentials: 'include',
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(object)
    });

    return request.ok;
}
export async function setShoesToBeFeatured(shoesId) {
    const request = await fetch(`${baseUrl}/SetFeature`, {
        credentials: 'include',
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(shoesId)
    });

    return request.ok;
}
export async function removeFeaturedShoes(shoesId) {
    const request = await fetch(`${baseUrl}/RemoveFeature`, {
        credentials: 'include',
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(shoesId)
    });

    return request.ok;
}