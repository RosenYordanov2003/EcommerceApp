import { useContext, useState, useEffect } from "react";
import { UserContext } from "../../../Contexts/UserContext";
import { Link } from "react-router-dom";
import { useNavigate } from "react-router-dom";
import { logout } from "../../../services/authService";
import MobileNavStyle from "../MobileNavigation/MobileNavStyle.css";

export default function MobileNavigation() {

    const { user, setUser } = useContext(UserContext);
    const navigate = useNavigate();

    const [isOpen, setIsOpen] = useState(true);

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

    function onLogout() {
        logout()
            .then(() => {
                setUser({});
                navigate("/");
            })
            .catch(error => console.error(error))
    }
   

    return (
        <>
        <nav className="mobile-nav">
                <div onClick={() => setIsOpen(!isOpen)} className={`menu-icon ${isOpen === true ? 'open' : 'closed'}`}>
                    <div className="first-bar menu-icon-bar"></div>
                    <div className="second-bar menu-icon-bar"></div>
                    <div className="third-bar menu-icon-bar"></div>
                </div>
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
                    <li onClick={handleThemeChange} className="theme-item"><i className={`${theme === 'dark' ? "fa-regular fa-moon" : "fa-regular fa-sun"}`}></i></li>
                {user !== undefined ?
                    <>
                        <li>
                            <Link to="/Gender/women">
                                Favorite Products
                            </Link>
                        </li>

                        <li>
                            <Link to="/Cart">
                                Cart
                            </Link>
                        </li>
                        <li className="logout" onClick={onLogout}>
                            Logout
                        </li>
                    </>
                    :
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
            </ul>
        </nav>
        </>
    )
}