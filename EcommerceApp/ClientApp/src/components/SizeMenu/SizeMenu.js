export default function SizeMenu({ productSize }) {

    const result = productSize.quantity > 0 ? <li className="size-item">{productSize.size}</li> : <li className="size-item"> <del>{productSize.size}</del> </li>;

    return (result);
}