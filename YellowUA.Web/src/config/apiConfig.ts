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
    products: {
      method: "GET"
    },
    addProduct: {
      method: "POST",
      body: ["name", "price", "inStock"]
    },
    updateProduct: {
      method: "PATCH",
      id: true,
      body: ["name","price","inStock","isAvailable"]
    },
    deleteProduct: {
      method: "DELETE",
      id: true
    },
    users: {
      method: "GET"
    },
    getOrdersInShoppingCart: {
      method: "GET"
    },
    getOrdersPurchased: {
      method: "GET"
    },
    changeOrderStatus: {
      method: "PATCH",
      body: ["orderId","status"]
    },
    changeAccountBalance: {
      method: "PATCH",
      body: ["accountId","newBalance"]
    }
  }
} as const;