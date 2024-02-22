export function findInputError(errors, inputName) {
    const filtered = Object.keys(errors)
        .filter(key => key.includes(inputName))
        .reduce((cur, key) => {
            return Object.assign(cur, { error: errors[key] })
        }, {})
    return filtered
}
