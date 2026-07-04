# Sales Order Management System

Sales Order Management System is a full-stack web application developed using .NET Core Web API, React, Redux Toolkit, Tailwind CSS, Entity Framework Core, and SQL Server.

The application allows users to create, view, edit, and print sales orders. Customers and items are loaded from the database, and sales order totals are calculated automatically based on quantity, price, and tax rate.

This project was developed based on the given web application development instructions, including a .NET Core backend, React frontend, SQL Server database, layered backend architecture, DTOs, services, repositories, and sales order screens.

## Features

- Home screen with sales order list
- Add new sales order
- Edit existing sales order by double-clicking an order row
- Customer dropdown loaded from the Client table
- Customer address, suburb/city, and post code auto-fill
- Item code dropdown loaded from the Item table
- Item description dropdown loaded from the Item table
- Item code and description dropdowns are synchronized
- Automatic price display based on selected item
- Line amount calculations:
  - Excl Amount = Quantity × Price
  - Tax Amount = Excl Amount × Tax Rate / 100
  - Incl Amount = Excl Amount + Tax Amount
- Total Excl, Total Tax, and Total Incl calculation
- Save sales order
- Update existing sales order
- Print sales order using browser print option
- Redux Toolkit used for sales order list state management

## Tech Stack

### Backend

- .NET Core Web API
- Entity Framework Core
- SQL Server Express
- AutoMapper
- Repository Pattern
- Service Layer
- Dependency Injection
- DTOs
- CORS

### Frontend

- React
- React Hooks
- React Router DOM
- Redux Toolkit
- React Redux
- Axios
- Tailwind CSS
- Vite

## Project Structure

```text
SalesOrder-Management-System
├── backend
│   ├── SalesOrderManagement.sln
│   └── SalesOrderManagement.API
│       ├── API
│       │   ├── Controllers
│       │   └── Models
│       ├── Application
│       ├── Domain
│       ├── Infrastructure
│       ├── Migrations
│       ├── appsettings.json
│       └── Program.cs
├── frontend
│   └── SalesOrderManagement.Client
├── database
│   ├── schema.sql
│   └── sample-data.sql
├── .gitignore
└── README.md
```