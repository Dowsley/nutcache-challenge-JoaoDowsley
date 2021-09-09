# PeopleApi: A MVC Application for Registering Employees
## Technical Solution
### Chosen Technology
[ASP.NET Core MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-5.0) is a powerful framework by itself, but it was my choice because I deemed it as especially useful to accomplish the challenge requirements of having both Front-end AND Back-end, due to its **MVC architecture pattern**.
### Overral Architecture
The PeopleApi follows the MVC Architecture Pattern, so, of course, it was implemented separated in those three major parts. I assume the reader is already familiar with the concepts, but in case they're not, [read here](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93controller). Now, a summary of each part:
#### Model
The Model class `Models/Person.cs` is a data structure that represents the concept of a *Person* (or *Employee* if you prefer, but I'll call it Person along the rest of the explanation), which is what the whole of PeopleApi is built around. It contains the following fields (along with its validation and display rules):
- Id (long)
    - Non-nullable
    - Is automatically handled by the Framework
- Name (string)
    - Non-nullable
    - Display: "Name"
- BirthDate (DateTime) 
    - Non-nullable
    - Display: "Birth Date"
- Gender (GenderTypeEnum)
    - ENUM OPTIONS: Male, Female, Other
    - Non-nullable
    - Display: "Gender"
- Email (string)
    - Validated by email regex (built-in annotation)
    - Non-nullable
    - Display: "Email"
- CPF (string)
    - Validated by custom regex, accepts CPF without dashes and/or dots.
    - Non-nullable
    - Display: "CPF"
- Start Date (string) 
    - String validated by regex
    - Validated by custom regex against the MM/YYYY format.
    - Non-nullable
- Team (TeamTypeEnum)
    - ENUM OPTIONS: Mobile, Frontend, Backend
    - NULLABLE

#### Controller
The `Controllers/PeopleController.cs` class contains several endpoints that handle user interaction, and through a instance of the `Data/PeopleContext.cs` class, can make use of the the Model `Person` regardless of how it is stored. In this case, I'm using SQLite, but it can be changed rather easily passing the right parameters to `PeopleContext`. 

The PeopleApi is a Full-Stack application, so it's the responsability of each GET Endpoint to render an HTML View with the data properly injected in it, instead of just returning JSON data. Here are the endpoints along with what requirements they cover and views they load:

- GET: People (root of the web app)
    - REQUIREMENT: Define and implement an API for all employees already registered;
    - PARAMETERS: None
    - Loads a list of all `Person` instances stored in `PeopleContext` and renders the "Index" with this data.
- POST: People/Create
    - REQUIREMENT: Define and implement a people registration API;
    - PARAMETERS: `Person` object in Form Data. Handled by the View.
    - Creates a new `Person` instance and stores it in `PersonContext` if valid. Then redirects to "Index" View.
- POST: People/Edit/Id
    - REQUIREMENT: Define and implement an API to edit a previously registered employee;
    - PARAMETERS: `Id` string in url parameter AND `Person` object in Form Data, Handled by the view.
    - Finds a `Person` stored in the context, by the provided Id. If found and if the change data provided is valid, updates this person with the new info and then stores it. At least, it redirects to the "Index" View.
- POST: People/Delete/Id
    - REQUIREMENT: Define and implement an API to delete a previously registered employee;
    - PARAMETERS: `Id` string in url parameter.
    -  Finds a `Person` stored in the context, by the provided Id.  If found, deletes it from the Context. Then it redirects to the "Index" View.
- GET: People/Details/Id
    - REQUIREMENT: **None, that's an extra!**
    - PARAMETERS: `Id` string in url parameter.
    -  Finds a `Person` stored in the context by the provided Id.  If found, returns the "Detail" View.

**There are Unit Tests for each endpoint. You can check how to run them in the Usage section.**

#### View
The main View is "Index", which is also the root of the application. It contains a "Add New Employee" button that opens a pop-up with a Partial View Form that, once filled, will fetch POST: People/Create and update the page.

When there are Employees Registered, they will be listed in the Table Grid with the following information: `Name, Email, Start Date and Team`; To the side of the Grid, for each Employee, there will be three buttons for each of the other three Endpoints:
- Edit: Will open a Pop-up Form similar to the Creation Form that, upon confirmation, calls FORM: People/Edit/Id.
- Details: Using the data fetched from GET: People/Details/Id, will open the Pop-up Partial View with the Employee Details.
- Delete: Will open a Pop-up confirmation box that, upon confirmation, calls POST: People/Delete/Id.

**All Forms contain validation matching the Data Annotations from the Model.**

## Usage Instructions
### Setup & Environment
To execute this project, and run its tests, you have to use Visual Studio 2019 and have .NET 5.0 installed with its proper libraries and utils. The project should run and build in any OS and Processor, but preferrably use Windows if you can.

With VS 2019 opened and .NET 5.0 installed, import the project by choosing the `PeopleApi.sln` file: 
![Foo](https://i.imgur.com/frCyyXn.png)

### Execution
With the project open, compile it by going to **Build -> Build Solution** or just using `Ctrl + Shift + B`.
![Foo](https://i.imgur.com/Y2NdAXf.png)

Now that the Build is ready, you can execute it by finding the green arrow button and choosing the correct project name (PeopleApi). The app will use the Port 5001, so it's important the it is not being used by other application.
![Foo](https://i.imgur.com/XESig5r.png)

### Usage
After execution, it should automatically open the browser for you on in the root view, which is the "Index" List of Employees. In case it did not, go to https://localhost:5001/.

Now that it's your first time opening the App, the Employees Grid will be empty. You can add one by clicking this button.
![Foo](https://i.imgur.com/I2KRvUr.png)

After employees are added, try interacting with the other endpoints through the buttons.
![Foo](https://i.imgur.com/qNgevFY.png)

### Tests
I'm using NUnit for Unitary Tests on the Controller. There is one test for each endpoint, and they are located in `Controllers/PeopleControllerTest.cs`.

To run them in Visual Studio, you''ll need the proper packages installed. Then go to **Tests -> Run All Tests** or simply press `Ctrl + R, A`. You can also run `dotnet test` from the Integrated Terminal, if you have the test utility installed.
![Foo](https://i.imgur.com/h9QIpXc.png)
