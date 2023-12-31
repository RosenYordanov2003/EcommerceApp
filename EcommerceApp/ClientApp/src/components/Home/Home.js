import CategoriesSection from "../Categories/CategoriesSection"
import { useState, useEffect, useContext } from "react";
import { loadFeaturedShoes } from "../../services/productService";
import FeaturedProduct from "../Products/FeaturedProduct";
import { loadFeaturedClothes } from "../../services/productService";
import HomeStyle from "../Home/HomeStyle.css";
import ContactContainer from "../ContactContainer/ContactContainer";
import { UserContext } from "../../Contexts/UserContext";


export default function Home({ categories, isActive }) {
    const [featuredShoes, setFeaturedShoes] = useState([]);
    const [featuredClothes, setFeaturedClothes] = useState([]);

    const { user, setUser } = useContext(UserContext);

    useEffect(() => {
        loadFeaturedShoes(user?.id)
            .then(res => setFeaturedShoes(res))
        .catch((error) => console.error(error))
    }, [user?.id])


    useEffect(() => {
        loadFeaturedClothes(user?.id)
            .then(res => setFeaturedClothes(res))
        .catch((error) => console.error(error))
    }, [user?.id])
    const shoesResult =  featuredShoes?.map((shoes) => <FeaturedProduct key={shoes.id} product={shoes} />);
    const clothesResult = featuredClothes?.map((clothes) => <FeaturedProduct key={clothes.id} product={clothes} />);

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
