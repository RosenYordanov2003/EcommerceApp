import OrderProductStyle from "../OrderProduct/OrderProductStyle.css";

export default function OrderProduct({ product }) {
    return (
        <article className="order-product-container">
            <div className="order-product-img-container">
                <img src={product.imgUrl}></img>
            </div>
            <div className="product-order-info">
                <h4>{product.name}</h4>
                <p className="order-product-price">${Number.parseFloat(Number.parseFloat(product.price)).toFixed(2)}</p>
                <p className="order-product-quantity">X {product.quantity }</p>
                <p className="order-product-quantity">Size: {product.size }</p>
            </div>
        </article>
    )
}