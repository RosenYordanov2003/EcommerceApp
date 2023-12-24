import { useNavigate } from "react-router-dom";

export default function UserFavoriteProducts({ product }) {

    const navigate = useNavigate();

    function handleProductClick() {
        navigate(`/ProductAbout/${product.productId}/${product.categoryName}`);
    }

    return (
        <article onClick={handleProductClick} className="product-favorite-card">
            <div className="favorite-product-img-container">
                <img src={product.imgUrl}/>
            </div>
            <div className="favorite-product-info">
                <h3 className="product-title">{product.productName}</h3>
            </div>
            <i class="fa-solid fa-xmark remove-mark"></i>
        </article>
    )
}