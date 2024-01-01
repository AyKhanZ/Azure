import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";

export const getProducts = createAsyncThunk(
  "GetBooks",
  async (_, { getState }) => {
    const state = getState();

    const url = `${state.products.base}`;
    const response = await fetch(url, { method: "GET" });
    if (!response.ok) {
      throw new Error("Failed to get books");
    }
    const data = await response.json();
    return data;
  }
);

export const getProductById = createAsyncThunk(
  "GetBook/id",
  async (id, { getState }) => {
    const state = getState();

    const url = `${state.products.base}/${id}`;
    const response = await fetch(url, { method: "GET" });
    if (!response.ok) {
      throw new Error("Failed to get book by id");
    }
    const data = await response.json();

    console.log(data);
    return data;
  }
);

export const clear = createAsyncThunk(
  "Clear",
  async () => {

    console.log('Cleared');
  }
);

const productsSlice = createSlice({
  name: "products",
  initialState: {
    books: {},
    book: {},
    base: "https://miniturboazapi.azurewebsites.net/Product",
  },
  extraReducers: (builder) => {
    builder.addCase(getProducts.fulfilled, (state, action) => {
      state.books = action.payload
    })
    builder.addCase(getProductById.fulfilled, (state, action) => {
      state.book = action.payload
    })
    builder.addCase(clear.fulfilled, (state) => {
      state.book = {};
    });
  }

});

export { productsSlice };