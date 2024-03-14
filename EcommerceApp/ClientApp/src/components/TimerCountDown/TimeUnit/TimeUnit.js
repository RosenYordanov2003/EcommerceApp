import { useEffect } from "react";
import "../TimeUnit/TimeUnitStyle.css";

export default function TimeUnit({ unit }) {

    return (
        <section className="flip-card flip">
            <div className="top">{unit }</div>
            <div className="bottom">{unit}</div>
            {unit - 1 > 0 && <p className="next-unit">{unit - 1}</p> }
        </section>
    )
}