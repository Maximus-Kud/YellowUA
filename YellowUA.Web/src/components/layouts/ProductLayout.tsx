import type { Product } from "../../types/Product";
import compareIcon from '../../assets/icons/compare-icon.png'



type Props = {
  products: Product[],
}





function ProductLayout(props: Props) {
  const filterModel = [
    { name: "iPhone 17", count: 20 },
    { name: "iPhone 17 Pro", count: 18 },
    { name: "iPhone 17 Pro Max", count: 24 },
    { name: "iPhone 17 Air", count: 12 },
    { name: "iPhone 17e", count: 10 }
  ];

  const filterStorage = [
    { name: "256 Гб", count: 6 },
    { name: "512 Гб", count: 6 },
    { name: "1 Тб", count: 6 },
    { name: "2 Тб", count: 6 }
  ];

  const filterSIM = [
    { name: "1 SIM", count: 12 },
    { name: "eSIM", count: 12 }
  ];

  const filterRAM = [
    { name: "12 ГБ", count: 24 }
  ];

  const filterColors = [
    { name: "Blue", count: 8, className: "blue" },
    { name: "Silver", count: 8, className: "silver" },
    { name: "Orange", count: 8, className: "orange" }
  ];





  return (
    <div className="product-layout">
      <span className="path">
        <span>Головна</span>
        <svg height="800px" width="800px" version="1.1" id="Layer_1" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 50 50" enable-background="new 0 0 50 50">
          <path fill="#231F20" d="M15.563,40.836c0.195,0.195,0.451,0.293,0.707,0.293s0.512-0.098,0.707-0.293l15-15 c0.391-0.391,0.391-1.023,0-1.414l-15-15c-0.391-0.391-1.023-0.391-1.414,0s-0.391,1.023,0,1.414l14.293,14.293L15.563,39.422 C15.172,39.813,15.172,40.446,15.563,40.836z" />
        </svg>
        <span>Apple</span>
        <svg height="800px" width="800px" version="1.1" id="Layer_1" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 50 50" enable-background="new 0 0 50 50">
          <path fill="#231F20" d="M15.563,40.836c0.195,0.195,0.451,0.293,0.707,0.293s0.512-0.098,0.707-0.293l15-15 c0.391-0.391,0.391-1.023,0-1.414l-15-15c-0.391-0.391-1.023-0.391-1.414,0s-0.391,1.023,0,1.414l14.293,14.293L15.563,39.422 C15.172,39.813,15.172,40.446,15.563,40.836z" />
        </svg>
        <span>iPhone</span>
        <svg height="800px" width="800px" version="1.1" id="Layer_1" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 50 50" enable-background="new 0 0 50 50">
          <path fill="#231F20" d="M15.563,40.836c0.195,0.195,0.451,0.293,0.707,0.293s0.512-0.098,0.707-0.293l15-15 c0.391-0.391,0.391-1.023,0-1.414l-15-15c-0.391-0.391-1.023-0.391-1.414,0s-0.391,1.023,0,1.414l14.293,14.293L15.563,39.422 C15.172,39.813,15.172,40.446,15.563,40.836z" />
        </svg>
        <span style={{color: '#999999'}}>iPhone 17</span>
      </span>

      <div className="product-name-big">Apple iPhone 17 Pro Max</div>


      <div id='filters'>
        <div className="filters-title">Перегляд товарів по:</div>

        <span className="delete-tag">
          <svg fill="#6a5eff" width="800" height="800" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path d="M20.48 3.512a11.97 11.97 0 0 0-8.486-3.514C5.366-.002-.007 5.371-.007 11.999c0 3.314 1.344 6.315 3.516 8.487A11.97 11.97 0 0 0 11.995 24c6.628 0 12.001-5.373 12.001-12.001 0-3.314-1.344-6.315-3.516-8.487m-1.542 15.427a9.8 9.8 0 0 1-6.943 2.876c-5.423 0-9.819-4.396-9.819-9.819a9.8 9.8 0 0 1 2.876-6.943 9.8 9.8 0 0 1 6.942-2.876c5.422 0 9.818 4.396 9.818 9.818a9.8 9.8 0 0 1-2.876 6.942z" /><path d="m13.537 12 3.855-3.855a1.091 1.091 0 0 0-1.542-1.541l.001-.001-3.855 3.855-3.855-3.855A1.091 1.091 0 0 0 6.6 8.145l-.001-.001 3.855 3.855-3.855 3.855a1.091 1.091 0 1 0 1.541 1.542l.001-.001 3.855-3.855 3.855 3.855a1.091 1.091 0 1 0 1.542-1.541l-.001-.001z" /></svg>
          Серія: iPhone 17 Pro Max
        </span>

        <div className="clear-tags">очистити все</div>

        <div id='filterPrice' className='filter'>
          <div className='text section-title'>Ціна</div>

          <div id='priceRange'>
            <div id='range'></div>
            <div id='priceBar'></div>
            <div id='range'></div>
          </div>

          <div id='prices'>
            <div className='filterText'>61799 грн</div>
            <div className='filterText'>102899 грн</div>
          </div>
        </div>

        <hr></hr>
        
        <div id='filterModel' className='filter'>
          <div className='text section-title'>Серія</div>

          {filterModel.map(model => (
            <div className='filterTextWithCheckbox' key={model.name}>
              <input type='checkbox' checked={model.name === "iPhone 17 Pro Max"} />
              <div className='text fontRegular filter-line'>
                {model.name} <span className='count'>({model.count})</span>
              </div>
            </div>
          ))}
        </div>

        <hr></hr>

        <div id='filterStorage' className='filter'>
          <div className='text section-title'>Вбудована пам'ять</div>

          {filterStorage.map(item => (
            <div className='filterTextWithCheckbox' key={item.name}>
              <input type='checkbox' />
              <div className='text fontRegular filter-line'>
                {item.name} <span className='count'>({item.count})</span>
              </div>
            </div>
          ))}
        </div>

        <hr></hr>

        <div id='filterSIM' className='filter'>
          <div className='text section-title'>Кількість SIM-карт</div>

          {filterSIM.map(item => (
            <div className='filterTextWithCheckbox' key={item.name}>
              <input type='checkbox' />
              <div className='text fontRegular filter-line'>
                {item.name} <span className='count'>({item.count})</span>
              </div>
            </div>
          ))}
        </div>

        <hr></hr>

        <div id='filterRAM' className='filter'>
          <div className='text section-title'>Оперативна пам'ять</div>

          {filterRAM.map(item => (
            <div className='filterTextWithCheckbox' key={item.name}>
              <input type='checkbox' />
              <div className='text fontRegular filter-line'>
                {item.name} <span className='count'>({item.count})</span>
              </div>
            </div>
          ))}
        </div>

        <hr></hr>

        <div className='filter'>
          <div className='text section-title'>Колір</div>

          {filterColors.map(color => (
            <div className='colorItem' key={color.name}>
              <span className={`colorBox ${color.className}`}></span>
              {color.name} <span className='filterText'>({color.count})</span>
            </div>
          ))}
        </div>
      </div>


      <div id='table'>
        {props.products.map(product => (
          <div key={product.id} className='item'>
            <div className='top'>
              <div className='images'>
                <img src={compareIcon} className='compareIcon'></img>
                <img src={product.image} alt={product.name} className='photo'></img>
              </div>
              <div className='name'>{product.name}</div>
            </div>

            <div className='bottom'>
              <div className='price'>{product.price} грн</div>
              <div className='buttons'>
                <button className={product.isAvailable ? "buyButton order" : "buyButton"}>{product.isAvailable ? "Замовлення" : "Купити"}</button>
                <button className={product.isAvailable ? "hidden" : "creditButton"}>В кредит</button>
              </div>
              <div className='description'><div className='status'>{product.isAvailable}</div><div className='code'>{product.code}</div></div>
            </div>
          </div>
        ))}
      </div>
    </div>
  )
}


export default ProductLayout;