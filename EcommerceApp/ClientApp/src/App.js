import { Route, Routes } from 'react-router-dom';
import Home from "./components/Home/Home";
import Navigation from "./components/Navigation/Navigation";
import { useState } from "react";

export default function App() {

    const [categories, setCategories] = useState([]);
    const [isActive, setActivity] = useState()


    function loadCategories(categories) {
        setCategories(categories);
    }
    function setIsActive(activity) {
        setActivity(activity);
        console.log(isActive);
    }
    return (
        <>
           
            <Navigation loadCategories={loadCategories} setIsActive={setIsActive }></Navigation>
            <Routes>
                <Route path="/" element={<Home categories={categories} isActive={isActive } />} />
                <Route path="/Home" element={<Home categories={categories} isActive={isActive } />} />
            </Routes>
       </>
    )
}
