import { useContext, useState } from 'react';
import { UserContext } from '../../../Contexts/UserContext';
import FormStyle from "../../Auth/FormStyle.css"
import { login } from "../../../services/authService";
import { useNavigate } from "react-router-dom";
import { FormProvider, useForm } from 'react-hook-form'
import { userNameInput, registerPasswordInput } from "../../../utilities/inputValidations";
import Input from "../Input/Input";
import InputError from "../InputError/InputError";

export default function Login() {

    let navigate = useNavigate();
    const methods = useForm();
    const { setUser } = useContext(UserContext);
    const [errorMessage, setErrorMessage] = useState(undefined);

    const handleOnLoginSubmit = methods.handleSubmit(data => {
        
        login(data)
            .then(res => {

                if (res.success) {
                    const user = {
                        username: res.username,
                        id: res.id,
                        userFavoriteProducts: res.userFavoriteProducts,
                        cart: res.cartModel,
                        roles: res.roles
                    };
                    setUser(user);
                    navigate('/Home');
                }
                setErrorMessage(res.error);
            })
            .catch(error => console.error(error));
    })

    return (
        <FormProvider {...methods}>
            <div className="auth-form-container">
                <h1 className="auth-form-title">Login</h1>
                <form className="auth-form" onSubmit={(event) => event.preventDefault()} method="post">
                    <Input {...userNameInput} />
                    <Input {...registerPasswordInput }/>
                    <button onClick={handleOnLoginSubmit} className="submit-btn" type="submit">Login</button>
                    {errorMessage && <InputError message={errorMessage} />}
                </form>
            </div>
       </FormProvider>
    )
}