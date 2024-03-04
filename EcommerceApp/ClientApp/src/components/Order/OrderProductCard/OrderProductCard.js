import Style from "../OrderProductCard/Style.css";

export default function OrderProductCard({ product }) {
    return (
        <article className="order-product-recap">
            <div className="recap-product-img-container">
                <img src={product.imgUrl}></img>
            </div>
            <section className="product-order-section-details">
                <div className="about-order-details-product">
                    <p>Name:</p>
                    <p className="order-product-prop">{product.name}</p>
                </div>
                <div className="about-order-details-product">
                    <p>Category:</p>
                    <p className="order-product-prop">{product.categoryName}</p>
                </div>
                <div className="about-order-details-product">
                    <p>Size:</p>
                    <p className="order-product-prop">{product.size}</p>
                </div>
                <div className="about-order-details-product">
                    <p>Quantity:</p>
                    <p className="order-product-prop">{product.quantity}</p>
                </div>
                <div className="about-order-details-product">
                    <p>Price:</p>
                    <p className="order-product-prop">${Number(product.price).toFixed(2)}</p>
                </div>
                <div className="about-order-details-product">
                    <p>Total Price:</p>
                    <p className="order-product-prop">${Number(product.price * product.quantity).toFixed(2)}</p>
                </div>
            </section>
           
        </article>
    )
}