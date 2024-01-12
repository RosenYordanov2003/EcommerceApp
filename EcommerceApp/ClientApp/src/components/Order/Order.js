import { useState, useEffect, useContext } from "react";
import { UserContext } from "../../Contexts/UserContext";
import OrderProduct from "../Products/OrderProduct/OrderProduct";
import OrderStyle from "../Order/OrderStyle.css";
import { finishOrder } from "../../services/cartService";
import { useNavigate } from "react-router-dom";

export default function Order() {
    const { user, setUser } = useContext(UserContext);
    const navigate = useNavigate();

    const [inputObject, setInputObject] = useState({
        firstName: '',
        lastName: '',
        country: '',
        city: '',
        streetAdress: '',
        email: '',
        postalCode: '',
        phoneNumber: ''
    })
    const [shippingObject, setShippingObject] = useState(undefined);
    const [totalPrice, setTotalPrice] = useState(0);

    useEffect(() => {

        const checkOutObject = JSON.parse(localStorage.getItem('checkout-info'));
        if (checkOutObject) {
            setInputObject({ ...inputObject, city: checkOutObject.city, country: checkOutObject.country, postalCode: checkOutObject.postalCode });
            setShippingObject(checkOutObject.shippingObject);
            setTotalPrice(checkOutObject.totalPrice);
        }
    }, [user?.id])


    function handleFormSubmit(event) {
        event.preventDefault();

        console.log(shippingObject);

        const object = {
            userOrderInfo: inputObject,
            shippingInfo: shippingObject,
            totalPrice,
            userId: user.id,
            discount: 0
        };

        finishOrder(object)
            .then((res) => {

                if (res) {
                    console.log(true)
                    localStorage.removeItem('checkout-info');
                    setUser({
                        ...user, cart: {
                            ...user.cart,
                            cartShoes: [],
                            cartProducts: []
                        }
                    });

                    navigate("/CompletedOrder");
                }
                else {
                    console.log(false);
                }
            })
            .catch((error) => console.error(error));

    }

    const products = user?.cart?.cartProducts?.map((product) => <OrderProduct key={product.id} product={product} />);
    const shoes = user?.cart?.cartShoes?.map((product) => <OrderProduct key={product.id} product={product} />);

    return (
        <div className="order-container">
            <div className="order-details-container">
                <h1 className="order-title">Order Details</h1>
                <form onSubmit={handleFormSubmit}>
                    <div className="order-input-container">
                        <label htmlFor="email-adress">Email Adress</label>
                        <input onChange={(event) => setInputObject({ ...inputObject, email: event.target.value })} value={inputObject.emailAdress} id="email-adress">
                        </input>
                    </div>
                    <div className="order-input-container">
                        <label htmlFor="first-name">First Name</label>
                        <input onChange={(event) => setInputObject({ ...inputObject, firstName: event.target.value })} value={inputObject.firstName} id="first-name">
                        </input>
                    </div>
                    <div className="order-input-container">
                        <label htmlFor="last-name">Last Name</label>
                        <input onChange={(event) => setInputObject({ ...inputObject, lastName: event.target.value })} value={inputObject.lastName} id="last-name">
                        </input>
                    </div>
                    <div className="order-input-container">
                        <label htmlFor="street">Street Adress</label>
                        <input onChange={(event) => setInputObject({ ...inputObject, streetAdress: event.target.value })} value={inputObject.streetAdress} id="street">
                        </input>
                    </div>
                    <div className="order-input-container">
                        <label htmlFor="city">City</label>
                        <input onChange={(event) => setInputObject({ ...inputObject, city: event.target.value })} value={inputObject.city} id="city">
                        </input>
                    </div>
                    <div className="order-input-container">
                        <label htmlFor="postal-zip-code">ZIP/POSTAL CODE</label>
                        <input onChange={(event) => setInputObject({ ...inputObject, postalCode: event.target.value })} value={inputObject.postalCode} id="postal-zip-code">
                        </input>
                    </div>
                    <div className="order-input-container">
                        <label htmlFor="country">Country</label>
                        <select onChange={(event) => setInputObject({ ...inputObject, country: event.target.vaalue })} id="country" value={inputObject.country}>
                            <option value="Bulgaria">Bulgaria</option>
                            <option value="Greece">Greece</option>
                            <option value="Turkey">Turkey</option>
                            <option value="United Kingdom">United Kingdom</option>
                        </select>
                    </div>
                    <div className="order-input-container">
                        <label htmlFor="phone-number">Phone Number</label>
                        <input onChange={(event) => setInputObject({ ...inputObject, phoneNumber: event.target.value })} value={inputObject.phoneNumber} id="phone-number"></input>
                    </div>
                    <button type="submit" className="place-order-button">Place Order</button>
                </form>
            </div>
            <div className="order-summary">
                <h2 className="order-summary-title">Order Summary</h2>
                <section className="order-price">
                    <div className="order-price-container">
                        <p>Shipping: {shippingObject?.method === "fast" ? "Fast Shipping" : "Standard Shipping"}</p>
                        <p>${shippingObject?.price?.toFixed(2) ?? 0}</p>
                    </div>
                    <div className="order-price-container">
                        <p>Discount:</p>
                        <p>${Number(0).toFixed(2)}</p>
                    </div>
                    <div className="order-price-container">
                        <p className="total">Total</p>
                        <p className="total-price">${totalPrice?.toFixed(2) ?? 0}</p>
                    </div>
                </section>
                <hr></hr>
                <section className="order-products">
                    {products}
                    {shoes}
                </section>
            </div>
        </div>

    )
}