import type { ApplicationUser } from "./ApplicationUser"
import type { Product } from "./Product"



export type CartProduct = {
  id: string,
  userId: string,
  user: ApplicationUser,
  productId: number,
  product: Product,
  quantity: number
}