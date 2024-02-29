import Style from "../DialogContainer/Style.css";
import { useEffect, useState } from "react";

export default function DialogContainer({onAgreement, onCancel }) {
    const [isActive, setIsActive] = useState(false);

    useEffect(() => {
        setTimeout(() => {
            setIsActive(true);
        }, 50)
    }, [])

    function handleOnCancel() {
        setIsActive(false);
        onCancel();
    }
    function handleOnAgreement() {
        setIsActive(false);
        onAgreement();
    }

    return (
        <div className={`dialog-container ${isActive && "active-dialog-container"}`}>
            <h2 className="dialog-title">Are you sure, that you want to perform this action?</h2>
            <section className="dialog-actions">
                <button onClick={handleOnAgreement} className="dialog-button">Yes</button>
                <button onClick={handleOnCancel} className="dialog-button">No</button>
            </section>
        </div>
    )
}