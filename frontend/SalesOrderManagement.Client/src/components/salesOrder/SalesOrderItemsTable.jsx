import { calculateSalesOrderRow } from '../../utils/salesOrderCalculations'

function SalesOrderItemsTable({ items, orderItems, onItemChange }) {
  const getSelectedItem = (itemId) => {
    return items.find((item) => item.id === Number(itemId))
  }

  return (
    <div className="mt-5">
      <table className="w-full border-collapse border border-black text-sm text-black">
        <thead>
          <tr className="bg-gray-300">
            <th className="h-[40px] border border-black px-1 text-left font-normal">
              Item Code
            </th>
            <th className="h-[40px] border border-black px-1 text-left font-normal">
              Description
            </th>
            <th className="h-[40px] border border-black px-1 text-left font-normal">
              Note
            </th>
            <th className="h-[40px] border border-black px-1 text-left font-normal">
              Quantity
            </th>
            <th className="h-[40px] border border-black px-1 text-left font-normal">
              Price
            </th>
            <th className="h-[40px] border border-black px-1 text-left font-normal">
              Tax
            </th>
            <th className="h-[40px] border border-black px-1 text-left font-normal">
              Excl Amount
            </th>
            <th className="h-[40px] border border-black px-1 text-left font-normal">
              Tax Amount
            </th>
            <th className="h-[40px] border border-black px-1 text-left font-normal">
              Incl Amount
            </th>
          </tr>
        </thead>

        <tbody>
          {orderItems.map((row, index) => {
            const selectedItem = getSelectedItem(row.itemId)
            const calculated = calculateSalesOrderRow(row, selectedItem)

            return (
              <tr
                key={index}
                className={index % 2 === 0 ? 'bg-white' : 'bg-gray-100'}
              >
                <td className="h-[31px] border border-black">
                  <select
                    value={row.itemId}
                    onChange={(event) =>
                      onItemChange(index, 'itemId', event.target.value)
                    }
                    className="h-full w-full bg-transparent px-1 outline-none"
                  >
                    <option value=""></option>
                    {items.map((item) => (
                      <option key={item.id} value={item.id}>
                        {item.itemCode}
                      </option>
                    ))}
                  </select>
                </td>

                <td className="h-[31px] border border-black">
                  <select
                    value={row.itemId}
                    onChange={(event) =>
                      onItemChange(index, 'itemId', event.target.value)
                    }
                    className="h-full w-full bg-transparent px-1 outline-none"
                  >
                    <option value=""></option>
                    {items.map((item) => (
                      <option key={item.id} value={item.id}>
                        {item.description}
                      </option>
                    ))}
                  </select>
                </td>

                <td className="h-[31px] border border-black">
                  <input
                    value={row.note}
                    onChange={(event) =>
                      onItemChange(index, 'note', event.target.value)
                    }
                    className="h-full w-full bg-transparent px-1 outline-none"
                  />
                </td>

                <td className="h-[31px] border border-black">
                  <input
                    value={row.quantity}
                    onChange={(event) =>
                      onItemChange(index, 'quantity', event.target.value)
                    }
                    className="h-full w-full bg-transparent px-1 outline-none"
                  />
                </td>

                <td className="h-[31px] border border-black px-1">
                  {selectedItem ? calculated.price.toFixed(2) : ''}
                </td>

                <td className="h-[31px] border border-black">
                  <input
                    value={row.taxRate}
                    onChange={(event) =>
                      onItemChange(index, 'taxRate', event.target.value)
                    }
                    className="h-full w-full bg-transparent px-1 outline-none"
                  />
                </td>

                <td className="h-[31px] border border-black px-1">
                  {selectedItem ? calculated.exclAmount.toFixed(2) : ''}
                </td>

                <td className="h-[31px] border border-black px-1">
                  {selectedItem ? calculated.taxAmount.toFixed(2) : ''}
                </td>

                <td className="h-[31px] border border-black px-1">
                  {selectedItem ? calculated.inclAmount.toFixed(2) : ''}
                </td>
              </tr>
            )
          })}
        </tbody>
      </table>
    </div>
  )
}

export default SalesOrderItemsTable