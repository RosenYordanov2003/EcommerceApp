import { useState, useEffect } from "react";
import { getCreateProductModel } from "../../../../adminServices/clothesService";
import { createProduct } from "../../../../adminServices/clothesService";
import Input from "../../../Auth/Input/Input";
import { FormProvider, useForm } from 'react-hook-form';
import {productNameInput, productPriceInput, productDescriptionInput} from "../../../../utilities/inputValidations";

import "../CreateProduct/Style.css";

export default function CreateProduct() {
    const [inputObject, setInputObject] = useState({
        name: '',
        brandId: 0,
        starRating: 0,
        price: 0,
        categoryId: 0,
        description: '',
        categories: [],
        brands: [],
        gender: 'men',
    });

    useEffect(() => {
        getCreateProductModel()
            .then(res => {
                setInputObject({ ...inputObject, categories: res.categories, brands: res.brands, brandId: res.brands[0].id, categoryId: res.categories[0].id });
            })
    }, [])

    const [files, setFiles] = useState([]);
    const methods = useForm();

    const categories = inputObject.categories.map((category) => <option value={category.id}>{category.name}</option>);
    const brands = inputObject.brands.map((brand) => <option value={brand.id}>{brand.name}</option>);

    function handleOnBrandChange(event) {
        const value = Number.parseInt(event.target.options[event.target.selectedIndex].value);
        setInputObject({ ...inputObject, brandId: value });
    }
    function handleOnCategoryChange(event) {
        const value = Number.parseInt(event.target.options[event.target.selectedIndex].value);
        setInputObject({ ...inputObject, categoryId: value });
    }
    const handleOnFormSubmit = methods.handleSubmit(data => {

        const formData = new FormData();
        formData.append("categoryId", inputObject.categoryId);
        formData.append("imgFiles", files);
        formData.append("starRating", inputObject.starRating);
        formData.append("brandId", inputObject.brandId);
        for (const key in data) {
            formData.append(key, data[key]);
            console.log(`${key} - ${data[key]}`);
            createProduct(formData)
            .then(() => console.log('created'))
            .catch((error) => console.error(error));
        }
    })

    const stars = Array.from({ length: 6 }, (_, index) => <option value={index}>{index}</option>);

    return (
        <div className="product-modifying-container">
                <div className="create-product-buttons-container">
                    <section className="add-img-container-section">
                        <div className="add-img-container">
                        <input accept=".jpg, .jpeg, .png, .webp"
                                multiple
                                onChange={(e) => setFiles(e.target.files)} type="file"></input>
                            <button>Upload Imgs</button>
                        </div>
                    </section>
                </div>

            <div className="product-modifying-content">
                <FormProvider {...methods}>
                    <form onSubmit={(e) => e.preventDefault()}>
                        <Input {...productNameInput } classNameValue="product-input-container"/>
                        <div className="product-input-container">
                            <label>Category</label>
                            <select onChange={handleOnCategoryChange} value={inputObject.categoryId}>
                                {categories}
                            </select>
                        </div>
                        <div className="product-input-container">
                            <label>Gender</label>
                            <select onChange={(event) => setInputObject({ ...inputObject, gender: event.target.options[event.target.selectedIndex].value })} value={inputObject.gender}>
                                <option value="Men">Men</option>
                                <option value="Women">Women</option>
                            </select>
                        </div>
                        <div className="product-input-container">
                            <label>Star Rating</label>
                            <select onChange={(event) => setInputObject({ ...inputObject, starRating: event.target.options[event.target.selectedIndex].value })} value={inputObject?.starRating}>
                                {stars}
                            </select>
                        </div>
                        <div className="product-input-container">
                            <label>Brand</label>
                            <select onChange={handleOnBrandChange} value={inputObject.brandId}>
                                {brands}
                            </select>
                        </div>
                        <Input {...productPriceInput } classNameValue="product-input-container"/>
                        <Input {...productDescriptionInput} classNameValue="product-input-container" />
                        <button onClick={handleOnFormSubmit} className="edit-product-button" type="submit">Cretae</button>
                    </form>
                </FormProvider>
              
            </div>
        </div>
    )
}