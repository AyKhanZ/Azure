import { createAsyncThunk, createSlice,  } from "@reduxjs/toolkit";

export const getCategories = createAsyncThunk(
  "GetCategories",
  async (_, { getState }) => {
    const state = getState();

    const url = `${state.products.base}/Categories`;
    const response = await fetch(url, { method: "GET" });
    if (!response.ok) {
      throw new Error("Failed to get categories");
    }
    const data = await response.json();
    return data;
  }
); 

export const getProductsByCategoryId = createAsyncThunk(
  "GetProductsByCategoryId",
  async (categoryId, { getState }) => {
    const state = getState();

    const url = `${state.products.base}/Category/${categoryId}`;
    const response = await fetch(url);
    if (!response.ok) {
      throw new Error("Failed to get products");
    }
    const data = await response.json();
    return data;

  }
); 


const productsSlice = createSlice({
    name: "products",
    initialState: {
      categories: {},
      products: {},
      base: "https://localhost:7246/Product",
    },
    extraReducers: (builder) => {
      builder.addCase(getCategories.fulfilled, (state, action) => 
      {
        state.categories = action.payload
      })
      builder.addCase(getProductsByCategoryId.fulfilled, (state, action) => 
      {
        state.products = action.payload
      })
    }
    
  });

  export {productsSlice};