let main = document.querySelector("main")

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

let buttonCrearView = main.children.crearView

buttonCrearView.addEventListener("click", e => {
  getView(e.target.dataset.actionlink)
})

function getView(url){
  let xhr = new XMLHttpRequest
  xhr.open("GET", url)
  xhr.addEventListener("readystatechange", () => {
    if(xhr.readyState == 4 && xhr.status == 200){
      main.innerHTML = xhr.response
      console.dir(main)
      let buttonSubmit = main.children._form.lastElementChild
      attachAction(buttonSubmit, main.children._form.dataset.actionlink)
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
