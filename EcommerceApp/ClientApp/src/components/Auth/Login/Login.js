import { useContext } from 'react';
import { UserContext } from '../../../Contexts/UserContext';
import FormStyle from "../../Auth/FormStyle.css"
import { login } from "../../../services/authService";
import { useNavigate } from "react-router-dom";

export default function Login() {

    let navigate = useNavigate();
    const { user, setUser } = useContext(UserContext);

    function onInputFouc(event) {
        event.target.parentElement.children[0].classList.add("active-label");
    }
    function onInputBlur(event) {
        event.target.parentElement.children[0].classList.remove("active-label");
    }
    function onFormSubmit(event) {
        event.preventDefault();
        const formData = new FormData(event.currentTarget);

        const userInfoObject = {
            UserName: formData.get("username"),
            Password: formData.get("password"),
        }
        login(userInfoObject)
            .then(res => {
                const user = {
                    username: res.username,
                    id: res.id,
                    userFavoriteProducts: res.userFavoriteProducts,
                    cart: res.cartModel
                };
                setUser(user);
                navigate('/Home');

            })
            .catch(error => console.error(error));

    }

    return (
        <div className="auth-form-container">
            <h1 className="auth-form-title">Login</h1>
            <form className="auth-form" onSubmit={onFormSubmit} method="post">

                <section className="input-container">
                    <label htmlFor="username">Username</label>
                    <input name="username" onBlur={onInputBlur} onFocus={onInputFouc} id="username" type="text" autoComplete="username" aria-required="true" placeholder="Enter username..." />
                </section>
                <section className="input-container">
                    <label htmlFor="password">Password</label>
                    <input name="password" onBlur={onInputBlur} onFocus={onInputFouc} id="password" type="password" autoComplete="password" aria-required="true" placeholder="Enter password" />
                </section>
                <button className="submit-btn" type="submit">Login</button>
            </form>

        </div>
       
    )
}