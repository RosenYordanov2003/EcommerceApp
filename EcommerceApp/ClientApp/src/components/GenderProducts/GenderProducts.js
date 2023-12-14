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
    const [filters, setFilters] = useState({ brands: [], categories: []});

    useEffect(() => {
        loadProductsByGender(gender)
            .then((result) => {
                const filteredProducts = filter(filters.brands, filters.categories, result.products);
                const filteredShoes = filter(filters.brands, filters.categories, result.shoes);

                setResultObject(result);
                setProducts(filteredProducts);
                setShoes(filteredShoes);
            })
            .catch((error) => console.error(error));
    }, [gender]);

    function filterProducts(brandsArray, categoriesArray) {


        const brandNames = brandsArray.map((brand) => brand.name);
        const categoryNames = categoriesArray.map((category) => category.name);

        const filterByBrandAndCategory = (product) => {
            const brandMatch = brandNames.length === 0 || brandNames.includes(product.brand);
            const categoryMatch = categoryNames.length === 0 || categoryNames.includes(product.category);
            return brandMatch && categoryMatch;
        };

        const filteredProducts = resultObject.products.filter(filterByBrandAndCategory);
        const filteredShoes = resultObject.shoes.filter(filterByBrandAndCategory);
        setFilters({ brands: brandsArray, categories: categoriesArray });
        setProducts(filteredProducts);
        setShoes(filteredShoes);
    }
    function filter(brandsArray, categoriesArray, productsArray) {
        const brandNames = brandsArray.map((brand) => brand.name);
        const categoryNames = categoriesArray.map((category) => category.name);

        const filterByBrandAndCategory = (product) => {
            const brandMatch = brandNames.length === 0 || brandNames.includes(product.brand);
            const categoryMatch = categoryNames.length === 0 || categoryNames.includes(product.category);
            return brandMatch && categoryMatch;
        };

        return productsArray.filter(filterByBrandAndCategory);
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