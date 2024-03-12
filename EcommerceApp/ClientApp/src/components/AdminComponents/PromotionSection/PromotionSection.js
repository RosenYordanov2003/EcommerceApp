import { useEffect, useState } from "react"
import "../PromotionSection/Style.css";
import PoppupMessage from "../../PoppupMessage/PoppupMessage";
import { removePromotion, addPromotion } from "../../../adminServices/promotionService";

export default function PromotionSection({ promotionModel }) {

    const [inputObject, setInputObject] = useState();
    const [message, setMessage] = useState(undefined);

    useEffect(() => {
        setInputObject({
            percentages: promotionModel?.percentageDiscount,
            expirationTime: promotionModel?.expireTime
        });
    }, [promotionModel?.percentageDiscount, promotionModel?.expireTime])

    const productId = window.location.pathname.split('/')[2];
    const category = window.location.pathname.split('/')[3];

    function formatDateToYYYYMMDD(date) {

        if (date === undefined || date === null) {
            date = new Date();
        }
        const year = date.getFullYear();
        const month = (date.getMonth() + 1).toString().padStart(2, '0');
        const day = date.getDate().toString().padStart(2, '0');
        return `${year}-${month}-${day}`;
    }

    const inputObjectDate = inputObject?.expirationTime !== null ? new Date(inputObject?.expirationTime) : new Date();
    const promotionObjectDate = promotionModel?.expireTime !== undefined ? new Date(promotionModel?.expireTime) : new Date();

    const formattedDateInputObject = formatDateToYYYYMMDD(inputObjectDate);
    const formattedDatePromotionModel = formatDateToYYYYMMDD(promotionObjectDate);


    let buttonContent;


    if (!inputObject?.percentages && !inputObject?.expirationTime) {
        buttonContent = "Create Promotion";
    }
    else if (formattedDateInputObject === formattedDatePromotionModel && Number.parseFloat(inputObject?.percentages) === promotionModel.percentageDiscount) {
        buttonContent = "Current Promotion"
    }
    else {
        buttonContent = "Apply Promotion";
    }

    function closeNotification() {
        setMessage(undefined);
    }

    function handleOnFormSubmit(event) {
        event.preventDefault();

        const promotionObject = {
            expirationTime: inputObject.expirationTime,
            percentages: inputObject.percentages,
            productCategory: category,
            productId: productId
        };

        addPromotion(promotionObject)
            .then(() => {
                setMessage(<PoppupMessage message="Successfully Apply Promotion" removeNotification={closeNotification} />);
                window.scrollTo({ top: 0, behavior: "smooth" });
            })
            .catch((error) => console.error(error));
    }
    function handleOnPromotionDelete(e) {
        e.preventDefault();
        e.stopPropagation();
        removePromotion(promotionModel?.id)
            .then(() => {
                setInputObject(undefined);
                setMessage(<PoppupMessage message="Successfully Remove Promotion" removeNotification={closeNotification} />);
                window.scrollTo({ top: 0, behavior: "smooth" });
            })
            .catch((error) => console.error(error));
    }
    const date = new Date();
    date.setFullYear(date.getFullYear() + 1);
    return (
        <>
            {message}
            <form onSubmit={handleOnFormSubmit} className="promotion-form">
                <div className="product-input-container">
                    <label htmlFor="percenteges">Promotion Percentages</label>
                    <input id="percenteges" onChange={(e) => setInputObject({ ...inputObject, percentages: e.target.value })} value={inputObject?.percentages === null ? Number(0).toFixed(2) : inputObject?.percentages}></input>
                </div>
                <div className="product-input-container">
                    <label htmlFor="promotion-date">Promotion Expire Date</label>
                    <input id="promotion-date" onChange={(e) => setInputObject({ ...inputObject, expirationTime: e.target.value })} type="date"
                        max={`${date.getFullYear()}-12-31`} value={formattedDateInputObject}></input>
                </div>
                <div className="promotion-section-button-container">
                    <button type="submit">{buttonContent}</button>
                    {buttonContent === "Current Promotion" && <button onClick={handleOnPromotionDelete}>Remove Promotion</button>}
                </div>
            </form>
       </>
    )
}