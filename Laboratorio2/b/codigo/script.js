function agregar() {
  const list = document.getElementById("lista");
  const listItems = list.querySelectorAll("li");
  const numberOfItems = listItems.length;
  const newItem = document.createElement("li");
  newItem.textContent = "Elemento" + (numberOfItems + 1);
  list.appendChild(newItem);
}

function borrar() {
  const list = document.getElementById("lista");
  if (list.children.length > 0) {
    list.removeChild(list.lastElementChild);
  }
}

function cambiarFondo() {
  let newColor = "gray";
  if (document.body.style.backgroundColor == "gray") {
    newColor = "white";
  }

  document.body.style.backgroundColor = newColor;
}