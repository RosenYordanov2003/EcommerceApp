import { useState, useContext } from "react";
import { UserContext } from "../../../Contexts/UserContext";
import { removeProductFromUserCart, modifyProductCartQuantity } from "../../../services/cartService";
import Notification from "../../Notification/Notification";

export default function UserCartItem({ item, handleIncreaseItemPrice, handleDecreaseItemPrice }) {

    const [quantity, setQuantity] = useState(item.quantity);
    const { user, setUser } = useContext(UserContext);
    const [notification, setNotification] = useState(undefined);

    function handleOnDecreasingProductQuantity() {
        if (quantity == 1) {
            return;
        }
        const object = {
            userId: user.id,
            productCategoryName: item.categoryName,
            productId: item.id,
            operation: 'decrease',
            quantity: item.quantity,
            size: item.size,
        };
        modifyProductCartQuantity(object)
            .then(() => {
                setQuantity(quantity - 1);
                handleDecreaseItemPrice(item.id, item.price);
            })
            .catch((error) => console.error(error));
    }
    function handleOnIncreasingItemQuantity() {
        if (quantity + 1 <= 20) {

            const object = {
                userId: user.id,
                productCategoryName: item.categoryName,
                productId: item.id,
                operation: 'increase',
                quantity: item.quantity,
                size: item.size,
            };

            modifyProductCartQuantity(object)
                .then((res) => {
                    if (res.success === false) {
                        setNotification(<Notification message={res.error} typeOfMessage="error" closeNotification={removeNotification} />);
                        return;
                    }
                    setQuantity(quantity + 1);
                    handleIncreaseItemPrice(item.id, item.price);
                })
                .catch((error) => console.error(error));
        }
    }
    function removeNotification() {
        setNotification(undefined);
    }
    function handleOnRemovingItem() {

        const productObject = {
            userId: user.id,
            categoryName: item.categoryName,
            productId: item.id,
            size: item.size.toString(),
            quantity: item.quantity
        }

        if (item.categoryName === "Shoes") {
            setUser({
                ...user,
                cart: {
                    ...user.cart,
                    cartShoes: user.cart.cartShoes.filter((shoes) => {
                        if (shoes.id === item.id && shoes.size.toString() === item.size.toString()) {
                            return undefined;
                        }
                        else {
                            return shoes;
                        }
                    })
                }
            })
        }
        else {
            setUser({
                ...user,
                cart: {
                    ...user.cart,
                    cartProducts: user.cart.cartProducts.filter((product) => {
                        if (product.id === item.id && product.size == item.size) {
                            return undefined;
                        }
                        else {
                            return product;
                        }
                    })
                }
            })
        }
        removeProductFromUserCart(productObject)
            .then(() => {
                handleDecreaseItemPrice(undefined, item.price * quantity);
            })
    }

    return (
        <>
            {notification }
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
                <p className="item-price">{item.size}</p>
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