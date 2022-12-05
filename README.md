# Rocket_Elevators_Information_System

# Description of the REST API requirements 

Creating new GET and PUT requests in the REST API

The REST API needs to be modified and enhanced to offer data through new interaction points:

-GET: Returns all fields of all intervention Request records that do not have a start date and are in "Pending" status.
-PUT: Change the status of the intervention request to "InProgress" and add a start date and time (Timestamp).
-PUT: Change the status of the request for action to "Completed" and add an end date and time (Timestamp).


# Command to use
The links for each Interventions contact points can be viewed in the Postman application, or directlty in the browser after starting the server by running the dotnet run command.
* `https://localhost:5001/api/Interventions/?startDate=null&status=pending`Returns all fields of all intervention Request records that do not have a start date and are in "Pending" status.
*

# Video's Link





