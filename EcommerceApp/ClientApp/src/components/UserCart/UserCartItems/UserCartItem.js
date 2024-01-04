import { useState } from "react";

export default function UserCartItem({ item }) {

    const [quantity, setQuantity] = useState(1);

    return (
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
            <section className="item-price">
                <p>${Number.parseFloat(item.price).toFixed(2)}</p>
                <div className="quantity-buttons-container">
                    <button>-</button>
                    {quantity }
                    <button>+</button>
                </div>
            </section>
         {/*   <hr></hr>*/}
        </section>
    )
}