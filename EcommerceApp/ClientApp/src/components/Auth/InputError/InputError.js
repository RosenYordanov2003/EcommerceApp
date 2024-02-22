import {  motion } from 'framer-motion'
import { MdError } from 'react-icons/md'
import InputErrrorStyle from "../InputError/InputErrrorStyle.css";

export default function InputError({ message }) {
    const framer_error = {
        initial: { opacity: 0, y: 10 },
        animate: { opacity: 1, y: 0 },
        exit: { opacity: 0, y: 10 },
        transition: { duration: 0.2 },
    }

    return (
        <motion.p
            className="input-error"
            {...framer_error}
             >
            <MdError />
            {message}
        </motion.p>
    )
}