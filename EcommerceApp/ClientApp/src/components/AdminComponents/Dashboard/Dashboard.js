import { useState, useEffect } from "react";
import DashBoardStyle from "../Dashboard/DashBoardStyle.css";
import { loadDashboard } from "../../../services/dashboardService";

export default function Dashboard() {

    const [dashboardObject, setDashboardObject] = useState(undefined);
    const [date, setDate] = useState(undefined);

    useEffect(() => {
        loadDashboard(date)
            .then((res) => {
                console.log(res);
                setDashboardObject(res);
            })
            .catch((error) => console.error(error));
    }, [date])


    console.log(date);

    return (
        <div className="dashboard-container">
            <h1 className="dashboard-title">Dashboard</h1>
            <input onChange={(e) => setDate(e.target.value)} type="date"></input>
            <div className={`statistic-container ${(date !== undefined && date !== "") ? "statistic-tripple-container" : ""}` }>
                <section className="statistic-section">
                    <div className="content">
                        <span className="material-symbols-outlined total-sales-icon">
                            monitoring
                        </span>
                        <h3 className="statistic-title">Total Sales</h3>
                        <p className="statistic-result">${Number(dashboardObject?.totalSales).toFixed(3)}</p>
                    </div>
                    <div className="circle-container">
                        <svg>
                            <circle cx="38" cy="38" r="36"></circle>
                        </svg>
                        <p className="statistic-percentage">45%</p>
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
                        <svg>
                            <circle cx="38" cy="38" r="36"></circle>
                        </svg>
                        <p className="statistic-percentage">55%</p>
                    </div>
                </section>
                {(date!== undefined && date!== "") && <section className="statistic-section">
                    <div className="content">
                        <span className="material-symbols-outlined">
                            equalizer
                        </span>
                        <h3 className="statistic-title">Day Sales</h3>
                        <p className="statistic-result">${Number(dashboardObject?.totalSalesForParticularDay).toFixed(3)}</p>
                    </div>
                    <div className="circle-container">
                        <svg>
                            <circle cx="38" cy="38" r="36"></circle>
                        </svg>
                        <p className="statistic-percentage">55%</p>
                    </div>
                </section>}
              
            </div>
        </div>
    )
}