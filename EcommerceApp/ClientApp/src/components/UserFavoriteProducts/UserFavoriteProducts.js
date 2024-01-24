import { useEffect, useState, useContext } from "react"
import { getUserFavoriteProducts } from "../../services/productService";
import FeaturedProduct from "../Products/FeaturedProduct";
import Style from "../UserFavoriteProducts/Style.css";
import { UserContext } from "../../Contexts/UserContext";

export default function UserFavoriteProducts() {

    const { user } = useContext(UserContext);
    const [products, setProducts] = useState([]);
    const [userName, setUserName] = useState('');

    const userId = window.location.pathname.split('/')[2];


    useEffect(() => {
        getUserFavoriteProducts(userId)
            .then(res => {
                setProducts(res.products);
                setUserName(res.userName);
            })
            .catch((error) => console.error(error))
    }, [user?.userFavoriteProducts])

    console.log(products);

    const productsResult = products?.map((product) => <FeaturedProduct key={product.id} product={product} />)

    return (
        <>
            <h1 className="personal-products-title">Your favorite products {userName}</h1>
            <div className="favorite-products-section-wrapper">
                <section className="favorite-products-section">
                    {productsResult}
                </section>
            </div>
        </>
    )
}