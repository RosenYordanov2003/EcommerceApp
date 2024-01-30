import { useState, useEffect, useContext } from "react";
import { getReviewToEdit, editReview } from "../../services/reviewService";
import { UserContext } from "../../Contexts/UserContext";
import EditReviewStyle from "../EditReviewForm/EditReviewStyle.css";
import Notification from "../Notification/Notification";
import EditReviewResponsiveStyle from "../EditReviewForm/EditReviewResponsiveStyle.css";

export default function EditReview() {

    const urlPath = window.location.pathname.split('/');
    const reviewId = urlPath[urlPath.length - 1];

    const [formObject, setFormObject] = useState({});
    const { user, setUser } = useContext(UserContext);
    const [notification, setNotification] = useState(undefined);

    useEffect(() => {
        if (user?.id) {
            getReviewToEdit(reviewId, user.id)
                .then(res => {
                    setFormObject({ content: res.content, starEvaluation: res.starEvaluation, id: res.id });
                })
                .catch((error) => console.error(error));
        }
    }, [user?.id])


    let stars = Array.from({ length: 5 }, (star, index) => {
        if (index + 1 <= formObject?.starEvaluation) {
            return <i onClick={() => setFormObject({ ...formObject, starEvaluation: index + 1 })} key={index} className="fa-solid fa-star star"></i>
        }
        else {
            return <i onClick={() => setFormObject({ ...formObject, starEvaluation: index + 1 })} key={index} className="fa-regular fa-star star"></i>
        }
    })

    function handleContentChange(event) {
        setFormObject({ ...formObject, content: event.target.value });
    }
    function clearStarResult(event) {
        event.preventDefault();
        setFormObject({ ...formObject, starEvaluation: 0 });
    }
    function handleEditReviewSubmit(event) {

        event.preventDefault();
        editReview(formObject)
            .then(() => setNotification(<Notification closeNotification={closeNotification} message="You have successfully edited your review" typeOfMessage="Success" />))
            .catch(() => setNotification(<Notification closeNotification={closeNotification} message="Invalid review-content length" typeOfMessage="Error" />));

        function closeNotification() {
            setNotification(undefined);
        }
    }

    return (
        <form onSubmit={handleEditReviewSubmit} className="review-form edit-form">
            {notification }
            <div className="write-review-star-container">
                <p>Your evaluation</p>
                <div>{stars}</div>
                <button onClick={clearStarResult} className="clear-stars-button">Clear Stars</button>
            </div>
            <div className="input-container">
                <label htmlFor="review">Review</label>
                <textarea onChange={handleContentChange} value={formObject.content} name="review" rows={10} cols={60} id="review"></textarea>
            </div>
            <button type="submit" className="edit-review-button">Edit Review</button>
        </form>
    )
}