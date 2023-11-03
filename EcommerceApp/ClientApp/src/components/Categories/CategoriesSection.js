import Style from "../Categories/Styles/Style.css";

export default function CategoriesSection({ categories, isActive }) {

    const listItems = categories.map((category) => <li key={category.id}>{category.name}</li>)
    const activityClassName = isActive ? "active" : "not-active"
    return (
        <ul className={`category-list ${activityClassName}`}>{listItems}</ul>
    )
}