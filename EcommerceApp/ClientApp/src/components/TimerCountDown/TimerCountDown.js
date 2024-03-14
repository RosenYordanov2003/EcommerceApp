import { useState, useEffect } from "react";
import "../TimerCountDown/TimerCountDownStyle.css";
import "../TimerCountDown/TimeCountDownResponsiveStyle.css";
import TimeUnit from "../TimerCountDown/TimeUnit/TimeUnit";

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

        return {
            seconds,
            minutes,
            hours, 
            days: totalDays 
        }

    }
    const timeObject = formatTime(duration);

    return (
        <>
            {duration > 0 && <div className="timer-container">
                <section className="unit-time-section">
                    <h3 className="unit-time-title">Days</h3>
                    <div className="unit-time">
                        <TimeUnit key={timeObject.days} unit={timeObject.days} />
                        <p className="dot-separator">:</p>
                    </div>
                </section>
                <section className="unit-time-section">
                    <h3 className="unit-time-title">Hours</h3>
                    <div className="unit-time">
                        <TimeUnit key={timeObject.hours} unit={timeObject.hours} />
                        <p className="dot-separator">:</p>
                    </div>
                </section>
                <section className="unit-time-section">
                    <h3 className="unit-time-title">Minutes</h3>
                    <div className="unit-time">
                        <TimeUnit key={timeObject.minutes} unit={timeObject.minutes} />
                        <p className="dot-separator">:</p>
                    </div>
                </section>
                <section className="unit-time-section">
                    <h3 className="unit-time-title">Seconds</h3>
                    <div className="unit-time">
                        <TimeUnit key={timeObject.seconds} unit={timeObject.seconds} />
                    </div>
                </section>
            </div>
            }
          
         </>
      
    )
}