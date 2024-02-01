import { useEffect, useState } from "react"

export default function SvgCircle({ percantage }) {

    const [strokeDasharrayValue, setStrokeDasharrayValue] = useState(0);

    useEffect(() => {
        let roundRadius = 40;
        let roundPercent = percantage;
        let roundCircum = 2 * roundRadius * Math.PI;
        let roundDraw = roundPercent * roundCircum / 100;
        setStrokeDasharrayValue(roundDraw);
    }, [percantage])

    const myStyle = {
        strokeDasharray: `${strokeDasharrayValue}, 999`
    };

    return (
        <>
            <svg class="round" viewBox="0 0 100 100" width="200" height="200" data-percent={percantage} style={myStyle} >
                <circle cx="50" cy="50" r="40"/>
            </svg>
            <p className="statistic-percentage">{percantage.toFixed(2)}%</p>
       </>
           
    )
}