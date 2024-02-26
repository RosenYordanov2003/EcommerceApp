import Style from "../UserMessageCard/Style.css";

export default function UserMessageCard({ userMessage }) {


    return (
        <article className="user-message-card">
            <div className="user-message-header">
                <h3>{userMessage.username}</h3>
                <p>3h ago</p>
            </div>
            <p className="user-message-content">{userMessage.message}</p>
            <section className="actions-container">
                <div className="action">
                    <i class="fa-solid fa-reply"></i>
                    <button className="action-button">Reply</button>
                </div>
                <div className="action">
                    <i class="fa-solid fa-trash"></i>
                    <button className="action-button">Delete</button>
                </div>
            </section>
        </article>
    )
}