import { Link } from "react-router-dom";
import Style from "../Navigation/Style.css"

export default function Navigation() {

    function loadWomenCategories(event) {
        event.target.classList.toggle("active-arrow");
        
    }

    return (
        <nav>
            <h2 className = "nav-logo">Fashion Store</h2>
            <ul>
                <li>
                    <Link to = "/Home">Home</Link>
                </li>
                <li>
                    <Link to="/Men">Men</Link>
                </li>
                <li>
                    <Link to="/Men">Women <i onClick={loadWomenCategories} className="women-arrow down-arrow fa-solid fa-angle-down"></i></Link>
                </li>
                {/*<li>*/}
                {/*    <Link to="/Register">Sing Up</Link>*/}
                {/*</li>*/}
                {/*<li>*/}
                {/*    <Link to="/Login">Login</Link>*/}
                {/*</li>*/}
                {/*<li>*/}
                {/*    <Link to="/Logout">Logout</Link>*/}
                {/*</li>*/}
                <li>
                    <Link to="/Cart"><i className="fa-solid fa-cart-shopping"></i></Link>
                </li>
            </ul>
        </nav>
    )
}