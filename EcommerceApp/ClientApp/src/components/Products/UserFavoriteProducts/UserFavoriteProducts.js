import { useContext } from "react";
import { useNavigate } from "react-router-dom";
import { removeProductFromUserFavoriteList, filterUserFavoriteProducts } from "../../../services/productService";
import { UserContext } from "../../../Contexts/UserContext";


export default function UserFavoriteProducts({ product }) {

    const { user, setUser } = useContext(UserContext);
    const navigate = useNavigate();

    function handleProductClick() {
        navigate(`/ProductAbout/${product.productId}/${product.categoryName}`);
    }
    function handleRemoveProductFromUserFavorite() {
        removeProductFromUserFavoriteList(user.id, product.productId, product.categoryName)
            .then(() => {
                const filteredProducts = filterUserFavoriteProducts(user.userFavoriteProducts, product.productId, product.categoryName);
                setUser({ ...user, userFavoriteProducts: filteredProducts })

            })
         .catch((error) => console.error(error));
    }

    return (
        <article className="product-favorite-card">
            <div onClick={handleProductClick} className="favorite-product-img-container">
                <img src={product.imgUrl}/>
            </div>
            <div onClick={handleProductClick} className="favorite-product-info">
                <h3 className="product-title">{product.productName}</h3>
            </div>
            <i onClick={handleRemoveProductFromUserFavorite} class="fa-solid fa-xmark remove-mark"></i>
        </article>
    )
}