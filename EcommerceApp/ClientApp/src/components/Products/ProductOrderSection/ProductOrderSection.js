import { useContext, useState } from "react";
import { UserContext } from "../../../Contexts/UserContext";
import Notification from "../../Notification/Notification";
import { addToCartProduct } from "../../../services/cartService";

export default function ProductOrderSection({ activeSizeItem, categoryName, count, id, handleMinusClick, handlePlusClick, product }) {

    const { user, setUser } = useContext(UserContext);
    const [notification, setNotification] = useState(undefined);


    function removeNotification() {
        setNotification(undefined);
    }

    function handleAddToCartProduct() {

        if (activeSizeItem === undefined) {
            setNotification(<Notification message={"Please, select size"} typeOfMessage="error" closeNotification={removeNotification} />)
            return;
        }

        addToCartProduct(id, user?.id, categoryName, count, activeSizeItem?.size?.toString())
            .then((res) => {
                const productId = Number.parseFloat(id);

                if (res.success == false) {
                    setNotification(<Notification message={res.error} typeOfMessage="error" closeNotification={removeNotification} />)
                    return;
                }

                const productObject = {
                    id: productId,
                    name: product.name,
                    categoryName,
                    price: product.price,
                    imgUrl: product.pictures[0].imgUrl,
                    quantity: count,
                    size: activeSizeItem?.size?.toString()
                };

                if (categoryName.toLocaleLowerCase() === 'shoes') {
                    setUser({
                        ...user,
                        cart: {
                            ...user.cart,
                            cartShoes: [...user.cart.cartShoes, productObject]
                        }
                    })
                }
                else {
                    setUser({
                        ...user,
                        cart: {
                            ...user.cart,
                            cartProducts: [...user.cart.cartProducts, productObject]
                        }
                    })
                }
            })
            .catch((error) => console.error(error))
    }

    let addToCartResult;

    if (activeSizeItem) {
        addToCartResult = activeSizeItem.quantity > 0 ? <button onClick={handleAddToCartProduct} className="add-to-cart">Add to cart</button> : "";
    }
    else {
        addToCartResult = product.isAvalilable ? <button onClick={handleAddToCartProduct} className="add-to-cart">Add to cart</button> : "";
    }

    return (
        <>
            {notification !== undefined && notification }
            <section className="order-section">
                <div className="order-count">
                    <button onClick={handleMinusClick} className="order-button"><i className="fa-solid fa-minus"></i></button>
                    <div className="order-number">{count}</div>
                    <button onClick={handlePlusClick} className="order-button"><i className="fa-solid fa-plus"></i></button>
                    {addToCartResult}
                </div>
            </section>

        </>
     
    )
}