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