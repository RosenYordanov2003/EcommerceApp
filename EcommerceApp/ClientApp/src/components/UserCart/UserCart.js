import { useEffect, useState, useContext } from "react";
import { UserContext } from "../../Contexts/UserContext";
import { useNavigate } from "react-router-dom";
import "../UserCart/ShoppingCartStyle.css";
import UserCartItem from "../UserCart/UserCartItems/UserCartItem";
import { applyCuppon } from "../../services/cupponService";
import PoppupMessage from "../PoppupMessage/PoppupMessage";
import "../UserCart/ResponsiveStyle.css";
import { FormProvider, useForm } from 'react-hook-form'
import Input from "../Auth/Input/Input";
import { cityInput, postalCodeInput } from "../../utilities/inputValidations";
import Notification from "../Notification/Notification";

export default function UserCart() {

    const navigate = useNavigate();
    const { user } = useContext(UserContext);
    const [totalPrice, setTotalPrice] = useState();
    const [shippingMethod, setShippingMethod] = useState(undefined);
    const [inputObject, setInputObject] = useState({country: 'Bulgaria', cuppon: '' });
    const [isActiveCuppon, setIsActiveCuppon] = useState(false);
    const [cuppon, setCuppon] = useState(undefined);
    const [discount, setDiscount] = useState(0);
    const [poppUpMessage, setpoppUpMessage] = useState(undefined);
    const [notification, setNotification] = useState(undefined);

    function handleIncreaseItemPrice(productId, price) {
        setTotalPrice(totalPrice + price);
    }
    function handleDecreaseItemPrice(productId, price) {
        setTotalPrice(totalPrice - price);
    }


    const methods = useForm();
    const items = user?.cart?.cartProducts?.map((item, index) => <UserCartItem handleIncreaseItemPrice={handleIncreaseItemPrice} handleDecreaseItemPrice={handleDecreaseItemPrice} item={item} key={index} />);

    const shoesItems = user?.cart?.cartShoes?.map((item, index) => <UserCartItem handleIncreaseItemPrice={handleIncreaseItemPrice} handleDecreaseItemPrice={handleDecreaseItemPrice} item={item} key={index} />);


    useEffect(() => {
        if (user?.cart?.cartId) {

            let shoesSum = user?.cart?.cartShoes?.reduce((acumulator, shoes) => {
                return acumulator + shoes.price;
            }, 0);

            let clothesSum = user?.cart?.cartProducts?.reduce((acumulator, product) => {
                return acumulator + product.price;
            }, 0);

            setTotalPrice(shoesSum + clothesSum);
        }
    }, [user?.cart?.cartId])


    const handleCheckoutClick = methods.handleSubmit(data => {

        const checkOutObject = {
            ...data,
            country: inputObject.country,
            shippingObject: shippingMethod,
            priceObject: {
                totalPrice,
                discount,
                cuppon
            }
        }
        if (shippingMethod === undefined) {
            setNotification(<Notification message="Please select shipping method" typeOfMessage="error" closeNotification={closeNotification}/>)
            return;
        }
         localStorage.setItem('checkout-info', JSON.stringify(checkOutObject));
         navigate('/Order');
    })

    function closeNotification() {
        setNotification(undefined);
    }
    function cloePopupMessage() {
        setpoppUpMessage(undefined);
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
                    setpoppUpMessage(<PoppupMessage message="You Have Successfully Applied Your Promotion Code" removeNotification={cloePopupMessage} />)
                    setTotalPrice(totalPrice - (totalPrice * res.cuppon.discountPercantages) / 100);
                    setDiscount(totalPrice * res.cuppon.discountPercantages / 100);
                }
            })
    }


    return (
        <>
            {notification !== undefined && notification }
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
                            <FormProvider {...methods}>
                                <Input {...cityInput} className="cart-input-container"/>
                                <Input {...postalCodeInput} className="cart-input-container"/>
                            </FormProvider>
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
                        <section className="total-price order-final-details">Total
                            <p>${Number.parseFloat(totalPrice).toFixed(2)}</p>
                        </section>
                        <section className="total-price order-final-details">Discount
                            <p>${Number.parseFloat(discount).toFixed(2)}</p>
                        </section>
                        <section className="total-price order-final-details">Shipping
                            <p>${Number.parseFloat(shippingMethod?.price ?? 0).toFixed(2)}</p>
                        </section>
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