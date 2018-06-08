# PhoneBookApi
In order to test the API on your machine, you need first to run Add-Migration and Update-Database and make sure you change options. Audience="http://localhost:4402/api/ in Startup.cs.
The application consists of two controllers "PhoneBookController"  and "TitlesController". "PhoneBookController" has 5 endpoints: HttpGet which returns a list of records from the database, HttpPost to create a new record in PhoneBook,  [HttpPut("{id}")] to update a record, [HttpDelete("{id}")] and [HttpGet("{id}")] to get a record by id. Authorization is required for (post, put and delete) an access token was provided in Startup.cs.  

Repository and unit of work pattern were used to build this API in order to build a loosely coupled, extensible and maintainable application.

Dependency Inversion Principle was taken into consideration to make sure that High-level modules do not depend on low-level modules and both should depend upon abstraction.
