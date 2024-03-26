import { useEffect } from 'react';
import {clearExpiredPromotions} from "../../services/promotionService";

export default function ClearExpiredPromotions() {
    useEffect(() => {
        const checkForExpiredPromtionsInterval = setInterval(() => {
            clearExpiredPromotions();
        }, 14 * 60 * 1000 + 50 * 1000);

        return () => clearInterval(checkForExpiredPromtionsInterval);
    }, []);
}