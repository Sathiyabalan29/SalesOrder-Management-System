function FormField({ label, children, className = '' }) {
  return (
    <div className={`grid items-center gap-2 sm:grid-cols-[105px_1fr] ${className}`.trim()}>
      <label className="text-sm font-medium text-gray-700">{label}</label>
      {children}
    </div>
  )
}

export default FormField
