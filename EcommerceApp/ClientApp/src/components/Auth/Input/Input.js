import { useFormContext } from 'react-hook-form'
import { AnimatePresence, motion } from 'framer-motion'
import { isFormInvalid } from "../../../utilities/isFormInvalid";
import { findInputError } from "../../../utilities/findInputError";
import InputError from "./../InputError/InputError";
import "../Input/InputStyle.css";

export default function Input({ label, type, id, placeHolder, validation, name, multiline, rows, cols, classNameValue="input-container"}) {

    const { register, formState: { errors }} = useFormContext();

    const inputError = findInputError(errors, name);
    const isInvalid = isFormInvalid(inputError);

    function onMouseEnter(event) {
        if (!label) {
            return;
        }
        event.target.parentElement.children[0].classList.add("active-label");
    }
    function onMouseLeave(event) {
        if (!label) {
            return;
        }
        event.target.parentElement.children[0].classList.remove("active-label");
    }

    return (
        <section className={classNameValue}>

            <AnimatePresence mode="wait" initial={false}>
                {isInvalid && (
                    <InputError
                        message={inputError.error.message}
                        key={inputError.error.message}
                    />
                )}
            </AnimatePresence>
            {label && <label htmlFor={id}>{label}</label> }
            {
                multiline ?
                    <textarea
                    onMouseEnter={onMouseEnter}
                    onMouseLeave={onMouseLeave}
                    id={id}
                    placeholder={placeHolder} {...register(`${name}`, validation)}
                    rows={rows}
                    cols={cols}
                 />
                    :
                    <input
                        onMouseEnter={onMouseEnter}
                        onMouseLeave={onMouseLeave}
                        id={id}
                        type={type}
                        placeholder={placeHolder}
                        {...register(name, validation)}
                    />
             }
        </section>
    )
}