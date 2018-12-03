# SimpleToDo
A simple to-do app using ASP.NET Core MVC 2.1

## Installation
### Configuring database connection
By default this application targets your MSSQLLocalDB instance. If you don't have one, you can change connection string in appsettings.json file to target any instance of Microsoft SQL Server. Just change the value of `DefaultConnection`. Alternatively, you can add a new key to this dictionary that contains your custom connection string and reference it in StartUp.cs:40.

### Creating the database
SimpleToDo uses Entity Framework for connecting with database. Entity Framework enables programmers to use code first approach. This approach was used to create SimpleToDo application. All you have to do is follow these points:
1. If you have a database instance on your SQL Server which is named `SimpleToDoDB` then either delete it or pick any other SQL Server instance.
2. Make sure that in Solution Explorer default project is set to `SimpleToDo.WebApp`.
3. Open `Packet Manager Console`.
4. Make sure that in Packet Manager Console "Default project" is set to `SimpleToDo.Database`.
5. Type `update-database` and confirm it by pressing Enter.
6. Database migration succeeded if you see "Done." in the last line of output.

### Launching the application
When database is created, you can launch web application project by pressing F5 (make sure its still a default project - its name should be displayed **in bold** in Solution Explorer). Now the project will build and when build succeeds a new browser window will be displayed with default page. **Please note that this application works best when using Google Chrome - a small issues might occur when using Mozilla Firefox or others.**

### Changing number of displayed tasks per page
By default application will display 10 tasks per single page. To change this you need to modify value passed to service method in TasksController.cs:27 from 10 to your own.

## Third Party software used by SimpleToDo
SimpleToDo relies on the following packages (via NuGet):
* [FluentValidation.AspNetCore](https://www.nuget.org/packages/FluentValidation.AspNetCore/8.0.101) is used for view model validation purposes.
* [X.PagedList.Mvc.Core](https://www.nuget.org/packages/X.PagedList.Mvc.Core/7.6.0) is used to provide paging.
* [AutoMapper](https://www.nuget.org/packages/AutoMapper/8.0.0) is used to map between entity type and view models.
* [Microsoft.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/2.1.4) is used for database communication.
* [BuildBundlerMinifier](https://www.nuget.org/packages/BuildBundlerMinifier/2.8.391) enables possibility to minify css and javascript files during project build. It is especially helpful when you build this project in Release mode.

Also SimpleToDo uses these npm packages (via libman):
* [twitter-bootstrap@4.1.3](https://cdnjs.com/libraries/twitter-bootstrap) is used for page layout (note that default version of bootstrap used for project template is 3.3.7, I've updated it to the latest version).
* [jquery@3.3.1](https://cdnjs.com/libraries/jquery) is used to provide basic bootstrap functionalities and as a validation base.
* [jquery-validate@1.18.0](https://cdnjs.com/libraries/jquery-validate) is one of the main validation frameworks used.
* [jquery-validation-unobtrusive@3.2.11](https://cdnjs.com/libraries/jquery-validation-unobtrusive) is second one of the main validation frameworks used.
* [bootstrap-toggle@2.2.2](https://cdnjs.com/libraries/bootstrap-toggle) is used to create a toggler in place of checkbox in search results, tasks index and task details pages.
* [tempusdominus-bootstrap-4@5.1.2](https://cdnjs.com/libraries/tempusdominus-bootstrap-4) is used to display date and time pickers in creation and edition forms.
* [moment.js@2.22.2](https://cdnjs.com/libraries/moment.js) is just tempusdominus's dependency.

For this software I give absolutely no warranty and I'm not responsible for their behaviour. 