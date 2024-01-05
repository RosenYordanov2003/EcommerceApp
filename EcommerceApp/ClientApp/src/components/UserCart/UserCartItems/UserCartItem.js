import { useState } from "react";

export default function UserCartItem({ item }) {

    const [quantity, setQuantity] = useState(1);


    return (
        <>
            <tr className="item-cotnainer">
                <td className="item-info">
                    <div className="item-img-container">
                        <img src={item.imgUrl}></img>
                    </div>
                    <div className="item-about">
                        <h4 className="item-name">{item.name}</h4>
                        <p className="item-category">Category: {item.categoryName}</p>
                    </div>
                </td>
                <td className="item-price">${Number.parseFloat(item.price).toFixed(2)}</td>
                <td className="quantity-buttons-container">
                    <button>-</button>
                    {quantity}
                    <button>+</button>
                </td>
                <td className="item-subtotal-price">${Number.parseFloat(item.price * quantity).toFixed(2)}</td>
                <button className="remove-button"><i class="fa-solid fa-xmark"></i></button>
            </tr>
            <hr className="item-hr"></hr>
        </>

    )
}