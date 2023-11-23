import FormStyle from "../../Auth/FormStyle.css"
import { register } from "../../../services/authService";

export default function Register() {

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
            Email: formData.get("email"),
            Password: formData.get("password"),
            RepeatPassword: formData.get("confirm-password"),
        }
        register(userInfoObject)
            .then(res => console.log(res))
            .catch((error) => console.error(error));
    }
    return (
        <form onSubmit={onFormSubmit } className="register-form" method="post">
         
            <section className="input-container">
                <label htmlFor = "username">Username</label>
                <input name = "username" onBlur={onInputBlur} onFocus={onInputFouc} id= "username" type="text" autoComplete="username" aria-required="true" placeholder="Enter username..." />
            </section>
            <section className="input-container">
                <label htmlFor = "email">Email</label>
                <input name="email" onBlur={onInputBlur} onFocus={onInputFouc} id="email" type="text" autoComplete="email" aria-required="true" placeholder="Enter email..." />
            </section>
            <section className="input-container">
                <label htmlFor = "password">Password</label>
                <input name="password" onBlur={onInputBlur} onFocus={onInputFouc} id="password" type="password" autoComplete="password" aria-required="true" placeholder="Enter password" />
            </section>
            <section className="input-container">
                <label htmlFor = "confirm-password" >Confirm Password</label>
                <input name = "confirm-password" onBlur={onInputBlur} onFocus={onInputFouc} id = "confirm-password" type="password" placeholder="Repeat password..." aria-required="true"  />
            </section>
            <button className="submit-btn" type="submit">Register</button>
        </form>
    )
}