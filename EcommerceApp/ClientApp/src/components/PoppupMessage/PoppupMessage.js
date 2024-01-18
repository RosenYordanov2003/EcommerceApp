import { useState } from 'react';
import PoppupMessageStyle from '../PoppupMessage/PoppupMessageStyle.css';

export default function PoppupMessage({ message }) {

    const [isActive, setIsActive] = useState(true);


    return (
        <div className={`popup-container ${isActive == true ? "active" : ""}`}>
            <div className="icon-container">
                <i className="fa-solid fa-check popup-icon"></i>
            </div>
            <h1>Success!</h1>
            <p>{message}</p>
            <button onClick={() => setIsActive(false)} className="close-button">Ok</button>
        </div>
    )
}