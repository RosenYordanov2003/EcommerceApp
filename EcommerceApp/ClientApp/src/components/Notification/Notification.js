import NotificationStyle from "../Notification/NotificationStyle.css";
import { useState } from "react";

export default function Notification({ message, typeOfMessage }) {

    const [isActive, setIsActive] = useState(true);

    let className = typeOfMessage == "Success" ? "notification-success" : "notification-error";
    function handleCloseNotification() {
        setIsActive(false);
    }
    return (
        <div className={`notification-container ${className} ${isActive == false ? "hide-notification" : "active-notification"}`}>
            {typeOfMessage == "Success" ? <i className="check fa-solid fa-circle-check success"></i> : <i className="fa-solid fa-circle-xmark error-mark"></i>}
            <p className="notification-message">{message}</p>
            <i onClick={handleCloseNotification} className="fa-solid fa-xmark close-mark"></i>
        </div>
    )
}