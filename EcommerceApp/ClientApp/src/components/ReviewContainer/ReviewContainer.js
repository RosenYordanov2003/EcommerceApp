import { useState, useContext } from "react";
import { UserContext } from '../../Contexts/UserContext';
import { postReview } from "../../services/reviewService";
import Notification from "../Notification/Notification";
import Input from "../Auth/Input/Input";
import { reviewSubjectInput ,reviewContent } from "../../utilities/inputValidations";
import { FormProvider, useForm } from 'react-hook-form'

export default function ReviewContainer({ id, category, product, updateProduct }) {

    const { user } = useContext(UserContext);
    const [starIndex, setStarIndex] = useState(-1);
    const [inputObject, setInputObject] = useState({ name: undefined, summary: undefined, review: undefined });
    const [notification, setNotification] = useState(undefined);

    const methods = useForm();

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

    const handleOnSubmit = methods.handleSubmit(data => {
        const reviewObject = {
            ...data,
            username: user?.username,
            productId: id,
            productCategory: category,
            userId: user?.id,
            starRating: starIndex + 1,
        };
        const element = document.querySelector('.productinfo-card-container');
        postReview(reviewObject)
            .then(res => {
                setInputObject({ name: undefined, summary: undefined, review: undefined });
                updateProduct(res.updatedProduct);
                setStarIndex(-1);
                setNotification(<Notification closeNotification={closeNotification} message="You have successfully post a review" typeOfMessage="Success" />);
                element.scrollIntoView({ behavior: 'smooth' });
            })
            .catch(() => {
                setNotification(<Notification closeNotification={closeNotification} message="Your review is invalid, please try again" typeOfMessage="Error" />)
                element.scrollIntoView({ behavior: 'smooth' });
            });

        function closeNotification() {
            setNotification(undefined);
        }

    })

    return (
        <>
            {notification}
            <h2 className="review-title">Customor Reviews</h2>
            <div className="evaluation-container">
                <p className="product-evaluation">{Number.parseFloat(product.averageRating).toFixed(2)}</p>
                <div className="divider">/</div>
                <p className="reviews-count">{product.totalReviewsCount} Reviews</p>
            </div>
            <div className="write-review-wrapper">
                <button className="review-button">Write Review</button>
            </div>
            <h2 className="write-title">Write Review</h2>
            <div className="write-review-star-container">
                <p>Your evaluation</p>
                <div>{stars}</div>
            </div>
            <FormProvider {...methods}>
                <form onSubmit={(e) => e.preventDefault()} className="review-form">
                    <div className="input-container">
                        <label htmlFor="name">Name</label>
                        <input readOnly value={user?.username} name="name" id="name"></input>
                    </div>
                    <Input {...reviewSubjectInput}/>
                    <Input {...reviewContent}/>
                    <button onClick={handleOnSubmit} className="submit-review-button">Submit Review</button>
                </form>
            </FormProvider>
           
        </>
    )
}