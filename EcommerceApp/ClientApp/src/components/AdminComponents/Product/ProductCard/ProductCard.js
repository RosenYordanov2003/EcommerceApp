import { useNavigate } from "react-router-dom";

export default function ProductCard({ product }) {

    const navigate = useNavigate();

    const category = window.location.pathname.split('/')[1];

    const stars = Array.from({ length: product.starRating }, (star, index) => (
        <i key={index} className="fa-solid fa-star star"></i>
    ));

    return (
        <div onClick={() => navigate(`/Product/${product.id}/${category}`)} className="featured-product-card">
            <div className="img-container">
                <img src={product?.imgUrls[0]?.imgUrl} />
            </div>
            <div className="product-content">
                <div className="star-rating">{stars}</div>
                <h2 className="name">{product.name}</h2>
                <p className="price">${product.price.toFixed("2")}</p>
            </div>
        </div>
    )
}