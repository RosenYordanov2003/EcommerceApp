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
import FeaturedProduct from './components/Products/FeaturedProduct';
import Clothes from "../src/components/AdminComponents/Clothes/Clothes";

export default function App() {

    const navigate = useNavigate();
    const [categories, setCategories] = useState([]);
    const [isActive, setActivity] = useState(false);
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
                    <Route path="/Product/:id" element={<UserFavoriteProducts />} />
                    <Route path="/" element={<Dashboard />} />
                </Routes>
            </>
    }
    else {
        result = <>
            <Navigation />
            <Routes>
                <Route path="/Home" element={<Home categories={categories} isActive={isActive} />} />
                <Route path="/Register" element={<Register />} />
                <Route path="/Login" element={<Login />} />
                <Route path="/Gender" element={<GenderProducts />}>
                    <Route path=":gender" element={<GenderProducts />} />
                </Route>
                <Route path="/ProductAbout/:productid/:category" element={<ProductInfo />} />
                <Route path="/" element={<Home categories={categories} isActive={isActive} />} />
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
                {result}

            </UserContext.Provider>

        </>
    )
}
