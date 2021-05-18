# BlueHarvest
BlueHarvest Assignment

This API has 5 different services.
* GET Customers    : Get All Customers Details 
* GET Customer     : Get Customer Details by Id
* POST Customer    : Create Customer 

* POST Account     : Create Account 

* POST Transaction : Create Transaction


# How to Execute Service
First Need to Create Docker Container of Our App
`docker build -t greenflux .`

After That We Can Run Our App and SQL Server with Docker Composer
`docker-compose up`

# How to Test
I activated Swagger also for Production Environment, You can reach it by this link and test over Swagger all services: 
`http://localhost:5000/swagger/index.html`
