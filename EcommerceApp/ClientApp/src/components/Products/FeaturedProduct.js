import { useState, useContext, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import "../Products/FeaturedProductStyle.css";
import { UserContext } from "../../Contexts/UserContext";
import { addProductToUserFavoriteProductsList, removeProductFromUserFavoriteList, createProductObject, filterUserFavoriteProducts } from "../../services/productService";

export default function FeaturedProduct({ product }) {

    const navigate = useNavigate();


    const { user, setUser } = useContext(UserContext);

    const stars = Array.from({ length: product.starRating }, (star, index) => (
        <i key={index} className="fa-solid fa-star star"></i>
    ));

    useEffect(() => {
        setIsFavorite(product.isFavorite);
    }, [product.isFavorite])

    const [isFavorite, setIsFavorite] = useState(product.isFavorite);

    const [imgUrl, setImgUrl] = useState(product.pictures[0].imgUrl);

    function activateProductCard(event) {
        setTimeout(() => {
            setImgUrl(product.pictures[1].imgUrl);
        }, 500)
        if (user?.id == undefined) {
            return;
        }
        event.currentTarget.children[0].classList.remove('favorite-removed');
        event.currentTarget.children[0].classList.add('favorite');
    }
    function deactivateProductCard(event) {
       
        setTimeout(() => {
            setImgUrl(product.pictures[0].imgUrl);
        }, 500)
        if (user?.id == undefined) {
            return;
        }
        event.currentTarget.children[0].classList.add('favorite-removed');
        event.currentTarget.children[0].classList.remove('favorite');
    }
    function handleProductClick() {
        if (product) {
            navigate(`/ProductAbout/${product.id}/${product.categoryName}`);
        }
    }

    function handleUserFavoriteProduct() {
        const favoriteResult = !isFavorite;
        if (favoriteResult) {
            addProductToUserFavoriteProductsList(user.id, product.id, product.categoryName)
                .then(() => {
                    const productInstance = createProductObject(product.name, product.id, product.pictures[0].imgUrl, product.categoryName);
                    setUser({ ...user, userFavoriteProducts: [...user.userFavoriteProducts, productInstance] })
                })
                .catch((error) => console.error(error));
        }
        else {
            removeProductFromUserFavoriteList(user.id, product.id, product.categoryName)
                .then(() => {
                    const filteredProducts = filterUserFavoriteProducts(user.userFavoriteProducts, product.id, product.categoryName);
                    setUser({ ...user, userFavoriteProducts: filteredProducts })

                })
                .catch((error) => console.error(error));
        }
        setIsFavorite(favoriteResult);
    }
    const heartClass = !isFavorite ? "fa-regular fa-heart favorite-heart heart" : "fa-solid fa-heart active-heart favorite heart"

    return (
        <div className="featured-product-card">
            <div onMouseOver={activateProductCard} onMouseLeave={deactivateProductCard} className="img-container">
                {user?.id != undefined && <i onClick={handleUserFavoriteProduct} className={heartClass}></i>}
                <img onClick={handleProductClick} src={imgUrl} />
            </div>
            <div className="product-content">
                <div className="star-rating">{stars}</div>
                <h2 className="name">{product.name}</h2>
                {product.dicountPercentage !== 0 ?
                 <section className="price-with-promotion-container">
                    <del><p className="price">${product.price.toFixed(2)}</p></del>
                    <p className="price-with-discount">${(product.price - (product.price * product.dicountPercentage) / 100).toFixed(2)}</p>
                </section>
                    :
                <p className="price">${product.price.toFixed("2")}</p>
                }
            </div>
        </div>
    )
}