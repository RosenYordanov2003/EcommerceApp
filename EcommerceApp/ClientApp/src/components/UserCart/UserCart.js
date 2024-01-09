import { useEffect, useState, useEffet, useContext } from "react";
import { UserContext } from "../../Contexts/UserContext";
import ShoppingCartStyle from "../UserCart/ShoppingCartStyle.css";
import UserCartItem from "../UserCart/UserCartItems/UserCartItem";

export default function UserCart() {
    const { user, setUser } = useContext(UserContext);
    const [totalPrice, setTotalPrice] = useState();
    const [shippingMethod, setShippingMethod] = useState(undefined);




    function handleIncreaseItemPrice(productId, price) {
        console.log(price + totalPrice);
        setTotalPrice(totalPrice + price);
    }
    function handleDecreaseItemPrice(productId, price) {
        setTotalPrice(totalPrice - price);
    }



    const items = user?.cart?.cartProducts?.map((item) => <UserCartItem handleIncreaseItemPrice={handleIncreaseItemPrice} handleDecreaseItemPrice={handleDecreaseItemPrice} item={item} key={item.id} />)

    const shoesItems = user?.cart?.cartShoes?.map((item) => <UserCartItem handleIncreaseItemPrice={handleIncreaseItemPrice} handleDecreaseItemPrice={handleDecreaseItemPrice} item={item} key={item.id} />)


    useEffect(() => {
        if (user?.cart?.cartId) {

            let sum = 0;

            for (let i = 0; i < user?.cart?.cartShoes.length; i++) {
                sum += Number.parseFloat(user?.cart?.cartShoes[i]?.price) * user?.cart?.cartShoes[i]?.quantity;
            }
            for (let i = 0; i < user?.cart?.cartProducts.length; i++) {
                sum += Number.parseFloat(user?.cart?.cartProducts[i]?.price) * user?.cart?.cartProducts[i]?.quantity;
            }
            setTotalPrice(sum);
        }
    }, [user?.cart?.cartId])

    return (
        <>
            <h2 className="shopping-cart-title">Shopping Cart</h2>
            <div className="cart-container">
                <section className="cart-order">
                    <div className="shopping-cart-table">
                        <section className="shopping-cart-headers">
                            <h4>Item</h4>
                            <h4>Price</h4>
                            <h4>Quantity</h4>
                            <h4>Subtotal</h4>
                        </section>
                        {items}
                        {shoesItems}
                    </div>
                </section>
                <section className="order-info-container">
                    <div className="cuppon-container">
                        <input type="text" placeholder="Enter cupon"></input>
                        <button className="apply-cuppon-button">Apply</button>
                    </div>
                    <div className="order-info">
                        <div className="cart-input-container">
                            <label htmlFor="country">country</label>
                            <select id="country">
                                <option value="Bulgaria">Bulgaria</option>
                                <option value="Greece">Greece</option>
                                <option value="Turkey">Turkey</option>
                                <option value="United Kingdom">United Kingdom</option>
                            </select>
                        </div>
                        <div className="cart-input-container">
                            <label htmlFor="adress">Adress</label>
                            <input type="text" id="adress" placeholder="Enter adress"></input>
                        </div>
                        <div className="cart-input-container">
                            <label htmlFor="postal-code">ZIP/POSTAL CODE</label>
                            <input type="text" id="postal-code"></input>
                        </div>
                        <div className="cart-shipping-container">
                            <label htmlFor="standard-shipping">Standard Shipping: $5.00</label>
                            <div className="round">
                                <input onClick={() => setShippingMethod({ method: 'standard', price: 5 })} id="standard-shipping" checked={shippingMethod?.method === 'standard'} type="checkbox" />
                                <label htmlFor="standard-shipping"></label>
                            </div>
                        </div>
                        <div className="cart-shipping-container">
                            <label htmlFor="fast-shipping">Fast Shipping: $10.00</label>
                            <div className="round">
                                <input onClick={() => setShippingMethod({ method: 'fast', price: 10 }) } type="checkbox" checked={shippingMethod?.method === 'fast'} id="fast-shipping"></input>
                                <label htmlFor="fast-shipping"></label>
                            </div>
                        </div>
                    </div>
                    <div className="finish-order">
                        <p className="total-price order-final-details">Total
                            <p>${Number.parseFloat(totalPrice).toFixed(2)}</p>
                        </p>
                        <p className="total-price order-final-details">Discount
                            <p>${Number.parseFloat(0).toFixed(2)}</p>
                        </p>
                        <p className="total-price order-final-details">Shipping
                            <p>${Number.parseFloat(10).toFixed(2)}</p>
                        </p>
                        <button className="check-out-button">Checkout</button>
                    </div>
                </section>
            </div>
        </>
    )
}