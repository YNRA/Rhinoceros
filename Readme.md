# Api
https://localhost:5001/swagger/index.html

# Writer 
Database is not set up, you have to run Writer in order to fill it up (dotnet run in Writer directory)


# Reader
## Route get all db
https://localhost:5001/Rhinoceros/

## Route get departments by id
https://localhost:5001/Rhinoceros/6162d1050f4cf766959653bc


## Route get departments by name
https://localhost:5001/Rhinoceros/Gironde

## Route get departments by postal code
https://localhost:5001/Rhinoceros/GetDepartmentByPostalCode?PostalCode=32

## Route to search in DB by name & postal code & population < or >
curl -X POST "https://localhost:5001/Rhinoceros/search" -H  "accept: text/plain" -H  "Content-Type: application/json-patch+json" -d " \"departmentName\":\"Gir\",\"postalCode\":\"33\",\"population\":30,\"conditionPopulation\":\">\"}"
