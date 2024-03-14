import TimerCountDown from "../../TimerCountDown/TimerCountDown";

export default function ProductPromotionPriceSection({ product }) {
    return (
        <section className="price-section">
            <del><p className="product-price">${Number.parseFloat(product?.price).toFixed(2)}</p></del>
            <p className="product-price">${Number.parseFloat(product?.price - ((product?.price * product?.dicountPercentage) / 100)).toFixed(2)}</p>
            {
                product?.totalMilisecondsDifference !== undefined &&
                <div className="product-promotion-section">
                    <h3>Promotion Ends In</h3>
                    <TimerCountDown key={product?.totalMilisecondsDifference} miliseconds={product?.totalMilisecondsDifference} />
                </div>

            }
        </section>
    )
}