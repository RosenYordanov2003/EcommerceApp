import { Link } from "react-router-dom";
import Style from "../Navigation/Style.css"
import { useState } from "react";

export default function Navigation({ loadCategories, setIsActive }) {
    const baseUrl = "https://localhost:7122/api/categories";

    const [isMenArrowActive, setIsMenArrowActive] = useState(false);
    const [isWomenArrowActive, setIsWomenArrowActive] = useState(false);

    function toggleMenCategories() {
        setIsMenArrowActive(!isMenArrowActive);
        if (isMenArrowActive) {
            setIsActive(false);
        } else {
            setIsActive(true);
            loadCategoriesByGender("m");
        }
      
        setIsWomenArrowActive(false);
    }

    function toggleWomenCategories() {
        setIsWomenArrowActive(!isWomenArrowActive);
        if (isWomenArrowActive) {
            setIsActive(false);
        } else {
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

    return (
        <nav>
            <h2 className="nav-logo">Fashion Store</h2>
            <ul>
                <li>
                    <Link to="/Home">
                        Men{" "}
                        <i
                            onClick={toggleMenCategories}
                            className={`men-arrow down-arrow fa-solid fa-angle-down ${isMenArrowActive ? "active-arrow" : "not-active-arrow"
                                }`}
                        ></i>
                    </Link>
                </li>
                <li>
                    <Link to="Home">
                        Women{" "}
                        <i
                            onClick={toggleWomenCategories}
                            className={`women-arrow down-arrow fa-solid fa-angle-down ${isWomenArrowActive ? "active-arrow" : ""
                                }`}
                        ></i>
                    </Link>
                </li>
                <li>
                    <Link to="/Cart">
                        <i className="fa-solid fa-cart-shopping"></i>
                    </Link>
                </li>
            </ul>
        </nav>
    );
}