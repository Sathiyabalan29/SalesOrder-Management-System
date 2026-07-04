export function calculateSalesOrderRow(row, selectedItem) {
  const price = Number(selectedItem?.price) || 0
  const quantity = Number(row.quantity) || 0
  const taxRate = Number(row.taxRate) || 0

  const exclAmount = quantity * price
  const taxAmount = (exclAmount * taxRate) / 100
  const inclAmount = exclAmount + taxAmount

  return {
    price,
    exclAmount,
    taxAmount,
    inclAmount,
  }
}

export function calculateSalesOrderTotals(rows, items) {
  return rows.reduce(
    (total, row) => {
      const selectedItem = items.find((item) => item.id === Number(row.itemId))
      const calculated = calculateSalesOrderRow(row, selectedItem)

      return {
        totalExcl: total.totalExcl + calculated.exclAmount,
        totalTax: total.totalTax + calculated.taxAmount,
        totalIncl: total.totalIncl + calculated.inclAmount,
      }
    },
    {
      totalExcl: 0,
      totalTax: 0,
      totalIncl: 0,
    },
  )
}