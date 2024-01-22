import { useEffect, useState, useContext } from "react";
import { UserContext } from "../../Contexts/UserContext";
import { useNavigate } from "react-router-dom";
import ShoppingCartStyle from "../UserCart/ShoppingCartStyle.css";
import UserCartItem from "../UserCart/UserCartItems/UserCartItem";
import { applyCuppon } from "../../services/cupponService";
import PoppupMessage from "../PoppupMessage/PoppupMessage";
import ResponsiveStyle from "../UserCart/ResponsiveStyle.css";

export default function UserCart() {

    const navigate = useNavigate();
    const { user } = useContext(UserContext);
    const [totalPrice, setTotalPrice] = useState();
    const [shippingMethod, setShippingMethod] = useState(undefined);
    const [inputObject, setInputObject] = useState({ city: '', postalCode: '', country: 'Bulgaria', cuppon: '' });
    const [isActiveCuppon, setIsActiveCuppon] = useState(false);
    const [cuppon, setCuppon] = useState(undefined);
    const [discount, setDiscount] = useState(0);
    const [poppUpMessage, setpoppUpMessage] = useState(undefined);

    function handleIncreaseItemPrice(productId, price) {
        setTotalPrice(totalPrice + price);
    }
    function handleDecreaseItemPrice(productId, price) {
        setTotalPrice(totalPrice - price);
    }



    console.log(user);

    const items = user?.cart?.cartProducts?.map((item, index) => <UserCartItem handleIncreaseItemPrice={handleIncreaseItemPrice} handleDecreaseItemPrice={handleDecreaseItemPrice} item={item} key={index} />)

    const shoesItems = user?.cart?.cartShoes?.map((item, index) => <UserCartItem handleIncreaseItemPrice={handleIncreaseItemPrice} handleDecreaseItemPrice={handleDecreaseItemPrice} item={item} key={index} />)


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
            setpoppUpMessage(<PoppupMessage message="You Have Successfully Applied Your Promotion Code"/>)
        }
    }, [user?.cart?.cartId])


    function handleCheckoutClick() {
        const checkOutObject = {
            country: inputObject.country,
            city: inputObject.city,
            postalCode: inputObject.postalCode,
            shippingObject: shippingMethod,
            priceObject: {
                totalPrice,
                discount,
                cuppon
            }
        };
        localStorage.setItem('checkout-info', JSON.stringify(checkOutObject));
        navigate('/Order');
    }
    function handleApplyCupponClick() {
        applyCuppon(inputObject.cuppon, user?.id)
            .then((res) => {
                if (res.error) {
                    console.log(res.error)
                }
                else {
                    setIsActiveCuppon(true);
                    setCuppon(res.cuppon);
                    setTotalPrice(totalPrice - (totalPrice * res.cuppon.discountPercantages) / 100);
                    setDiscount(totalPrice * res.cuppon.discountPercantages / 100);
                }
            })
    }


    return (
        <>
            <h2 className="shopping-cart-title">{items?.length + shoesItems?.length > 0 ? "Shopping Cart" : "Shopping Cart Is Empty"}</h2>
            {items?.length + shoesItems?.length > 0 &&
                <div className="cart-container">
                <section className="cart-order">
                    <div className="shopping-cart-table">
                        <section className="shopping-cart-headers">
                            <h4>Item</h4>
                            <h4>Price</h4>
                            <h4>Size</h4>
                            <h4>Quantity</h4>
                            <h4>Subtotal</h4>
                        </section>
                        {items}
                        {shoesItems}
                    </div>
                </section>
                {poppUpMessage }
                <section className="order-info-container">
                    <div className={`cuppon-container ${isActiveCuppon && 'active-cuppon'}`}>
                        <input type="text" placeholder="Enter cupon" value={inputObject.cuppon} onChange={(event) => setInputObject({ ...inputObject, cuppon: event.target.value })}></input>
                        <button onClick={handleApplyCupponClick} className="apply-cuppon-button">Apply</button>
                    </div>
                    <div className="order-info">
                        <div className="cart-input-container">
                            <label htmlFor="country">country</label>
                            <select onChange={(event) => setInputObject({ ...inputObject, country: event.target.value })} id="country" value={inputObject.country}>
                                <option value="Bulgaria">Bulgaria</option>
                                <option value="Greece">Greece</option>
                                <option value="Turkey">Turkey</option>
                                <option value="United Kingdom">United Kingdom</option>
                            </select>
                        </div>
                        <div className="cart-input-container">
                            <label htmlFor="city">City</label>
                            <input onChange={(event) => setInputObject({ ...inputObject, city: event.target.value })} type="text" id="city" placeholder="Enter city"></input>
                        </div>
                        <div className="cart-input-container">
                            <label htmlFor="postal-code">ZIP/POSTAL CODE</label>
                            <input onChange={(event) => setInputObject({ ...inputObject, postalCode: event.target.value })} placeholder="Enter postal/zip code" type="text" value={inputObject.postalCode} id="postal-code"></input>
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
                                <input onClick={() => setShippingMethod({ method: 'fast', price: 10 })} type="checkbox" checked={shippingMethod?.method === 'fast'} id="fast-shipping"></input>
                                <label htmlFor="fast-shipping"></label>
                            </div>
                        </div>
                    </div>
                    <div className="finish-order">
                        <p className="total-price order-final-details">Total
                            <p>${Number.parseFloat(totalPrice).toFixed(2)}</p>
                        </p>
                        <p className="total-price order-final-details">Discount
                            <p>${Number.parseFloat(discount).toFixed(2)}</p>
                        </p>
                        <p className="total-price order-final-details">Shipping
                            <p>${Number.parseFloat(shippingMethod?.price ?? 0).toFixed(2)}</p>
                            </p>
                            <div className="check-out-button-container">
                                <button onClick={handleCheckoutClick} className="check-out-button">Checkout</button>
                            </div>
                    </div>
                </section>
            </div>
            }
        </>
    )
}