import { useEffect, useState, useEffet, useContext } from "react";
import { UserContext } from "../../Contexts/UserContext";

export default function UserCart() {
    const { user, setUser } = useContext(UserContext);

    useEffect(() => {

        if (user?.id) {

        }

    }, [user?.id])
}