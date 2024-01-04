import { useState, useContext } from "react";
import ReviewContainer from "../../ReviewContainer/ReviewContainer";
import { UserContext, userContext } from "../../../Contexts/UserContext";
import { useNavigate } from "react-router-dom";

export default function ProductDetails({ product, id, category, updateProduct }) {

    const { user, setUser } = useContext(UserContext);
    const [informationVisibility, setInformationVisibility] = useState(false);
    const [descriptionVisibility, setDescriptionVisibility] = useState(false);
    const [reviewVisibility, setReviewVisibility] = useState(false);

    const navigate = useNavigate();

    let informationClassName = informationVisibility ? "active-information" : "product-about";
    let descriptionClassName = descriptionVisibility ? "active-description" : "product-about";
    let reviewClassName = reviewVisibility ? "active-review" : "product-about"; 

    function handleAllReviewsClick() {
        navigate(`/AllReviews/${id}/${category}`);
    }

    return (
        <>
            <div className="product-information">
                <div className="product-section-header">
                    <i onClick={() => { setInformationVisibility(!informationVisibility); } } className={`fa-solid ${informationVisibility == true ? "fa-minus" : "fa-plus"}`}></i>
                    <p>Information</p>
                </div>
                <div className={`${informationClassName}`}>
                    <h3 className="product-about-title">Brand</h3>
                    <p className="product-about-content">{product?.brand}</p>
                </div>
                <div className={`${informationClassName}`} >
                    <h3 className="product-about-title">Category</h3>
                    <p className="product-about-content">{product?.categoryName}</p>
                </div>
            </div>
            <hr></hr>
            <div className="product-information">
                <div className="product-section-header">
                    <i onClick={() => setDescriptionVisibility(!descriptionVisibility)} className={`fa-solid ${descriptionVisibility == true ? "fa-minus" : "fa-plus"}`}></i>
                    <p>Description</p>
                </div>
                <div className={`${descriptionClassName}`}>
                    <p className= "product-description">{product.description }</p>
                </div>
            </div>
            <hr></hr>
            <div className="product-reviews">
                <div className="product-section-header">
                    <i onClick={() => setReviewVisibility(!reviewVisibility)} className={`fa-solid ${reviewVisibility == true ? "fa-minus" : "fa-plus"}`}></i>
                    <p>Reviews</p>
                </div>
                <div className={reviewClassName}>
                    {user?.id && <ReviewContainer updateProduct={updateProduct} product={product} id={id} category={category} />}
                </div>
            </div>
            <button onClick={handleAllReviewsClick} className="all-reviews-button">View All Reviews</button>
        </>
    )
}