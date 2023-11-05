import { useState } from "react";
import FeaturedProductStyle from "../Products/FeaturedProductStyle.css";

export default function FeaturedProduct({ product }) {

    const stars = Array.from({ length: product.starRating }, (star, index) => (
        <i key={index} className="fa-solid fa-star star"></i>
    ));

    const [imgUrl, setImgUrl] = useState(product.pictures[0].imgUrl);

    function activateProductCard(event) {
        setTimeout(() => {
            setImgUrl(product.pictures[1].imgUrl);
        },500)
        event.currentTarget.children[0].classList.remove('favorite-removed');
        event.currentTarget.children[0].classList.add('favorite');
    }
    function deactivateProductCard(event) {
        setTimeout(() => {
            setImgUrl(product.pictures[0].imgUrl);
        }, 500)
        event.currentTarget.children[0].classList.add('favorite-removed');
        event.currentTarget.children[0].classList.remove('favorite');
    }

    return (
        <div className="product-card">
            <div onMouseOver={activateProductCard} onMouseLeave={deactivateProductCard} className="img-container">
                <i className="fa-regular fa-heart"></i>
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