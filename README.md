# Ecommerce Application
## About
### The application design is custom created from me and is fully responsive for all devices. From 280px width to 1920px width.
The application represents ecommerce app where users can buy products (clothes, shoes). Every user has own user-cart and list of his favorite products.
## The application has 2 roles:
### User Role
- User can buy products, can filter products by given criteria and also to write reviews about products. Every user can read all reviews about particular product and to modify his reviews.
### Admin Role
- Admin user can modify all products and also can add product stock for particular product, also can archive product or add promotion to that product.
- Admin user can creates products and also upload imgs about every product.
- Admin user can see all statistics about the app for example total income of the application for particular month, for particular day and total income for all time.
- Admin user can see all orders and can see order-details for particular order.

## Database diagram
![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/b929e603-3b87-481c-9d55-e6c026cc815e)

![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/7fb0281a-3912-4c64-801f-d11d2ab52492)

![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/a76e5055-9e74-476a-9384-a25a6271c903)

## Functionality
- Authenticated users can write reviews about particular product and can edit their own reviews.
- Authenticated users can buy products and can add them in their user-cart. Аfter each successfully placed order, the user receives an email with information about the order
- Users can recieve a promotion code by their email when they reach particular orders-count
- Users can filter products by brand or category and can search about products in search bar
- Authenticated users can write and read reviews about particular product, can edit their own reviews, can buy products
- The anonymous ones can read reviews about particular product, can filter products. 
## Login Page
![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/8a890a9c-78ba-4749-b35c-155c1c77de65)
## Register Page
![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/1a213cf3-a01b-4f65-a239-b199c0dc7ee4)
## Authentication
Authentication is made by using JWT token with Refresh token. On every 15 minutes client app make request to the server to get new jwt token without logout the user by using user refresh token.

![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/636b2cbb-c66f-4401-a034-ae15e7ee0aa8)
## Home page
Home page represents a page with all featured products

![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/8b6f2534-5fad-46cd-b744-28b4a8b6ea4b)

![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/c21fd726-bdc8-4d62-9b02-e501e19363c6)

![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/156a1a8e-c790-41a2-a5ec-570b7c80851b)

## Responsive pictures
![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/9a9f485f-c947-46c4-84cd-f43a0ae5716f)

![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/52884b48-22c1-47b2-92ac-9ca7e9546f1d)

### Products by gender page
- On this page user can filter products and can search for particular product
  
![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/9c3ad309-2c53-412f-bfdd-6c61439e64a7)
## Responsive pictures
![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/7d3448b9-7693-4725-87dc-3e2ed65d618b)

![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/daadcc87-ff6d-4246-9aa5-c35226f404cc)

## Dark Mode
- The application has dark mode which state is saved in local storage
  
![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/879a543f-d936-40eb-bc46-23dbbbb40d64)
  
![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/466f2856-f7e1-4a65-99c4-f6be0f19e077)

## Product Info page
- Here user can add product with particualr size and quantity to his user cart
- If there is no available size which is selected for this product there is no option to be added to user cart
- If quantity is not enough notification message will popup
- If quantity for the selected size is enough the product goes to user cart and this quantity for this product with the selected size is reserved

![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/ac3604b6-249a-4bc0-ab98-0ac8a306ed5f)

![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/e416466f-f99f-40fe-941f-842862bf02e4)

## Products review section
- Here authenticated users can write reviews about particular product

  ![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/96039e0b-9bf5-455c-bc18-decc0304fc04)
- After user successfully post a review popup message will come
   
![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/58c6421d-eaf7-4f8f-a3b1-0e3dfc83ab3f)

## All reviews about particular product page
- Here users can read and modify their own reviews
- Users can choose how many reviews to be visualized per page (default number is 5)
- There is pagination logic
     
![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/4f938813-220b-4837-b8db-4bfda5ce52f7)
     
![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/abfdd065-7518-42fe-9091-71dd5169291b)

## User Cart
- User cart store all products selected by user with particular size and quantity
- User can increase quantity for particular product with particular size if there is any available
- User can decrease quantity for particular product with particular size
- User can apply promotion code on his order
- Promotion code is generated if user reach specific number of total orders and this code is sent by email
- After evry order user recieves an email with his order info

![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/41ea07de-a121-4a78-b169-8a67f8ce2436)

![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/bd96117e-5125-482b-9a8a-0c614cb48400)
       
- If promotion code is applied notification message will come
         
![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/64035b1f-e6a0-4807-8734-8035f77acaa8)

## Order summary page

![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/6a8ca743-da8c-4e57-bbeb-4e372742300c)

## Success Page after finish order

![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/7f35a286-d1e3-4b36-a182-be7855b7beb2)

## Email message
       
![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/b01e14b0-4d3f-42d7-ac19-9d3f22b3b796)
# Admin Dashboard
- Admin Dashboard represents a page with statistics about app income with all orders.
- Admin user can select particular month or a day and can see income for that mont/day
- Admin Dashboard is updating dynamically using SignalR. When someone make an order, the dashboard will be automatically updated.
         
![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/fcf54599-f668-489d-918b-bfa874516fe4)
       
 ![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/f565d2c2-6b8e-463a-bfe0-9f42ec577e7d)

- When particular day is selected new staticstic container will be visualized
       
![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/a0b4606c-8645-41f3-a445-677f7f410388)

- By default initially the selected month is the current month, but when admin change it the statistic container about the month will be updated
      
![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/026e01ab-0270-4b59-b7dc-6c134ceb3d94)

## Product page

![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/664481a4-05a1-425d-96e0-97f97d5ede75)

## Page about particular product
- On this page admin can modify particular product by adding product stock or a promotion
- Admin can change product price, description, brand, category, name and can remove or upload imgs
- Uploaded imgs go on the server

![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/380d6b46-d97c-4751-b6a2-40f8dbc1ebd2)

![image](https://github.com/RosenYordanov2003/EcommerceApp/assets/107473016/5a6c1a7c-f447-4d4e-b0e4-67a4bd167fbf)

## The project is not finished yet!

## Тechnologies I have used
- C#
- ASP.NET Web Api
- Entity Framework core
- Microsoft SQL Server
- SignalR
- SmtpClient
- ReactJS
- CSS
- Ajax
- Git
      











         





















