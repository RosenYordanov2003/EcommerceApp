export default function FeaturedProduct({product }) {
    return (
        <div className="product-card">
            <div className="img-container">
                <img src={product.pictures[0].imgUrl }/>
            </div>
            <div className="product-content">
                <p>{product.starRating}</p>
                <p>{product.name }</p>
                <p>{product.price.toFixed("2") }</p>
            </div>
        </div>
       )
}