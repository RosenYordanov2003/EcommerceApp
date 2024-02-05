import { useState } from "react"
import Style from "../ProductStock/Style.css";

export default function ProductStock({ productStock }) {

    const [quantity, setQuantity] = useState(productStock.quantity);

    return (
        <div className="product-stock-admin-container">
            <p>{productStock.size }</p>
                <button>-</button>
                <p>{quantity}</p>
                <button>+</button>
        </div>
    )
}