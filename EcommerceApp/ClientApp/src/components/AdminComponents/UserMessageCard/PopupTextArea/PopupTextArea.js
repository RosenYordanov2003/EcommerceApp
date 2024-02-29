import Style from "../PopupTextArea/Style.css";
import { useEffect, useState } from "react";

export default function PopupTextArea({ handleOnCloseFunction, handleOnSendFunction, username }) {

    const [message, setMessage] = useState('');
    const [isActive, setIsActive] = useState(false);

    useEffect(() => {
        setTimeout(() => {
            setIsActive(true);
        }, 50)
    }, [])
    function handleOnCloseNotification() {
        setIsActive(false);
        handleOnCloseFunction();
    }
    function handleOnSendClick() {
        handleOnCloseNotification();
        handleOnSendFunction(message);
    }
   

    return (
        <section className={`popup-text-area-container ${isActive === true ? 'active-text-area' : ''}`}>
            <h2 className="username-response-title">Reply to: {username}</h2>
            <i onClick={handleOnCloseNotification} className="fa-solid fa-xmark close-text-area"></i>
            <textarea onChange={(e) => setMessage(e.target.value)}></textarea>
            <button className="send-message-to-user" onClick={handleOnSendClick}>Send</button>
        </section>
    )
}