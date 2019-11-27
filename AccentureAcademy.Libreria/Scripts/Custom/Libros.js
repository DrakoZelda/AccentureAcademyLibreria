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
  getCrearView(e.target.dataset.actionlink)
})

function getCrearView(url){
  let xhr = new XMLHttpRequest
  xhr.open("GET", url)
  xhr.addEventListener("readystatechange", () => {
    if(xhr.readyState == 4 && xhr.status == 200){
      main.innerHTML = xhr.response
    }
  })
  xhr.send()
}
