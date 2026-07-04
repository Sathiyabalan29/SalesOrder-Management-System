import { configureStore } from '@reduxjs/toolkit'
import salesOrderReducer from './slices/salesOrderSlice'

export const store = configureStore({
  reducer: {
    salesOrders: salesOrderReducer,
  },
})