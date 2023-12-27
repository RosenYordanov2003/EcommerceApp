import { useState, useContext } from "react";
import { useNavigate } from "react-router-dom";
import FeaturedProductStyle from "../Products/FeaturedProductStyle.css";
import { UserContext } from "../../Contexts/UserContext";
import { addProductToUserFavoriteProductsList, removeProductFromUserFavoriteList } from "../../services/productService";

export default function FeaturedProduct({ product }) {

    const navigate = useNavigate();

    const { user, setUser } = useContext(UserContext);

    const stars = Array.from({ length: product.starRating }, (star, index) => (
        <i key={index} className="fa-solid fa-star star"></i>
    ));

    const [isFavorite, setIsFavorite] = useState(product.isFavorite);

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
    function handleProductClick() {
        if (product) {
            navigate(`/ProductAbout/${product.id}/${product.categoryName}`);
        }
    }

    console.log(product);

    function handleUserFavoriteProduct() {
        const favoriteResult = !isFavorite;

        if (favoriteResult) {
            addProductToUserFavoriteProductsList(user.id, product.id, product.categoryName)
                .then(res => {

                    const productObject = {
                        productName: product.name,
                        productId: product.id,
                        imgUrl: product.pictures[0].imgUrl,
                        categoryName: product.categoryName
                    }

                    setUser({ ...user, userFavoriteProducts: [...user.userFavoriteProducts, productObject] })
                })
                .catch((error) => console.error(error));
        }
        else {
            removeProductFromUserFavoriteList(user.id, product.id, product.categoryName)
                .then(res => {
                    const products = user.userFavoriteProducts.map((product) => {
                        if (product.productId != product.id) {
                            return product;
                        }
                        else {
                            if (product.categoryName !== product.categoryName) {
                                return product;
                            }
                        }
                    });
                    const filteredProducts = products.filter((product) => product !== undefined);
                    console.log(filteredProducts);
                    setUser({ ...user, userFavoriteProducts: filteredProducts })

                })
                .catch((error) => console.error(error));
        }
        setIsFavorite(favoriteResult);
    }

    const heartClass = !isFavorite ? "fa-regular fa-heart favorite-heart heart" : "fa - solid fa-heart active-heart heart"

    return (
        <div className="product-card">
            <div onMouseOver={activateProductCard} onMouseLeave={deactivateProductCard} className="img-container">
                <i onClick={handleUserFavoriteProduct} className={heartClass}></i>
                <img onClick={handleProductClick} src={imgUrl} />
            </div>
            <div className="product-content">
                <div className="star-rating">{stars}</div>
                <h2 className = "name">{product.name }</h2>
                <p className = "price">${product.price.toFixed("2") }</p>
            </div>
        </div>
    )
}