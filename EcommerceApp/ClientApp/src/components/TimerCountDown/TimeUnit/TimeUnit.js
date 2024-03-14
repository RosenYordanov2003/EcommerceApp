import "../TimeUnit/TimeUnitStyle.css";
import "../TimeUnit/TimeUnitResponsiveStyle.css";

export default function TimeUnit({ unit }) {

    return (
        <section className="flip-card flip">
            <div className="top">{unit }</div>
            <div className="bottom">{unit}</div>
            <div className="next-unit">{unit}</div>
            <div className="top-next-unit">{unit}</div>
        </section>
    )
}