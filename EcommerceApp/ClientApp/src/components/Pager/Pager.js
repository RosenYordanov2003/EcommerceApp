import "../Pager/PagerStyle.css";

export default function Pager({ startPage, endPage, onPageNumberChange, currentPage }) {

    let result = [];
    for (let i = startPage; i <= endPage ; i++) {
        result.push(i);
    }
    function handlePageNumberClick(pageNumber) {
        onPageNumberChange(pageNumber);
    }


    return (
        <div className="pager-container">
            {currentPage - 1 >= startPage && <button onClick={() => handlePageNumberClick(currentPage - 1)} className="previous-button">Previous</button>}

            <ul className="pager-ul">
                {result.map((x, index) => <li className={x === currentPage ? 'active-page' : ''} onClick={() => handlePageNumberClick(x)} key={index}>{x}</li>) }
            </ul>

            {currentPage + 1 <= endPage && <button onClick={() => handlePageNumberClick(currentPage + 1)} className="next-button">Next</button> }
        </div>
    )
}