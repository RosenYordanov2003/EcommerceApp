import PagerStyle from "../Pager/PagerStyle.css";

export default function Pager({ totalReviewsLength, currentPage, endPage, pageNumberChange }) {

    let result = []
    for (let i = 1; i <=endPage ; i++) {
        result.push(i);
    }
    function handlePageNumberClick(pageNumber) {
        pageNumberChange(pageNumber);
    }

    return (
        <div className="pager-container">
            {currentPage - 1 > 0 && <button onClick={() => handlePageNumberClick(currentPage - 1)} className="previous-button">Previous</button>}

            <ul className="pager-ul">
                {result.map((x, index) => <li onClick={() => handlePageNumberClick(x)} key={index}>{x}</li>) }
            </ul>

            {currentPage + 1 <= endPage && <button onClick={() => handlePageNumberClick(currentPage + 1)} className="next-button">Next</button> }
        </div>
    )
}