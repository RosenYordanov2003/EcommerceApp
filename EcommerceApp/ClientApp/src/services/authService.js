const baseUrl = "https://localhost:7122/api/account/";

export async function register(userInfo) {
    const request = await fetch(`${baseUrl}register`, {
        method: 'POST',
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(userInfo)
    })

     if (!request.ok) {
         throw new Error(`HTTP error! Status: ${request.status}`);
     }

    const response = await request.json();

    return response;
} 
export async function login(userInfo) {
    const request = await fetch(`${baseUrl}login`,
        {
            method: 'POST',
            credentials: 'include',
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(userInfo)
        }
    )
    if (!request.ok) {
        throw new Error(`HTTP error! Status: ${request.status}`);
    }
    const response = await request.json();

    return response;
}
export async function refreshToken() {

    const request = await fetch(`${baseUrl}RefreshToken`, { credentials: 'include' })

    const response = await request;

    return response;
}