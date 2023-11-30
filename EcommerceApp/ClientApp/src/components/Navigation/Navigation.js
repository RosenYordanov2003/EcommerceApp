import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { useContext } from 'react';
import { UserContext } from "../../Contexts/UserContext";
import { Link } from "react-router-dom";
import Style from "../Navigation/Style.css"
import { logout } from "../../services/authService";

export default function Navigation({ loadCategories, setIsActive }) {

    const navigate = useNavigate();
    const { user, setUser } = useContext(UserContext);

    const baseUrl = "https://localhost:7122/api/categories";

    const [isMenArrowActive, setIsMenArrowActive] = useState(false);
    const [isWomenArrowActive, setIsWomenArrowActive] = useState(false);

    function handleToggleMenCategories() {
        setIsMenArrowActive(!isMenArrowActive);
        if (isMenArrowActive) {
            setIsActive(false);
        }
        else {
            setIsActive(true);
            loadCategoriesByGender("m");
        }

        setIsWomenArrowActive(false);
    }

    function handleToggleWomenCategories() {
        setIsWomenArrowActive(!isWomenArrowActive);
        if (isWomenArrowActive) {
            setIsActive(false);
        }
        else {
            setIsActive(true);
            loadCategoriesByGender("w");
        }

        setIsMenArrowActive(false);
    }

    function loadCategoriesByGender(gender) {
        fetch(`${baseUrl}?gender=${gender}`)
            .then((res) => res.json())
            .then((res) => {
                loadCategories(res);
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
            <li onClick={onLogout}>
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
        <nav>
            <h2 className="nav-logo">Fashion Store</h2>
            <ul>
                <li>
                    <Link to="">
                        Men{" "}
                        <i
                            onClick={handleToggleMenCategories}
                            className={`men-arrow down-arrow fa-solid fa-angle-down ${isMenArrowActive ? "active-arrow" : "not-active-arrow"
                                }`}
                        ></i>
                    </Link>
                </li>
                <li>
                    <Link to="">
                        Women{" "}
                        <i
                            onClick={handleToggleWomenCategories}
                            className={`women-arrow down-arrow fa-solid fa-angle-down ${isWomenArrowActive ? "active-arrow" : ""
                                }`}
                        ></i>
                    </Link>
                </li>
                {listImes}
            </ul>
        </nav>
    );
}