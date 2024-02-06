import { useEffect, useState } from "react"
import Style from "../PromotionSection/Style.css";
import { addPromotion } from "../../../adminServices/clothesService";
import { removePromotion } from "../../../adminServices/promotionService";

export default function PromotionSection({ promotionModel }) {

    const [inputObject, setInputObject] = useState();

    useEffect(() => {
        setInputObject({
            percentages: promotionModel?.percentageDiscount,
            expirationTime: promotionModel?.expireTime
        });
    }, [promotionModel?.percentageDiscount, promotionModel?.expireTime])

    const productId = window.location.pathname.split('/')[2];

    function formatDateToYYYYMMDD(date) {
        const year = date.getFullYear();
        const month = (date.getMonth() + 1).toString().padStart(2, '0');
        const day = date.getDate().toString().padStart(2, '0');
        return `${year}-${month}-${day}`;
    }

    const inputObjectDate = new Date(inputObject?.expirationTime);
    const promotionObjectDate = new Date(promotionModel?.expireTime);

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
    function handleOnFormSubmit(event) {
        event.preventDefault();

        const promotionObject = {
            expirationTime: inputObject.expirationTime,
            percentages: inputObject.percentages,
            shoesId: null,
            productId: productId
        };

        addPromotion(promotionObject)
            .then(() => console.log(true))
            .catch((error) => console.error(error));
    }
    console.log(promotionModel);
    function handleOnPromotionDelete() {
        removePromotion(promotionModel?.id)
            .then(() => setInputObject(undefined))
            .catch((error) => console.error(error));
    }

    return (
        <form onSubmit={handleOnFormSubmit} className="promotion-form">
            <div className="product-input-container">
                <label htmlFor="percenteges">Promotion Percentages</label>
                <input id="percenteges" onChange={(e) => setInputObject({ ...inputObject, percentages: e.target.value })} value={inputObject?.percentages}></input>
            </div>
            <div className="product-input-container">
                <label htmlFor="promotion-date">Promotion Expire Date</label>
                <input id="promotion-date" onChange={(e) => setInputObject({ ...inputObject, expirationTime: e.target.value })} type="date" value={formattedDateInputObject}></input>
            </div>
            <div className="promotion-section-button-container">
                <button type="submit">{buttonContent}</button>
                {buttonContent === "Current Promotion" && <button onClick={handleOnPromotionDelete}>Remove Promotion</button> }
            </div>
        </form>
    )
}