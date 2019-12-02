function ValidateLibroForm() {
    let nombre = document.forms["_form"]["Nombre"].value
    let anioPublicacion = document.forms["_form"]["AnioPublicacion"].value
    let nroPaginas = document.forms["_form"]["NroPaginas"].value
    let isbn = document.forms["_form"]["ISBN"].value
    let errorsMessages = []

    if (nombre == "" || nombre == null) {
        errorsMessages.push("El titulo es requerido")
    }

    if (nombre.length > 50 || nombre.length < 2) {
        errorsMessages.push("El titulo debe poseer entre 2 y 50 caracteres")
    }

    if (nroPaginas <= 0 || nroPaginas >= 5001) {
        errorsMessages.push("El numero de paginas debe ser mayor a 0 y menor o igual a  5000")
    }

    if (isbn == "" || isbn == null) {
        errorsMessages.push("El ISBN es requerido")
    }

    if (isbn.length > 22 || isbn.length < 22) {
        errorsMessages.push("El ISBN debe ser de 22 caracteres de longitud")
    }

    if (errorsMessages.length > 0) {
        errorsMessages.forEach(errorMessage => {
            let p = document.createElement("p")
            p.innerText = errorMessage
            document.forms["_form"].appendChild(p)
            return false
        })
    } else {
        return true
    }
}