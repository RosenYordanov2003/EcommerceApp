import FormStyle from "../../Auth/FormStyle.css"
import { register } from "../../../services/authService";
import { useNavigate } from "react-router-dom";
import { useState } from "react";
import Input from "../Input/Input";
import { userNameInput, registerPasswordInput, repeatPasswordInput, emailInput } from "../../../utilities/inputValidations";
import { FormProvider, useForm } from 'react-hook-form'

export default function Register() {
    const methods = useForm();
    const navigate = useNavigate();
    const onSubmit = methods.handleSubmit(data => {
        register(data)
            .then(() => navigate("/Login"))
            .catch((error) => console.error(error));
    })
  
    return (
        <FormProvider {...methods }>
            <div className="auth-form-container">


                <form noValidate className="auth-form" onSubmit={(event) => event.preventDefault()} method="post">

                    <Input {...userNameInput }/>
                    <Input {...emailInput } />
                    <Input {...registerPasswordInput } />
                    <Input {...repeatPasswordInput } />
                    <button onClick={onSubmit} className="submit-btn" type="submit">Register</button>
                </form>

            </div>
       </FormProvider>
    )
}