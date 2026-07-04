import { useEffect } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { useNavigate } from 'react-router-dom'
import WindowFrame from '../components/common/WindowFrame'
import OrderTable from '../components/orders/OrderTable'
import { fetchSalesOrders } from '../redux/slices/salesOrderSlice'

function HomePage() {
  const navigate = useNavigate()
  const dispatch = useDispatch()

  const { orders, loading, error } = useSelector((state) => state.salesOrders)

  useEffect(() => {
    dispatch(fetchSalesOrders())
  }, [dispatch])

  return (
    <main className="min-h-screen bg-gray-50 p-4 sm:p-6">
      <WindowFrame title="Home">
        <div className="border-b-2 border-black bg-white px-3 py-3 sm:px-4">
          <button
            type="button"
            onClick={() => navigate('/sales-order')}
            className="h-8 w-32 rounded-[5px] border-2 border-black bg-white text-sm font-medium text-black transition hover:bg-gray-100 sm:w-36"
          >
            Add New
          </button>
        </div>

        <div className="p-3 sm:p-4">
          {error && (
            <p className="mb-3 text-sm text-red-600">
              {error}
            </p>
          )}

          <OrderTable
            orders={orders}
            loading={loading}
            onRowDoubleClick={(id) => navigate(`/sales-order/${id}`)}
          />
        </div>
      </WindowFrame>
    </main>
  )
}

export default HomePage