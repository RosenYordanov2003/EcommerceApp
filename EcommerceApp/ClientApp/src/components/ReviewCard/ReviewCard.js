import "../ReviewCard/ReviewCardStyle.css";
import { useContext, useState } from "react";
import { useNavigate } from "react-router-dom";
import { UserContext } from "../../Contexts/UserContext";
import { deleteReview } from "../../services/reviewService";
import Notification from "../Notification/Notification";

export default function ReviewCard({ review, removeReviewById }) {

    const navigate = useNavigate();
    const { user } = useContext(UserContext);
    const [notification, setNotification] = useState(undefined);

    const stars = Array.from({ length: 5 }, (star, index) => {
        if (index + 1 <= review.starEvaluation) {
            return <i key={index} className="fa-solid fa-star star"></i>
        }
        else {
            return <i key={index} className="fa-regular fa-star star"></i>
        }
    })


    let modifySectionResult = user?.id == review.userId ?
        <section className="modifyReviewSection">
            <button onClick={handleEditReviewAction} className="edit-button">Edit</button>
            <button onClick={handleDeleteReviewAction} className="delete-button">Delete</button>
        </section>
        : "";

    function handleEditReviewAction() {
        navigate(`/Review/${review.id}`);
    }
    function handleDeleteReviewAction() {
        deleteReview(review.id)
            .then(() => {
                removeReviewById(review.id);
            } )
            .catch(() => setNotification(<Notification typeOfMessage="Error" content="Unexisting review" closeNotification={closeNotification} />) )
    }
    function closeNotification() {
        setNotification(undefined);
    }
    return (
        <>
            {notification}
            <div className="review-card">
                <div className="review-user">
                    <h5 className="review-username">{review.username}</h5>
                    <p className="review-subject">{review.subject}</p>
                    <div className="review-evaluation">
                        <section className="star-section">
                            {stars}
                        </section>
                        <p className="evaluation">{Number.parseFloat(review.starEvaluation).toFixed(2)}</p>
                        <p>{review.timeDifferenceFormat}</p>
                    </div>
                </div>
                <section className="review-content">
                    <p>{review.content}</p>
                </section>
                {modifySectionResult}
            </div>
        </>
      
    )
}