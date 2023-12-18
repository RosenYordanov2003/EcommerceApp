import { useState } from "react";

export default function ProductDetails({ product }) {

    const [informationVisibility, setInformationVisibility] = useState(false);
    const [descriptionVisibility, setDescriptionVisibility] = useState(false);

    let informationClassName = informationVisibility ? "active-information" : "product-about";
    let descriptionClassName = descriptionVisibility ? "active-description" : "product-about";
    return (
        <>
            <div className="product-information">
                <div className="product-section-header">
                    <i onClick={() => { setInformationVisibility(!informationVisibility); } } className="fa-solid fa-plus"></i>
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
                    <i onClick={() => setDescriptionVisibility(!descriptionVisibility)} className="fa-solid fa-plus"></i>
                    <p>Description</p>
                </div>
                <div className={`${descriptionClassName}`}>
                    <p className= "product-description">{product.description }</p>
                </div>
            </div>
        </>
    )
}