import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { useContext } from 'react';
import { UserContext } from "../../Contexts/UserContext";
import { Link } from "react-router-dom";
import Style from "../Navigation/Style.css"
import { logout } from "../../services/authService";
import CategoriesSection from "../Categories/CategoriesSection";

export default function Navigation() {

    const baseUrl = "https://localhost:7122/api/categories";
    const navigate = useNavigate();
    const { user, setUser } = useContext(UserContext);
    const [categories, setCategories] = useState([]);
    const [isActive, setActivity] = useState(true);


    const [isMenArrowActive, setIsMenArrowActive] = useState(false);
    const [isWomenArrowActive, setIsWomenArrowActive] = useState(false);

    function handleToggleMenCategories() {
        setIsMenArrowActive(!isMenArrowActive);
        if (isMenArrowActive) {
            setActivity(false);
        }
        else {
            setActivity(true);
            loadCategoriesByGender("m");
        }

        setIsWomenArrowActive(false);
    }

    function handleToggleWomenCategories() {
        setIsWomenArrowActive(!isWomenArrowActive);
        if (isWomenArrowActive) {
            setActivity(false);
        }
        else {
            setActivity(true);
            loadCategoriesByGender("w");
        }

        setIsMenArrowActive(false);
    }

    function loadCategoriesByGender(gender) {
        fetch(`${baseUrl}?gender=${gender}`)
            .then((res) => res.json())
            .then((res) => {
                setCategories(res);
            })
            .catch((error) => console.error(error));
    }

    let listImes;
    if (user) {
        listImes =
            <>
                <li>{user}</li>
                <li>
                    <Link to="/Cart">
                        <i className="fa-solid fa-cart-shopping"></i>
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
                setUser(undefined);
                navigate("/");
            })
            .catch(error => console.error(error))
    }

    return (
        <>
            <nav className = "main-nav">
                <h2 className="nav-logo">Fashion Store</h2>
                <ul>
                    <li>

                        <Link to="/Gender/men">
                            Men{" "}
                        </Link>
                        <i
                            onClick={handleToggleMenCategories}
                            className={`men-arrow down-arrow fa-solid arrow fa-angle-down ${isMenArrowActive ? "active-arrow" : "not-active-arrow"
                            }`}
                        ></i>
                    </li>
                    <li>
                        <Link to= "/Gender/women">
                            Women{" "}
                        </Link>
                        <i
                            onClick={handleToggleWomenCategories}
                            className={`women-arrow down-arrow arrow fa-solid fa-angle-down ${isWomenArrowActive ? "active-arrow" : ""
                                }`}
                        ></i>
                    </li>
                    {listImes}
                </ul>
            </nav>
            {categories.length > 0 ? <CategoriesSection categories={categories} isActive={isActive} /> : ""}
        </>
    );
}