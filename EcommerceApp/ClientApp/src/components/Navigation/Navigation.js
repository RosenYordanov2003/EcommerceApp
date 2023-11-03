import { Link } from "react-router-dom";
import Style from "../Navigation/Style.css"


export default function Navigation({ loadCategories, setIsActive }) {

    const baseUrl = "https://localhost:7122/api/categories"
    function loadWomenCategories(event) {
        event.target.classList.toggle("active-arrow");
        if (event.target.classList.contains("active-arrow")) {
            const genderQyeryParam = event.target.classList.contains('women-arrow') ? 'w' : 'm';

            fetch(`${baseUrl}?gender=${genderQyeryParam}`)
                .then(res => res.json())
                .then(res => {
                    loadCategories(res);
                    setIsActive(true);
                })
            .catch((error) => console.error(error));
        }
        else {
            setIsActive(false);
        }
    }
    return (
        <nav>
            <h2 className = "nav-logo">Fashion Store</h2>
            <ul>
                <li>
                    <Link to="/Home">Men<i onClick={loadWomenCategories} className="men-arrow down-arrow fa-solid fa-angle-down"></i></Link>
                </li>
                <li>
                    <Link to="Home">Women <i onClick={loadWomenCategories} className="women-arrow down-arrow fa-solid fa-angle-down"></i></Link>
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