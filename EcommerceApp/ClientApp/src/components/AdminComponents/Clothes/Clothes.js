import { useState, useEffect } from "react";
import { loadAllProducts } from "../../../services/productService";
import ClothesStyle from "./ClothesStyle.css";
export default function Clothes() {

    const [clothes, setClothes] = useState([]);

    useEffect(() => {
        loadAllProducts()
            .then((res) => setClothes(res))
    }, []) 
}