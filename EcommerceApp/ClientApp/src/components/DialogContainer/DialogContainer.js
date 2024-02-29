import Style from "../DialogContainer/Style.css";
import { useEffect, useState } from "react";

export default function DialogContainer() {
    const [isActive, setIsActive] = useState(false);

    useEffect(() => {
        setTimeout(() => {
            setIsActive(true);
        }, 50)
    }, [])


    return (
        <div className={`dialog-container ${isActive && "active-dialog-container"}`}>
            <h2 className="dialog-title">Are you sure, that you want to perform this action?</h2>
            <section className="dialog-actions">
            <button className="dialog-button">Yes</button>
            <button className="dialog-button">No</button>
            </section>
        </div>
    )
}