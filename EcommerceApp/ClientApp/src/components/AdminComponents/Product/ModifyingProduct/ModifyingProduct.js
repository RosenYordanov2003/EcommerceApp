import { useEffect, useState } from "react";
import { getProductToModify, editProduct } from "../../../../adminServices/clothesService";
import Style from "../ModifyingProduct/Style.css";
import ProductStock from "../../ProductStock/ProductStock";
import PoppupMessage from "../../../PoppupMessage/PoppupMessage";

export default function ModifyingProduct() {

    const path = window.location.pathname.split('/');
    const [message, setMessage] = useState(undefined);
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
                    brandId: res.selectedBrandId,
                    categoryId: res.selectedCategoryId,
                    price: res.price,
                    description: res.description,
                    id: productId
                });
            })
    }, [])


    const imgs = product?.imgUrls?.map((img, index) => <div className="admin-img-container"><img key={index} src={img.imgUrl} /> </div>);
    const sizes = product?.productStocks?.map((ps) => <ProductStock productStock={ps} key={ps.id} />);
    const categories = product?.categories?.map((category) => <option value={category.id}>{category.name}</option>);
    const brands = product?.brands?.map((brand) => <option value={brand.id}>{brand.name}</option>);

    function handleOnBrandChange(event) {
        const value = Number.parseInt(event.target.options[event.target.selectedIndex].value);
        setInputObject({ ...inputObject, brandId: value });
    }
    function handleOnCategoryChange(event) {
        const value = Number.parseInt(event.target.options[event.target.selectedIndex].value);
        setInputObject({ ...inputObject, categoryId: value });
    }
    function closeNotification() {
        setMessage(undefined);
    }
    function handleFormSubmit(event) {
        event.preventDefault();

        editProduct(inputObject)
            .then(() => setMessage(<PoppupMessage message="Successfully update product" removeNotification={closeNotification} />))
    }

    return (
        <div className="product-modifying-container">
            {message !== undefined && message}
            <div className="imgs-container">
                {imgs}
            </div>
            <div className="product-modifying-content">
                <form onSubmit={handleFormSubmit}>
                    <div className="product-input-container">
                        <label htmlFor="name">Name</label>
                        <input id="name" onChange={(e) => setInputObject({ ...inputObject, name: e.target.value })} value={inputObject.name}></input>
                    </div>
                    <div className="product-input-container">
                        <label>Category</label>
                        <select onChange={handleOnCategoryChange} value={inputObject.categoryId}>
                            {categories}
                        </select>
                    </div>
                    <div className="product-input-container">
                        <label>Brand</label>
                        <select onChange={handleOnBrandChange} value={inputObject.brandId}>
                            {brands}
                        </select>
                    </div>
                    <div className="product-input-container">
                        <label htmlFor="price">Price</label>
                        <input id="price" onChange={(e) => setInputObject({ ...inputObject, price: e.target.value })} value={inputObject.price}></input>
                    </div>
                    <div className="product-input-container">
                        <label htmlFor="description">Description</label>
                        <textarea id="description" onChange={(e) => setInputObject({ ...inputObject, description: e.target.value })} rows={10} cols={24} value={inputObject.description}></textarea>
                    </div>
                    <button className="edit-product-button" type="submit">Edit</button>
                </form>
                <section className="product-sizes">
                    <h3 className="sizes-title">Sizes</h3>
                    {sizes}
                </section>
            </div>
        </div>
    )
}