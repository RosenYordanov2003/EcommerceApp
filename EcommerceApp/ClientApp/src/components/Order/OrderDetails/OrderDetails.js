import { useState, useEffect } from "react";
import { getOrderById } from "../../../services/orderService";
import OrderProductCard from "../OrderProductCard/OrderProductCard";

import Style from "../OrderDetails/Style.css";

export default function () {

    const id = window.location.pathname.split('/')[2];
    const [orderObject, setOrderObject] = useState(undefined);


    useEffect(() => {
        getOrderById(id)
        .then(res => setOrderObject(res))
    }, [])

    console.log(orderObject);

    const orderProducts = orderObject?.products.map((product, index) => <OrderProductCard product={product} key={index} />);

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
        </div>
       
    )
}