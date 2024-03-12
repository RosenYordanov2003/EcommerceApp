import { useEffect, useState, useContext } from "react";
import { loadProductById, addProductToUserFavoriteProductsList, removeProductFromUserFavoriteList, createProductObject, filterUserFavoriteProducts } from "../../services/productService";
import "../Products/ProductInfoStyle.css";
import SizeItem from "../SizeMenu/SizeMenu";
import ProductDetails from "../Products/ProductDetails/ProductDetails";
import FeaturedProduct from "../Products/FeaturedProduct";
import { UserContext } from "../../Contexts/UserContext";
import { addToCartProduct } from "../../services/cartService";
import Notification from "../Notification/Notification";
import "../Products/ProductInfoResponsiveStyle.css";
import TimerCountDown from "../TimerCountDown/TimerCountDown";

export default function ProductInfo() {

    const { user, setUser } = useContext(UserContext);

    const [product, setProduct] = useState({});
    const [activePicture, setActivePictures] = useState(undefined);
    const [indexPicture, setIndexPicture] = useState(0);
    const [count, setCount] = useState(1);
    const [isActiveArrows, setActiveArrows] = useState(false);
    const [activeSizeItem, setActiveSizeItem] = useState(undefined);
    const [isFavorite, setIsFavorite] = useState(undefined);
    const [notiffication, setNotification] = useState(undefined);

    const pathArray = window.location.pathname.split('/');
    const id = pathArray[pathArray.length - 2];
    const categoryName = pathArray[pathArray.length - 1];


    useEffect(() => {
        loadProductById(id, categoryName, user?.id)
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

    const relatedProducts = product?.relatedProducts?.map((product) => <FeaturedProduct key={product.id} product={product} />)


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
            addProductToUserFavoriteProductsList(user.id, id, categoryName, count)
                .then(() => {
                    const productObject = createProductObject(product.name, id, product.pictures[0].imgUrl, categoryName);

                    setUser({ ...user, userFavoriteProducts: [...user.userFavoriteProducts, productObject] })
                })
                .catch((error) => console.error(error));
        }
        else {
            removeProductFromUserFavoriteList(user.id, id, categoryName)
                .then(() => {
                    const products = filterUserFavoriteProducts(user.userFavoriteProducts, id, categoryName)
                    setUser({ ...user, userFavoriteProducts: products })
                })
                .catch((error) => console.error(error));
        }
        setIsFavorite(favoriteResult);
    }
    function removeNotification() {
        setNotification(undefined);
    }
    function handleAddToCartProduct() {

        if (activeSizeItem === undefined) {
            setNotification(<Notification message={"Please, select size"} typeOfMessage="error" closeNotification={removeNotification} />)
            return;
        }

        addToCartProduct(id, user?.id, categoryName, count, activeSizeItem?.size?.toString())
            .then((res) => {
                const productId = Number.parseFloat(id);

                if (res.success == false) {
                    setNotification(<Notification message={res.error} typeOfMessage="error" closeNotification={removeNotification}/>)
                    return;
                }

                const productObject = {
                    id: productId,
                    name: product.name,
                    categoryName,
                    price: product.price,
                    imgUrl: product.pictures[0].imgUrl,
                    quantity: count,
                    size: activeSizeItem?.size?.toString()
                };

                if (categoryName.toLocaleLowerCase() === 'shoes') {
                    setUser({
                        ...user,
                        cart: {
                            ...user.cart,
                            cartShoes: [...user.cart.cartShoes, productObject]
                        }
                    })
                }
                else {
                    setUser({
                        ...user,
                        cart: {
                            ...user.cart,
                            cartProducts: [...user.cart.cartProducts, productObject]
                        }
                    })
                }
            })
            .catch((error) => console.error(error))
    }

    let addToCartResult;



    if (activeSizeItem) {
        addToCartResult = activeSizeItem.quantity > 0 ? <button onClick={handleAddToCartProduct} className="add-to-cart">Add to cart</button> : "";
    }
    else {
        addToCartResult = product.isAvalilable ? <button onClick={handleAddToCartProduct} className="add-to-cart">Add to cart</button> : "";
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

            <div className="productinfo-card-container">
                {notiffication}
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
                            <section className="price-section"> 
                                <del><p className="product-price">${Number.parseFloat(product?.price).toFixed(2)}</p></del>
                                <p className="product-price">${Number.parseFloat(product?.price - ((product?.price * product?.dicountPercentage) / 100)).toFixed(2)}</p>
                                {
                                    product?.totalMilisecondsDifference !== undefined &&
                                    <TimerCountDown key={`${id} - ${categoryName}`} miliseconds={product?.totalMilisecondsDifference}/>
                                }
                            </section>
                    }
                  
                    <h4>Size</h4>
                    <ul className="size-ul">
                        {sizeItmes}
                    </ul>
                    <section className="order-section">
                        <div className="order-count">
                            <button onClick={handleMinusClick} className="order-button"><i className="fa-solid fa-minus"></i></button>
                            <div className="order-number">{count}</div>
                            <button onClick={handlePlusClick} className="order-button"><i className="fa-solid fa-plus"></i></button>
                            {addToCartResult}
                        </div>
                    </section>
                    {user?.id && <div className="wishlist-container">
                        <button onClick={handleAddToFavoriteProduct} className="wishlist-button"><i className={!isFavorite ? "fa-regular fa-heart favorite-heart" : "fa - solid fa-heart active-heart"}></i></button>
                        <p>Wishlist</p>
                    </div>}
                    <hr></hr>
                    <section className="product-details">
                        {productDetails}
                    </section>
                </div>
            </div>
            {product?.id && relatedProducts?.length > 0 &&
                <section className="related-products-section">
                    <h2 className="related-products-title">Related Products</h2>
                    <hr></hr>
                    <div className="related-products-container">
                        {relatedProducts}
                    </div>
                </section>
            }
        </>
    )
}


