import { useState, useEffect } from "react";
import { getAllMessages } from "../../../services/userMessageService";
import UserMessageCard from "../UserMessageCard/UserMessageCard";
import Style from "../AllUserMessages/Style.css";
import Pager from "../../Pager/Pager";
import { Grid } from 'react-loader-spinner';
import { HubConnectionBuilder } from '@microsoft/signalr';

export default function AllUserMessages() {

    const [messages, setMessages] = useState([]);
    const [connection, setConnection] = useState(null);
    const [pageObject, setPageObject] = useState(undefined);
    const [isLoading, setIsLoading] = useState(false);
    const [currentPage, setCurrentPage] = useState(1);


    useEffect(() => {
        const newConnection = new HubConnectionBuilder()
            .withUrl('https://localhost:7122/notifications-hub')
            .withAutomaticReconnect()
            .build();
        setConnection(newConnection);
    }, [])

    useEffect(() => {
        getAllMessages(currentPage)
            .then(res => {
                setMessages(res.messages);
                setPageObject(res.pagerObject)
            })
            .catch(error => console.error(error));
    }, [currentPage])


    useEffect(() => {
        if (connection) {
            connection.start()
                .then(() => {
                    connection.on('UserMessagesModification', () => {
                        getAllMessages(currentPage)
                            .then((res) => {
                                setMessages(res.messages);
                                setPageObject(res.pagerObject);
                            })
                            .catch((error) => console.error(error));
                    });
                })
                .catch(console.error);
        }
    }, [connection]);

    const messagesResult = messages.map((m) => <UserMessageCard handleOnDeleteMessage={handleOnDeleteMessage} key={m.id} userMessage={m} />);

    function handleOnDeleteMessage(messageId) {
        const filteredMessages = messages.filter((message) => message.id !== messageId);
        setMessages(filteredMessages);
        if (filteredMessages.length == 0 && currentPage - 1 > 0) {
            setCurrentPage(currentPage - 1);
        }
    }

    function handleOnPageNumberChange(newPageNumber) {
        setCurrentPage(newPageNumber);
        configureLoading();
    }
    function configureLoading() {
        setIsLoading(true);
        setTimeout(() => {
            setIsLoading(false);
        }, 500)
    }

    return (
        <>
            {
                isLoading == true ? <Grid
                    height="80"
                    width="80"
                    color="#035096"
                    ariaLabel="grid-loading"
                    radius="12.5"
                    wrapperStyle={{}}
                    wrapperClass="spinner"
                    className="spinner-loading"
                    visible={true} /> :
                    <section className="user-messages">
                        {messagesResult}
                        <Pager startPage={pageObject?.startPage} endPage={pageObject?.endPage} currentPage={currentPage} onPageNumberChange={handleOnPageNumberChange} />
                    </section>
            }
            
       </>
       
    )
}