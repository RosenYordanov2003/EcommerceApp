import ContactContainerStyle from "../ContactContainer/ContactContainerStyle.css";


export default function ContactContainer() {


    return (
        <div className = "contact-container">
            <div>
                <h2 className = "title">Contact Us</h2>
                <p>Send us an E-mail </p>
            </div>
            <form className = "contact-form">
                <input className = "contact-input" type="text">

                </input>
                 <i className="fa-regular message-icon fa-envelope"></i>
                <button className = "send-button">Send</button>
            </form>
        </div>
    )

}