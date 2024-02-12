const baseUrl = "https://localhost:7122/api/picture";

export async function uploadImg(formObject) {
    const request = await fetch(`${baseUrl}/UploadImg`, {
        credentials: 'include',
        method: 'POST',
        body: formObject,
    })

    if (!request.ok) {
        throw new Error(request.Error);
    }

    return request.ok;
}
export async function deleteImg(deleteImgObject) {
    const request = await fetch(`${baseUrl}/DeleteImg`, {
        credentials: 'include',
        method: 'DELETE',
        headers: {
            'Content-Type' : 'application/json'
        },
        body: JSON.stringify(deleteImgObject),
    })

    if (!request.ok) {
        throw new Error(request.Error);
    }

    return request.ok;
}