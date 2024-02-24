import {configureStore} from '@reduxjs/toolkit'
import { productsSlice } from './reducer'


let store = configureStore(
    {
        reducer: 
        {
            products: productsSlice.reducer
        }
    }
)

export default store;