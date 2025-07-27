# Store Management System - C# Console Application

## 📝 Overview

This console-based Store Management System was developed as a hands-on project to solidify my core C# programming skills and concepts. It served as a practical review and application of fundamental C# knowledge before diving into learning ASP.NET MVC.

The application simulates a basic inventory/order management system, allowing users to manage stores, items, and orders through a text-based interface, with data stored in simple text files.

## 🎯 Purpose & Learning Journey

This project was specifically designed and built as a **comprehensive C# refresher** to ensure a strong foundation before transitioning to ASP.NET MVC development. Key goals included:

- Reinforcing **Object-Oriented Programming** principles (Classes, Objects, Inheritance, Polymorphism)
- Practicing **Collections and LINQ** for data manipulation
- Understanding **Layered Architecture** (UI, Business Logic, Data Access Layers)
- Gaining experience with **File I/O Operations** for basic data persistence
- Implementing **Generic Interfaces** and reusable code patterns
- Strengthening problem-solving skills through console application development


## 🏗️ Architecture

The project follows a **3-layer architecture**:

1. **UI Layer** (`StoreAppCSharp`)
   - Console-based user interface
   - Handles user input and displays output

2. **Business Logic Layer** (`StoreBl.Bl`)
   - Contains business rules and operations
   - Implements generic interfaces for CRUD operations

3. **Data Access Layer** (`StoreBl.DataAccessL`)
   - Handles data persistence to text files
   - Abstracts file operations through interfaces


## 🚀 Features

- **Store Management**: Add, view, and delete stores
- **Item Management**: Add, view, and delete items
- **Order Management**: Create, view, and delete orders
- **File-based Data Storage**: Data persisted in text files
- **Input Validation**: Basic validation for user inputs
- **Generic CRUD Interface**: Reusable business logic interface

## 🔧 Technologies Used

- **Language**: C# (.NET Framework)
- **Concepts**: OOP, Generic Interfaces, File I/O, Collections, LINQ
- **Patterns**: Layered Architecture, Factory Pattern
- **Data Storage**: Text files (.txt)

## 📦 Getting Started

### Prerequisites
- Visual Studio or any C# IDE
- .NET Framework

### Installation
1. Clone the repository
2. Open the solution file in Visual Studio
3. Build the project
4. Run the application

### Usage
1. Run the console application
2. Navigate through the menu options:
   - Press `1` to manage stores
   - Press `2` to manage items
   - Press `3` to manage orders
   - Press `0` to exit the application

## 🏗️ Code Structure Highlights

### Models
- `StoreModel`: Represents store information
- `ItemModel`: Represents item information
- `OrderModel`: Represents order information with relationships

### Business Logic
- `ClsItem`: Manages store operations
- `ClsItems`: Manages item operations
- `ClsOrders`: Manages order operations
- `IBusinessLayer<T>`: Generic interface for CRUD operations

### Data Access
- `FileDataLayer`: Handles file-based data operations
- `IDataAccess`: Interface for data access operations
- `DataAccessHelper`: Factory class for creating data access objects

## 🎯 Learning Outcomes

Through this project, I reinforced my understanding of:
- Object-Oriented Programming (Classes, Objects, Inheritance, Interfaces)
- Generic programming and reusable code
- File I/O operations and data persistence
- Collection manipulation and LINQ queries
- Layered architecture and separation of concerns
- Input validation and error handling basics

## 🚀 Next Steps

This project serves as a solid foundation for learning:
- ASP.NET MVC Framework
- Database integration (SQL Server, Entity Framework)
- Advanced C# concepts
- Unit testing and test-driven development
- Web application development

## 📝 Author

Mohamed Abdeen

## 📄 License

This project is for educational purposes and personal portfolio development.
