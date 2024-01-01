import { useEffect, useContext, useState } from "react";
import { UserContext } from "../../Contexts/UserContext";
import { loadAllReviewsAboutProduct } from "../../services/reviewService";
import ReviewCard from "../../components/ReviewCard/ReviewCard";
import AllReviewsStyle from "../AllReviews/AllReviewsStyle.css";

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


    const reviewsResult = reviews?.map((review) => <ReviewCard review={review} key={review.id }/> )

    return (
        <div className="review-container">
        { reviewsResult }
        </div>
    )
}