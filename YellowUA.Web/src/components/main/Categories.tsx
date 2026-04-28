import { Link } from "react-router-dom";



function Categories() {
  return (
    <div id='categories'>
      <Link to="/products" className="category">Apple</Link>
      <div className="category">Смартфони Планшети</div>
      <div className="category">Ноутбуки</div>
      <div className="category">Фото Аудіо PS5</div>
      <div className="category">Телевізори</div>
      <div className="category">Побутова техніка</div>
    </div>
  )
}


export default Categories;