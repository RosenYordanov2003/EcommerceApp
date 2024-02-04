import { useState, useEffect } from "react";
import DashBoardStyle from "../Dashboard/DashBoardStyle.css";
import { loadDashboard, getAllOrders, getRecentOrders } from "../../../services/dashboardService";
import OrderTableRows from "../OrderTableRows/OrderTableRows";
import SvgCircle from "../SvgCircle/SvgCircle";
import { HubConnectionBuilder} from '@microsoft/signalr';

export default function Dashboard() {

    const [dashboardObject, setDashboardObject] = useState(undefined);
    const [date, setDate] = useState(undefined);
    const [month, setMonth] = useState(undefined);
    const [areShowed, setAreShowed] = useState(false);
    const [connection, setConnection] = useState(null);


    const weekday = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
    const months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

    useEffect(() => {
        const newConnection = new HubConnectionBuilder()
            .withUrl('https://localhost:7122/notifications-hub')
            .withAutomaticReconnect()
            .build();
        setConnection(newConnection);
    }, [])

    useEffect(() => {
        loadDashboard(date, month)
            .then((res) => setDashboardObject(res))
            .catch((error) => console.error(error));
    }, [date, month])

    useEffect(() => {
        if (connection) {
            connection.start()
                .then(() => {
                    console.log('Connection started!');
                    connection.on('PurchaseMade', () => {
                        loadDashboard(date, month)
                            .then((res) => setDashboardObject(res))
                            .catch((error) => console.error(error));
                    });
                })
                .catch(console.error);
        }
    }, [connection]);

    const ordersResult = dashboardObject?.orders.map((order) => <OrderTableRows order={order} key={order.id} />);


    function showAllOrders() {
        if (areShowed === false) {
            getAllOrders()
                .then(res => {
                    setDashboardObject({ ...dashboardObject, orders: res });
                    setAreShowed(!areShowed);
                })
                .catch((error) => console.error(error));
        }
        else {
            getRecentOrders()
                .then((res) => {
                    setDashboardObject({ ...dashboardObject, orders: res });
                    setAreShowed(!areShowed);
                })
                .catch((error) => console.error(error));
        }
    }

    return (
        <div className="dashboard-container">
            <h1 className="dashboard-title">Dashboard</h1>
            <section className="dates-container">
                <div className="date-container">
                    <label htmlFor="day">Select Day</label>
                    <input id="day" onChange={(e) => setDate(e.target.value)} type="date"></input>
                </div>
                <div className="date-container">
                    <label htmlFor="month">Select Month</label>
                    <input id="motnh" onChange={(e) => setMonth(e.target.value)} type="date"></input>
                </div>
            </section>
            <div className={`statistic-container ${(date !== undefined && date !== "") ? "statistic-tripple-container" : ""}`}>
                <section className="statistic-section">
                    <div className="content">
                        <span class="material-symbols-outlined">
                            attach_money
                        </span>
                        <h3 className="statistic-title">Total Sales</h3>
                        <p className="statistic-result">${Number(dashboardObject?.totalSales).toFixed(3)}</p>
                    </div>
                    <div className="circle-container">
                        <SvgCircle percantage={100} />
                    </div>
                </section>
                <section className="statistic-section">
                    <div className="content">
                        <span className="material-symbols-outlined">
                            equalizer
                        </span>

                        {
                            (month !== undefined && month !== "") ?
                            <>
                                    <h3 className="statistic-title">Total Sales For {`${months[new Date(month).getMonth()]} ${new Date(month).getFullYear()}`}</h3>
                                <p className="statistic-result">${Number(dashboardObject?.totalSalesForParticulMonth).toFixed(3)}</p>
                            </>
                                :
                             <>
                                <h3 className="statistic-title">Total Sales For The Month</h3>
                                <p className="statistic-result">${Number(dashboardObject?.totalSalesForTheMonth).toFixed(3)}</p>
                             </>
                        }
                    </div>
                    <div className="circle-container">
                    {
                            (month !== undefined && month !== "") ?
                                <SvgCircle percantage={(dashboardObject?.totalSalesForParticulMonth / dashboardObject?.totalSales) * 100} />
                                :
                                <SvgCircle percantage={(dashboardObject?.totalSalesForTheMonth / dashboardObject?.totalSales) * 100} />
                    }
                    </div>
                </section>
                {(date !== undefined && date !== "") && <section className="statistic-section">
                    <div className="content">
                        <span class="material-symbols-outlined">
                            monitoring
                        </span>
                        <h3 className="statistic-title">Day Sales For {`${weekday[new Date(date).getDay()]} - ${months[new Date(date).getMonth()]} - ${new Date(date).getFullYear() }`}</h3>
                        <p className="statistic-result">${Number(dashboardObject?.totalSalesForParticularDay).toFixed(3)}</p>
                    </div>
                    <div className="circle-container">
                        <SvgCircle percantage={(dashboardObject?.totalSalesForParticularDay / dashboardObject?.totalSales) * 100} />
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
                    <button onClick={showAllOrders} className="show-all">{areShowed ? "Hide" : "Show All" }</button>
                </div>
            </div>
        </div>

    )
}