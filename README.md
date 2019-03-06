# chinook-refit
A RESTful API demo console using C# and refit library for Chinook database

## Goal:
To consume a webAPI in C# using Refit library from a python tornado server 

## Just for the record...
### What is a Web API?
You can send a request to an API through web, and if there is no error, you get a response, normally a json response. 

### What is Refit?
Refit is an open-source automatic type-safe REST library which works in Desktop.NET, Xamarin and .NET Core. Refit allows you to make API calls using an interface which hides the HTTP and JSON serialization/deserialization.

### Which sample database?
The Chinook is an SQLite sample database. Its data model represents a digital media store, including tables for artists, albums, media tracks, invoices and customers. In this repo was included the database, and each table in separate files for further inspection.


## How to:
1. Run the tornado server first (Python 3.5 or newer)
2. Start the console application (Visual Studio 2015 or newer)

## Reference:
- Refit https://github.com/reactiveui/refit
- Chinook http://www.sqlitetutorial.net/sqlite-sample-database/
- Consuming a RESTful web service using Refit https://xamgirl.com/consuming-a-restful-web-service-in-xamarin-forms-using-refit-part-1/
- Rest API in Python https://medium.com/octopus-labs-london/how-to-build-a-rest-api-in-python-with-tornado-fc717c33824a

## Tools: 
- Postman https://www.getpostman.com/
- SQLiteStudio https://sqlitestudio.pl/index.rvt
