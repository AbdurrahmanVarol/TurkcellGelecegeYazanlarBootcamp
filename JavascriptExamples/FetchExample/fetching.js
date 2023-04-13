const loadCategories = ()=>{
    let categories = []
    fetch("https://dummyjson.com/products/categories")
      .then((response) => response.json())
      .then((data) => {        
          categories.push(...data)
          const categoryElement = document.getElementById("categories")
          let htmlResult = ``
          for (let category of categories) {
            console.log("Category:" + category)
            htmlResult += `<button class="list-group-item" onClick="getProductsByCategory('${category}')">${category}</button>`
          }
          console.log(htmlResult)
          categoryElement.innerHTML=htmlResult
      });     
}
loadCategories()
const getProductsByCategory =(category)=>{
   //https://dummyjson.com/products/category/laptops
   fetch(`https://dummyjson.com/products/category/${category}`)
   .then((response) => response.json())
   .then((data) => { 
       let productElement  = document.getElementById('products')
       let htmlResult =``

       for(let product of data.products){
        htmlResult += getProductAsCard(product)
       }
       productElement.innerHTML = htmlResult
   });     
}

const getProductAsCard= (product)=>{
  return `
        <div class="card p-2 productCard">
          <div class="card-header">
            ${getImagesAsSlider(product)}
          </div>
          <div class="card-body">
            <h3 class="card-title">${product.title}</h3>
            <p class="card-text">
              ${product.description}
              </p>
              </div>
              <button class="btn btn-success">Add To Cart</button>
        </div>
  
  `
}
const getImagesAsSlider = (product)=>{
  let imagesAsString = `<div class="carousel-item active">
                          <img src="${product.images[0]}" class="d-block w-100" alt="...">
                        </div>`


 for (let index = 1; index < product.images.length; index++) {
    imagesAsString += `
                      <div class="carousel-item">
                       <img src="${product.images[index]}" class="d-block w-100" alt="...">
                      </div>`
  }

  return `
          <div id="carousel${product.id}" class="carousel slide" data-bs-ride="carousel">
            <div class="carousel-inner">
              ${imagesAsString}
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carousel${product.id}" data-bs-slide="prev">
              <span class="carousel-control-prev-icon" aria-hidden="true"></span>
              <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carousel${product.id}" data-bs-slide="next">
              <span class="carousel-control-next-icon" aria-hidden="true"></span>
              <span class="visually-hidden">Next</span>
            </button>
          </div>  `
}
