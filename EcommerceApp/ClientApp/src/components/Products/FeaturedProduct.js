import { useState } from "react";
import FeaturedProductStyle from "../Products/FeaturedProductStyle.css";

export default function FeaturedProduct({ product }) {

    const stars = Array.from({ length: product.starRating }, (star, index) => (
        <i key={index} className="fa-solid fa-star star"></i>
    ));

    const [imgUrl, setImgUrl] = useState(product.pictures[0].imgUrl);

    function activateProductCard(event) {
        setImgUrl(product.pictures[1].imgUrl);
        event.currentTarget.classList.add('active-product-card');
    }
    function deactivateProductCard() {
        setImgUrl(product.pictures[0].imgUrl);
    }

    return (
        <div className="product-card">
            <div onMouseOver={activateProductCard} onMouseOut={deactivateProductCard} className="img-container">
                <i className="fa-regular fa-heart favorite"></i>
                <img src={imgUrl} />
            </div>
            <div className="product-content">
                <div className="star-rating">{stars}</div>
                <h2 className = "name">{product.name }</h2>
                <p className = "price">${product.price.toFixed("2") }</p>
            </div>
        </div>
       )
}