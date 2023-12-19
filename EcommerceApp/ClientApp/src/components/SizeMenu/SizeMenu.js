import { useState } from "react";

export default function SizeItem({ productSize, index, handleSizeItem }) {

    const [isActive, setIsActive] = useState(false);

    function handleSizeClick(event) {
        handleSizeItem(index);
      /*  setIsActive(!isActive);*/
    }

    const className = isActive == true ? "active-size" : "";
    const result = productSize.quantity > 0 ? <li onClick={handleSizeClick} className={`size-item ${className}`}>{productSize.size}</li> :
        <li onClick={handleSizeClick} className={`size-item not-available ${className}`}> <del>{productSize.size}</del> </li>;

    return (result);
}