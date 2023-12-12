import { useEffect } from "react";
import { loadProductsByGender } from "../../services/productService";

export default function GenderProducts() {
    const pathArray = window.location.pathname.split('/');
    const gender = pathArray[pathArray.length - 1];

    useEffect(() => {
        loadProductsByGender(gender)
            .then((result) => console.log(result));
    }, [])
}