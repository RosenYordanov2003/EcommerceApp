export default function ReviewContainer() {

    const stars = Array.from({ length: 5 }, (star, index) => (
        <i key={index} className="fa-regular fa-star star"></i>
    ));

    return (
        <>
            <h2 className="review-title">Customor Reviews</h2>
            <div className="evaluation-container">
                <p className="product-evaluation">4.9</p>
                <div className="divider">/</div>
                <p className="reviews-count">2221 Reviews</p>
            </div>
            <button className="review-button">Write Review</button>
            <h2 className="write-title">Write Review</h2>
            <div className="write-review-star-container">
                <p>Your evaluation</p>
                <div>{stars }</div>
            </div>
            <form className = "review-form">
                <div className="input-container">
                    <label htmlFor="name">Name</label>
                    <input id = "name"></input>
                </div>
                <div className="input-container">
                    <label htmlFor="summary">Summary</label>
                    <input id="summary"></input>
                </div>
                <div className="input-container">
                    <label htmlFor="review">Review</label>
                    <textarea rows={10} cols={60} id="review"></textarea>
                </div>
                <button className = "submit-review-button">Submit Review</button>
            </form>
        </>
    )
}