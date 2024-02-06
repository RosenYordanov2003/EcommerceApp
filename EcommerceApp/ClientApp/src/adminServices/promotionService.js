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