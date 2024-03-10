import "../SuccessfullPage/SuccessPageStyle.css";
import"../SuccessfullPage/ResponsiveStyle.css";
import { useNavigate } from "react-router-dom";

export default function SuccessFullPage() {

    const navigate = useNavigate();

    return (
        <div className="successfull-main-container">
            <div className="successfull-container">
                <div className="success-header">
                    <i class="fa-regular fa-circle-check success-order-icon"></i>
                    <h1 className="successfull-title">Your order has been completed</h1>
                </div>
                <div className="success-content">
                    <p>Congrats, your order is on its way to you.</p>
                    <button onClick={() => navigate("/Home")} className="continue-button">Continue</button>
                </div>
            </div>

        </div>
    )
}