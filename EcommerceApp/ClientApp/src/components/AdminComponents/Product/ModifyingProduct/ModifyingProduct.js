import { useEffect, useState } from "react";
import { getProductToModify } from "../../../../adminServices/clothesService";

export default function ModifyingProduct() {

    const path = window.location.pathname.split('/');

    const productId = path[2];

    const [product, setProduct] = useState(undefined);

    useEffect(() => {
        getProductToModify(productId)
        .then((res) => setProduct(res))
    }, [])

    console.log(product);

    return (
        <div className="product-modifying-container">

        </div>
    )
}