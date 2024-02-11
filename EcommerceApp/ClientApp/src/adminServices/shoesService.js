﻿const baseUrl = "https://localhost:7122/api/shoes";

export async function loadAllShoes() {
    const request = await fetch(`${baseUrl}/LoadAllShoes`, { credentials: 'include' });

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