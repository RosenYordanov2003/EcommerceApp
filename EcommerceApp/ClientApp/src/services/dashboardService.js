const baseUrl = "https://localhost:7122/api/dashboard"

export async function loadDashboard(particularDate, month) {
    const request = await fetch(`${baseUrl}/Dashboard?particularDay=${particularDate}&&particularMonth=${month}`, { credentials: "include" });

    if (!request.ok) {
        throw Error(request.Error);
    }
    const response = request.json();

    return response;
}