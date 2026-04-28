import Categories from "../components/main/Categories";
import Header from "../components/main/Header";

import { useEffect } from "react";
import { marketplaceGetAvailableProducts } from "../services/api";
import type { Product } from "../types/Product";
import ProductLayout from "../components/layouts/ProductLayout";





type Props = {
  products: Product[],
  setProduct: (newProducts: Product[]) => void
}



function ProductPage(props: Props) {


  useEffect(() => {
    marketplaceGetAvailableProducts()
      .then((data) => {
        console.log("API results:", data);
        props.setProduct(data);
      })
      .catch((e) => {
        console.error(e);
      })
  }, []);





  return (
    <>
      <Header />

      <Categories />

      <ProductLayout
        products={props.products}
      />
    </>
  )
}


export default ProductPage;