import { useState } from "react";
import ReviewContainer from "../../ReviewContainer/ReviewContainer";

export default function ProductDetails({ product, id, category, updateProduct }) {

    const [informationVisibility, setInformationVisibility] = useState(false);
    const [descriptionVisibility, setDescriptionVisibility] = useState(false);
    const [reviewVisibility, setReviewVisibility] = useState(false);

    let informationClassName = informationVisibility ? "active-information" : "product-about";
    let descriptionClassName = descriptionVisibility ? "active-description" : "product-about";
    let reviewClassName = reviewVisibility ? "active-review" : "product-about"; 


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
                    <ReviewContainer updateProduct={updateProduct} product={product} id={id} category={category}/>
                </div>
            </div>
        </>
    )
}