import { useState } from "react";
import { deleteImg } from "../../../adminServices/pictureService";

export default function ProductImg({ imgUrl, id }) {

    const [isActive, setIsActive] = useState(false);
    const category = window.location.pathname.split('/')[3];

    function handleOnImgDelete() {
        const object = {
            id: id,
            pictureProductCategory: category,
            imgUrl: imgUrl
        }
        deleteImg(object)
            .then(() => console.log(true))
            .catch((error) => console.error(error));
    }

    return (
        <div onMouseEnter={() => setIsActive(true)} onMouseOut={() => setIsActive(false)} className="admin-img-container">
            <img src={imgUrl} />
            <button onClick={handleOnImgDelete} className={`delete-img-button ${isActive ? 'active-delete-button' : ''}`}>Delete</button>
        </div>
    )
}