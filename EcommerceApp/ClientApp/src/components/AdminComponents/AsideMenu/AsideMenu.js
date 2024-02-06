import { useState, useContext } from "react";
import { logout } from "../../../services/authService";
import { useNavigate } from "react-router-dom";
import { UserContext } from "../../../Contexts/UserContext";
import AsideMenuStyle from "../AsideMenu/AsideMenuStyle.css";

export default function AsideMenu() {

    const [activeElementIndex, setActiveElementIndex] = useState(undefined);
    const { user, setUser } = useContext(UserContext);
    const navigate = useNavigate();

    function handleLogout() {
        logout()
            .then(() => {
                setUser(undefined);
                navigate("/Home");
            })
            .catch((error) => console.error(error));
    }
    function setActiveIndex(index, navigationPath) {
        setActiveElementIndex(index);
        navigate(navigationPath);
    }

    return (
        <aside>
            <h2 className="nav-logo aside-logo">Fashion Store</h2>
            <div className="asside-wrapper">
                <div onClick={() => setActiveIndex(0, '/Dashboard')} className={`icon-container ${activeElementIndex === 0 ?"active-icon-container" : ""}`}>
                    <span className="material-symbols-outlined">
                        dashboard
                    </span>
                    <p className="icon-text-content">Dashboard</p>
                </div>
                <div onClick={() => setActiveIndex(1, '/Clothes')} className={`icon-container ${activeElementIndex === 1 ? "active-icon-container" : ""}`}>
                    <span className="material-symbols-outlined">
                        apparel
                    </span>
                    <p className="icon-text-content">Clothes</p>
                </div>
                <div onClick={() => setActiveElementIndex(2)} className={`icon-container ${activeElementIndex === 2 ? "active-icon-container" : ""}`}>
                    <span className="material-symbols-outlined">
                        podiatry
                    </span>
                    <p className="icon-text-content">Shoes</p>
                </div>
                <div onClick={() => setActiveElementIndex(3)} className={`icon-container ${activeElementIndex === 3 ? "active-icon-container" : ""}`}>
                    <span className="material-symbols-outlined">
                        person
                    </span>
                    <p className="icon-text-content">Customers</p>
                </div>
                <div onClick={() => setActiveElementIndex(4)} className={`icon-container ${activeElementIndex === 4 ? "active-icon-container" : ""}`}>
                    <span className="material-symbols-outlined">
                        add
                    </span>
                    <p className="icon-text-content">Add Product</p>
                </div>
                <div onClick={handleLogout} className="icon-container">
                    <span className="material-symbols-outlined">
                        logout
                    </span>
                    <p className="icon-text-content">Logout</p>
                </div>
            </div>
        </aside>
    )
}