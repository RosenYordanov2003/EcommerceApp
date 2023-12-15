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



export default function App() {

    const navigate = useNavigate();
    const [categories, setCategories] = useState([]);
    const [isActive, setActivity] = useState(false);
    const [user, setUser] = useState(undefined);


    useEffect(() => {
        if (!user) {
            refreshToken()
                .then((res) => {
                    setUser(res.username);
                })
                .catch(() => {
                    navigate("/Login");
                })
        }
    }, [])
   
    return (
        <>
            <UserContext.Provider value={{ user, setUser }}>
                
                <Navigation/>
                <RefreshToken/>
                <Routes>
                    <Route path="/Home" element={<Home categories={categories} isActive={isActive} />} />
                    <Route path="/Register" element={<Register />} />
                    <Route path="/Login" element={<Login />} />
                    <Route path="/Gender" element={<GenderProducts/>}>
                        <Route path=":gender" element={<GenderProducts />} />
                    </Route>
                    <Route path="/ProductAbout/:productid" element={<ProductInfo/>}/>
                    <Route path="/" element={<Home categories={categories} isActive={isActive} />} />
                </Routes>
            </UserContext.Provider>
          
       </>
    )
}
