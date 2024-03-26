const baseUrl = "https://localhost:7122/api/promotion";

export async function clearExpiredPromotions() {
    const request = await fetch(`${baseUrl}/Clear`, { credentials: 'include', method: 'POST' });

    return request.ok;
}