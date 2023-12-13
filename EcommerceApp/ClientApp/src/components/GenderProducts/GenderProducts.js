import { useEffect, useState } from "react";
import { loadProductsByGender } from "../../services/productService";
import FeaturedProduct from "../Products/FeaturedProduct";
import FilterMenu from "../ProductsFilterMenu/FilterMenu";
import GenderProductsStyle from "../GenderProducts/GenderProductsStyle.css";

export default function GenderProducts() {
    const pathArray = window.location.pathname.split('/');
    const gender = pathArray[pathArray.length - 1];

    const [resultObject, setResultObject] = useState(undefined);

    useEffect(() => {
        loadProductsByGender(gender)
            .then((result) => setResultObject(result))
            .catch((error) => console.error(error));
    }, [])

    console.log(resultObject);
    const shoesResult = resultObject == undefined ? "" : resultObject.shoes.map((shoes) => <FeaturedProduct key={shoes.id} product={shoes} />)
    const productsResult = resultObject == undefined ? "" : resultObject.products.map((product) => <FeaturedProduct key={product.id} product={product} />)
    return (
        <div>

            { resultObject && <FilterMenu props={resultObject} />}

            <div className="products-container">
                <section className = "products-section">
                    {productsResult}
                </section>
                <section className = "products-section">
                    {shoesResult}
                </section>
            </div>
        </div>

    )
}