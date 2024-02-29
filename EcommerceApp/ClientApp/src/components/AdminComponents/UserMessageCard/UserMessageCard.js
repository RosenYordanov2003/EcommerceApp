import { useState, useContext } from "react";
import Style from "../UserMessageCard/Style.css";
import PopupTextArea from "../UserMessageCard/PopupTextArea/PopupTextArea";
import { UserContext } from "../../../Contexts/UserContext";
import { responToUserMessage } from "../../../services/userMessageService";
import CircleSpinner from "../../CircleSpinner/CircleSpinner";
import PoppupMessage from "../../PoppupMessage/PoppupMessage";
import DialogContainer from "../../DialogContainer/DialogContainer";

export default function UserMessageCard({ userMessage }) {
    const [popupMessage, setPopupMessage] = useState(undefined);
    const [spinner, setSpinner] = useState(undefined);
    const { user } = useContext(UserContext);

    function closePopupTextArea() {
        setTimeout(() => {
            setPopupMessage(undefined);
        }, 500)
    }
    function sendMessage(message) {
        const object = {
            message: userMessage.message,
            messageId: userMessage.id,
            responseMessage: message,
            userId: user.id
        };
        setSpinner(<CircleSpinner />);
        responToUserMessage(object)
            .then(() => {
                setSpinner(undefined);
                setPopupMessage(<PoppupMessage message="Your respond has been successfully sent" removeNotification={() => setPopupMessage(undefined)} />);
            })
            .catch((error) => console.error(error));
    }

    return (
        <>
            {spinner !== undefined && spinner}
            {popupMessage !== undefined ? popupMessage : ''}
            <article className="user-message-card">
                <div className="user-message-header">
                    <h3>{userMessage.username}</h3>
                    <p>3h ago</p>
                </div>
                <p className="user-message-content">{userMessage.message}</p>
                <section className="actions-container">
                    <div onClick={() => setPopupMessage(<PopupTextArea handleOnCloseFunction={closePopupTextArea} handleOnSendFunction={sendMessage} username={userMessage.username} />)} className="action">
                        <i className="fa-solid fa-reply"></i>
                        <button className="action-button">Reply</button>
                    </div>
                    <div className="action">
                        <i className="fa-solid fa-trash"></i>
                        <button onClick={() => setPopupMessage(<DialogContainer/>)} className="action-button">Delete</button>
                    </div>
                </section>
            </article>
        </>
    )
}