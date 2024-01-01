import ReviewCardStyle from "../ReviewCard/ReviewCardStyle.css";
import { useContext } from "react";
import { UserContext } from "../../Contexts/UserContext";
import { getReviewToEdit } from "../../services/reviewService";
import { useNavigate } from "react-router-dom";
export default function ReviewCard({ review }) {

    const navigate = useNavigate();
    const { user, setUser } = useContext(UserContext);

    const stars = Array.from({ length: 5 }, (star, index) => {
        if (index + 1 <= review.starEvaluation) {
            return <i key={index} className="fa-solid fa-star star"></i>
        }
        else {
            return <i key={index} className="fa-regular fa-star star"></i>
        }
    })

    const reviewDate = new Date(review.createdOn);
    const currentDate = new Date(Date.now());

    const currentDateYear = currentDate.getDay();

    const reviewDateYear = reviewDate.getDay();

    const result = currentDateYear - reviewDateYear;

    let modifySectionResult = user?.id == review.userId ?
        <section className="modifyReviewSection">
            <button onClick={handleEditReviewAction} className="edit-button">Edit</button>
            <button className="delete-button">Delete</button>
        </section>
        : "";

    function handleEditReviewAction() {
        navigate(`/Review/${review.id}`);
    }

    return (
        <div className="review-card">
            <div className="review-user">
                <h5 className="review-username">{review.username}</h5>
                <div className="review-evaluation">
                    <section className="star-section">
                        {stars}
                    </section>
                    <p className="evaluation">{Number.parseFloat(review.starEvaluation).toFixed(2)}</p>
                    <p>{review.createdOn}</p>
                </div>
            </div>
            <section className="review-content">
                <p>{review.content}</p>
            </section>
            {modifySectionResult}
        </div>
    )
}