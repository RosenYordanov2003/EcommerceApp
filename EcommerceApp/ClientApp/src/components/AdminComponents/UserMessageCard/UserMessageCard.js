import { useState, useContext } from "react";
import Style from "../UserMessageCard/Style.css";
import PopupTextArea from "../UserMessageCard/PopupTextArea/PopupTextArea";
import { UserContext } from "../../../Contexts/UserContext";
import { responToUserMessage } from "../../../services/userMessageService";
export default function UserMessageCard({ userMessage }) {

    const [popupTextArea, setPopupTextArea] = useState(undefined);
    const { user } = useContext(UserContext);

    function closePopupTextArea() {
        setTimeout(() => {
            setPopupTextArea(undefined);
        }, 470)
    }
    function sendMessage(message) {
        const object = {
            message: userMessage.message,
            messageId: userMessage.id,
            responseMessage: message,
            userId: user.id
        };
        responToUserMessage(object)
            .then(() => {
                closePopupTextArea();
            })
            .catch((error) => console.error(error));
        
    }


    return (
        <>
            {popupTextArea !== undefined ? popupTextArea : ''}
            <article className="user-message-card">
                <div className="user-message-header">
                    <h3>{userMessage.username}</h3>
                    <p>3h ago</p>
                </div>
                <p className="user-message-content">{userMessage.message}</p>
                <section className="actions-container">
                    <div onClick={() => setPopupTextArea(<PopupTextArea handleOnCloseFunction={closePopupTextArea} handleOnSendFunction={sendMessage} username={userMessage.username} />)} className="action">
                        <i className="fa-solid fa-reply"></i>
                        <button className="action-button">Reply</button>
                    </div>
                    <div className="action">
                        <i className="fa-solid fa-trash"></i>
                        <button className="action-button">Delete</button>
                    </div>
                </section>
            </article>
        </>

    )
}