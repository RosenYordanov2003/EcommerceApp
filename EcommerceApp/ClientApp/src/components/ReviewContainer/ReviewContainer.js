import { useState, useContext } from "react";
import { UserContext } from '../../Contexts/UserContext';
import { postReview } from "../../services/reviewService";
import Notification from "../Notification/Notification";

export default function ReviewContainer({ id, category, product, updateProduct }) {

    const { user, setUser } = useContext(UserContext);
    const [starIndex, setStarIndex] = useState(-1);
    const [inputObject, setInputObject] = useState({ name: undefined, summary: undefined, review: undefined });
    const [notification, setNotification] = useState(undefined);

    function handleOnStarClick(idnex) {
        setStarIndex(idnex);
    }

    const stars = Array.from({ length: 5 }, (star, index) => {
        if (index > starIndex) {
            return <i onClick={() => handleOnStarClick(index)} key={index} className="fa-regular fa-star star"></i>
        }
        else {
            return <i onClick={() => handleOnStarClick(index)} key={index} className="fa-solid fa-star star"></i>
        }
    })
    function handleSubmitReviewPost(event) {
        event.preventDefault();
        const reviewObject = {
            content: inputObject.review,
            summary: inputObject.summary,
            username: inputObject.name,
            productId: id,
            productCategory: category,
            userId: user?.id,
            starRating: starIndex + 1
        };


        postReview(reviewObject)
            .then(res => {
                setInputObject({ name: undefined, summary: undefined, review: undefined });
                updateProduct(res.updatedProduct);
                setStarIndex(-1);
                setNotification(<Notification message="You have successfully post a review" typeOfMessage="Success" />);

            })
            .catch((error) => {
                setNotification(<Notification message="Your review is invalid, please try again" typeOfMessage="Error" />)
            });

        setTimeout(() => {
            setNotification(undefined);
        }, 8000)

    }

    function handleOnNameChange(event) {
        setInputObject({ ...inputObject, name: event.target.value });
    }
    function handleOnSummaryChange(event) {
        setInputObject({ ...inputObject, summary: event.target.value });
    }
    function handleOnReviewChange(event) {
        setInputObject({ ...inputObject, review: event.target.value });
    }

    return (
        <>
           
            {notification}
            <h2 className="review-title">Customor Reviews</h2>
            <div className="evaluation-container">
                <p className="product-evaluation">{Number.parseFloat(product.averageRating).toFixed(2)}</p>
                <div className="divider">/</div>
                <p className="reviews-count">{product.totalReviewsCount} Reviews</p>
            </div>
            <button className="review-button">Write Review</button>
            <h2 className="write-title">Write Review</h2>
            <div className="write-review-star-container">
                <p>Your evaluation</p>
                <div>{stars}</div>
            </div>
            <form onSubmit={handleSubmitReviewPost} className="review-form">
                <div className="input-container">
                    <label htmlFor="name">Name</label>
                    <input onChange={handleOnNameChange} value={inputObject.name == undefined ? "" : inputObject.name} name="name" id="name"></input>
                </div>
                <div className="input-container">
                    <label htmlFor="summary">Summary</label>
                    <input onChange={handleOnSummaryChange} value={inputObject.summary == undefined ? "" : inputObject.summary} name="summary" id="summary"></input>
                </div>
                <div className="input-container">
                    <label htmlFor="review">Review</label>
                    <textarea onChange={handleOnReviewChange} value={inputObject.review == undefined ? "" : inputObject.review} name="review" rows={10} cols={60} id="review"></textarea>
                </div>
                <button className="submit-review-button">Submit Review</button>
            </form>
        </>
    )
}