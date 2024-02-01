import { useState, useEffect } from "react";
import DashBoardStyle from "../Dashboard/DashBoardStyle.css";
import { loadDashboard } from "../../../services/dashboardService";
import OrderTableRows from "../OrderTableRows/OrderTableRows";
import SvgCircle from "../SvgCircle/SvgCircle";

export default function Dashboard() {

    const [dashboardObject, setDashboardObject] = useState(undefined);
    const [date, setDate] = useState(undefined);


    const weekday = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
    const months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

    useEffect(() => {
        loadDashboard(date)
            .then((res) => setDashboardObject(res))
            .catch((error) => console.error(error));
    }, [date])


    const ordersResult = dashboardObject?.orders.map((order) => <OrderTableRows order={order} key={order.id} />)

    return (
        <div className="dashboard-container">
            <h1 className="dashboard-title">Dashboard</h1>
            <input id="day" onChange={(e) => setDate(e.target.value)} type="date"></input>
            <div className={`statistic-container ${(date !== undefined && date !== "") ? "statistic-tripple-container" : ""}`}>
                <section className="statistic-section">
                    <div className="content">
                        <span className="material-symbols-outlined total-sales-icon">
                            monitoring
                        </span>
                        <h3 className="statistic-title">Total Sales</h3>
                        <p className="statistic-result">${Number(dashboardObject?.totalSales).toFixed(3)}</p>
                    </div>
                    <div className="circle-container">
                        <SvgCircle percantage={100}/>
                    </div>
                </section>
                <section className="statistic-section">
                    <div className="content">
                        <span className="material-symbols-outlined">
                            equalizer
                        </span>
                        <h3 className="statistic-title">Total Sales For The Month</h3>
                        <p className="statistic-result">${Number(dashboardObject?.totalSalesForTheMonth).toFixed(3)}</p>
                    </div>
                    <div className="circle-container">
                        <SvgCircle percantage={45} />
                    </div>
                </section>
                {(date !== undefined && date !== "") && <section className="statistic-section">
                    <div className="content">
                        <span className="material-symbols-outlined">
                            equalizer
                        </span>
                        <h3 className="statistic-title">Day Sales For {`${weekday[new Date(date).getDay()]} - ${months[new Date(date).getMonth()]}`}</h3>
                        <p className="statistic-result">${Number(dashboardObject?.totalSalesForParticularDay).toFixed(3)}</p>
                    </div>
                    <div className="circle-container">
                        <SvgCircle percantage={(dashboardObject?.totalSalesForParticularDay / dashboardObject?.totalSales) * 100 } />
                    </div>
                </section>
                }
            </div>
            <div className="orders-container">
                <h1 className="orders-title">Orders</h1>
                <table>
                    <thead>
                        <tr>
                            <th>Order Id</th>
                            <th>Order Status</th>
                            <th>Total Price</th>
                        </tr>
                    </thead>
                    <tbody>
                        {ordersResult}
                    </tbody>
                </table>
                <div className="show-all-wrapper">
                    <button className="show-all">Show all</button>
                </div>
            </div>
        </div>

    )
}