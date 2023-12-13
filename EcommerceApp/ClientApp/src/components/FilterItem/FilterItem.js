export default function FilterItem({ filterItem }) {
    return (
        <div>
            <input className = "filter-input" type="checkBox" />
            <p className = "filter-name">{filterItem.name}</p>
        </div>
    )
}