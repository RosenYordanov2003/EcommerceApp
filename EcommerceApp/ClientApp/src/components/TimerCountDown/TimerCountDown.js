import { useState, useEffect } from "react";
import "../TimerCountDown/TimerCountDownStyle.css";

export default function TimerCountDown({ miliseconds}) {

    const [duration, setDuration] = useState(miliseconds);

    useEffect(() => {
        setTimeout(() => {
            if (duration !== undefined) {
                const newDuration = duration - 1000;
                setDuration(newDuration);
            }
        }, 1000)
    }, [duration])

    function formatTime(time) {
        const totalSeconds = Number.parseInt(time / 1000);
        const totalMinutes = Number.parseInt(totalSeconds / 60);
        const totalHours = Number.parseInt(totalMinutes / 60);
        const totalDays = Number.parseInt(totalHours / 24);


        const seconds = totalSeconds % 60;
        const minutes = totalMinutes % 60;
        const hours = totalHours % 24;


        const formattedSseconds = seconds < 10 ? `0${seconds}` : seconds;
        const formattedMinutes = minutes < 10 ? `0${minutes}` : minutes;
        const formattedHours = hours < 10 ? `0${hours}` : hours;
        const formattedDays = totalDays < 10 ? `0${totalDays}` : totalDays


        return `${formattedDays}:${formattedHours}:${formattedMinutes}:${formattedSseconds}`;
    }

    return (
        <div className="timer-container">
            {duration !== undefined && formatTime(duration)}
        </div>
    )
}