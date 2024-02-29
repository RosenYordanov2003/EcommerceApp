import { useState, useEffect } from "react";
import { getAllMessages } from "../../../services/userMessageService";
import UserMessageCard from "../UserMessageCard/UserMessageCard";
import Style from "../AllUserMessages/Style.css";
import { HubConnectionBuilder } from '@microsoft/signalr';

export default function AllUserMessages() {

    const [messages, setMessages] = useState([]);
    const [connection, setConnection] = useState(null);

    useEffect(() => {
        getAllMessages()
            .then(res => {
                setMessages(res);
                const newConnection = new HubConnectionBuilder()
                    .withUrl('https://localhost:7122/notifications-hub')
                    .withAutomaticReconnect()
                    .build();
                setConnection(newConnection);
            })
            .catch(error => console.error(error));
    }, [])

    useEffect(() => {
        if (connection && connection?.state === "Disconnected") {
            connection.start()
                .then(() => {
                    connection.on('UserMessageSent', () => {
                        getAllMessages()
                            .then((res) => setMessages(res))
                            .catch((error) => console.error(error));
                    });
                })
                .catch(console.error);
        }
    }, [connection]);

    const messagesResult = messages.map((m) => <UserMessageCard key={m.id} userMessage={m}/>)

    return (
        <section className="user-messages">
            {messagesResult}
        </section>
    )
}