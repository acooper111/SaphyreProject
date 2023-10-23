# SaphyreProject

This is a simple CRUD application made as a take home project for Saphyre. It uses a .NET stack with a Blazor front end and SQL Server DB.

The front end is very simple and is based mostly off of the default Blazor template. 
There are three pages, the home screen that lists all the users in the DB, a page to add and edit users, and a page to delete users.

The back end is also very simple. The main interest here are the User model, UserService, and UserRepository. 
The User model defines the User object that is used in the rest of the solution and has input validation. 
The UserService is a layer between the fron end and the repository that doesn't serve much of a purpose in a simple app like this but would be where all the business logic would go in a more complicated application.
The UserRepository allows the app to interact with the DB. This is where the Create, Read, Update, and Delete functionality is implemented.

Because my app seemed a little simple I also implemented a custom logger with model, service and repository classes.
In the model I added an enum to make tracking LogLevel a little easier.
In the service we have different methods depending on the level of log we want to create and they then call the repo method to store the log in the DB
