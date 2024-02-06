import { useState } from 'react';
import PoppupMessageStyle from '../PoppupMessage/PoppupMessageStyle.css';

export default function PoppupMessage({ message, removeNotification }) {

    const [isActive, setIsActive] = useState(true);

    function handleOnCloseNotification() {
        setIsActive(false);
        setTimeout(() => {
            removeNotification();
        }, 300)
    }

    return (
        <div className={`popup-container ${isActive == true ? "active" : ""}`}>
            <div className="popup-icon-container">
                <i className="fa-solid fa-check popup-icon"></i>
            </div>
            <h1>Success!</h1>
            <p>{message}</p>
            <button onClick={handleOnCloseNotification} className="close-button">Ok</button>
        </div>
    )
}