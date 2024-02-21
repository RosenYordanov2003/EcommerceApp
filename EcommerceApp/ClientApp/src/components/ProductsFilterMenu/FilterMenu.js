import FilterItem from "../FilterItem/FilterItem";
import FilterMenuStyle from "../ProductsFilterMenu/FilterMenuStyle.css";
import { useState, useEffect } from "react";

export default function FilterMenu({ result: {brands, categories }, onCheckInput }) {

    const [checkedBrnadInputs, setBrandCheckedInputs] = useState([]);
    const [checkedCategoryInputs, setCategoryInputs] = useState([]);
    const [status, setStatus] = useState('not-visible-filter-menu');

    useEffect(() => {
        onCheckInput(checkedBrnadInputs, checkedCategoryInputs);
    }, [checkedBrnadInputs, checkedCategoryInputs]);

    const brandElements = brands.map((brand) => <li key={brand.id}><FilterItem addCheckedInputValues={addCheckedInputValues} filterItem={brand}></FilterItem></li>);
    const categoryElements = categories.map((category) => <li key={category.id}><FilterItem filterItem={category} addCheckedInputValues={addCheckedInputValues}></FilterItem></li>);
  

    function addCheckedInputValues(checkedInputObject) {

        if (brands.some((brand) => brand.name == checkedInputObject.name)) {
            if (checkedInputObject.checkedValue === true) {
                setBrandCheckedInputs([...checkedBrnadInputs, checkedInputObject]);
            }
            else {
                setBrandCheckedInputs(checkedBrnadInputs.filter(({ name }) => name !== checkedInputObject.name));
            }
        }
        else
        {
            if (checkedInputObject.checkedValue === true) {
                setCategoryInputs([...checkedCategoryInputs, checkedInputObject]);
            } else {
                setCategoryInputs(checkedCategoryInputs.filter(({ name }) => name !== checkedInputObject.name));
            }
        }
        setStatus('closed');
    }

    function changeStatus() {
        if (status === 'not-visible') {
            setStatus('visible');
        }
        else if (status === 'visible') {
            setStatus('closed');
        }
        else {
            setStatus('visible');
        }
    }

    return (
        <>
            <button onClick={changeStatus} className="filter-button"></button>
            <nav id="filter-menu-navigation">

                <h4 className="filter-title">Brands</h4>
                <ul className={`${status}`}>
                    {brandElements}
                </ul>
                <hr></hr>
                <h4 className="filter-title">Categories</h4>
                <ul className={`${status}`}>
                    {categoryElements}
                </ul>
            </nav>
        </>
      
    )
}