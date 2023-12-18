﻿import { useEffect, useState } from "react";
import { loadProductById } from "../../services/productService";
export default function ProductInfo() {

    const [product, setProduct] = useState({});

    const pathArray = window.location.pathname.split('/');
    const id = pathArray[pathArray.length - 2];
    const categoryName = pathArray[pathArray.length - 1];

    useEffect(() => {
        loadProductById(id, categoryName)
            .then((res) => {
                console.log(res);
                setProduct(res)
            })
            .catch((error) => console.error(error));
    }, [])

}