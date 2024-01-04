import { useEffect, useState, useEffet, useContext } from "react";
import { UserContext } from "../../Contexts/UserContext";
import ShoppingCartStyle from "../UserCart/ShoppingCartStyle.css";
import UserCartItem from "../UserCart/UserCartItems/UserCartItem";

export default function UserCart() {
    const { user, setUser } = useContext(UserContext);

    const items = user?.cart?.cartProducts?.map((item) => <UserCartItem item={item} key={item.id} />)


    return (
        <div className="shopping-cart-container">
            <h2 className="shopping-cart-title">Shopping Cart</h2>
            <section className="shopping-cart-headers">
                    <h4 className="main-header">Item</h4>
                    <h4>Price</h4>
                    <h4>Quantity</h4>
                    <h4>Subtotal</h4>
            </section>
            <>{items }</>
        </div>
    )
}