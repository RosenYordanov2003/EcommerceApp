import { useFormContext } from 'react-hook-form'
import { AnimatePresence, motion } from 'framer-motion'
import { MdError } from 'react-icons/md'
import { isFormInvalid } from "../../../utilities/isFormInvalid";
import { findInputError } from "../../../utilities/findInputError";
import InputError from "./../InputError/InputError";

export default function Input({ label, type, id, placeHolder, validation, name, multiline, rows, cols}) {

    //is used to register an input field with the library,
    //allowing it to handle validation.This function will be passed to the input element.

    const { register, formState: { errors } } = useFormContext();

    const inputError = findInputError(errors, name)
    const isInvalid = isFormInvalid(inputError)

    function handleOnInputFouc(event) {
        event.target.parentElement.children[0].classList.add("active-label");
    }
    function handleOnInputBlur(event) {
        event.target.parentElement.children[0].classList.remove("active-label");
    }

    return (
        <section className="input-container">

            <AnimatePresence mode="wait" initial={false}>
                {isInvalid && (
                    <InputError
                        message={inputError.error.message}
                        key={inputError.error.message}
                    />
                )}
            </AnimatePresence>
            <label htmlFor={id}>{label}</label>
            {
                multiline ? <textarea id={id} placeholder={placeHolder} {...register(`${name}`, validation)} rows={rows} cols={cols } />
                    :
                    <input
                        id={id}
                        type={type}
                        placeholder={placeHolder}
                        {...register(name, validation)}
                    />
             }
           
        </section>
    )
}