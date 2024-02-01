export default function OrderTableRows({ order }) {
    return (
        <tr>
            <td>{order?.id }</td>
            <td className={`${order?.status === 'Pending' ? "pending-status" : "delivered-status"}`}>{order?.status }</td>
            <td>${order?.price.toFixed(2)}</td>
            <td>Details</td>
        </tr>
    )
}