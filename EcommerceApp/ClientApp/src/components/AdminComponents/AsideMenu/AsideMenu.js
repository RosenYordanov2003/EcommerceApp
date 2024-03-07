import { useState, useContext, useEffect } from "react";
import { logout } from "../../../services/authService";
import { useNavigate } from "react-router-dom";
import { UserContext } from "../../../Contexts/UserContext";
import "../AsideMenu/AsideMenuStyle.css";
import { HubConnectionBuilder } from '@microsoft/signalr';
import {getMessageCount} from "../../../services/userMessageService";

export default function AsideMenu() {

    const [activeElementIndex, setActiveElementIndex] = useState(undefined);
    const [connection, setConnection] = useState(null);
    const [messageCount, setMessageCount] = useState(0);
    const { setUser } = useContext(UserContext);
    const navigate = useNavigate();

    useEffect(() => {
        getMessageCount()
            .then(res => {
                setMessageCount(res);
                const newConnection = new HubConnectionBuilder()
                    .withUrl('https://localhost:7122/notifications-hub')
                    .withAutomaticReconnect()
                    .build();
                setConnection(newConnection);
            })
    }, [])

    useEffect(() => {
        if (connection) {
            connection.start()
                .then(() => {
                    connection.on('UserMessageCountChanged', () => {
                        getMessageCount()
                        .then(res => setMessageCount(res))
                    });
                })
                .catch(console.error);
        }
    }, [connection]);

    function handleLogout() {
        logout()
            .then(() => {
                setUser(undefined);
                navigate("/Home");
            })
            .catch((error) => console.error(error));
    }
    function setActiveIndex(index, navigationPath) {
        setActiveElementIndex(index);
        navigate(navigationPath);
    }

    return (
        <aside>
            <h2 className="nav-logo aside-logo">Fashion Store</h2>
            <div className="asside-wrapper">
                <div onClick={() => setActiveIndex(0, '/Dashboard')} className={`icon-container ${activeElementIndex === 0 ?"active-icon-container" : ""}`}>
                    <span className="material-symbols-outlined">
                        dashboard
                    </span>
                    <p className="icon-text-content">Dashboard</p>
                </div>
                <div onClick={() => setActiveIndex(1, '/Clothes')} className={`icon-container ${activeElementIndex === 1 ? "active-icon-container" : ""}`}>
                    <span className="material-symbols-outlined">
                        apparel
                    </span>
                    <p className="icon-text-content">Clothes</p>
                </div>
                <div onClick={() => setActiveIndex(2, '/Shoes')} className={`icon-container ${activeElementIndex === 2 ? "active-icon-container" : ""}`}>
                    <span className="material-symbols-outlined">
                        podiatry
                    </span>
                    <p className="icon-text-content">Shoes</p>
                </div>
                <div onClick={() => setActiveElementIndex(3)} className={`icon-container ${activeElementIndex === 3 ? "active-icon-container" : ""}`}>
                    <span className="material-symbols-outlined">
                        person
                    </span>
                    <p className="icon-text-content">Customers</p>
                </div>
                <div onClick={() => setActiveIndex(4, '/Create')} className={`icon-container ${activeElementIndex === 4 ? "active-icon-container" : ""}`}>
                    <span className="material-symbols-outlined">
                        add
                    </span>
                    <p className="icon-text-content">Add Product</p>
                </div>
                <div onClick={() => setActiveIndex(5, '/Messages')} className={`icon-container ${activeElementIndex === 5 ? "active-icon-container" : ""}`}>
                    <span className="material-symbols-outlined">
                        mail
                    </span>
                    <p className="messages-count">{messageCount}</p>
                     <p className="icon-text-content">Messages</p>
                </div>
                <div onClick={handleLogout} className="icon-container">
                    <span className="material-symbols-outlined">
                        logout
                    </span>
                    <p className="icon-text-content">Logout</p>
                </div>
            </div>
        </aside>
    )
}