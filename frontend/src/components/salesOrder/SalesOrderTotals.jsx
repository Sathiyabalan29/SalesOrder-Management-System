function SalesOrderTotals({ totals }) {
  return (
    <div className="mt-5 ml-auto w-[330px] space-y-1 text-sm text-black">
      <div className="grid grid-cols-[110px_1fr] items-center">
        <label>Total Excl</label>
        <input
          value={totals.totalExcl.toFixed(2)}
          readOnly
          className="h-[22px] border-2 border-black px-2 outline-none"
        />
      </div>

      <div className="grid grid-cols-[110px_1fr] items-center">
        <label>Total Tax</label>
        <input
          value={totals.totalTax.toFixed(2)}
          readOnly
          className="h-[22px] border-2 border-black px-2 outline-none"
        />
      </div>

      <div className="grid grid-cols-[110px_1fr] items-center">
        <label>Total Incl</label>
        <input
          value={totals.totalIncl.toFixed(2)}
          readOnly
          className="h-[22px] border-2 border-black px-2 outline-none"
        />
      </div>
    </div>
  )
}

export default SalesOrderTotals