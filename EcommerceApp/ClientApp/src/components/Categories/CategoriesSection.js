export default function CategoriesSection({categories }) {

    const listItems = categories.map((category) => <li key={category.id}>{category.name}</li>)
    console.log(categories);
    return (
        <ul className = "category-list">{listItems }</ul>
    )
}