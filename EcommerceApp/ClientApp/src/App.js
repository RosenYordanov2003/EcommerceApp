import { Route, Routes } from 'react-router-dom';
import Home from "./components/Home/Home";
import Navigation from "./components/Navigation/Navigation";

export default function App() {

    return (
        <>
            <Navigation></Navigation>
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/Home" element={<Home />} />
            </Routes>
       </>
    )
}
