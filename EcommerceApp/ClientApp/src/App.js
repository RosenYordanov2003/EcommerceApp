import { Route, Routes } from 'react-router-dom';
import Home from "./components/Home/Home";
import Navigation from "./components/Navigation/Navigation";
import { useState } from "react";
import Register from "./components/Auth/Register/Register";
import Login from "./components/Auth/Login/Login";


export default function App() {
   
    const [categories, setCategories] = useState([]);
    const [isActive, setActivity] = useState(false);


    function loadCategories(categories) {
        setCategories(categories);
    }
    function setIsActive(activity) {
        setActivity(activity);
    }
    return (
        <>
           
            <Navigation loadCategories={loadCategories} setIsActive={setIsActive }></Navigation>
            <Routes>
                <Route path ="/" element={<Home categories={categories} isActive={isActive } />} />
                <Route path ="/Home" element={<Home categories={categories} isActive={isActive} />} />
                <Route path="/Register" element={<Register />} />
                <Route path="/Login" element={<Login/> }/>
            </Routes>
       </>
    )
}
