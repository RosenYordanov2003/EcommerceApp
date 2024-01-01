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
        throw Error(request.Error);
    }
    const response = request.json();

    return response;
}
export async function loadAllReviewsAboutProduct(productId, productCategory) {
    const request = await fetch(`${baseUrl}/AllReviews?productId=${productId}&&productCategory=${productCategory}`, {
        credentials: 'include'
    })

    if (!request.ok) {
        throw Error(request.Error);
    }
    const response = request.json();

    return response;
}
export async function getReviewToEdit(reviewId, userId) {
    const request = await fetch(`${baseUrl}/GetReviewToEdit?reviewId=${reviewId}&&userId=${userId}`, { credentials: 'include' });

    if (!request.ok) {
        throw Error(request.Error);
    }
    const response = request.json();

    return response;
}
export async function editReview(reviewObject) {

    const request = await fetch(`${baseUrl}/EditReview`, {
        credentials: 'include',
        method: 'POST',
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(reviewObject),
    })

    if (!request.ok) {
        throw Error(request.Error);
    }
    const response = request.json();

    return response;
}