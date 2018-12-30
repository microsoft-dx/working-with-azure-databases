# Working with Azure Databases

This workshop was hosted at the [Microsoft Innovation Center @ UPB](https://microsoft.pub.ro/) as an introduction to the Azure Databases service.

By the end of the workshop you will have an understanding of:
- What is Azure?
    - cloud-computing platform
    - open, flexible, enterprise-grade
- What is a SQL Database
    - relational database
- How does a relational database work
    - data is organized into one or more tables
    - tables have columns and rows
    - each entry has a unique key
- What is Entity Framework
    - Object Relational Mapping (ORM)
    - eliminates the need for most of the data-access code
    - less code
- What is an entry
    - a row in a table
    - unique key
- How to store different elements in the database
    - INSERT -> SQL query for inserting entries
    - UPDATE -> SQL query for updating entries
    - DELETE -> SQL query for removing entries
- How to acces the elements from the database
    - SELECT -> SQL query for retrieving entries

### How to get started?

You can set up your workspace by starting with the "CreatingADB.mp4" video that will step you through the steps of creating a database on the Azure Cloud.

### What will we do?

Workshop's blueprint is built around two different approaches on working with SQL Databases. In this manner, we will implement the basic operations of a database manager (SELECT, INSERT, UPDATE, DELETE) in two ways: 
- Using classic SQL
- Using the Entity Framework

For testing what we've made, we are going to make a blueprint class, called "IDemo", that will allow us to test the database in both ways mentioned above. 

### In conclusion

As you may have observed, no high knowledge is required to create a simple database using Azure services and C#. For a better understanding on how powerful the Entity Framework really is and what you can do with it, [Microsoft Docs](https://docs.microsoft.com/en-us/ef/ef6/) is a good way to start. Also, thanks to [Azure SQL](https://azure.microsoft.com/en-us/services/sql-database/) everything is easy and fast to implement.

So, there you have it, these are your first steps into the Database Management world. Stay tuned on our [Facebook Page](https://www.facebook.com/microsoft.pub.ro/) for future workshops and courses. 