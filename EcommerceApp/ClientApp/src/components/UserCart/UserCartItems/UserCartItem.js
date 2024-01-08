import { useState } from "react";

export default function UserCartItem({ item }) {

    const [quantity, setQuantity] = useState(1);


    return (
        <>
            <section className="item-cotnainer">
                <div className="item-info">
                    <div className="item-img-container">
                        <img src={item.imgUrl}></img>
                    </div>
                    <div className="item-about">
                        <h4 className="item-name">{item.name}</h4>
                        <p className="item-category">Category: {item.categoryName}</p>
                    </div>
                </div>
                <p className="item-price">${Number.parseFloat(item.price).toFixed(2)}</p>
                <div className="quantity-buttons-container">
                    <button>-</button>
                    {quantity}
                    <button>+</button>
                </div>
                <p className="item-subtotal-price">${Number.parseFloat(item.price * quantity).toFixed(2)}</p>
                <button className="remove-button"><i className="fa-solid fa-xmark"></i></button>
            </section>
            <hr className="item-hr"></hr>
        </>

    )
}