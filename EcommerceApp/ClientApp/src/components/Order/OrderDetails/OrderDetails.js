import { useState, useEffect } from "react";
import { getOrderById } from "../../../services/orderService";

import Style from "../OrderDetails/Style.css";

export default function () {

    const id = window.location.pathname.split('/')[2];


    useEffect(() => {
        getOrderById(id)
        .then(res => console.log(res))
    }, [])

    return (
        <p>Details</p>
    )
}