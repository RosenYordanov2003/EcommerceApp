import { useEffect, useState } from 'react';
import { loadAllShoes } from "../../../adminServices/shoesService";
import ProductCard from "../Product/ProductCard/ProductCard";
import Pager from "../../Pager/Pager";
import { Grid } from 'react-loader-spinner';
export default function Shoes() {

    const [shoes, setShoes] = useState([]);
    const [pageNumber, setPageNumber] = useState(1);
    const [pageObject, setPageObject] = useState(undefined);
    const [isLoading, setIsLoading] = useState(false);

    useEffect(() => {
        loadAllShoes(pageNumber)
            .then(res => {
                setShoes(res.shoes);
                setPageObject(res.pagerObject);
            })
            .catch((error) => console.error(error));
    }, [pageNumber])

    const shoesResult = shoes?.map((s) => <ProductCard product={s} key={s.id} />);

    function handleOnPageNumberChange(newPageNumber) {
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
            {
                isLoading == true ? <Grid
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
                            {shoesResult}
                        </div>
                        <Pager startPage={pageObject?.startPage} currentPage={pageNumber} endPage={pageObject?.endPage} onPageNumberChange={handleOnPageNumberChange} />
                    </section>
            }
        </>
    )
}