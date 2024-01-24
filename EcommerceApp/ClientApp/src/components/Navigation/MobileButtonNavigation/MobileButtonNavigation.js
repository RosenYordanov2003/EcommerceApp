import { useState } from "react";

import MobileButtonStyle from "./MobileButtonStyle.css";

export default function MobileNavigation() {

    const [isOpen, setIsOpen] = useState(false);


    return (
        <div onClick={() => setIsOpen(!isOpen)} className={`menu-icon ${isOpen === true ? 'open' : 'closed'}`}>
            <div className="first-bar menu-icon-bar"></div>
            <div className="second-bar menu-icon-bar"></div>
            <div className="third-bar menu-icon-bar"></div>
        </div>
    )
}