import { useEffect, useState } from 'react';
import { loadAllShoes } from "../../../adminServices/shoesService";
import ProductCard from "../Product/ProductCard/ProductCard";
export default function Shoes() {

    const [shoes, setShoes] = useState([]);

    useEffect(() => {
        loadAllShoes()
            .then(res => setShoes(res))
            .catch((error) => console.error(error));
    }, [])

    const shoesResult = shoes?.map((s) => <ProductCard product={s} key={s.id} />);

    return (
        <div className="clothes-container-admin">
            {shoesResult}
        </div>
    )
}