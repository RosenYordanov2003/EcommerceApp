import { useEffect } from 'react';
import { refreshToken } from "../../../services/authService";

export default function RefreshToken() {
    useEffect(() => {
        const refreshTokenInterval = setInterval(() => {
            refreshToken();
        }, 14 * 60 * 1000 + 50 * 1000);

        return () => clearInterval(refreshTokenInterval);
    }, []);
}