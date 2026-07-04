import FormField from '../common/FormField'

function InvoiceDetailsForm({ form, onChange }) {
  return (
    <div className="space-y-2">
      <FormField label="Invoice No.">
        <input
          value={form.invoiceNo}
          onChange={(event) => onChange('invoiceNo', event.target.value)}
          className="h-8 rounded border-2 border-black px-2 text-sm outline-none"
        />
      </FormField>

      <FormField label="Invoice Date">
        <input
          value={form.invoiceDate}
          onChange={(event) => onChange('invoiceDate', event.target.value)}
          className="h-8 rounded border-2 border-black px-2 text-sm outline-none"
        />
      </FormField>

      <FormField label="Reference no">
        <input
          value={form.referenceNo}
          onChange={(event) => onChange('referenceNo', event.target.value)}
          className="h-8 rounded border-2 border-black px-2 text-sm outline-none"
        />
      </FormField>

      <FormField label="Note" className="items-start">
        <textarea
          value={form.note}
          onChange={(event) => onChange('note', event.target.value)}
          className="h-[87px] resize-none rounded border-2 border-black px-2 py-1 text-sm outline-none"
        />
      </FormField>
    </div>
  )
}

export default InvoiceDetailsForm