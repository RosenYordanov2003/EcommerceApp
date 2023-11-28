import { Route, Routes } from 'react-router-dom';
import { UserContext } from "./Contexts/UserContext";
import Home from "./components/Home/Home";
import Navigation from "./components/Navigation/Navigation";
import { useState } from "react";
import Register from "./components/Auth/Register/Register";
import Login from "./components/Auth/Login/Login";
import RefreshToken from "./components/Auth/RefreshToken/RefreshToken";


export default function App() {
   
    const [categories, setCategories] = useState([]);
    const [isActive, setActivity] = useState(false);
    const [user, setUser] = useState(undefined);


    function loadCategories(categories) {
        setCategories(categories);
    }
    function setIsActive(activity) {
        setActivity(activity);
    }
    return (
        <>
            <UserContext.Provider value={{ user, setUser }}>
                
                <Navigation loadCategories={loadCategories} setIsActive={setIsActive}></Navigation>
                <RefreshToken/>
                <Routes>
                    <Route path="/" element={<Home categories={categories} isActive={isActive} />} />
                    <Route path="/Home" element={<Home categories={categories} isActive={isActive} />} />
                    <Route path="/Register" element={<Register />} />
                    <Route path="/Login" element={<Login />} />
                </Routes>
            </UserContext.Provider>
          
       </>
    )
}
