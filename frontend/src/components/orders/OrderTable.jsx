function OrderTable({ orders, loading, onRowDoubleClick }) {
  const emptyRows = Array.from({ length: Math.max(7 - orders.length, 0) })

  return (
    <table className="w-full border-collapse border border-black text-sm text-black">
      <thead>
        <tr className="bg-gray-300">
          <th className="h-[48px] border border-black px-2 text-left font-normal">
            ▼ Order No
          </th>
          <th className="h-[48px] border border-black px-2 text-left font-normal">
            ▼ Date
          </th>
          <th className="h-[48px] border border-black px-2 text-left font-normal">
            ▼ Customer
          </th>
          <th className="h-[48px] border border-black px-2 text-left font-normal">
            ▼ Total
          </th>
          <th className="h-[48px] border border-black px-2 text-left font-normal">
            ▼ Status
          </th>
          <th className="h-[48px] border border-black px-2 text-left font-normal">
            ▼ Action
          </th>
          <th className="h-[48px] border border-black px-2 text-left font-normal">
            ▼ Note
          </th>
        </tr>
      </thead>

      <tbody>
        {loading ? (
          <tr>
            <td className="h-[58px] border border-black px-2" colSpan="7">
              Loading...
            </td>
          </tr>
        ) : (
          <>
            {orders.map((order, index) => (
              <tr
                key={order.id}
                onDoubleClick={() => onRowDoubleClick(order.id)}
                className={`cursor-pointer ${index % 2 === 0 ? 'bg-white' : 'bg-gray-100'}`}
              >
                <td className="h-[58px] border border-black px-2">
                  {order.orderNumber}
                </td>
                <td className="h-[58px] border border-black px-2">
                  {new Date(order.orderDate).toLocaleDateString()}
                </td>
                <td className="h-[58px] border border-black px-2">
                  {order.customerName}
                </td>
                <td className="h-[58px] border border-black px-2">
                  {order.totalInclAmount}
                </td>
                <td className="h-[58px] border border-black px-2">Saved</td>
                <td className="h-[58px] border border-black px-2">
                  Double click
                </td>
                <td className="h-[58px] border border-black px-2">"</td>
              </tr>
            ))}

            {emptyRows.map((_, index) => (
              <tr
                key={`empty-${index}`}
                className={(orders.length + index) % 2 === 0 ? 'bg-white' : 'bg-gray-100'}
              >
                <td className="h-[58px] border border-black px-2">"</td>
                <td className="h-[58px] border border-black px-2">"</td>
                <td className="h-[58px] border border-black px-2">"</td>
                <td className="h-[58px] border border-black px-2">"</td>
                <td className="h-[58px] border border-black px-2">"</td>
                <td className="h-[58px] border border-black px-2">"</td>
                <td className="h-[58px] border border-black px-2">"</td>
              </tr>
            ))}
          </>
        )}
      </tbody>
    </table>
  )
}

export default OrderTable