import FormStyle from "../../Auth/FormStyle.css"
import { register } from "../../../services/authService";
import { useNavigate } from "react-router-dom";
import { useState } from "react";

export default function Register() {

    const navigate = useNavigate();

    const [inputObject, setInputObject] = useState({
        UserName: { value: '', error: false, errorMessage: '' },
        Email: { value: '', error: false, errorMessage: '' },
        Password: { value: '', error: false, errorMessage: '' },
        RepeatPassword: { value: '', error: false, errorMessage: '' }
    });

    function onInputFouc(event) {
        event.target.parentElement.children[0].classList.add("active-label");
    }
    function onInputBlur(event) {
        event.target.parentElement.children[0].classList.remove("active-label");
    }
    function onFormSubmit(event) {
        event.preventDefault();
        if (!validateInputObject()) {
            return;
        }
        register(inputObject)
            .then(() => navigate('/Login'))
            .catch((error) => console.error(error));
    }
    function validateInputObject() {
        let isValid = true;

        if (inputObject.UserName.value === '' || inputObject.UserName.value === ' ') {
            isValid = false;
            setInputObject({ ...inputObject, UserName: { ...inputObject.UserName, error: true, errorMessage: 'UserName is required!' } });
        }
        if (inputObject.Password.value === '') {
            isValid = false;
            setInputObject({ ...inputObject, Password: { ...inputObject.Password, error: true, errorMessage: 'Password is required!' } });
        }
        const passwordRegex = /\S{5,}/;
        if (!passwordRegex.test(inputObject.Password.value)) {
            isValid = false;
            setInputObject({ ...inputObject, Password: { ...inputObject.Password, error: true, errorMessage: 'Password must be at least 5 symbols' } });
        }
        if (inputObject.RepeatPassword.value !== inputObject.Password.value) {
            isValid = false;
            setInputObject({ ...inputObject, RepeatPassword: { ...inputObject.RepeatPassword, error: true, errorMessage: 'Repeat password does not match password field!'} });
        }
        console.log(inputObject);
        return isValid;
    }
    return (
        <div className="auth-form-container">

            <h1 className="auth-form-title">Register</h1>

            <form className="auth-form" onSubmit={onFormSubmit} method="post">

                <section className="input-container">
                    <label htmlFor="username">Username</label>
                    <input onChange={(e) => setInputObject({ ...inputObject, UserName: { ...inputObject.UserName, value: e.target.value, error: false } })} value={inputObject.UserName.value} name="username" id="username" onBlur={onInputBlur}
                        onFocus={onInputFouc} id="username" type="text" autoComplete="username" aria-required="true" placeholder="Enter username..." />
                    {inputObject.UserName.error && <span className="error-validation-message">{inputObject.UserName.errorMessage}</span>}
                </section>
                <section className="input-container">
                    <label htmlFor="email">Email</label>
                    <input onChange={(e) => setInputObject({ ...inputObject, Email: { ...inputObject.Email, value: e.target.value, error: false } })} name="email" id="email" onBlur={onInputBlur}
                        onFocus={onInputFouc} value={inputObject.Email.value} id="email" type="text" autoComplete="email"
                        aria-required="true" placeholder="Enter email..." />
                </section>
                <section className="input-container">
                    <label htmlFor="password">Password</label>
                    <input name="password" onChange={(e) => setInputObject({ ...inputObject, Password: { ...inputObject.Password, value: e.target.value, error: false } })} id="password" onBlur={onInputBlur} onFocus={onInputFouc} id="password" type="password"
                        autoComplete="password" value={inputObject.Password.value} aria-required="true" placeholder="Enter password" />
                    {inputObject.Password.error && <span className="error-validation-message">{inputObject.Password.errorMessage}</span>}
                </section>
                <section className="input-container">
                    <label htmlFor="confirm-password">Confirm Password</label>
                    <input name="confirm-password" id="confirm-password" onChange={(e) => setInputObject({ ...inputObject, RepeatPassword: { ...inputObject.RepeatPassword, value: e.target.value, error: false } })} onBlur={onInputBlur} onFocus={onInputFouc} id="confirm-password"
                        type="password" value={inputObject.RepeatPassword.value} placeholder="Repeat password..." aria-required="true" />
                    {inputObject.RepeatPassword.error && <span className="error-validation-message">{inputObject.RepeatPassword.errorMessage}</span>}
                </section>
                <button className="submit-btn" type="submit">Register</button>
            </form>

       </div>
       
    )
}