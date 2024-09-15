# DtoPractice API

## Project Overview

DtoPractice API is a sample project designed to understand and practice concepts related to Data Transfer Objects (DTOs), mapping, and validation within an ASP.NET Core application. The project demonstrates the use of DTOs to separate concerns between the API and business logic layers, implement manual and library-based mapping techniques, and apply validation using FluentValidation.

## Technologies Used

- **ASP.NET Core 8**: Framework for building the API.
- **Entity Framework Core**: ORM for database operations.
- **FluentValidation**: Library for validating DTOs.
- **AutoMapper**: Library for object-to-object mapping.
- **Mapster**: Another mapping library.

## Endpoints

### Products

#### Create a Product
- **POST** `/api/product`
- **Description**: Creates a new product.
- **Request Body**: `ProductCreateDTO`
- **Response**: `ProductGetDTO`

#### Get All Products
- **GET** `/api/product`
- **Description**: Retrieves a list of all products.
- **Response**: `List<ProductGetDTO>`

#### Get Product By ID
- **GET** `/api/product/{id}`
- **Description**: Retrieves a single product by its ID.
- **Response**: `ProductGetDTO`

#### Update a Product
- **PUT** `/api/product/{id}`
- **Description**: Updates an existing product by its ID.
- **Request Body**: `ProductUpdateDTO`
- **Response**: `NoContent` (204)

#### Delete a Product
- **DELETE** `/api/product/{id}`
- **Description**: Deletes a product by its ID.
- **Response**: `NoContent` (204) or `NotFound` (404)

Feel free to adjust any sections based on your specific implementation and project needs!
