const baseUrl = "https://localhost:7122/api/dashboard"

export async function loadDashboard(particularDate) {
    const request = await fetch(`${baseUrl}/Dashboard?particularDay=${particularDate}`, { credentials: "include" });

    if (!request.ok) {
        throw Error(request.Error);
    }
    const response = request.json();

    return response;
}