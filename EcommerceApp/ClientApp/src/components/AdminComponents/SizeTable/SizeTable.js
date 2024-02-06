import Style from "../SizeTable/Style.css";

export default function SizeTable({ productStockArray }) {

    const tableHeaders = productStockArray?.map((productStock) => <th>{productStock.size}</th>);
    const quantityResult = productStockArray?.map((productStock) => <td>{productStock.quantity}</td>)

    return (
        <>
            <h3 className="size-table-title">Available Sizes</h3>
            <table className="size-table">
                <thead>
                    <tr>
                        {tableHeaders}
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        {quantityResult}
                    </tr>
                </tbody>
            </table>
        </>
      
    )
}