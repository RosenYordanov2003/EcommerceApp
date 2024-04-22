import { useEffect, useState, useContext } from "react";
import { loadProductById, addProductToUserFavoriteProductsList, removeProductFromUserFavoriteList, createProductObject, filterUserFavoriteProducts } from "../../services/productService";
import {addShoesToUserFavoriteProducts, removeShoesFromUserFavorite, loadShoesById} from "../../services/shoesService";
import "../Products/ProductInfoStyle.css";
import "../Products/ProductInfoResponsiveStyle.css";
import SizeItem from "../SizeMenu/SizeMenu";
import ProductDetails from "../Products/ProductDetails/ProductDetails";
import { UserContext } from "../../Contexts/UserContext";
import ProductOrderSection from "../Products/ProductOrderSection/ProductOrderSection";
import ProductPromotionPriceSection from "../Products/ProductPromotionPriceSection/ProductPromotionPriceSection";
import RelatedProductsSection from "../Products/RelatedProductsSection/RelatedProductsSection";

export default function ProductInfo() {

    const { user, setUser } = useContext(UserContext);

    const [product, setProduct] = useState({});
    const [activePicture, setActivePictures] = useState(undefined);
    const [indexPicture, setIndexPicture] = useState(0);
    const [count, setCount] = useState(1);
    const [isActiveArrows, setActiveArrows] = useState(false);
    const [activeSizeItem, setActiveSizeItem] = useState(undefined);
    const [isFavorite, setIsFavorite] = useState(undefined);

    const pathArray = window.location.pathname.split('/');
    const id = pathArray[pathArray.length - 2];
    const categoryName = pathArray[pathArray.length - 1];


    useEffect(() => {
        const functionToInvoke = categoryName.toLocaleLowerCase() === "shoes" ? loadShoesById : loadProductById;

        functionToInvoke(id, user?.id)
            .then((res) => {
                setProduct(res);
                setIsFavorite(res.isFavorite);
                setActivePictures(res.pictures[indexPicture]);
                window.scrollTo({ top: 0, behavior: "smooth" })
            })
            .catch((error) => console.error(error));
    }, [id, user?.id, user?.userFavoriteProducts])


    function UpdateProductInfo(productModel) {
        setProduct(productModel);
    }

    function handleSizeItem(index) {
        const activeItem = product.productStocks[index];
        setActiveSizeItem(activeItem);
    }

    let sizeItmes = [];
    if (product.productStocks) {
        sizeItmes = product.productStocks.map((productStock, index) => {
            if (activeSizeItem !== undefined && activeSizeItem.id === productStock.id) {
                return <SizeItem productSize={productStock} index={index} handleSizeItem={handleSizeItem} isActive={true} key={productStock.id} />
            }
            else {
                return <SizeItem productSize={productStock} index={index} handleSizeItem={handleSizeItem} isActive={false} key={productStock.id} />
            }
        });
    }
    const productDetails = <ProductDetails updateProduct={UpdateProductInfo} product={product} id={id} category={categoryName} />



    function handleimgRightArrowClick() {
        if (indexPicture >= product?.pictures?.length - 1) {
            setIndexPicture(0);
            setActivePictures(product.pictures[0]);
        }
        else {
            setIndexPicture(indexPicture + 1);
            setActivePictures(product?.pictures[indexPicture + 1]);
        }
    }
    function handleimgLeftArrowClick() {
        if (indexPicture - 1 <= 0) {
            setIndexPicture(0);
            setActivePictures(product?.pictures[0]);
        }
        else {
            setIndexPicture(indexPicture - 1);
            setActivePictures(product?.pictures[indexPicture - 1]);
        }
    }
    function handleMinusClick() {
        if (count - 1 >= 1) {
            setCount(count - 1);
        }
    }
    function handlePlusClick() {
        if (count + 1 <= 20) {
            setCount(count + 1);
        }
    }

    let className = isActiveArrows ? "active-arrow" : "";

    function handleAddToFavoriteProduct() {

        const favoriteResult = !isFavorite;

        if (favoriteResult) {
            const functionToInvoke = categoryName.toLocaleLowerCase() === "shoes" ? addShoesToUserFavoriteProducts : addProductToUserFavoriteProductsList;
            functionToInvoke(user.id, id)
                .then(() => {
                    const productObject = createProductObject(product.name, id, product.pictures[0].imgUrl, categoryName);

                    setUser({ ...user, userFavoriteProducts: [...user.userFavoriteProducts, productObject] })
                })
                .catch((error) => console.error(error));
        }
        else {
            const functionToInvoke = categoryName.toLocaleLowerCase() === "shoes" ? removeShoesFromUserFavorite : removeProductFromUserFavoriteList;
            functionToInvoke(user.id, id, categoryName)
                .then(() => {
                    const products = filterUserFavoriteProducts(user.userFavoriteProducts, id, categoryName)
                    setUser({ ...user, userFavoriteProducts: products })
                })
                .catch((error) => console.error(error));
        }
        setIsFavorite(favoriteResult);
    }

    let stockObject = {};

    if (activeSizeItem?.id) {
        if (activeSizeItem.quantity > 0) {
            stockObject.content = 'In Stock'
            stockObject.class = 'in-stock'
        }
        else {
            stockObject.content = 'Out Of Stock'
            stockObject.class = 'out-of-stock'
        }
    }
    else {
        if (product.isAvalilable) {
            stockObject.content = 'In Stock'
            stockObject.class = 'in-stock'
        }
        else {
            stockObject.content = 'Out Of Stock'
            stockObject.class = 'out-of-stock'
        }
    }
    return (
        <>
            <div key={id} className="productinfo-card-container">
                <div onMouseOver={() => { setActiveArrows(true) }} onMouseOut={() => { setActiveArrows(false) }} className="productinfo-img-container">
                    <button onClick={handleimgLeftArrowClick} className={`arrow-button left-arrow-button ${className}`}>  <i className="fa-solid fa-chevron-left"></i></button>
                    <img src={activePicture?.imgUrl}></img>
                    <button onClick={handleimgRightArrowClick} className={`arrow-button right-arrow-button ${className}`}> <i className="fa-solid fa-chevron-right"></i></button>
                </div>
                <div  className="productinfo-about-container">
                    <h2 className="product-info-title">{product.name}</h2>
                    <p className={`product-stock ${stockObject.class}`}>
                        {stockObject.content}</p>
                    {
                          product?.dicountPercentage === 0 ? <p className="product-price">${Number.parseFloat(product?.price).toFixed(2)}</p>
                            :
                           <ProductPromotionPriceSection product={product}/>
                    }
                    {product?.productStocks?.length > 0 && <h4>Size</h4>}
                    <ul className="size-ul">
                        {sizeItmes}
                    </ul>
                    <ProductOrderSection activeSizeItem={activeSizeItem} categoryName={categoryName} count={count} id={id}
                        handleMinusClick={handleMinusClick} handlePlusClick={handlePlusClick} product={product} />
                    {user?.id && <div className="wishlist-container">

                        <button onClick={handleAddToFavoriteProduct} className="wishlist-button"><i className={!isFavorite ? "fa-regular fa-heart favorite-heart" : "fa - solid fa-heart active-heart"}></i></button>
                        <p>Wishlist</p>
                    </div>
                    }
                    <hr></hr>
                    <section className="product-details">
                        {productDetails}
                    </section>
                </div>
            </div>
            {product?.id && product.relatedProducts?.length > 0 && <RelatedProductsSection product={product}/>}
        </>
    )
}


