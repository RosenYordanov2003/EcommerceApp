const baseUrl = 'https://localhost:7122/api/cuppons';

export async function applyCuppon(cupponId, userId) {
    const request = await fetch(`${baseUrl}/Apply`, {
        credentials: 'include',
        method: 'POST',
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({cupponId, userId})
    })

    if (!request.ok) {
        throw Error(request.Error);
    }
    const response = await request.json();

    return response;
}