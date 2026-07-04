import { createAsyncThunk, createSlice } from '@reduxjs/toolkit'
import api from '../../services/api'

export const fetchSalesOrders = createAsyncThunk(
  'salesOrders/fetchSalesOrders',
  async () => {
    const response = await api.get('/salesorders')
    return response.data
  },
)

const salesOrderSlice = createSlice({
  name: 'salesOrders',
  initialState: {
    orders: [],
    loading: false,
    error: null,
  },
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(fetchSalesOrders.pending, (state) => {
        state.loading = true
        state.error = null
      })
      .addCase(fetchSalesOrders.fulfilled, (state, action) => {
        state.loading = false
        state.orders = action.payload
      })
      .addCase(fetchSalesOrders.rejected, (state) => {
        state.loading = false
        state.error = 'Failed to load sales orders'
      })
  },
})

export default salesOrderSlice.reducer