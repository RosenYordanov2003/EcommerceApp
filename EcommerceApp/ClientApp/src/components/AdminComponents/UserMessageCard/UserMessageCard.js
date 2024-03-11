import { useState, useContext } from "react";
import "../UserMessageCard/Style.css";
import PopupTextArea from "../UserMessageCard/PopupTextArea/PopupTextArea";
import { UserContext } from "../../../Contexts/UserContext";
import { responToUserMessage, deleteUserMessage } from "../../../services/userMessageService";
import CircleSpinner from "../../CircleSpinner/CircleSpinner";
import PoppupMessage from "../../PoppupMessage/PoppupMessage";
import DialogContainer from "../../DialogContainer/DialogContainer";
import { getTimeDifference} from "../../../utilities/timeDifference";

export default function UserMessageCard({ userMessage, handleOnDeleteMessage, handleOnMessageResponse }) {
    const [popupMessage, setPopupMessage] = useState(undefined);
    const [spinner, setSpinner] = useState(undefined);
    const { user } = useContext(UserContext);

    function closePopupMessage() {
        setTimeout(() => {
            setPopupMessage(undefined);
        }, 500)
    }

   /* const result = getTimeDifference(userMessage.createdOn);*/
 
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
                setPopupMessage(<PoppupMessage message="Your respond has been successfully sent" removeNotification={() => {
                    setPopupMessage(undefined);
                    handleOnMessageResponse(userMessage.id)
                }}
                />);
            })
            .catch((error) => console.error(error));
    }
    function handleOnDeleteAgreement() {
        setTimeout(() => {
            setPopupMessage(undefined);
            deleteMessageRequest();
        }, 500)

    }
    function deleteMessageRequest() {
        setSpinner(<CircleSpinner />);
        const id = userMessage.id;
        deleteUserMessage(id)
            .then(() => {
                setSpinner(undefined);
                setPopupMessage(<PoppupMessage message="Your have successfully deleted a message" removeNotification={() => {
                    setPopupMessage(undefined);
                    handleOnDeleteMessage(id);
                }} />);
            })
            .catch((error) => console.error(error));
    }

    return (
        <>
            {spinner !== undefined && spinner}
            {popupMessage !== undefined ? popupMessage : ''}
            <article className={`user-message-card ${userMessage.isResponded && "responded"}`}>
                <div className="user-message-header">
                    <h3>{userMessage.username}</h3>
                    <p>{userMessage.elapsedTime}</p>
                </div>
                <p className="user-message-content">{userMessage.message}</p>
                <section className="actions-container">
                    <div onClick={() => setPopupMessage(<PopupTextArea handleOnCloseFunction={closePopupMessage} handleOnSendFunction={sendMessage} username={userMessage.username} />)} className="action">
                        <i className="fa-solid fa-reply"></i>
                        <button className="action-button">Reply</button>
                    </div>
                    <div onClick={() => setPopupMessage(<DialogContainer onCancel={closePopupMessage} onAgreement={handleOnDeleteAgreement} />)} className="action">
                        <i className="fa-solid fa-trash"></i>
                        <button className="action-button">Delete</button>
                    </div>
                </section>
            </article>
        </>
    )
}