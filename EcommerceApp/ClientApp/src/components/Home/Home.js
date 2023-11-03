import CategoriesSection from "../Categories/CategoriesSection"
import { useEffect } from "react";
import { useState } from "react";
import { loadFeaturedShoes } from "../../services/productService";
import FeaturedProduct from "../Products/FeaturedProduct";
import HomeStyle from "../Home/HomeStyle.css";
export default function Home({ categories, isActive }) {

    const [featuredShoes, setFeaturedShoes] = useState([]);

    useEffect(() => {
        loadFeaturedShoes()
            .then(res => setFeaturedShoes(res))
        .catch((error) => console.error(error))
    }, [])
    const result = featuredShoes.map((shoes) => <FeaturedProduct key={shoes.id} product={shoes } />)
    return (
        <>
            <CategoriesSection categories={categories} isActive={isActive} />
            <section className = "featured-shoes-section">
                {result}
            </section>
         </>
    );
}
