import CategoriesSection from "../Categories/CategoriesSection"
import { useEffect } from "react";
import { useState } from "react";
import { loadFeaturedShoes } from "../../services/productService";
import FeaturedProduct from "../Products/FeaturedProduct";
import { loadFeaturedClothes } from "../../services/productService";
import HomeStyle from "../Home/HomeStyle.css";
import ContactContainer from "../ContactContainer/ContactContainer";

export default function Home({ categories, isActive }) {
    const [featuredShoes, setFeaturedShoes] = useState([]);
    const [featuredClothes, setFeaturedClothes] = useState([]);

    useEffect(() => {
        loadFeaturedShoes()
            .then(res => setFeaturedShoes(res))
        .catch((error) => console.error(error))
    }, [])

    useEffect(() => {
        loadFeaturedClothes()
            .then(res => {
                setFeaturedClothes(res);
            })
        .catch((error) => console.error(error))
    }, [])

    const shoesResult = featuredShoes.length > 0? featuredShoes.map((shoes) => <FeaturedProduct key={shoes.id} product={shoes} />) : "";
    const clothesResult = featuredClothes.length > 0 ? featuredClothes.map((clothes) => <FeaturedProduct key={clothes.id} product={clothes} />): "";

    return (
        <>
            <CategoriesSection categories={categories} isActive={isActive} />
            <h2 className = "feature-title">Featured Shoes</h2>
            <section className = "featured-shoes-section">
                {shoesResult}
            </section>
            <h2 className="feature-title">Featured Clothes</h2>
            <section className="featured-shoes-section">
                {clothesResult}
            </section>
            <ContactContainer/>
         </>
    );
}
