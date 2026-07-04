function WindowFrame({ title, children }) {
  return (
    <div className="mx-auto w-full max-w-[980px] overflow-hidden rounded-[4px] border-2 border-black bg-white shadow-sm">
      <div className="relative flex h-[34px] items-center justify-center border-b-2 border-black bg-gray-200">
        <div className="absolute left-3 flex items-center gap-2">
          <span className="flex h-3.5 w-3.5 items-center justify-center rounded-full border border-black text-[10px] font-bold leading-none">
            +
          </span>
          <span className="flex h-3.5 w-3.5 items-center justify-center rounded-full border border-black text-[10px] font-bold leading-none">
            -
          </span>
          <span className="flex h-3.5 w-3.5 items-center justify-center rounded-full border border-black text-[9px] font-bold leading-none">
            x
          </span>
        </div>

        <h1 className="text-base font-normal text-black">{title}</h1>
      </div>

      {children}
    </div>
  )
}

export default WindowFrame