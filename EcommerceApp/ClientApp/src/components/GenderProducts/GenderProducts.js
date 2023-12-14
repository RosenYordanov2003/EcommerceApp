import { useEffect, useState } from "react";
import { loadProductsByGender } from "../../services/productService";
import FeaturedProduct from "../Products/FeaturedProduct";
import FilterMenu from "../ProductsFilterMenu/FilterMenu";
import GenderProductsStyle from "../GenderProducts/GenderProductsStyle.css";

export default function GenderProducts() {
    const pathArray = window.location.pathname.split('/');
    const gender = pathArray[pathArray.length - 1];

    const [resultObject, setResultObject] = useState(undefined);
    const [products, setProducts] = useState([]);
    const [shoes, setShoes] = useState([]);

    useEffect(() => {
        loadProductsByGender(gender)
            .then((result) => {
                setResultObject(result);
                setProducts(result.products);
                setShoes(result.shoes);
            })
            .catch((error) => console.error(error));
    }, [gender])

    function filterProducts(brandsArray, categoriesArray) {
        const brandNames = brandsArray.map((brand) => brand.name);
        const categoryNames = categoriesArray.map((category) => category.name);

        const filterByBrandAndCategory = (item) => {
            const brandMatch = brandNames.length === 0 || brandNames.includes(item.brand);
            const categoryMatch = categoryNames.length === 0 || categoryNames.includes(item.category);
            return brandMatch && categoryMatch;
        };

        if (brandNames.length > 0 || categoryNames.length > 0) {
            const filteredProducts = resultObject.products.filter(filterByBrandAndCategory);
            const filteredShoes = resultObject.shoes.filter(filterByBrandAndCategory);

            setProducts(filteredProducts);
            setShoes(filteredShoes);
        }
    }

    let shoesResult;
    let productsResult;

    if (shoes) {
        shoesResult = shoes.map((product) => <FeaturedProduct key={product.id} product={product} />)
    }
    else {
        shoesResult = resultObject == undefined ? "" : resultObject.shoes.map((shoes) => <FeaturedProduct key={shoes.id} product={shoes} />)
    }

    if (products) {
        productsResult = products.map((product) => <FeaturedProduct key={product.id} product={product} />)
    }
    else {
        productsResult = resultObject == undefined ? "" : resultObject.products.map((product) => <FeaturedProduct key={product.id} product={product} />)
    }

    return (
        <div className="main-container">

            {resultObject && <FilterMenu result={resultObject} onCheckInput={filterProducts} />}

            <div className="products-container">
                <section className="products-section">
                    {productsResult}
                </section>
                <section className="products-section">
                    {shoesResult}
                </section>
            </div>
        </div>

    )
}