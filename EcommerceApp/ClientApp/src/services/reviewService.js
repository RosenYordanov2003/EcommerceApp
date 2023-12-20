const baseUrl = "https://localhost:7122/api/reviews";

export async function postReview(reviewObject) {
    const request = await fetch(`${baseUrl}/PostReview`, {
        method: 'POST',
        credentials: 'include',
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(reviewObject),
    });

    if (!request.ok) {
        throw Error(request.ok);
    }
    const response = request.json();

    return response;
}