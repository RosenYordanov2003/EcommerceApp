import ContactContainerStyle from "../ContactContainer/ContactContainerStyle.css";
import Input from "../Auth/Input/Input";
import { FormProvider, useForm } from 'react-hook-form';
import { userMessageInput } from "../../utilities/inputValidations";

export default function ContactContainer() {

    const methods = useForm();

    const handleOnMessageSubmit = methods.handleSubmit(data => {
        console.log(data);
    })

    return (
        <div className = "contact-container">
            <div>
                <h2 className = "title">Contact Us</h2>
                <p>Send us an E-mail </p>
            </div>
            <FormProvider {...methods}>
                <form onSubmit={(event) => event.preventDefault()} className="contact-form">
                    <div className="contact-input-container">
                        <Input {...userMessageInput }/>
                        <button onClick={handleOnMessageSubmit} className="send-button">Send</button>
                    </div>
                        <i className="fa-regular message-icon fa-envelope"></i>
                </form>
            </FormProvider>
        </div>
    )

}