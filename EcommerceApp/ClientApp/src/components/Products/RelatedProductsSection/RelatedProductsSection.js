import FeaturedProduct from "../FeaturedProduct";

export default function RelatedProductsSection({ product }) {

    const relatedProducts = product.relatedProducts.map((product) => <FeaturedProduct key={product.id} product={product} />)

    return (
        <section className="related-products-section">
            <h2 className="related-products-title">Related Products</h2>
            <hr></hr>
            <div className="related-products-container">
                {relatedProducts}
            </div>
        </section>
    )
}