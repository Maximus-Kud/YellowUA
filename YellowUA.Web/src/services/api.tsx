import { apiConfig } from "../config/apiConfig";
import { localhost } from "../config/constants";
import { getWithExpiry, setWithExpiry } from "./storage";





export async function callApi(controller: keyof typeof apiConfig, endpoint: keyof typeof apiConfig[typeof controller] | "" = "", data: any = {}, id?: string | number) {
  const config = apiConfig[controller][endpoint];
  if (!config) throw new Error(`Unknown endpoint: ${controller}/${endpoint}`);

  let url = `${localhost}${controller}`;

  if (endpoint) url += `/${endpoint}`;
  if (config.id && id !== undefined) url += `/${id}`;

  const token = getWithExpiry("token"); 

  const options: RequestInit = {
    method: config.method,
    headers: {
      "Content-Type": "application/json",
      Authorization: token ? `Bearer ${token}` : "",
    },
  };

  if (config.body && config.method !== "GET") options.body = JSON.stringify(data);

  const response = await fetch(url, options);
  const text = await response.text();

  if (!response.ok) {
    let errorData = {};

    try {
      errorData = text ? JSON.parse(text) : {};
    }
    catch {
      errorData = { message: text };
    }

    throw errorData;
  }

  const result = text ? JSON.parse(text) : {};

  if (endpoint === 'login' && result.token) {
    setWithExpiry("token", result.token, 3);
    setWithExpiry("username", result.user, 3);
    setWithExpiry("email", result.email, 3);
  }


  return result;
}





// ========== Authentication ==========
export async function authenticationRegister(data: {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
}) {
  return callApi("Authentication", "register", data);
}


export async function authenticationLogin(data: {
  email: string,
  password: string
}) {
  return callApi("Authentication", "login", data);
}





// ========== Marketplace ==========
export async function marketplaceGetAvailableProducts() {
  return callApi("Marketplace", "getProducts");
}


export async function marketplaceGetAccountInfo() {
  return callApi("Marketplace", "getAccountInfo");
}




// ========== Cart ==========
export async function cartGetProducts() {
  return callApi("Cart", "")
}


export async function cartAddItemToCart(data: {
  userId: string,
  productId: number
}) {
  return callApi("Cart", "addItemToCart", data,);
}


export async function cartRemoveItemFromCart(data: {
  userId: string,
  productId: number
}) {
  return callApi("Cart", "removeItemFromCart", data);
}


export async function cartBuyProducts() {
  return callApi("Cart", "buyProducts");
}





// ========== Admin ==========
export async function adminGetAllUsers() {
  return callApi("Admin", "getAllUsers");
}


export async function adminGetAllProducts() {
  return callApi("Admin", "getAllProducts");
}


export async function adminAddProduct(data: {
  productName: string,
  price: number,
  inStock: number,
  code: string
}) {
  return callApi("Admin", "addProduct", data);
}


export async function adminChangeProduct(data: {
  name: string,
  price: number,
  inStock: number,
  isAvailable: boolean,
  code: string
}, id: number) {
  return callApi("Admin", "changeProduct", data, id);
}


export async function adminDeleteProduct(id: number) {
  return callApi("Admin", "deleteProduct", {}, id);
}


export async function adminGetProductsInCart() {
  return callApi("Admin", "getProductsInCart");
}


export async function adminChangeAccountBalance(data: {
  userId: string,
  newBalance: number
}) {
  return callApi("Admin", "changeAccountBalance", data);
}