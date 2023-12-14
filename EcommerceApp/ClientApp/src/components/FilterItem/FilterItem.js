import { useState } from "react";

export default function FilterItem({ filterItem, addCheckedInputValues }) {

    const [checked, setIsChecked] = useState(false);

    function handleInputClick(e) {
        setIsChecked(!checked);
        const objectInput = {
            checkedValue: !checked,
            name: e.target.parentElement.children[1].textContent
        };

        addCheckedInputValues(objectInput);
    }

    return (
        <div>
            <input onClick={handleInputClick} className = "filter-input" type="checkBox" />
            <p className = "filter-name">{filterItem.name}</p>
        </div>
    )
}