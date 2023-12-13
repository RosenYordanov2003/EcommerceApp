export default function FilterItem({ filterItem }) {
    return (
        <div>
            <input type="checkBox" />
            <p>{filterItem.name}</p>
        </div>
    )
}