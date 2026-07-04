import { BrowserRouter, Route, Routes } from 'react-router-dom'
import HomePage from './pages/HomePage'
import SalesOrderPage from './pages/SalesOrderPage'

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/sales-order" element={<SalesOrderPage />} />
        <Route path="/sales-order/:id" element={<SalesOrderPage />} />
      </Routes>
    </BrowserRouter>
  )
}

export default App