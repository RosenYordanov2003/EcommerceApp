﻿const baseUrl = "https://localhost:7122/api/userMessage/";

export async function uploadUserMessage(object) {
    const request = await fetch(`${baseUrl}Upload`, {
        method: 'POST',
        headers: {
            'Content-Type':'application/json'
        },
        credentials: 'include',
        body: JSON.stringify(object)
    });

    const response = await request.json();

    return response;
}
export async function getMessageCount() {
    const request = await fetch(`${baseUrl}GetCount`, { credentials: 'include' });

    const response = await request.json();

    return response;
}
export async function getAllMessages() {
    const request = await fetch(`${baseUrl}GetAll`, { credentials: 'include' });

    const response = await request.json();

    return response;
}
export async function responToUserMessage(object) {
    const request = await fetch(`${baseUrl}Respond`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        credentials: 'include',
        body: JSON.stringify(object)
    });

    return request.ok;
}