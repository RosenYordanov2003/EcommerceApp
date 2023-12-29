import { useEffect, useContext, useState } from "react";
import { UserContext } from "../../Contexts/UserContext";
import { loadAllReviewsAboutProduct } from "../../services/reviewService";

export default function AllReviews() {
    const { user, setUser } = useContext(UserContext);
    const [reviews, setReviews] = useState([]);

    const pathArray = window.location.pathname.split('/');

    const productId = pathArray[2];
    const productCategory = pathArray[3];
    useEffect(() => {
        loadAllReviewsAboutProduct(productId, productCategory)
            .then(res => setReviews(res))
            .catch((error) => console.error(error));
      
    }, [])


    return (
        <p>All Reviews</p>
    )
}