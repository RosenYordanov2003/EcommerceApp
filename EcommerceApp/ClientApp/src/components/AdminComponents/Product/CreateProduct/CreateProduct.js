import { useState, useEffect } from "react";
import { getCreateProductModel } from "../../../../adminServices/clothesService";
import { createProduct } from "../../../../adminServices/clothesService";
import Style from "../CreateProduct/Style.css";

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

    console.log(inputObject);

    const [files, setFiles] = useState([]);

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
    //const packFiles = () => {
    //    const data = new FormData()

    //    for (let i = 0; i < files.length; i++) {
    //        data.append(`file-${i}`, files[i]);
    //    }
    //    return data
    //}
    function handleOnFormSubmit(event) {

        event.preventDefault();

        const formData = new FormData();
        formData.append("name", inputObject.name);
        formData.append("categoryId", inputObject.categoryId);
        formData.append("imgFiles", files);
        formData.append("starRating", inputObject.starRating);
        formData.append("price", inputObject.price);
        formData.append("gender", inputObject.gender);
        formData.append("brandId", inputObject.brandId);
        formData.append("description", inputObject.description);

        createProduct(formData)
            .then(() => console.log('created'))
            .catch((error) => console.error(error));

    }

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
                <form onSubmit={handleOnFormSubmit}>
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
                    <div className="product-input-container">
                        <label htmlFor="price">Price</label>
                        <input id="price" onChange={(e) => setInputObject({ ...inputObject, price: e.target.value })} value={inputObject.price}></input>
                    </div>
                    <div className="product-input-container">
                        <label htmlFor="description">Description</label>
                        <textarea id="description" onChange={(e) => setInputObject({ ...inputObject, description: e.target.value })} rows={10} cols={24} value={inputObject.description}></textarea>
                    </div>
                    <button className="edit-product-button" type="submit">Cretae</button>
                </form>
            </div>
        </div>
    )
}