import { useEffect, useState } from "react";
import { loadAllReviewsAboutProduct } from "../../services/reviewService";
import { getReviewsForParticularPage } from "../../services/reviewService";
import ReviewCard from "../../components/ReviewCard/ReviewCard";
import "../AllReviews/AllReviewsStyle.css";
import "../AllReviews/AllReviewsResponsiveStyle.css";
import Notification from "../Notification/Notification";
import Pager from "../Pager/Pager";
import { Grid } from 'react-loader-spinner';

export default function AllReviews() {

    const [reviewsPerPage, setReviewsPerPage] = useState(5);
    const [pageNumber, setPageNumber] = useState(1);
    const [reviews, setReviews] = useState([]);
    const [notification, setNotification] = useState(undefined);
    const [isLoading, setIsLoading] = useState(false);
    const [pageObject, setPageObject] = useState(undefined);

    const pathArray = window.location.pathname.split('/');
    const productId = pathArray[2];
    const productCategory = pathArray[3];

    useEffect(() => {
        loadAllReviewsAboutProduct(productId, productCategory)
            .then(res => {
                setReviews(res.reviews);
                setPageObject({ startPage: res.startPage, endPage: res.endPage });
            })
            .catch((error) => console.error(error));
    }, [])

    useEffect(() => {
        getReviewsForParticularPage(pageNumber, productCategory, productId, reviewsPerPage == 0 ? 5 : reviewsPerPage)
            .then(res => {
                setReviews(res.reviews);
                setPageObject({ startPage: res.startPage, endPage: res.endPage });
            })
            .catch(error => console.error(error));

        configureLoading();
    }, [pageNumber, reviewsPerPage])

    function removeReviewById(reviewId) {
        const filteredReviews = reviews.filter((review) => review.id !== reviewId);
        setReviews(filteredReviews);
        setNotification(<Notification closeNotification={closeNotification} message="You have successfully deleted your review" typeOfMessage="Success" />);
    }
    function closeNotification() {
        setNotification(undefined);
    }

    function pageNumberChange(newPageNumber) {
        setPageNumber(newPageNumber);
    }
    function handlePagneItemsNumberChange(event) {
        const value = event.target.options[event.target.selectedIndex].value;
        setReviewsPerPage(value);
        setPageNumber(1);
    }
    function configureLoading() {
        setIsLoading(true);

        setTimeout(() => {
            setIsLoading(false);
        }, 500)
    }

    const reviewsResult = reviews?.map((review) => <ReviewCard review={review} key={review.id} removeReviewById={removeReviewById} />)

    const result = reviews?.length > 0 ? reviewsResult : <p className="no-reviews">This product has no reviews yet</p>


    return (
        <>
            {isLoading == true ? <Grid
                height="80"
                width="80"
                color="#035096"
                ariaLabel="grid-loading"
                radius="12.5"
                wrapperStyle={{}}
                wrapperClass="spinner"
                className="spinner-loading"
                visible={true} /> :

                <>
                    {reviews.length > 0 && <section className="comments-per-page">
                        <h4>Choose reviews number per page</h4>
                        <select value={reviewsPerPage} onChange={handlePagneItemsNumberChange}>
                            <option value={8}>8</option>
                            <option value={10}>10</option>
                            <option value={20}>20</option>
                            <option value={5}>Default</option>
                        </select>
                    </section>}
                    <div className="all-review-container">
                        {notification}
                        {result}
                    </div>
                    {reviews.length > 0 && <Pager onPageNumberChange={pageNumberChange} startPage={pageObject?.startPage} endPage={pageObject?.endPage} currentPage={pageNumber } />}
                </>
            }
        </>
    )
}