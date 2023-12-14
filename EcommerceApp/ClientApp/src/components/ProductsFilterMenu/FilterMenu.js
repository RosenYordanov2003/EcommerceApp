import FilterItem from "../FilterItem/FilterItem";
//import ResetStyle from "../../ResetStyles/ResetStyle.css";
import FilterMenuStyle from "../ProductsFilterMenu/FilterMenuStyle.css";
import { useState, useEffect } from "react";

export default function FilterMenu({ result: {brands, categories }, onCheckInput }) {

    const [checkedBrnadInputs, setBrandCheckedInputs] = useState([]);
    const [checkedCategoryInputs, setCategoryInputs] = useState([]);

    useEffect(() => {
        onCheckInput(checkedBrnadInputs, checkedCategoryInputs);
    }, [checkedBrnadInputs, checkedCategoryInputs]);

    const brandElements = brands.map((brand) => <li key={brand.id}><FilterItem addCheckedInputValues={addCheckedInputValues} filterItem={brand}></FilterItem></li>);
    const categoryElements = categories.map((category) => <li key={category.id}><FilterItem filterItem={category} addCheckedInputValues={addCheckedInputValues}></FilterItem></li>);
    const subCategoryArrays = categories.map((category) => category.subCategories.map(subCateogry => subCateogry));

    let subCategoryElements = [];
    subCategoryArrays.forEach((array) => {
        let currentArray = array.concat(subCategoryElements);
        subCategoryElements = currentArray;
    });

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
    }


    const subCategoryItems = subCategoryElements.map((subCategory) => <li key={subCategory.id}><FilterItem filterItem={subCategory}></FilterItem></li>)

    return (
        <nav id="filter-menu-navigation">
          
            <h4 className="filter-title">Brands</h4>
            <ul>
                {brandElements }
            </ul>
            <hr></hr>
            <h4 className="filter-title">Categories</h4>
            <ul>
                {categoryElements}
                {/*{subCategoryItems}*/}
            </ul>
            <hr></hr>
        </nav>
    )
}