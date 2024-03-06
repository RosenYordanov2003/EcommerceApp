import { useState, useEffect } from "react";
import { loadAllProducts } from "../../../adminServices/clothesService";
import ClothesStyle from "./ClothesStyle.css";
import ProductCard from "../Product/ProductCard/ProductCard";
import ResponsiveStyle from "../Clothes/ResponsiveStyle.css";
import Pager from "../../Pager/Pager";
import { Grid } from 'react-loader-spinner';
export default function Clothes() {

    const [clothes, setClothes] = useState([]);
    const [pageNumber, setPageNumber] = useState(1);
    const [pageObject, setPageObject] = useState(undefined);
    const [isLoading, setIsLoading] = useState(false);

    useEffect(() => {
        loadAllProducts(pageNumber)
            .then((res) => {
                setClothes(res.clothes);
                setPageObject(res.pagerObject);
            })
    }, [pageNumber])
    const clothesResult = clothes?.map((x) => <ProductCard product={x} key={x.id} />);

    function handlePageNumberChange(newPageNumber) {
        setPageNumber(newPageNumber);
        configureLoading();
    }
    function configureLoading() {
        setIsLoading(true);

        setTimeout(() => {
            setIsLoading(false);
        }, 500)
    }

    return (
        <>
            {isLoading == true ? <Grid
                height="80"
                width="80"
                color="#035096"
                ariaLabel="grid-loading"
                radius="12.5"
                wrapperStyle={{}}
                wrapperClass="spinner"
                className="spinner-loading"
                visible={true} /> :
                <section>
                    <div className="clothes-container-admin">
                        {clothesResult}
                    </div>
                    <Pager startPage={pageObject?.startPage} endPage={pageObject?.endPage} onPageNumberChange={handlePageNumberChange} currentPage={pageNumber} />
                </section>
            }
       </>
        
        
    )
}