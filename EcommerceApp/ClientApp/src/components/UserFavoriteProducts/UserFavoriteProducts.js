import { useEffect, useState } from "react"
import { getUserFavoriteProducts } from "../../services/productService";
import FeaturedProduct from "../Products/FeaturedProduct";

export default function UserFavoriteProducts() {

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
    },[])

    const productsResult = products.map((product) => <FeaturedProduct product={product} /> ) 

    return (
        <>
            <h1 className="personal-products-title">Your favorite products {userName }</h1>
            {productsResult }
        </>
    )
}