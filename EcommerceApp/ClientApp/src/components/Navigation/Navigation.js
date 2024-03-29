﻿import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { useContext } from 'react';
import { UserContext } from "../../Contexts/UserContext";
import { Link } from "react-router-dom";
import "../Navigation/Style.css"
import { logout } from "../../services/authService";
import UserFavoriteProducts from "../Products/UserFavoriteProducts/UserFavoriteProducts";
import "../Navigation/ResponsiveStyle.css";
import MobileNavigation from "./MobileButtonNavigation/MobileButtonNavigation";

export default function Navigation() {

    const navigate = useNavigate();
    const context = useContext(UserContext);
    const [favoriteMenuActivity, setFavoriteMenuActivity] = useState(false);
    const [theme, setTheme] = useState(undefined);

    useEffect(() => {

        let themeObject = JSON.parse(localStorage.getItem('theme'));

        if (themeObject) {
            setTheme(themeObject);
        }
        else {
            setTheme('light');
        }
    }, [theme])


    function handleThemeChange() {
        if (theme == 'light') {
            setTheme('dark');
            localStorage.setItem('theme', JSON.stringify('dark'));
        }
        else {
            setTheme("light");
            localStorage.setItem('theme', JSON.stringify('light'));
        }
    }

    let listImes;

    if (context?.user?.username) {

        let userFavoriteProducts;
        if (context?.user.userFavoriteProducts?.length < 3) {
            userFavoriteProducts = context?.user?.userFavoriteProducts.map((product) => <UserFavoriteProducts product={product} key={product.id} />);
        }
        else {
            userFavoriteProducts = context?.user?.userFavoriteProducts.slice(0, 3).map((product) => <UserFavoriteProducts product={product} key={product.id} />);
        }
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
                            {context?.user?.userFavoriteProducts?.length > 3 && <div className="view-all-wrapper"><button onClick={() => navigate(`/FavoriteProducts/${context?.user?.id}`)} className="view-all-products">View All</button></div> }
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
                        <p className="user-products-count">{context.user?.cart?.cartProducts?.length === undefined ? 0 : context.user?.cart?.cartProducts?.length + context.user?.cart?.cartShoes?.length}</p>
                    </Link>
            </li>
            <li className="user-favorite-mobile"><Link to={`/FavoriteProducts/${context?.user?.id}`}>Favorite Products</Link></li>
            <li className="user-cart-mobile"><Link to="/Cart">Cart</Link></li>

                <li className="logout" onClick={onLogout}>Logout</li>
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
                <MobileNavigation/>
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
                    <li onClick={handleThemeChange} className="theme-icon"><i className={`${theme === 'dark' ? "fa-regular fa-moon" : "fa-regular fa-sun"}`}></i></li>
                    {listImes}
                </ul>
            </nav>
        </>
    );
}