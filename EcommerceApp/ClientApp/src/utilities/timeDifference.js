export function getTimeDifference(userMessagedate) {

    const today = new Date();
    const messageDate = new Date(userMessagedate);

    const diff = today - messageDate;
    const seconds = Math.floor(diff / 1000);

    const secondsInYear = 31556926;
    const secondsInWeek = 604800;
    const secondsInDay = 86400;
    const secondsInMonth = 2629743.83;
    const secondsInHour = 3600;
    const secondInMinute = 60;

    let result;

    if (seconds / secondsInYear >= 1) {
        const dateValue = calculateTimeValue(seconds, secondsInYear);
        result = `${dateValue} ${dateValue > 1 ? "years" : "year"} ago`;
    }
    else if (seconds / secondsInMonth >= 1) {
        const dateValue = calculateTimeValue(seconds, secondsInMonth);
        result = `${dateValue} ${dateValue > 1 ? "motnhs" : "month"} ago`;
    }
    else if (seconds / secondsInWeek >= 1) {
        const dateValue = calculateTimeValue(seconds, secondsInWeek);
        result = `${dateValue} ${dateValue > 1 ? "weeks" : "week"} ago`;
    }
    else if (seconds / secondsInDay >= 1) {
        const dateValue = calculateTimeValue(seconds, secondsInDay);
        result = `${dateValue} ${dateValue > 1 ? "days" : "day"} ago`;
    }
    else if (seconds / secondsInHour >= 1) {
        const dateValue = calculateTimeValue(seconds, secondsInHour);
        result = `${dateValue} ${dateValue > 1 ? "hours" : "hour"} ago`;
    }
    else if (seconds / secondInMinute >= 1) {
        const dateValue = calculateTimeValue(seconds, secondInMinute);
        result = `${dateValue} ${dateValue > 1 ? "minutes" : "minute"} ago`;
    }
    else {
        result = `${seconds} ${seconds > 1 ? "seconds" : "second"} ago`;
    }
    return result;

    function calculateTimeValue(seconds, timeParameter) {
        const value = Number.parseInt(seconds / timeParameter);

        return value;
    }

}