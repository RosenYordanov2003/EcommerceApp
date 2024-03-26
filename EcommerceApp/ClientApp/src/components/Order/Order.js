import { useState, useEffect, useContext } from "react";
import { UserContext } from "../../Contexts/UserContext";
import OrderProduct from "../Products/OrderProduct/OrderProduct";
import "../Order/OrderStyle.css";
import { finishOrder } from "../../services/cartService";
import { useNavigate } from "react-router-dom";
import "../Order/ResponsiveStyle.css";
import Input from "../Auth/Input/Input";
import { FormProvider, useForm } from 'react-hook-form'
import { postalCodeInput, firstNameInput, lastNameInput, streetAdressInput, cityOrderInput, emailOrderInput, phoneNumberInput } from "../../utilities/inputValidations";

export default function Order() {
    const { user, setUser } = useContext(UserContext);
    const navigate = useNavigate();
    const methods = useForm();

    const [inputObject, setInputObject] = useState({
        country: '',
        city: '',
        postalCode: '',
    })
    const [shippingObject, setShippingObject] = useState(undefined);
    const [priceObject, setPriceObject] = useState(undefined);

    useEffect(() => {

        const checkOutObject = JSON.parse(localStorage.getItem('checkout-info'));
        if (checkOutObject) {
            setInputObject({ ...inputObject, city: checkOutObject.city, country: checkOutObject.country, postalCode: checkOutObject.postalCode });
            setShippingObject(checkOutObject.shippingObject);
            setPriceObject(checkOutObject.priceObject);
        }
    }, [user?.id])


    const handleOnOrderSubmit = methods.handleSubmit(data => {

        const object = {
            userOrderInfo: {...data, country: inputObject.country},
            shippingInfo: shippingObject,
            totalPrice: priceObject?.totalPrice,
            userId: user.id,
            discount: priceObject?.discount,
            cuppon: priceObject?.cuppon
        };

        finishOrder(object)
            .then((res) => {

                if (res === true) {
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

    })

    const products = user?.cart?.cartProducts?.map((product) => <OrderProduct key={product.id} product={product} />);
    const shoes = user?.cart?.cartShoes?.map((product) => <OrderProduct key={product.id} product={product} />);

    return (
        <div className="order-container">
            <div className="order-details-container">
                <h1 className="order-title">Order Details</h1>
                <FormProvider {...methods}>
                    <form onSubmit={(event) => event.preventDefault()}>
                        <Input {...emailOrderInput} classNameValue="order-input-container"/>
                        <Input {...firstNameInput} classNameValue="order-input-container"/>
                        <Input {...lastNameInput} classNameValue="order-input-container"/>
                        <Input {...streetAdressInput} classNameValue="order-input-container"/>
                        <Input {...cityOrderInput} classNameValue="order-input-container" inputValue={inputObject.city}/>
                        <Input {...postalCodeInput} classNameValue="order-input-container" inputValue={inputObject.postalCode}/>
                        
                        <div className="order-input-container">
                            <label htmlFor="country">Country</label>
                            <select onChange={(event) => setInputObject({ ...inputObject, country: event.target.vaalue })} id="country" value={inputObject.country}>
                                <option value="Bulgaria">Bulgaria</option>
                                <option value="Greece">Greece</option>
                                <option value="Turkey">Turkey</option>
                                <option value="United Kingdom">United Kingdom</option>
                            </select>
                        </div>
                        <Input {...phoneNumberInput} classNameValue="order-input-container" />
                        <button onClick={handleOnOrderSubmit} className="place-order-button">Place Order</button>
                    </form>
                </FormProvider>
               
            </div>
            <div className="order-summary">
                <h2 className="order-summary-title">Order Summary</h2>
                <section className="order-price">
                    <div className="order-price-container">
                        <p>Shipping: {shippingObject?.method === "fast" ? "Fast Shipping" : "Standard Shipping"}</p>
                        <p>${shippingObject?.price?.toFixed(2) ?? Number(0).toFixed(2)}</p>
                    </div>
                    <div className="order-price-container">
                        <p>Discount:</p>
                        <p>${priceObject?.discount.toFixed(2)}</p>
                    </div>
                    <div className="order-price-container">
                        <p className="total">Total</p>
                        <p className="total-price">${priceObject?.totalPrice.toFixed(2) ?? 0}</p>
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