import { useState } from "react"
import Style from "../ProductStock/Style.css";
import { addProductStock } from "../../../adminServices/clothesService";
import PoppupMessage from "../../PoppupMessage/PoppupMessage";

export default function ProductStock({ productStock }) {


    const [message, setMessage] = useState(undefined);
    const [quantity, setQuantity] = useState(undefined);

    function closeMessage() {
        setMessage(undefined);
    }

    function handleOnFormSubmit(event) {
        event.preventDefault();

        const object = {
            productStockId: productStock.id,
            size: productStock.size,
            productQuantityToAdd : quantity
        }
        addProductStock(object)
            .then(() => setMessage(<PoppupMessage message="Successfully add product stock" removeNotification={closeMessage} />))
            .catch((error) => console.error(error));
    }

    return (
        <div className="product-stock-admin-container">
            {message !== undefined && message }
            <p>{productStock.size }</p>
            <form onSubmit={handleOnFormSubmit} className="product-stock-form">
                <input onChange={(e) => setQuantity(e.target.value)} value={quantity} name="quantity"></input>
                <button>Add Quantity</button>
            </form>
        </div>
    )
}