import { useState, useEffect } from "react";
import { getAllMessages } from "../../../services/userMessageService";
import UserMessageCard from "../UserMessageCard/UserMessageCard";
import Style from "../AllUserMessages/Style.css";

export default function AllUserMessages() {

    const [messages, setMessages] = useState([]);

    useEffect(() => {
        getAllMessages()
            .then(res => setMessages(res))
            .catch(error => console.error(error));
    }, [])

    const messagesResult = messages.map((m) => <UserMessageCard key={m.id} userMessage={m}/>)

    return (
        <section className="user-messages">
            {messagesResult}
        </section>
    )
}