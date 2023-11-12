const baseUrl = "https://localhost:7122/api/account/register";

export async function register(userInfo) {
    console.log(userInfo);
    const request = await fetch(baseUrl, {
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