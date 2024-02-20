import { archiveProduct, restoreProduct, setProductToBeFeatured, removeProductToBeFeatured } from "../../../../adminServices/clothesService";
import { setShoesToBeFeatured, removeFeaturedShoes } from "../../../../adminServices/shoesService";
import { uploadImg } from "../../../../adminServices/pictureService";
import PoppupMessage from "../../../PoppupMessage/PoppupMessage";
import { useState } from "react";

export default function ButtonsContainer({ isArchived, isFeatured, productId, category, addMessage }) {

    const [fileInputObject, setFileInput] = useState(undefined);


    function handleOnImgUpload() {

        const formData = new FormData();
        formData.append("productId", productId);
        formData.append("productCategory", category);
        formData.append("pictureFile", fileInputObject);

        uploadImg(formData)
            .then(() => addMessage("Successfully upload an img"))
            .catch((error) => console.error(error));
    }
    function handleOnFileChange(e) {
        setFileInput(e.target.files[0]);
    }
    function handleOnArchiveClickToggle() {
        if (!isArchived) {
            archiveProduct(productId, category)
                .then(() => addMessage("Successfylly Archive Product"))
                .catch((error) => console.error(error));
        }
        else {
            restoreProduct(productId, category)
                .then(() => addMessage("Successfylly Restore Product"))
                .catch((error) => console.error(error));
        }
    }
    function handleOnFeatureClick() {
        if (category.toLocaleLowerCase() === 'shoes') {
            if (isFeatured) {
                removeFeaturedShoes(productId)
                    .then(() => addMessage("Successfully remove product from feature product collection"))
                    .catch((error) => console.error(error));
            }
            else {
                setShoesToBeFeatured(productId)
                    .then(() => addMessage("Successfully add product to feature product collection"))
                    .catch((error) => console.error(error));
            }
        }
        else {
            if (isFeatured) {
                removeProductToBeFeatured(productId)
                    .then(() => addMessage("Successfully remove product from feature product collection"))
                    .catch((error) => console.error(error));
            }
            else {
                setProductToBeFeatured(productId)
                    .then(() => addMessage("Successfully remove product from feature product collection"))
                    .catch((error) => console.error(error));
            }

        }
    }

    return (
        <div className="product-buttons-container">
            <section className="add-img-container-section">
                <div className="add-img-container">
                    <input onChange={(handleOnFileChange)} type="file"></input>
                    <button>Add Img</button>
                </div>
                <button className="upload-img" onClick={handleOnImgUpload}>Upload</button>
            </section>
            <div onClick={handleOnArchiveClickToggle} className="archive-container"><button>{isArchived ? "Restore" : "Archive"}</button></div>
            <div onClick={handleOnFeatureClick} className="feature-container"><button>{isFeatured ? "Remove From Feature" : "Set Feature"}</button></div>
        </div>
    )
}