import { useEffect, useState } from "react";
import { loadProductById } from "../../services/productService";
import ProductInfoStyle from "../Products/ProductInfoStyle.css";
import SizeItem from "../SizeMenu/SizeMenu";
import ProductDetails from "../Products/ProductDetails/ProductDetails";
export default function ProductInfo() {

    const [product, setProduct] = useState({});
    const [activePicture, setActivePictures] = useState(undefined);
    const [indexPicture, setIndexPicture] = useState(0);
    const [count, setCount] = useState(1);
    const [isActiveArrows, setActiveArrows] = useState(false);
    const [activeSizeItem, setActiveSizeItem] = useState(undefined);

    const pathArray = window.location.pathname.split('/');
    const id = pathArray[pathArray.length - 2];
    const categoryName = pathArray[pathArray.length - 1];


    useEffect(() => {
        loadProductById(id, categoryName)
            .then((res) => {
                setProduct(res);
                setActivePictures(res.pictures[indexPicture]);
            })
            .catch((error) => console.error(error));
    }, [])

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

    const productDetails = <ProductDetails product={product} id={id} category={categoryName} />

    function handleimgRightArrowClick() {
        if (indexPicture >= product.pictures.length - 1) {
            setIndexPicture(0);
            setActivePictures(product.pictures[0]);
        }
        else {
            setIndexPicture(indexPicture + 1);
            setActivePictures(product?.pictures[indexPicture + 1]);
        }
        console.log(indexPicture);
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
    return (
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
                    <button className="wishlist-button"><i className="fa-regular fa-heart"></i></button>
                    <p>Wishlist</p>
                </div>
                <hr></hr>
                <section className="product-details">
                    {productDetails}
                </section>
            </div>
        </div>
    )

}