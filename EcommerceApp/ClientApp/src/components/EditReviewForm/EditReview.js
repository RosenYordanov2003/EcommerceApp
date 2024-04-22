import { useState, useEffect, useContext } from "react";
import { getReviewToEdit, editReview } from "../../services/reviewService";
import { UserContext } from "../../Contexts/UserContext";
import "../EditReviewForm/EditReviewStyle.css";
import Notification from "../Notification/Notification";
import "../EditReviewForm/EditReviewResponsiveStyle.css";
import Input from "../Auth/Input/Input";
import { FormProvider, useForm } from 'react-hook-form'
import { reviewContent, reviewSubjectInput} from "../../utilities/inputValidations";

export default function EditReview() {

    const urlPath = window.location.pathname.split('/');
    const reviewId = urlPath[urlPath.length - 1];

    const [review, setReview] = useState(undefined);
    const { user } = useContext(UserContext);
    const [starEvaluation, setStarEvaluation] = useState(0);
    const [notification, setNotification] = useState(undefined);
    const methods = useForm();

    useEffect(() => {
        if (user?.id) {
            getReviewToEdit(reviewId, user.id)
                .then(res => {
                    setReview(res);
                    setStarEvaluation(res.starEvaluation);
                    methods.setValue('subject', res.subject);
                    methods.setValue('content', res.content);
                })
                .catch((error) => console.error(error));
        }
    }, [user?.id])

   

    let stars = Array.from({ length: 5 }, (star, index) => {
        if (index + 1 <= starEvaluation) {
            return <i onClick={() => setStarEvaluation(index + 1)} key={index} className="fa-solid fa-star star"></i>
        }
        else {
            return <i onClick={() => setStarEvaluation(index + 1)} key={index} className="fa-regular fa-star star"></i>
        }
    })

    function clearStarResult(event) {
        event.preventDefault();
        setStarEvaluation(0);
    }
    const handleOnSubmit = methods.handleSubmit(data => {
        const object = {
            ...data,
            starEvaluation,
            id: reviewId
        };
        editReview(object)
            .then(() => setNotification(<Notification closeNotification={closeNotification} message="You have successfully edited your review" typeOfMessage="Success" />))
            .catch(() => setNotification(<Notification closeNotification={closeNotification} message="Invalid review-content length" typeOfMessage="Error" />));
    })
    function closeNotification() {
        setNotification(undefined);
    }

    return (
        <FormProvider {...methods}>
            <form onSubmit={(event) => event.preventDefault} className="review-form edit-form">
                {notification}
                <div className="write-review-star-container">
                    <p>Your evaluation</p>
                    <div>{stars}</div>
                    <button onClick={clearStarResult} className="clear-stars-button">Clear Stars</button>
                </div>
                <Input {...reviewSubjectInput} />
                <Input {...reviewContent}/>
                <button onClick={handleOnSubmit} type="submit" className="edit-review-button">Edit Review</button>
            </form>
        </FormProvider>
       
    )
}