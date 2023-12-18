import { useEffect, useState } from "react";
import { loadProductById } from "../../services/productService";
import ProductInfoStyle from "../Products/ProductInfoStyle.css";
import SizeMenu from "../SizeMenu/SizeMenu";
export default function ProductInfo() {

    const [product, setProduct] = useState({});
    const [activePicture, setActivePictures] = useState(undefined);
    const [indexPicture, setIndexPicture] = useState(0);
    const [count, setCount] = useState(1);


    const pathArray = window.location.pathname.split('/');
    const id = pathArray[pathArray.length - 2];
    const categoryName = pathArray[pathArray.length - 1];


    useEffect(() => {
        loadProductById(id, categoryName)
            .then((res) => {
                console.log(res);
                setProduct(res);
                setActivePictures(res.pictures[indexPicture]);
            })
            .catch((error) => console.error(error));
    }, [])

    let sizeItmes = "";
    if (product.productStocks) {
        console.log(product);
        sizeItmes = product.productStocks.map((productStock) => <SizeMenu productSize={productStock} />) ;
    }

    return (
        <div className="productinfo-card-container">
            <div className="productinfo-img-container">
                <img src={activePicture?.imgUrl}></img>
            </div>
            <div className="productinfo-about-container">
                <h2 className="product-about-title">{product.name}</h2>
                <p className="product-price">${product.price}</p>
                <h4>Size</h4>
                <ul className="size-ul">
                    {sizeItmes}
                </ul>
                <section className="order-section">
                    <div className="order-count">
                        <button className="order-button"><i className="fa-solid fa-minus"></i></button>
                        <div className = "order-number">{count}</div>
                        <button className="order-button"><i className="fa-solid fa-plus"></i></button>
                        <button className="add-to-cart">Add to cart</button>
                    </div>
                </section>
            </div>
        </div>
    )

}