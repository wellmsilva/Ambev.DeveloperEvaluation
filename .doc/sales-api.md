[Back to README](../README.md)

### Sales

#### GET /sales

- Description: Retrieve a list of all sales
- Query Parameters:
  - `_page` (optional): Page number for pagination (default: 1)
  - `_size` (optional): Number of items per page (default: 10)
  - `_order` (optional): Ordering of results (e.g., "price desc, number asc")
- Response:
  ```json
  {
    "success": true,
    "message": "string",
    "errors": [
      {
        "error": "string",
        "detail": "string"
      }
    ],
    "data": [
      {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "number": "string",
        "date": "2025-04-08T08:44:57.755Z",
        "customerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "totalAmount": 0,
        "branch": "string"
      }
    ]
  }
  ```

#### POST /sales

- Description: Add a new Sale
- Request Body:
  ```json
  {
    "number": 0,
    "customerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "branch": "string",
    "products": [
      {
        "name": "string",
        "quantity": 0,
        "price": 0,
        "discount": 0,
        "amountTotal": 0
      }
    ]
  }
  ```
- Response:
  ```json
  {
    "success": true,
    "message": "string",
    "errors": [
      {
        "error": "string",
        "detail": "string"
      }
    ]
  }
  ```

#### GET /sales/{id}

- Description: Retrieve a specific sale by ID
- Path Parameters:
  - `id`: Sale ID
- Response:
  ```json
  {
    "success": true,
    "message": "string",
    "errors": [
      {
        "error": "string",
        "detail": "string"
      }
    ],
    "data": {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "number": "string",
      "date": "2025-04-08T08:52:07.282Z",
      "customerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "totalAmount": 0,
      "branch": "string",
      "products": [
        {
          "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          "name": "string",
          "price": 0,
          "quantity": 0,
          "discount": 0,
          "totalAmount": 0
        }
      ],
      "isCancelled": true
    }
  }
  ```

#### PUT /sales/{id}/cancel

- Description: Cancel a specific sale
- Path Parameters:
  - `id`: Sale ID
- Response:

```json
{
  "success": true,
  "message": "string",
  "errors": [
    {
      "error": "string",
      "detail": "string"
    }
  ]
}
```

#### DELETE /sales/{id}

- Description: Delete a specific sale
- Path Parameters:
  - `id`: Sale ID
- Response:
  ```json
  {
    "success": true,
    "message": "string",
    "errors": [
      {
        "error": "string",
        "detail": "string"
      }
    ]
  }
  ```
