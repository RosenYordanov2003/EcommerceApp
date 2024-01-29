import { useState, useEffect } from "react";

import MobileButtonStyle from "./MobileButtonStyle.css";

export default function MobileNavigation() {

    const [status, setStatus] = useState('');

    function changeStatus() {
        if (status === 'not-visible') {
            setStatus('closed');
        }
        else if (status === 'closed') {
            setStatus('open');
        }
        else if(status === 'open') {
            setStatus('closed');
        }
    }

    useEffect(() => {
        setStatus('not-visible');
    },[])

    return (
        <div onClick={changeStatus} className={`menu-icon ${status}`}>
            <div className="first-bar menu-icon-bar"></div>
            <div className="second-bar menu-icon-bar"></div>
            <div className="third-bar menu-icon-bar"></div>
        </div>
    )
}