import { useEffect, useState } from "react";
import { getProductToModify } from "../../../../adminServices/clothesService";
import Style from "../ModifyingProduct/Style.css";
import ProductStock from "../../ProductStock/ProductStock";

export default function ModifyingProduct() {

    const path = window.location.pathname.split('/');

    const productId = path[2];

    const [product, setProduct] = useState(undefined);
    const [inputObject, setInputObject] = useState({});

    useEffect(() => {
        getProductToModify(productId)
            .then((res) => {
                setProduct(res);
                setInputObject({
                    name: res.name,
                    starRating: res.starRating,
                    brand: res.brand,
                    category: res.category,
                    price: res.price
                });
            })
    }, [])


    const imgs = product?.imgUrls?.map((img, index) => <div className="admin-img-container"><img key={index} src={img.imgUrl} /> </div>);
    const sizes = product?.productStocks?.map((ps) => <ProductStock productStock={ps} key={ps.id}/>)

    return (
        <div className="product-modifying-container">
            <div className="imgs-container">
                {imgs}
            </div>
            <div className="product-modifying-content">
                <form>
                    <div className="product-input-container">
                        <label>Name</label>
                        <input onChange={(e) => setInputObject({...inputObject, name: e.target.value})} value={ product?.name }></input>
                    </div>
                    <div className="product-input-container">
                        <label>Category</label>
                        <input onChange={(e) => setInputObject({ ...inputObject, category: e.target.value })} value={product?.category}></input>
                    </div>
                    <div className="product-input-container">
                        <label>Brand</label>
                        <input onChange={(e) => setInputObject({ ...inputObject, brand: e.target.value })} value={product?.brand}></input>
                    </div>
                    <div className="product-input-container">
                        <label>Price</label>
                        <input onChange={(e) => setInputObject({ ...inputObject, price: e.target.value })} value={product?.price}></input>
                    </div>
                    <button className="edit-product-button" type="submit">Edit</button>
                </form>
                <section className="product-sizes">
                    <h3 className="sizes-title">Sizes</h3>
                    {sizes }
                </section>
            </div>
        </div>
    )
}