import NotificationStyle from "../Notification/NotificationStyle.css";
import { useState } from "react";

export default function Notification({ message, typeOfMessage, closeNotification }) {

    const [notificationObject, setNotificationObject] = useState({ isActive: true, isInProgress: true })

    let timeOutId = 0;
    let className = typeOfMessage == "Success" ? "notification-success" : "notification-error";
    function handleCloseNotification() {
        setNotificationObject({ isActive: false, isInProgress: false });
        clearTimeout(timeOutId);
        clearNotification();
    }
    if (notificationObject.isInProgress) {
        barProgress();
    }
    function barProgress() {
        timeOutId = setTimeout(() => {
            setNotificationObject({ isInProgress: false, isActive: false });
            clearNotification();
        }, 5000)
    }

    function clearNotification() {
        setTimeout(() => {
            closeNotification();
        }, 500)
    }

    return (
        <div className={`notification-container ${className} ${notificationObject.isActive == false ? "hide-notification" : "active-notification"}`}>
            {typeOfMessage == "Success" ? <i className="check fa-solid fa-circle-check success"></i> : <i className="fa-solid fa-circle-xmark error-mark"></i>}
            <p className="notification-message">{message}</p>
            <i onClick={handleCloseNotification} className="fa-solid fa-xmark close-mark"></i>
        </div>
    )
}