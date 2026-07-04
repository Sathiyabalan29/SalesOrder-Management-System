import { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import WindowFrame from '../components/common/WindowFrame'
import CustomerDetailsForm from '../components/salesOrder/CustomerDetailsForm'
import InvoiceDetailsForm from '../components/salesOrder/InvoiceDetailsForm'
import SalesOrderItemsTable from '../components/salesOrder/SalesOrderItemsTable'
import SalesOrderToolbar from '../components/salesOrder/SalesOrderToolbar'
import SalesOrderTotals from '../components/salesOrder/SalesOrderTotals'
import api from '../services/api'
import { calculateSalesOrderTotals } from '../utils/salesOrderCalculations'

const emptyOrderItem = {
  itemId: '',
  note: '',
  quantity: '',
  taxRate: '',
}

function SalesOrderPage() {
  const navigate = useNavigate()
  const { id } = useParams()

  const [clients, setClients] = useState([])
  const [items, setItems] = useState([])

  const [form, setForm] = useState({
    clientId: '',
    customerName: '',
    address: '',
    address2: '',
    address3: '',
    city: '',
    state: '',
    postCode: '',
    invoiceNo: '',
    invoiceDate: '',
    referenceNo: '',
    note: '',
  })

  const [orderItems, setOrderItems] = useState(
    Array.from({ length: 4 }, () => ({ ...emptyOrderItem })),
  )

  useEffect(() => {
    fetchInitialData()
  }, [id])

  const resetForm = () => {
    setForm({
      clientId: '',
      customerName: '',
      address: '',
      address2: '',
      address3: '',
      city: '',
      state: '',
      postCode: '',
      invoiceNo: '',
      invoiceDate: '',
      referenceNo: '',
      note: '',
    })
    setOrderItems(Array.from({ length: 4 }, () => ({ ...emptyOrderItem })))
  }

  const fetchInitialData = async () => {
    try {
      const [clientsResponse, itemsResponse] = await Promise.all([
        api.get('/clients'),
        api.get('/items'),
      ])

      setClients(clientsResponse.data)
      setItems(itemsResponse.data)

      if (id) {
        const orderResponse = await api.get(`/salesorders/${id}`)
        loadOrderData(orderResponse.data)
      } else {
        resetForm()
      }
    } catch (error) {
      console.error('Failed to load data:', error)
      alert('Failed to load sales order data.')
    }
  }

  const loadOrderData = (order) => {
    setForm({
      clientId: order.clientId,
      customerName: order.customerName,
      address: order.address,
      address2: '',
      address3: '',
      city: order.city,
      state: '',
      postCode: order.postCode || '',
      invoiceNo: order.orderNumber,
      invoiceDate: new Date(order.orderDate).toLocaleDateString(),
      referenceNo: '',
      note: '',
    })

    const savedRows = order.items.map((item) => ({
      itemId: item.itemId,
      note: item.note || '',
      quantity: item.quantity,
      taxRate: item.taxRate,
    }))

    const emptyRowsCount = Math.max(4 - savedRows.length, 0)

    const emptyRows = Array.from({ length: emptyRowsCount }, () => ({
      ...emptyOrderItem,
    }))

    setOrderItems([...savedRows, ...emptyRows])
  }

  const handleCustomerChange = (clientId) => {
    if (!clientId) {
      setForm({
        ...form,
        clientId: '',
        customerName: '',
        address: '',
        city: '',
        postCode: '',
      })
      return
    }

    const selectedClient = clients.find(
      (client) => client.id === Number(clientId),
    )

    if (!selectedClient) {
      return
    }

    setForm({
      ...form,
      clientId: selectedClient.id,
      customerName: selectedClient.customerName,
      address: selectedClient.address,
      city: selectedClient.city,
      postCode: selectedClient.postCode || '',
    })
  }

  const handleChange = (field, value) => {
    setForm({
      ...form,
      [field]: value,
    })
  }

  const handleItemChange = (index, field, value) => {
    const updatedItems = [...orderItems]

    updatedItems[index] = {
      ...updatedItems[index],
      [field]: value,
    }

    setOrderItems(updatedItems)
  }

  const handleSave = async () => {
    const validItems = orderItems
      .filter((item) => item.itemId && item.quantity)
      .map((item) => ({
        itemId: Number(item.itemId),
        note: item.note,
        quantity: Number(item.quantity),
        taxRate: Number(item.taxRate) || 0,
      }))

    if (!form.clientId) {
      alert('Please select a customer.')
      return
    }

    if (!form.address || !form.city || !form.postCode) {
      alert('Please fill address, suburb, and post code.')
      return
    }

    if (validItems.length === 0) {
      alert('Please add at least one item.')
      return
    }

    const payload = {
      clientId: Number(form.clientId),
      customerName: form.customerName,
      address: form.address,
      city: form.city,
      postCode: form.postCode,
      items: validItems,
    }

    try {
      if (id) {
        await api.put(`/salesorders/${id}`, payload)
        alert('Sales order updated successfully.')
      } else {
        await api.post('/salesorders', payload)
        alert('Sales order saved successfully.')
      }

      navigate('/')
    } catch (error) {
      console.error('Failed to save sales order:', error)
      alert('Failed to save sales order.')
    }
  }

  const totals = calculateSalesOrderTotals(orderItems, items)

  const handlePrint = () => {
    window.setTimeout(() => {
      window.print()
    }, 100)
  }

  return (
    <main className="min-h-screen bg-gray-50 p-4 sm:p-6">
      <WindowFrame title="Sales Order">
        <SalesOrderToolbar onSave={handleSave} onPrint={handlePrint} />

        <div className="p-3 text-sm text-gray-700 sm:p-4">
          <div className="grid gap-6 lg:grid-cols-2">
            <CustomerDetailsForm
              clients={clients}
              form={form}
              onCustomerChange={handleCustomerChange}
              onChange={handleChange}
            />

            <InvoiceDetailsForm form={form} onChange={handleChange} />
          </div>

          <SalesOrderItemsTable
            items={items}
            orderItems={orderItems}
            onItemChange={handleItemChange}
          />

          <SalesOrderTotals totals={totals} />

          <button
            type="button"
            onClick={() => navigate('/')}
            className="mt-4 h-[28px] w-[90px] rounded-[5px] border-2 border-black bg-white text-sm text-black hover:bg-gray-100"
          >
            Back
          </button>
        </div>
      </WindowFrame>
    </main>
  )
}

export default SalesOrderPage