function SalesOrderToolbar({ onSave, onPrint }) {
  return (
    <div className="flex h-[40px] items-center gap-2 border-b-2 border-black px-2">
      <button
        type="button"
        onClick={onSave}
        className="flex h-[28px] w-[120px] items-center justify-center gap-1 rounded-[5px] border-2 border-black bg-white text-sm text-black hover:bg-gray-100"
      >
        <span className="flex h-4 w-4 items-center justify-center rounded-full bg-black text-[10px] text-white">
          ✓
        </span>
        Save Order
      </button>

      <button
        type="button"
        onClick={onPrint}
        className="h-[28px] w-[90px] rounded-[5px] border-2 border-black bg-white text-sm text-black hover:bg-gray-100"
      >
        Print
      </button>
    </div>
  )
}

export default SalesOrderToolbar