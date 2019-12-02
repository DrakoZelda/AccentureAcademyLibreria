﻿let navBtns = document.querySelectorAll(".navigation-button")
let main = document.querySelector("main")
let chips = []
// let xhr = new XMLHttpRequest
//
// xhr.open("GET", "/Libros/Editar/1")
//
// xhr.addEventListener("readystatechange", () => {
//   if(xhr.readyState == 4 && xhr.status == 200){
//     main.innerHTML = xhr.response
//   }
// })
// xhr.send()
// let buttonCrearView =


navBtns.forEach(button => button.addEventListener("click", e => {
    if (e.target.name == "crearLibroView") {
        getViewLibro(e.target.dataset.actionlink)
    } else {
        getView(e.target.dataset.actionlink)

    }
}))

function chipsLibro() {
    let inputRelacion = document.getElementById("inputGeneros")

    inputRelacion.addEventListener("change", e => {
        chips = []
        chips.push(e.target.value + "X")
        let div = document.createElement("div")
        let close = document.createElement("button")
        close.className = "close"
        close.innerText = "x"
        div.className = "chip"
        div.innerText = e.target.value
        div.appendChild(close)
        let divInput = document.getElementById("divGeneros")
        divInput.appendChild(div)
        e.target.value = ""

        div.addEventListener("click", e => {
            let i = chips.indexOf(e.target.innerText)
            chips.splice(i, 1)
            e.target.parentNode.removeChild(e.target)
        })
    })
}


function getView(url){
  let xhr = new XMLHttpRequest
  xhr.open("GET", url)
  xhr.addEventListener("readystatechange", () => {
    if(xhr.readyState == 4 && xhr.status == 200){
      main.innerHTML = xhr.response
      let buttonSubmit = main.children._form.lastElementChild
      attachAction(buttonSubmit, main.children._form.dataset.actionlink)


    }
  })
  xhr.send()
}

function getViewLibro(url) {
    let xhr = new XMLHttpRequest
    xhr.open("GET", url)
    xhr.addEventListener("readystatechange", () => {
        if (xhr.readyState == 4 && xhr.status == 200) {
            main.innerHTML = xhr.response
            let buttonSubmit = main.children._form.lastElementChild
            chipsLibro()
        }
    })
    xhr.send()
}

function attachAction(button, actionlink){
  button.addEventListener("click", e => {
    e.preventDefault()
    sendFormTo(main.children._form, actionlink)
  })
}

function sendFormTo(form, actionlink){
  let xhr = new XMLHttpRequest
  let formData = new FormData(form)
  xhr.open("POST", actionlink)
  xhr.addEventListener("readystatechange", () =>{
    if(xhr.readyState == 4 && xhr.status == 200){
      return xhr.response
    }
  })
  xhr.send(formData)
}
