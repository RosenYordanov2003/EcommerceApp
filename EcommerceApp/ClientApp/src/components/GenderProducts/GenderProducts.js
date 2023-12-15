﻿import { useEffect, useState, useMemo } from "react";
import { loadProductsByGender } from "../../services/productService";
import FeaturedProduct from "../Products/FeaturedProduct";
import FilterMenu from "../ProductsFilterMenu/FilterMenu";
import GenderProductsStyle from "../GenderProducts/GenderProductsStyle.css";
import { faL } from "../../../../../node_modules/@fortawesome/free-solid-svg-icons/index";
import { Grid } from 'react-loader-spinner';
import ContactContainer from "../ContactContainer/ContactContainer";

export default function GenderProducts() {
    const pathArray = window.location.pathname.split('/');
    const gender = pathArray[pathArray.length - 1];

    const [resultObject, setResultObject] = useState(undefined);
    const [products, setProducts] = useState([]);
    const [shoes, setShoes] = useState([]);
    const [filters, setFilters] = useState({ brands: [], categories: [] });
    const [isLoading, setIsLoading] = useState(false);

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

        configureLoading();

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

    function filterProductsByQueryString(e) {
        e.preventDefault();

        const formData = new FormData(e.target);
        let queryString = formData.get("query");

        queryString = queryString.toLowerCase();

        let filterShoes = [];
        let filterPoducts = [];

        if (products.length > 0 && (filters.brands.length > 0 || filters.categories.length > 0)) {
            filterPoducts = products.filter((product) => product.name.toLowerCase().startsWith(queryString));
            setProducts(filterPoducts);
        }
        else {
            filterPoducts = resultObject.products.filter((product) => product.name.toLowerCase().startsWith(queryString));
        }

        if (shoes.length > 0 && (filters.brands.length > 0 || filters.categories.length > 0)) {
            filterShoes = shoes.filter((shoes) => shoes.name.toLowerCase().startsWith(queryString));
            setShoes(filterShoes);
        }
        else {
            filterShoes = resultObject.shoes.filter((shoes) => shoes.name.toLowerCase().startsWith(queryString));
        }


        setProducts(filterPoducts);
        setShoes(filterShoes);

        configureLoading();

    }

    function configureLoading() {
        setIsLoading(true);

        setTimeout(() => {
            setIsLoading(false);
        }, 500)
    }

    const shoesResult = useMemo(() => {
        return shoes.map((product) => <FeaturedProduct key={product.id} product={product} />);
    }, [shoes]);

    const productsResult = useMemo(() => {
        return products.map((product) => <FeaturedProduct key={product.id} product={product} />);
    }, [products]);

    const resultContainer = isLoading ? <Grid
        height="80"
        width="80"
        color="#035096"
        ariaLabel="grid-loading"
        radius="12.5"
        wrapperStyle={{}}
        wrapperClass="spinner"
        visible={true} />

        : <div className="products-container">
            <section className="products-section">
                {productsResult}
            </section>
            <section className="products-section">
                {shoesResult}
            </section>
        </div>

    return (

        <>
            <form onSubmit={filterProductsByQueryString} className="searchForm">
                <div className="search-input-container">
                    <input name = "query" placeholder="Search for products" className="search" type="text"></input>
                    <button className="search-button">Search</button>
                    <i className="search-icon fa-solid fa-magnifying-glass"></i>
                </div>

            </form>
            <div className="main-container">

                {resultObject && <FilterMenu result={resultObject} onCheckInput={filterProducts} />}

                <div>
                    {resultContainer}

                </div>
            </div>
        </>
    )
}