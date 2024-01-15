import { useState, useContext } from "react";
import { UserContext } from "../../../Contexts/UserContext";
import { removeProductFromUserCart, modifyProductCartQuantity } from "../../../services/cartService";

export default function UserCartItem({ item, handleIncreaseItemPrice, handleDecreaseItemPrice }) {

    const [quantity, setQuantity] = useState(item.quantity);
    const { user, setUser } = useContext(UserContext);

    function handleOnDecreasingProductQuantity() {
        if (quantity == 1) {
            return;
        }
        const object = {
            userId: user.id,
            productCategoryName: item.categoryName,
            productId: item.id,
            operation: 'decrease'
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
                operation: 'increase'
            };

            modifyProductCartQuantity(object)
                .then(() => {
                    setQuantity(quantity + 1);
                    handleIncreaseItemPrice(item.id, item.price);
                })
                .catch((error) => console.error(error));
        }
    }
    function handleOnRemovingItem() {

        const productObject = {
            userId: user.id,
            categoryName: item.categoryName,
            productId: item.id
        }

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

        removeProductFromUserCart(productObject)
            .then(() => {
                console.log(true);
            })

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
                <p className="item-price">{item.size }</p>
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