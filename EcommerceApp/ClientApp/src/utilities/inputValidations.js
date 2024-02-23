export const userNameInput = {
    name: 'username',
    label: 'Username',
    type: 'text',
    id: 'name',
    placeHolder: 'Enter Username ...',
    validation: {
        required: {
            value: true,
            message: 'required',
        },
        minLength: {
            value: 3,
            message: 'Username must be at least 5 symbols length',
        },
    }
}
export const registerPasswordInput = {
    name: 'password',
    label: 'Password',
    type: 'password',
    id: 'password',
    placeHolder: 'Enter password ...',
    validation: {
        required: {
            value: true,
            message: 'required',
        },
    }
}
export const repeatPasswordInput = {
    name: 'repeatPassword',
    label: 'Repeat Password',
    type: 'password',
    id: 'repeat-password',
    placeHolder: 'Repeat password ...',
    validation: {
        required: {
            value: true,
            message: 'required',
        },
    }
}
export const emailInput = {
    name: 'email',
    label: 'Email',
    type: 'email',
    id: 'email',
    placeHolder: 'Enter an email...',
    validation: {
        required: {
            value: true,
            message: 'required',
        },
        pattern: {
            value:
                /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/,
            message: 'Please enter a valid email',
        },
    }
}
export const reviewSubjectInput = {
    name: 'subject',
    label: 'Subject',
    type: 'text',
    id: 'subject',
    placeHolder: 'Enter a subject...',
    validation: {
        required: {
            value: true,
            message: 'required'
        }
    }
}
export const reviewContent = {
    name: 'content',
    label: 'Review',
    type: 'text',
    id: 'subject',
    placeHolder: 'Write review...',
    multiline: true,
    rows: 10,
    cols: 60,
    validation: {
        required: {
            value: true,
            message: 'required'
        },
        minLength: {
            value: 5,
            message: 'Review content must be at least 5 characters',
        },
        maxLength: {
            value: 200,
            message: 'Review content can not be more than 200 characters'
        }
    }
}
