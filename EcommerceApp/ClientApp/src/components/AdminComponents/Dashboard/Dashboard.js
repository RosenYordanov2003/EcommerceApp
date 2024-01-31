import DashBoardStyle from "../Dashboard/DashBoardStyle.css";

export default function Dashboard() {
    return (
        <div className="dashboard-container">
            <h1 className="dashboard-title">Dashboard</h1>
            <div className="statistic-container">
                <section className="statistic-section">
                    <div className="content">
                        <span className="material-symbols-outlined total-sales-icon">
                            monitoring
                        </span>
                        <h3 className="statistic-title">Total Sales</h3>
                        <p className="statistic-result">${Number(24.765).toFixed(3)}</p>
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
                        <span class="material-symbols-outlined">
                            equalizer
                        </span>
                        <h3 className="statistic-title">Total Sales For The Month</h3>
                        <p className="statistic-result">${Number(24.765).toFixed(3)}</p>
                    </div>
                    <div className="circle-container">
                        <svg>
                            <circle cx="38" cy="38" r="36"></circle>
                        </svg>
                        <p className="statistic-percentage">55%</p>
                    </div>
                </section>
            </div>
        </div>
    )
}