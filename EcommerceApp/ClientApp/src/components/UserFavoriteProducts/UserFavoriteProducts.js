import { useEffect, useState, useContext } from "react"
import { getUserFavoriteProducts } from "../../services/productService";
import FeaturedProduct from "../Products/FeaturedProduct";
import "../UserFavoriteProducts/Style.css";
import { UserContext } from "../../Contexts/UserContext";
import "../UserFavoriteProducts/ResponsiveStyle.css";
import { Grid } from 'react-loader-spinner';

export default function UserFavoriteProducts() {

    const { user } = useContext(UserContext);
    const [products, setProducts] = useState([]);
    const [userName, setUserName] = useState('');
    const [isLoading, setIsLoading] = useState(false);
    const userId = window.location.pathname.split('/')[2];


    useEffect(() => {
        getUserFavoriteProducts(userId)
            .then(res => {
                setProducts(res.products);
                setUserName(res.userName);
                setIsLoading(true);
                setTimeout(() => {
                    setIsLoading(false);
                }, 500)
            })
            .catch((error) => console.error(error))
    }, [user?.userFavoriteProducts])

    const productsResult = products?.map((product) => <FeaturedProduct key={product.id} product={product} />)

    return (
        <>
            {isLoading === true ? <Grid
                height="80"
                width="80"
                color="#035096"
                ariaLabel="grid-loading"
                radius="12.5"
                wrapperStyle={{}}
                wrapperClass="spinner"
                visible={true} /> :
                <>
                    <h1 className="personal-products-title">Your favorite products {userName}</h1>
                    <div className="favorite-products-section-wrapper">
                        <section className="favorite-products-section">
                            {productsResult}
                        </section>
                    </div>
                </>
            }
        </>
    )
}