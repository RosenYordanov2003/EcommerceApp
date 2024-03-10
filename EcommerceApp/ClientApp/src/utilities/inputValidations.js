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
export const emailOrderInput = {
    name: 'email',
    label: 'Email',
    type: 'email',
    id: 'email',
    placeHolder: '',
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
export const cityInput = {
    name: 'city',
    label: 'City',
    type: 'text',
    id: 'city',
    placeHolder: 'Enter city',
    validation: {
        required: {
            value: true,
            message: 'required'
        },
        minLength: {
            value: 4,
            message: 'City name must be at least 5 characters',
        },
        maxLength: {
            value: 60,
            message: 'City name can not be more than 200 characters'
        }
    }
}
export const postalCodeInput = {
    name: 'postalCode',
    label: 'ZIP/POSTAL CODE',
    type: 'text',
    id: 'postal-code',
    placeHolder: 'Enter POSTAL/ZIP CODE',
    validation: {
        required: {
            value: true,
            message: 'required'
        },
        pattern: {
            value:
                /^[0-9]{4,}$/,
            message: 'Please enter valid postal code',
        },
       
    }
}
export const firstNameInput = {
    name: 'firstName',
    label: 'First Name',
    type: 'text',
    id: 'first-name',
    placeHolder: '',
    validation: {
        required: {
            value: true,
            message: 'required'
        },
        minLength: {
            value: 3,
            message: 'Fitst Name must be at least 3 characters',
        },
        maxLength: {
            value: 30,
            message: 'Fitst Name can not be more than 30 characters'
        }
    }
}
export const lastNameInput = {
    name: 'lastName',
    label: 'Last Name',
    type: 'text',
    id: 'last-name',
    placeHolder: '',
    validation: {
        required: {
            value: true,
            message: 'required'
        },
        minLength: {
            value: 3,
            message: 'Fitst Name must be at least 3 characters',
        },
        maxLength: {
            value: 30,
            message: 'Fitst Name can not be more than 30 characters'
        }
    }
}
export const streetAdressInput = {
    name: 'streetAdress',
    label: 'Street Adress',
    type: 'text',
    id: 'street',
    placeHolder: '',
    validation: {
        required: {
            value: true,
            message: 'required'
        },
        minLength: {
            value: 4,
            message: 'Adress must be at least 4 characters',
        },
        maxLength: {
            value: 60,
            message: 'Adress Name can not be more than 60 characters'
        }
    }
}
export const cityOrderInput = {
    name: 'city',
    label: 'City',
    type: 'text',
    id: 'city',
    placeHolder: '',
    validation: {
        required: {
            value: true,
            message: 'required'
        },
        minLength: {
            value: 4,
            message: 'City must be at least 4 characters',
        },
        maxLength: {
            value: 60,
            message: 'City Name can not be more than 60 characters'
        }
    }
}
export const phoneNumberInput = {
    name: 'phoneNumber',
    label: 'Phone Number',
    type: 'text',
    id: 'phone-number',
    placeHolder: '',
    validation: {
        required: {
            value: true,
            message: 'required'
        },
        pattern: {
            value:
                /^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$/,
            message: 'Please enter valid phone number',
        }
       
    }
}
export const userMessageInput = {
    name: 'message',
    type: 'text',
    id: 'message',
    placeHolder: 'Write a message...',
    validation: {
        required: {
            value: true,
            message: 'required'
        },
        minLength: {
            value: 5,
            message: 'Message must be at least 4 characters',
        },
        maxLength: {
            value: 70,
            message: 'Message Name can not be more than 70 characters'
        }
    }
}
export const productNameInput = {
    name: 'name',
    type: 'text',
    label: 'Name',
    id: 'name',
    validation: {
        required: {
            value: true,
            message: 'required'
        },
        minLength: {
            value: 3,
            message: 'Product name must be at least 3 characters',
        },
        maxLength: {
            value: 55,
            message: 'Product name can not be more than 55 characters'
        }
    }
}
export const productDescriptionInput = {
    name: 'description',
    id: 'description',
    type: 'text',
    label: 'Description',
    validation: {
        required: {
            value: true,
            message: 'required'
        },
       
        maxLength: {
            value: 450,
            message: 'Product description can not be more than 55 characters'
        }
    }
}
export const productPriceInput = {
    name: 'price',
    label: 'Price',
    type: 'text',
    validation: {
        required: {
            value: true,
            message: 'required'
        },
        pattern: {
            value:
                /^[0-9]+$/,
            message: 'Please enter valid price',
        },
    }
}


