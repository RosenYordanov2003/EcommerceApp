import { useEffect, useState } from "react";
import { getProductToModify, editProduct } from "../../../../adminServices/clothesService";
import "../ModifyingProduct/Style.css";
import ProductStock from "../../ProductStock/ProductStock";
import PoppupMessage from "../../../PoppupMessage/PoppupMessage";
import SizeTable from "../../SizeTable/SizeTable";
import PromotionSection from "../../PromotionSection/PromotionSection";
import { getShoesToModify } from "../../../../adminServices/shoesService";
import { editShoes, setShoesToBeFeatured, removeFeaturedShoes } from "../../../../adminServices/shoesService";
import "../ModifyingProduct/ResponsiveStyle.css";
import ProductImg from "../../ProductImg/ProductImg";
import { HubConnectionBuilder } from '@microsoft/signalr';
import ButtonsContainer from "./../ButtonsContainer/ButtonsContainer";
import { productNameInput, productDescriptionInput, productPriceInput } from "../../../../utilities/inputValidations";
import Input from "../../../Auth/Input/Input";
import { FormProvider, useForm } from 'react-hook-form'

export default function ModifyingProduct() {

    const path = window.location.pathname.split('/');
    const productId = path[2];
    const category = path[3];

    const [message, setMessage] = useState(undefined);
    const [product, setProduct] = useState(undefined);
    const [inputObject, setInputObject] = useState({});
    const [connection, setConnection] = useState(null);
    const methods = useForm();

    useEffect(() => {

        const productLoadFunction = category !== "Shoes" ? getProductToModify : getShoesToModify;

        productLoadFunction(productId)
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

        const newConnection = new HubConnectionBuilder()
            .withUrl('https://localhost:7122/notifications-hub')
            .withAutomaticReconnect()
            .build();
        setConnection(newConnection);
      
    }, [])

    useEffect(() => {
        if (connection) {
            connection.start()
                .then(() => {
                    connection.on('ProductUpdated', () => {
                        if (category !== "Shoes") {
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
                                .catch((error) => console.error(error));
                        }
                        else {
                            getShoesToModify(productId)
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
                                .catch((error) => console.error(error));
                        }
                       
                    });
                })
                .catch(console.error);
        }
    }, [connection]);

    const imgs = product?.imgUrls?.map((img) => <ProductImg imgUrl={img.imgUrl} id={img.id}/>);
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
    const handleFormSubmit = methods.handleSubmit(data => {

        const object = {
            ...data,
            brandId: inputObject.brandId,
            categoryId: inputObject.categoryId,
            id: inputObject.id
        }

        if (category !== "Shoes") {
            editProduct(object)
                .then(() => setMessage(<PoppupMessage message="Successfully update product" removeNotification={closeNotification} />))
                .catch((error) => console.error(error));
        }
        else {
            editShoes(object)
                .then(() => setMessage(<PoppupMessage message="Successfully update product" removeNotification={closeNotification} />))
                .catch((error) => console.error(error));
        }
    })

    function addPopupMessage(message) {
        setMessage(<PoppupMessage message={message} removeNotification={closeNotification} />)
    }

    return (
        <div className="product-modifying-container">
            {message !== undefined && message}
            <div className="imgs-container-product">
                <div className="imgs-container">
                    {imgs}
                </div>
                <ButtonsContainer isArchived={product?.isArchived} isFeatured={product?.isFeatured} productId={productId} category={category} addMessage={addPopupMessage }/>
            </div>
            <div className="product-modifying-content">
                <FormProvider {...methods}>
                    <form onSubmit={(e) => e.preventDefault()}>
                        <Input {...productNameInput} inputValue={inputObject.name} classNameValue="product-input-container"/>
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
                        <Input {...productPriceInput} classNameValue="product-input-container" inputValue={inputObject.price}/>
                        <Input {...productDescriptionInput} classNameValue="product-input-container" inputValue={inputObject.description}/>
                        <button onClick={handleFormSubmit} className="edit-product-button" type="submit">Edit</button>
                    </form>
                </FormProvider>
               
                <SizeTable productStockArray={product?.productStocks} />
                <section className="product-sizes">
                    <h3 className="add-product-stock-title">Add Product Stock</h3>
                    {sizes}
                </section>
                <section className="promotion-section">
                    <PromotionSection promotionModel={product?.promotionModel} />
                </section>
            </div>
        </div>
    )
}