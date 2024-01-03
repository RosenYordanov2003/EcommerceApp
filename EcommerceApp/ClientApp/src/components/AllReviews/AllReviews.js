import { useEffect, useState } from "react";
import { loadAllReviewsAboutProduct } from "../../services/reviewService";
import ReviewCard from "../../components/ReviewCard/ReviewCard";
import AllReviewsStyle from "../AllReviews/AllReviewsStyle.css";
import Notification from "../Notification/Notification";
import Pager from "../Pager/Pager";
import { Grid } from 'react-loader-spinner';

export default function AllReviews() {

    const [reviewsPerPage, setReviewsPerPage] = useState(5);
    const [pageNumber, setPageNumber] = useState(1);
    const [currentPageReviews, setCurrentPageReviews] = useState([]);
    const [reviews, setReviews] = useState([]);
    const [notification, setNotification] = useState(undefined);
    const [isLoading, setIsLoading] = useState(false);

    const pathArray = window.location.pathname.split('/');
    const productId = pathArray[2];
    const productCategory = pathArray[3];

    useEffect(() => {
        loadAllReviewsAboutProduct(productId, productCategory)
            .then(res => {
                setReviews(res);
                const startIndex = (pageNumber - 1) * reviewsPerPage;
                const endIndex = pageNumber * reviewsPerPage;
                setCurrentPageReviews(res.slice(startIndex, endIndex));
            })
            .catch((error) => console.error(error));
    }, [])

    useEffect(() => {
        const startIndex = (pageNumber - 1) * reviewsPerPage;
        const endIndex = pageNumber * reviewsPerPage;
        configureLoading();
        setCurrentPageReviews(reviews.slice(startIndex, endIndex));

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

    const reviewsResult = currentPageReviews?.map((review) => <ReviewCard review={review} key={review.id} removeReviewById={removeReviewById} />)

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
                    <Pager pageNumberChange={pageNumberChange} totalReviewsLength={reviews.length} currentPage={pageNumber} endPage={Math.ceil(reviews.length / reviewsPerPage)} />
                </>
            }
        </>
    )
}