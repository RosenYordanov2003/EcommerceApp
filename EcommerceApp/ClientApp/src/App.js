import { Route, Routes, useParams } from 'react-router-dom';
import { useNavigate } from "react-router-dom";
import { useEffect } from "react";
import { UserContext } from "./Contexts/UserContext";
import Home from "./components/Home/Home";
import Navigation from "./components/Navigation/Navigation";
import { useState } from "react";
import Register from "./components/Auth/Register/Register";
import Login from "./components/Auth/Login/Login";
import RefreshToken from "./components/Auth/RefreshToken/RefreshToken";
import { refreshToken } from "./services/authService";
import GenderProducts from "../src/components/GenderProducts/GenderProducts";
import ProductInfo from "../src/components/Products/ProductInfo";
import AllReviews from "../src/components/AllReviews/AllReviews";
import EditReview from "../src/components/EditReviewForm/EditReview";
import UserCart from "../src/components/UserCart/UserCart";
import Order from "../src/components/Order/Order";
import SuccessFullPage from "../src/components/SuccessfullPage/SuccessfullPage";
import UserFavoriteProducts from "../src/components/UserFavoriteProducts/UserFavoriteProducts";
import Dashboard from "../src/components/AdminComponents/Dashboard/Dashboard";
import AsideMenu from "../src/components/AdminComponents/AsideMenu/AsideMenu";
import Clothes from "../src/components/AdminComponents/Clothes/Clothes";
import ModifyingProduct from "./components/AdminComponents/Product/ModifyingProduct/ModifyingProduct";
import Shoes from "../src/components/AdminComponents/Shoes/Shoes";
import CreateProduct from "../src/components/AdminComponents/Product/CreateProduct/CreateProduct";
import AllUserMessages from "../src/components/AdminComponents/AllUserMessages/AllUserMessages";
import OrderDetails from "../src/components/Order/OrderDetails/OrderDetails";
import ClearExpiredPromotions from "../src/components/ClearExpiredPromotions/ClearExpiredPromotions";
import { clearExpiredPromotions } from "../src/services/promotionService";


export default function App() {

    const navigate = useNavigate();
    const [user, setUser] = useState(undefined);


    useEffect(() => {
        if (!user) {
            refreshToken()
                .then((res) => {
                    const user = {
                        username: res.username,
                        id: res.id,
                        userFavoriteProducts: res.userFavoriteProducts,
                        cart: res.cartModel,
                        roles: res.roles
                    };
                    setUser(user);
                })
                .catch(() => {
                    navigate("/Login");
                })

            clearExpiredPromotions();
        }
    }, [])

    let result;

    if (user?.roles?.includes('Administrator')) {

        result =
            <>
                <AsideMenu />
                <Routes>
                    <Route path="/Dashboard" element={<Dashboard />} />
                    <Route path="/Home" element={<Dashboard />} />
                    <Route path="/Clothes" element={<Clothes />} />
                    <Route path="/Shoes" element={<Shoes />} />
                    <Route path="/Create" element={<CreateProduct />} />
                    <Route path="/Messages" element={<AllUserMessages />} />
                    <Route path="/Product/:id/:category" element={<ModifyingProduct />} />
                    <Route path="/OrderDetails/:id" element={<OrderDetails />} />
                    <Route path="/" element={<Dashboard />} />
                </Routes>
            </>
    }
    else {
        result = <>
            <Navigation />
            <Routes>
                <Route path="/Home" element={<Home/>} />
                <Route path="/Register" element={<Register />} />
                <Route path="/Login" element={<Login />} />
                <Route path="/Gender" element={<GenderProducts />}>
                    <Route path=":gender" element={<GenderProducts />} />
                </Route>
                <Route path="/ProductAbout/:productid/:category" element={<ProductInfo />} />
                <Route path="/" element={<Home />} />
                <Route path="/AllReviews/:id/:category" element={<AllReviews />} />
                <Route path="/Review/:id" element={<EditReview />} />
                <Route path="/Cart" element={<UserCart />} />
                <Route path="/Order" element={<Order />} />
                <Route path="/CompletedOrder" element={<SuccessFullPage />} />
                <Route path="/FavoriteProducts/:id" element={<UserFavoriteProducts />} />
            </Routes>
        </>
    }

    return (
        <>
            <UserContext.Provider value={{ user, setUser }}>

                <RefreshToken />
                <ClearExpiredPromotions/>
                {result}
            </UserContext.Provider>

        </>
    )
}
