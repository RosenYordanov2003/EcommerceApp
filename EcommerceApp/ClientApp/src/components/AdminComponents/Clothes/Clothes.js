import { useState, useEffect } from "react";
import { loadAllProducts } from "../../../services/productService";
import ClothesStyle from "./ClothesStyle.css";
import ProductCard from "../Product/ProductCard/ProductCard";
export default function Clothes() {

    const [clothes, setClothes] = useState([]);

    useEffect(() => {
        loadAllProducts()
            .then((res) => setClothes(res))
    }, [])
    const clothesResult = clothes?.map((x) => <ProductCard product={x} key={x.id} />);

    return (
        <div className="clothes-container-admin">
            {clothesResult}
        </div>
    )
}