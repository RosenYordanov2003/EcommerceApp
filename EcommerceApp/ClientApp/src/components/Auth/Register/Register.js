import "../../Auth/FormStyle.css"
import "../../Auth/FormStyleResponsive.css"
import { register } from "../../../services/authService";
import { useNavigate } from "react-router-dom";
import { useState } from "react";
import Input from "../Input/Input";
import InputError from "../InputError/InputError";
import { userNameInput, registerPasswordInput, repeatPasswordInput, emailInput } from "../../../utilities/inputValidations";
import { FormProvider, useForm } from 'react-hook-form'

export default function Register() {
    const methods = useForm();
    const navigate = useNavigate();
    const [errorObject, setErrorObject] = useState(undefined);

    const onSubmit = methods.handleSubmit(data => {

        if (data.password !== data.repeatPassword) {
            setErrorObject({ ...errorObject, errorMessage: 'Repeat password does not match password value' });
            return;
        }

        register(data)
            .then((res) => {
                if (res.success) {
                    navigate("/Login");
                }
                if (res.errorMessage) {
                    setErrorObject({ ...errorObject, errorMessage: res.errorMessage });
                }
                if (res.errors.length > 0) {
                    setErrorObject({ ...errorObject, errors: res.errors });
                }
            })
            .catch((error) => console.error(error));
    })

    return (
        <FormProvider {...methods}>
            <div className="auth-form-container">
                <h1 className="auth-form-title">Registrer</h1>
                <form noValidate className="auth-form" onSubmit={(event) => event.preventDefault()} method="post">

                    <Input {...userNameInput} />
                    <Input {...emailInput} />
                    <Input {...registerPasswordInput} />
                    <Input {...repeatPasswordInput} />
                    <button onClick={onSubmit} className="submit-btn" type="submit">Register</button>
                    {errorObject?.errorMessage && <InputError message={errorObject?.errorMessage}/>}
                </form>

            </div>
        </FormProvider>
    )
}