import { useEffect, useState, useContext } from "react";
import { loadProductById, addProductToUserFavoriteProductsList, removeProductFromUserFavoriteList } from "../../services/productService";
import ProductInfoStyle from "../Products/ProductInfoStyle.css";
import SizeItem from "../SizeMenu/SizeMenu";
import ProductDetails from "../Products/ProductDetails/ProductDetails";
import FeaturedProduct from "../Products/FeaturedProduct";
import { Grid } from 'react-loader-spinner';
import { UserContext } from "../../Contexts/UserContext";

export default function ProductInfo() {

    const { user, setUser } = useContext(UserContext);

    const [product, setProduct] = useState({});
    const [activePicture, setActivePictures] = useState(undefined);
    const [indexPicture, setIndexPicture] = useState(0);
    const [count, setCount] = useState(1);
    const [isActiveArrows, setActiveArrows] = useState(false);
    const [activeSizeItem, setActiveSizeItem] = useState(undefined);
    /*  const [isLoading, setIsLoading] = useState(false);*/
    const [isFavorite, setIsFavorite] = useState(undefined);

    const pathArray = window.location.pathname.split('/');
    const id = pathArray[pathArray.length - 2];
    const categoryName = pathArray[pathArray.length - 1];


    useEffect(() => {
        loadProductById(id, categoryName, user?.id)
            .then((res) => {
                setProduct(res);
                setIsFavorite(res.isFavorite);
                setActivePictures(res.pictures[indexPicture]);
            })
            .catch((error) => console.error(error));
    }, [id])


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

    //function configureLoading() {
    //    setIsLoading(true);

    //    setTimeout(() => {
    //        setIsLoading(false);
    //    }, 700)
    //}

    let className = isActiveArrows ? "active-arrow" : "";

    //const result = <Grid
    //    height="80"
    //    width="80"
    //    color="#035096"
    //    ariaLabel="grid-loading"
    //    radius="12.5"
    //    wrapperStyle={{}}
    //    wrapperClass="spinner"
    //    visible={true} />

    function handleAddToFavoriteProduct() {
        const favoriteResult = !isFavorite;

        if (favoriteResult) {
            addProductToUserFavoriteProductsList(user.id, id, categoryName)
                .then(res => {

                    const productObject = {
                        productName: product.name,
                        productId: id,
                        imgUrl: product.pictures[0].imgUrl,
                        categoryName: categoryName
                    }

                    setUser({ ...user, userFavoriteProducts: [...user.userFavoriteProducts, productObject] })
                })
                .catch((error) => console.error(error));
        }
        else {
            removeProductFromUserFavoriteList(user.id, id, categoryName)
                .then(res => {
                    const products = user.userFavoriteProducts.map((product) => {
                        if (product.productId != id) {
                            return product;
                        }
                        else {
                            if (product.categoryName !== categoryName) {
                                return product;
                            }
                        }
                    });
                    console.log(products);
                    const filteredProducts = products.filter((product) => product !== undefined);
                    console.log(filteredProducts);
                    setUser({...user, userFavoriteProducts: filteredProducts})

                })
                .catch((error) => console.error(error));
        }
        setIsFavorite(favoriteResult);
    }
    return (
        <>

            <div className="productinfo-card-container">
                <div onMouseOver={() => { setActiveArrows(true) }} onMouseOut={() => { setActiveArrows(false) }} className="productinfo-img-container">
                    <button onClick={handleimgLeftArrowClick} className={`arrow-button left-arrow-button ${className}`}>  <i className="fa-solid fa-chevron-left"></i></button>
                    <img src={activePicture?.imgUrl}></img>
                    <button onClick={handleimgRightArrowClick} className={`arrow-button right-arrow-button ${className}`}> <i className="fa-solid fa-chevron-right"></i></button>
                </div>
                <div className="productinfo-about-container">
                    <h2 className="product-info-title">{product.name}</h2>
                    <p className={`product-stock ${activeSizeItem?.quantity <= 0 ? 'out-of-stock' : 'in-stock'}`}>
                        {activeSizeItem?.quantity <= 0 ? "Out of stock" : "In Stock"}</p>
                    <p className="product-price">${Number.parseFloat(product?.price).toFixed(2)}</p>
                    <h4>Size</h4>
                    <ul className="size-ul">
                        {sizeItmes}
                    </ul>
                    <section className="order-section">
                        <div className="order-count">
                            <button onClick={handleMinusClick} className="order-button"><i className="fa-solid fa-minus"></i></button>
                            <div className="order-number">{count}</div>
                            <button onClick={handlePlusClick} className="order-button"><i className="fa-solid fa-plus"></i></button>
                            {activeSizeItem?.quantity <= 0 ? "" : <button disabled className="add-to-cart">Add to cart</button>}
                        </div>
                    </section>
                    <div className="wishlist-container">
                        <button onClick={handleAddToFavoriteProduct} className="wishlist-button"><i className={!isFavorite ? "fa-regular fa-heart favorite-heart" : "fa - solid fa-heart active-heart"}></i></button>
                        <p>Wishlist</p>
                    </div>
                    <hr></hr>
                    <section className="product-details">
                        {productDetails}
                    </section>
                </div>
            </div>
            {relatedProducts?.length > 0 &&
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

