# Task Tracker REST API
.NET 5 based Task management web API that responds to Post/Get/Put/Delete requests over REST protocol


## Live Demo at Azure Cloud
https://tasktrackerapi2.azurewebsites.net/

- GET Request&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=>&nbsp;&nbsp;&nbsp;.../api/Tasks &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=>&nbsp;&nbsp;&nbsp;Get all Tasks
- GET Request&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=>&nbsp;&nbsp;&nbsp;.../api/Tasks/3 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=>&nbsp;&nbsp;&nbsp;Get a Task with Id = 3
- GET Request&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=>&nbsp;&nbsp;&nbsp;.../api/Tasks/ama &nbsp;&nbsp;=> &nbsp;&nbsp;&nbsp;Get a Task whose description includes 'ama' (Search function)
- POST Request&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=>&nbsp;&nbsp;&nbsp;.../api/Tasks &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=>&nbsp;&nbsp;&nbsp;Creates a new Task
- PUT Request&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=>&nbsp;&nbsp;&nbsp;.../api/Tasks/1 &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;=>&nbsp;&nbsp;&nbsp;Updates a Tasks with Id = 3
- DELETE Request&nbsp;&nbsp;&nbsp;=>&nbsp;&nbsp;&nbsp;.../api/Tasks/1 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=>&nbsp;&nbsp;&nbsp;Deletes a Task with Id = 3


## Live Demo with a React web app

https://mehmetgokcek.github.io/task-tracker-react-app/

- React App provides a neat interface to manage 'Task' object by allowing the user to make Post/Get/Put/Delete requests to the Task Tracker REST API.

- Task data persists on an SQL database server.

- Both REST API and SQL Server run on Azure cloud.
