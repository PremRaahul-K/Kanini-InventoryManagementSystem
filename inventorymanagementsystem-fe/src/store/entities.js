import { combineReducers } from "@reduxjs/toolkit";
import productReducer from "./products";

export default combineReducers({
  products: productReducer,
});
