import { useState, useEffect } from "react";
import { getOrderById } from "../../../services/orderService";
import OrderProductCard from "../OrderProductCard/OrderProductCard";
import "../OrderDetails/Style.css";

export default function () {

    const id = window.location.pathname.split('/')[2];
    const [orderObject, setOrderObject] = useState(undefined);


    useEffect(() => {
        getOrderById(id)
        .then(res => setOrderObject(res))
    }, [])

    console.log(orderObject);

    const orderProducts = orderObject?.products.map((product, index) => <OrderProductCard product={product} key={index} />);

    console.log(orderObject);

    return (
        <div>
            <h1 className="order-detials-title">Your Order with id: 03945885</h1>
            <section className="order-details-section">
                <h4 className="recap-title">Recap</h4>
                <hr></hr>
                <section className="order-recap">
                    {orderProducts}
                </section>
            </section>
            <hr></hr>
            <section className="order-details">
                <h2 className="order-details-title">Order Details</h2>
                <div>
                    <p>Total</p>
                    <p className="order-details-result price">${orderObject?.totalPrice.toFixed(2)}</p>
                </div>
                <div>
                    <p>Shipping Method</p>
                    <p className="order-details-result">{orderObject?.shippingMethod}</p>
                </div>
                <div>
                    <p>Shipping Country</p>
                    <p className="order-details-result">{orderObject?.country}</p>
                </div>
                <div>
                    <p>Shipping Adress</p>
                    <p className="order-details-result">{orderObject?.city}, {orderObject?.shippingAddress}</p>
                </div>
                <div>
                    <p>Order Status</p>
                    <p className="order-details-result">{orderObject?.orderStatus}</p>
                </div>
            </section>
        </div>
       
    )
}