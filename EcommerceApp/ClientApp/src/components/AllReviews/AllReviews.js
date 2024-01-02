import { useEffect, useState } from "react";
import { loadAllReviewsAboutProduct } from "../../services/reviewService";
import ReviewCard from "../../components/ReviewCard/ReviewCard";
import AllReviewsStyle from "../AllReviews/AllReviewsStyle.css";
import Notification from "../Notification/Notification";

export default function AllReviews() {
    const [reviews, setReviews] = useState([]);
    const [notification, setNotification] = useState(undefined);

    const pathArray = window.location.pathname.split('/');

    const productId = pathArray[2];
    const productCategory = pathArray[3];
    useEffect(() => {
        loadAllReviewsAboutProduct(productId, productCategory)
            .then(res => setReviews(res))
            .catch((error) => console.error(error));

    }, [])

    function removeReviewById(reviewId) {
        const filteredReviews = reviews.filter((review) => review.id !== reviewId);
        setReviews(filteredReviews);
        setNotification(<Notification closeNotification={closeNotification} message="You have successfully deleted your review" typeOfMessage="Success" />);
    }
    function closeNotification() {
        setNotification(undefined);
    }

    const reviewsResult = reviews?.map((review) => <ReviewCard review={review} key={review.id} removeReviewById={removeReviewById } />)

    const result = reviews?.length > 0 ? reviewsResult : <p className="no-reviews">This product has no reviews yet</p>

    return (
        <div className="all-review-container">
            {notification}
            {result}
        </div>
    )
}