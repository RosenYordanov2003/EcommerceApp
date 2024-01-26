import PagerStyle from "../Pager/PagerStyle.css";

export default function Pager({ startPage, endPage, pageNumberChange }) {

    let result = []
    for (let i = startPage; i <=endPage ; i++) {
        result.push(i);
    }
    function handlePageNumberClick(pageNumber) {
        pageNumberChange(pageNumber);
    }

    return (
        <div className="pager-container">
            {startPage - 1 > 0 && <button onClick={() => handlePageNumberClick(startPage - 1)} className="previous-button">Previous</button>}

            <ul className="pager-ul">
                {result.map((x, index) => <li onClick={() => handlePageNumberClick(x)} key={index}>{x}</li>) }
            </ul>

            {startPage + 1 <= endPage && <button onClick={() => handlePageNumberClick(startPage + 1)} className="next-button">Next</button> }
        </div>
    )
}