import { createSlice } from "@reduxjs/toolkit";
import { apiCallBegan } from "./api";

const slice = createSlice({
  name: "Products",
  initialState: {
    list: [],
    loader: false,
  },
  reducers: {
    productAdded: (products, action) => {
      products.list.push(action.payload);
    },
    productsRetrived: (products, action) => {
      products.list = action.payload;
      products.loader = false;
    },
    productsRequested: (products, action) => {
      products.loader = true;
    },
    productDeleted: (products, action) => {
      if (action.payload && action.payload.id)
        products.list = products.list.filter(
          (product) => product.id !== action.payload.id
        );
    },
    productRequestFailed: (products, action) => {
      products.loader = false;
      console.log(action.payload);
    },
    productQuantityUpdated: (products, action) => {
      const { productId, newQuantity } = action.payload;
      const updatedList = products.list.map((product) =>
        product.id === productId
          ? { ...product, quantity: newQuantity.Quantity }
          : product
      );
      products.list = updatedList;
    },
  },
});

export const {
  productAdded,
  productsRetrived,
  productsRequested,
  productDeleted,
  productRequestFailed,
  productQuantityUpdated,
} = slice.actions;
export default slice.reducer;

const url = "/products";

export const addProduct = (product) =>
  apiCallBegan({
    url,
    method: "POST",
    data: product,
    onSuccess: productAdded.type,
  });

export const loadProducts = () =>
  apiCallBegan({
    url,
    onSuccess: productsRetrived.type,
    onStart: productsRequested.type,
  });

export const deleteProduct = (id) =>
  apiCallBegan({
    url: `${url}/${id}`,
    method: "DELETE",
    onSuccess: productDeleted.type,
    onError: productRequestFailed.type,
    payload: { id },
  });

export const updateProductQuantity = (productId, Quantity) =>
  apiCallBegan({
    url: `${url}/${productId}`,
    method: "PUT",
    onSuccess: productQuantityUpdated.type,
    onError: productRequestFailed.type,
    data: Quantity,
    payload: { productId, newQuantity: Quantity },
  });
