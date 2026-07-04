import FormField from '../common/FormField'

function CustomerDetailsForm({ clients, form, onCustomerChange, onChange }) {
  return (
    <div className="space-y-2">
      <FormField label="Customer Name">
        <select
          value={form.clientId}
          onChange={(event) => onCustomerChange(event.target.value)}
          className="h-8 rounded border-2 border-black bg-white px-2 text-sm outline-none"
        >
          <option value=""></option>
          {clients.map((client) => (
            <option key={client.id} value={client.id}>
              {client.customerName}
            </option>
          ))}
        </select>
      </FormField>

      <FormField label="Address 1">
        <input
          value={form.address}
          onChange={(event) => onChange('address', event.target.value)}
          className="h-8 rounded border-2 border-black px-2 text-sm outline-none"
        />
      </FormField>

      <FormField label="Address 2">
        <input
          value={form.address2}
          onChange={(event) => onChange('address2', event.target.value)}
          className="h-8 rounded border-2 border-black px-2 text-sm outline-none"
        />
      </FormField>

      <FormField label="Address 3">
        <input
          value={form.address3}
          onChange={(event) => onChange('address3', event.target.value)}
          className="h-8 rounded border-2 border-black px-2 text-sm outline-none"
        />
      </FormField>

      <FormField label="Suburb">
        <input
          value={form.city}
          onChange={(event) => onChange('city', event.target.value)}
          className="h-8 rounded border-2 border-black px-2 text-sm outline-none"
        />
      </FormField>

      <FormField label="State">
        <input
          value={form.state}
          onChange={(event) => onChange('state', event.target.value)}
          className="h-8 rounded border-2 border-black px-2 text-sm outline-none"
        />
      </FormField>

      <FormField label="Post Code">
        <input
          value={form.postCode}
          onChange={(event) => onChange('postCode', event.target.value)}
          className="h-8 rounded border-2 border-black px-2 text-sm outline-none"
        />
      </FormField>
    </div>
  )
}

export default CustomerDetailsForm