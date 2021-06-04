export default (value) => {
    const date = new Date(value)
    return date.toLocaleDateString(['br-BR'], {day: '2-digit', month: 'numeric',  year: 'numeric'})  //if you want, you can change locale date string
} 