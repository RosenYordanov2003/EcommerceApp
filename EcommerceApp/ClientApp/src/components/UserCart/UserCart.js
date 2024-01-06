import { useEffect, useState, useEffet, useContext } from "react";
import { UserContext } from "../../Contexts/UserContext";
import ShoppingCartStyle from "../UserCart/ShoppingCartStyle.css";
import UserCartItem from "../UserCart/UserCartItems/UserCartItem";

export default function UserCart() {
    const { user, setUser } = useContext(UserContext);

    const items = user?.cart?.cartProducts?.map((item) => <UserCartItem item={item} key={item.id} />)

    const shoesItems = user?.cart?.cartShoes?.map((item) => <UserCartItem item={item} key={item.id} />)

    console.log(user);

    return (
        <>
            <h2 className="shopping-cart-title">Shopping Cart</h2>
            <table className="shopping-cart-table">
                <thead className="shopping-cart-headers">
                    <tr>Item</tr>
                    <tr>Price</tr>
                    <tr>Quantity</tr>
                    <tr>Subtotal</tr>
                </thead>
                {items}
                {shoesItems }
            </table>
        </>

    )
}