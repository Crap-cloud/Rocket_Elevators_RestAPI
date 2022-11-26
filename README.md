# Rocket_Elevators_Information_System

# Description
Rocket Elevators Website using the Ruby on rails framework. This website is connected to mysql database, user login and quote form connected. 
The administrator of the page have access to a back office page that displays the employees section and quote form input results. We implemented some API's that retrieve status of batteries, column, elevators or that allows to change the status.

Using HTML / CSS / BOOTSTRAP / JAVASCRIPT / RUBY ON RAILS FRAMEWORK

Ruby's version : 2.7.6
Rails version : 5.2.7.1

To ensure that everything is in order, you need to download ruby and rails version above, and also mysql and postreSQL. You can also download DBeaver community to have a good look on databases and Postman to get outputs from our API's.

# Command to use

First, we use a lot of gem pluggins, so you need to type `bundle install` to download packages. It might not work because of previous tries, so you can try `bundle update`. 

Launch the server with : `rails s`or `rails server`.
After that go on `http://localhost:3000/`to see the result.

To check our databases and tables on the terminal you can go on the sql console with : `mysql -u root`.
To display databases type `SHOW DATABASES;`, and `USE <database_name>;` and now you just need to display the table you want with : `DESCRIBE <table_name>`.

Here is an example :
![alt text](https://github.com/Crap-cloud/Rocket_Elevators_RestAPI/blob/main/image.pngraw=true)

To experiment our API's endpoint you can run `dotnet run` and in your browser or in postamn try some of these addresses :
* `https://localhost:7235/api/interventions/pending`to retrieve all intervention that do not have a start date and are in "Pending" status.
* `https://localhost:7235/api/interventions/1/status/inProgress` to change the status of the intervention request to "InProgress" and add a start date and time
* `https://localhost:7235/api/interventions/1/status/Completed` to change the status of the request for action to "Completed" and add an end date and time 

(If you have no result it could be possible that in your database you have no intervention)

# Video's Link

Video : https://youtu.be/8UNmEqDcL80


