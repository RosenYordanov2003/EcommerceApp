import FilterItem from "../FilterItem/FilterItem";
import FilterMenuStyle from "../ProductsFilterMenu/FilterMenuStyle.css";

export default function FilterMenu({ props: { brands, categories } }) {

    const brandElements = brands.map((brand) => <li key={brand.id }><FilterItem filterItem={brand}></FilterItem></li>)

    return (
        <nav id = "filter-menu-navigation">
            <h4 className="title">Brands</h4>
            <ul>
                {brandElements }
            </ul>
        </nav>
    )
}