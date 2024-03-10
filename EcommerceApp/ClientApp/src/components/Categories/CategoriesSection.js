import "../Categories/Styles/Style.css";
import { useState,useEffect } from "react";

export default function CategoriesSection({ categories, isActive }) {

    const [isVisible, setIsVisible] = useState(true);

    useEffect(() => {
        if (isActive === false) {
            setTimeout(() => {
                setIsVisible(false);
            }, 1100)
        }
        else {
            setIsVisible(true);
        }
    }, [isActive])

    const listItems = categories.map((category) => {
        return (
            <li className= "main-category" key=
                {category.id} > {category.name}
                <ul className = "sub-category-list">
                    {category.subCategories.map((subCategory) => <li className = "sub-category-item" key={subCategory.id}>{subCategory.name}</li>) }
                </ul>
            </li >
        )
    })
    const activityClassName = isActive ? "active" : "not-active"
    const visibleClass = isVisible ? "" : "not-visible";

    return (
        <ul className={`category-list ${activityClassName} ${visibleClass}`}>{listItems}</ul>
    )
}