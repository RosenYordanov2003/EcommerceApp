import { useState } from "react"
import "../ProductStock/Style.css";
import { addProductStock } from "../../../adminServices/clothesService";
import { addShoesStcok } from "../../../adminServices/shoesService";
import PoppupMessage from "../../PoppupMessage/PoppupMessage";
import Input from "../../Auth/Input/Input";
import {productStockQuantityInput} from "../../../utilities/inputValidations";
import { FormProvider, useForm } from 'react-hook-form'

export default function ProductStock({ productStock }) {

    const methods = useForm();
    const [message, setMessage] = useState(undefined);

    const category = window.location.pathname.split("/")[3];

   const handleOnFormSubmit = methods.handleSubmit(data => {
       const object = {
           ...data,
           productStockId: productStock.id,
           productCategory: category,
       }
       const addProductStockFunction = category !== "Shoes" ? addProductStock : addShoesStcok;
       addProductStockFunction(object)
           .then(() => {
               setMessage(<PoppupMessage message="Successfully add product stock" removeNotification={() => setMessage(undefined)} />);
               methods.reset();
           })
           .catch((error) => console.error(error));
   })

    return (
            <div className="product-stock-admin-container">
                {message !== undefined && message}
            <p>{productStock.size}</p>
            <FormProvider {...methods}>
                <form onSubmit={(e) => e.preventDefault()} className="product-stock-form">
                    <Input {...productStockQuantityInput} classNameValue="add-product-stock-input"/>
                    <button onClick={handleOnFormSubmit}>Add Quantity</button>
                </form>
            </FormProvider>
               
            </div>
       
    )
}