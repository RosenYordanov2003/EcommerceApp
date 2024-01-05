import { useEffect, useState, useEffet, useContext } from "react";
import { UserContext } from "../../Contexts/UserContext";
import ShoppingCartStyle from "../UserCart/ShoppingCartStyle.css";
import UserCartItem from "../UserCart/UserCartItems/UserCartItem";

export default function UserCart() {
    const { user, setUser } = useContext(UserContext);

    const items = user?.cart?.cartProducts?.map((item) => <UserCartItem item={item} key={item.id} />)


    return (
        <>
            <h2 className="shopping-cart-title">Shopping Cart</h2>
            <table className="shopping-cart-table">
                <thead className="shopping-cart-headers">
                    <th>Item</th>
                    <th>Price</th>
                    <th>Quantity</th>
                    <th>Subtotal</th>
                </thead>
                {items}
            </table>
        </>
       
    )
}