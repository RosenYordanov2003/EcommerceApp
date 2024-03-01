import { useNavigate } from "react-router-dom";

export default function OrderTableRows({ order }) {

    const navigate = useNavigate();

    return (
        <tr>
            <td>{order?.id }</td>
            <td className={`${order?.status === 'Pending' ? "pending-status" : "delivered-status"}`}>{order?.status }</td>
            <td>${order?.price.toFixed(2)}</td>
            <td onClick={() => navigate(`/OrderDetails/${order?.id}`)}>Details</td>
        </tr>
    )
}