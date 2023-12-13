import FilterItem from "../FilterItem/FilterItem";
//import ResetStyle from "../../ResetStyles/ResetStyle.css";
import FilterMenuStyle from "../ProductsFilterMenu/FilterMenuStyle.css";


export default function FilterMenu({ props: { brands, categories } }) {

    const brandElements = brands.map((brand) => <li key={brand.id}><FilterItem filterItem={brand}></FilterItem></li>);
    const categoryElements = categories.map((category) => <li key={category.id}><FilterItem filterItem={category}></FilterItem></li>);
    const subCategoryArrays = categories.map((category) => category.subCategories.map(subCateogry => subCateogry));

    let subCategoryElements = [];
    subCategoryArrays.forEach((array) => {
        let currentArray = array.concat(subCategoryElements);
        subCategoryElements = currentArray;
    });


    const subCategoryItems = subCategoryElements.map((subCategory) => <li key={subCategory.id}><FilterItem filterItem={subCategory}></FilterItem></li>)

    console.log(categoryElements.Length + subCategoryElements.Length);
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
                {subCategoryItems}
            </ul>
            <hr></hr>
        </nav>
    )
}