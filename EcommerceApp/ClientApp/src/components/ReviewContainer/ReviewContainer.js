import { useState, useContext } from "react";
import { UserContext } from '../../Contexts/UserContext';
import { postReview } from "../../services/reviewService";

export default function ReviewContainer({id, category }) {
    const { user, setUser } = useContext(UserContext);
    const [starIndex, setStarIndex] = useState(-1);

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
    console.log(user);
    function handleSubmitReviewPost(event) {
        event.preventDefault();
        const formData = new FormData(event.target);
        console.log(user.id);
        const reviewObject = {
            content: formData.get("review"),
            summary: formData.get("summary"),
            username: formData.get("name"),
            productId: id,
            productCategory: category,
            userId: user?.id,
            starRating: starIndex + 1
        };

        postReview(reviewObject)
            .then(res => {
                console.log(res);
            })
            .catch((error) => console.error(error));
    }

    return (
        <>
            <h2 className="review-title">Customor Reviews</h2>
            <div className="evaluation-container">
                <p className="product-evaluation">4.9</p>
                <div className="divider">/</div>
                <p className="reviews-count">2221 Reviews</p>
            </div>
            <button className="review-button">Write Review</button>
            <h2 className="write-title">Write Review</h2>
            <div className="write-review-star-container">
                <p>Your evaluation</p>
                <div>{stars }</div>
            </div>
            <form onSubmit={handleSubmitReviewPost} className= "review-form">
                <div className="input-container">
                    <label htmlFor="name">Name</label>
                    <input name="name" id = "name"></input>
                </div>
                <div className="input-container">
                    <label htmlFor="summary">Summary</label>
                    <input name="summary" id="summary"></input>
                </div>
                <div className="input-container">
                    <label htmlFor="review">Review</label>
                    <textarea name="review" rows={10} cols={60} id="review"></textarea>
                </div>
                <button className= "submit-review-button">Submit Review</button>
            </form>
        </>
    )
}