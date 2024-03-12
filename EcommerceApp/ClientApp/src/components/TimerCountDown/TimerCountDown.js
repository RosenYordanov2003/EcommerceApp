import { useState, useEffect } from "react";

export default function TimerCountDown({ miliseconds }) {

    const [duration, setDuration] = useState(Number.parseInt(miliseconds));

    useEffect(() => {
        setTimeout(() => {
            const newDuration = Number.parseInt(duration) - 1000;
            setDuration(newDuration);
        }, 1000)
    }, [duration])

    function formatTime(time) {
        const totalSeconds = Number.parseInt(time / 1000);
        const totalMinutes = Number.parseInt(totalSeconds / 60);
        const totalHours = Number.parseInt(totalMinutes / 60);
        const totalDays = Number.parseInt(totalHours / 24);

        let seconds = totalSeconds % 60;
        let minutes = totalMinutes % 60;
        let hours = totalHours % 24;

        let formatedSseconds = seconds < 10 ? `0${seconds}` : seconds;
        let formatedMinutes = minutes < 10 ? `0${minutes}` : minutes;
        let formatedHours = hours < 10 ? `0${hours}` : hours;

        return `${totalDays}:${formatedHours}:${formatedMinutes}:${formatedSseconds}`;
    }

    return (
        <>
            {formatTime(duration)}
        </>
    )
}