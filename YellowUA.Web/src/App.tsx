import Header from './components/main/Header'
import Categories from './components/main/Categories'
import Banner from './components/main/Banner'


import './css/App.css'
import './css/pages/main-page/Header.css'
import './css/pages/main-page/Categories.css'
import './css/pages/main-page/Banner.css'

import ProductPage from './pages/ProductPage'
import './css/pages/products-page/ProductTable.css'

import './css/pages/products-page/ProductPage.css'
import { useState } from 'react'
import type { Product } from './types/Product'
import type { CartProduct } from './types/CartProduct'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import HomePage from './pages/HomePage'






function App() {
  const [products, setProducts] = useState<Product[]>([]);
  const [cartProducts, setCartProducts] = useState<CartProduct[]>([]);





  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<HomePage />} />

        <Route 
          path="/products" 
          element={
            <ProductPage
              products={products}
              setProduct={setProducts}
            />
          } 
        />
      </Routes>
    </BrowserRouter>
  )
}


export default App