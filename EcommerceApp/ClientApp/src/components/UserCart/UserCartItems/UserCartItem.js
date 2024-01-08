import { useState, useContext } from "react";
import { UserContext } from "../../../Contexts/UserContext";

export default function UserCartItem({ item, handleIncreaseItemPrice, handleDecreaseItemPrice }) {

    const [quantity, setQuantity] = useState(1);
    const { user, setUser } = useContext(UserContext);


    console.log(item);

    function handleOnDecreasingProductQuantity() {
        if (quantity == 1) {
            return;
        }
        setQuantity(quantity - 1);
        handleDecreaseItemPrice(item.id, item.price);
    }
    function handleOnIncreasingItemQuantity() {
        if (quantity + 1 <= 20) {
            setQuantity(quantity + 1);
            handleIncreaseItemPrice(item.id ,item.price);
        }
    }
    function handleOnRemovingItem() {
        if (item.categoryName === "Shoes") {
            setUser({
                ...user,
                cart: {
                    ...user.cart,
                    cartShoes: user.cart.cartShoes.filter((shoes) => shoes.id !== item.id)
                }
            })
        }
        else {
            setUser({
                ...user,
                cart: {
                    ...user.cart,
                    cartProducts: user.cart.cartProducts.filter((product) => product.id !== item.id)
                }
            })
        }

        handleDecreaseItemPrice(undefined, item.price * quantity);

    }

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
                    <button onClick={handleOnDecreasingProductQuantity}>-</button>
                    {quantity}
                    <button onClick={handleOnIncreasingItemQuantity}>+</button>
                </div>
                <p className="item-subtotal-price">${Number.parseFloat(item.price * quantity).toFixed(2)}</p>
                <button onClick={handleOnRemovingItem} className="remove-button"><i className="fa-solid fa-xmark"></i></button>
            </section>
            <hr className="item-hr"></hr>
        </>

    )
}