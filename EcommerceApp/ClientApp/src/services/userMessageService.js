const baseUrl = "https://localhost:7122/api/userMessage/";

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