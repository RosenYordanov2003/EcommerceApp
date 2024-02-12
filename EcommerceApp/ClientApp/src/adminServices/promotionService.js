const baseUrl = "https://localhost:7122/api/promotion";

export async function removePromotion(promotionId) {
    const request = await fetch(`${baseUrl}/RemovePromotion`, {
        method: 'DELETE',
        credentials: 'include',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(promotionId)
    });

    if (!request.ok) {
        throw new Error(request.Error);
    }

    return request.ok;
}
export async function addPromotion(promotionObject) {
    const request = await fetch(`${baseUrl}/AddPromotion`,
        {
            credentials: 'include',
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(promotionObject)
        }
    )

    if (!request.ok) {
        throw new Error(request.Error);
    }
    return request.ok;
}