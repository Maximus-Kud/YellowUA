type ApiMethodConfig = {
  method: "GET" | "POST" | "PATCH" | "DELETE";
  body?: string[];
  id?: boolean;
};

type ApiConfig = {
  [controller: string]: {
    [endpoint: string]: ApiMethodConfig;
  };
};


export const apiConfig: ApiConfig = {
  Authentication: {
    register: {
      method: "POST",
      body: ["firstName", "lastName", "email", "password"]
    },
    login: {
      method: "POST",
      body: ["email", "password"]
    }
  },

  
  Marketplace: {
    getProducts: {
      method: "GET"
    },
    getAccountInfo: {
      method: "GET"
    }
  },


  Cart: {
    "": {
      method: "GET"
    },
    addItemToCart: {
      method: "POST",
      body: ["userId", "productId"]
    },
    removeItemFromCart: {
      method: "DELETE",
      body: ["userId", "productId"]
    },
    buyProducts: {
      method: "POST",
    }
  },


  Admin: {
    getAllUsers: {
      method: "GET"
    },
    getAllProducts: {
      method: "GET"
    },
    addProduct: {
      method: "POST",
      body: ["productName", "price", "inStock", "code"]
    },
    changeProduct: {
      method: "PATCH",
      id: true,
      body: ["name", "price", "inStock", "isAvailable", "code"]
    },
    deleteProduct: {
      method: "DELETE",
      id: true
    },
    getProductsInCart: {
      method: "GET"
    },
    changeAccountBalance: {
      method: "PATCH",
      body: ["userId", "newBalance"]
    }
  }
} as const;