const colors = [
"B9EDDD",
"87CBB9",
"569DAA",
"577D86",
"41644A",
"263A29",
"E86A33",
"D14D72",
"FFABAB",
"393646",
"4F4557",
"FFE5CA",
"009FBD",
"F9E2AF",
"210062",
"77037B",
"7149C6",
"FC2947",
"FE6244"
]

const getRandomColorInColors = ()=>{
    let index = Math.floor(Math.random()*colors.length)
    return colors[index]
}

const changeColor = (event) =>{
    event.cancelBubble=true
    let color = getRandomColorInColors()
    event.target.style = `background-color: #${color}`
}
