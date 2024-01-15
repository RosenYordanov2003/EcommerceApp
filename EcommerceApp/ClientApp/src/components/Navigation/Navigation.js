import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { useContext } from 'react';
import { UserContext } from "../../Contexts/UserContext";
import { Link } from "react-router-dom";
import Style from "../Navigation/Style.css"
import { logout } from "../../services/authService";
import UserFavoriteProducts from "../Products/UserFavoriteProducts/UserFavoriteProducts";

export default function Navigation() {

    const navigate = useNavigate();
    const context = useContext(UserContext);
    const [favoriteMenuActivity, setFavoriteMenuActivity] = useState(false);


    let listImes;

    if (context?.user?.username) {

        const userFavoriteProducts = context?.user?.userFavoriteProducts.map((product) => <UserFavoriteProducts product={product} key={product.id} />);


        listImes =
            <>
                {
                    context?.user?.userFavoriteProducts?.length > 0 ?
                        <li onMouseOver={() => setFavoriteMenuActivity(true)} onMouseOut={() => setFavoriteMenuActivity(false)} className="user-favorite">
                            <i className="fa-regular fa-heart"></i>
                            <p className="user-favorite-count">{context.user?.userFavoriteProducts?.length}</p>
                            <div className={`favorite-products-container ${favoriteMenuActivity ? "active-favorite-menu" : "not-active-favorite-menu"}`}>
                                <h4 className="favorite-products-title">{context.user?.userFavoriteProducts?.length} Items</h4>
                                <hr></hr>
                                {userFavoriteProducts}
                            </div>
                        </li>
                        :
                        <li onMouseOver={() => setFavoriteMenuActivity(true)} onMouseOut={() => setFavoriteMenuActivity(false)} className="user-favorite">
                        <i className="fa-regular fa-heart"></i>
                        <p className="user-favorite-count">0</p>
                        </li>
                }

                <li className="user-cart-container">
                    <Link to="/Cart">
                    <i className="fa-solid fa-cart-shopping user-cart"></i>
                    <p className="user-products-count">{context.user?.cart?.cartProducts?.length === undefined ? 0 : context.user?.cart?.cartProducts?.length +  context.user?.cart?.cartShoes?.length }</p>
                    </Link>
                </li>
                <li className="logout" onClick={onLogout}>
                    Logout
                </li>
            </>
    }
    else {
        listImes =
            <>
                <li>
                    <Link to="/Register">
                        Register
                    </Link>
                </li>
                <li>
                    <Link to="/Login">
                        Login
                    </Link>
                </li>
            </>
    }
    function onLogout() {
        logout()
            .then(() => {
                context.setUser({});
                navigate("/");
            })
            .catch(error => console.error(error))
    }

    return (
        <>
            <nav className="main-nav">
                <h2 className="nav-logo">Fashion Store</h2>
                <ul>
                    <li>
                        <Link to="/Home">
                            Home
                        </Link>
                    </li>
                    <li>

                        <Link to="/Gender/men">
                            Men{" "}
                        </Link>
                    </li>
                    <li>
                        <Link to="/Gender/women">
                            Women{" "}
                        </Link>
                    </li>
                    {listImes}
                </ul>
            </nav>
        </>
    );
}