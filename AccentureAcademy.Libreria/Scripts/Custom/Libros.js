let main = document.querySelector("main")

let xhr = new XMLHttpRequest

xhr.open("GET", "/Libros/_FormLibros")

xhr.addEventListener("readystatechange", () => {
  if(xhr.readyState == 4 && xhr.status == 200){
    main.innerHTML = xhr.response
  }
})
xhr.send()
