# _Hair Salon_

#### _Application creates a web application for a Hair Salon, 12-07-2018_

#### By _**Sheila Stephen**_

## Description

_Create an MVC web application for a hair salon. The owner should be able to add a list of the stylists, and for each stylist, add clients who see that stylist. The stylists work independently, so each client only belongs to a single stylist._

**_User Stories_**
* _As a salon employee, I need to be able to see a list of all our stylists._
* _As an employee, I need to be able to select a stylist, see their details, and see a list of all clients that belong to that stylist._
* _As an employee, I need to add new stylists to our system when they are hired._
* _As an employee, I need to be able to add new clients to a specific stylist. I should not be able to add a client if no stylists have been added._

## Specs

1. _Create the basic project Structure with the Models, Views and Controllers files_
2. _Models_
            1. Stylist.cs
                    - Create a class Stylist, with the constructor and getter, setter methods and methods to update the database like -GetDescription(),SetDescription(), Save(), Edit(), GetAll(), Find().
            2. Client.cs
                    - Create a class Client, with the constructor and getter, setter methods and methods to update the database like -GetDescription(),SetDescription(), Save(), Edit(), GetAll(), Find(), clearAll()
3. _Controllers_
    Controllers follow the MVC RESTful routing standards.
            1. HomeController.cs
                    - HomeController has the Route to the landing page(/) and gets the view() of the root page.
            2. StylistsController.cs
                    - has a route to view the list of all the stylists in the Database.
                    - has a route to select a stylist, see their details and the list of clients that belong to that stylist.
                    - has a route to Add a new stylist to the system.
                    - has route to add new clients to a specific stylist.

### Database Design

1. _Database name : Sheila_Stephen_
2. _Test Database Name : Sheila_Stephen_test_
3. _Database Schema is One To Many_
4. _2 tables - stylists and clients_
5. _stylists has 2 columns - sid(primary key) and sname_
6. _clients has 3 columns - cid(primary key), cname and sid(foreign key)_

          **_Commands used to recreate the Database_**

          > CREATE DATABASE Sheila_Stephen;
          > USE Sheila_Stephen;
          > CREATE TABLE stylists (stylistId serial PRIMARY KEY, stylistName VARCHAR(255));
          > CREATE TABLE clients (clientId serial PRIMARY KEY, clientName VARCHAR(255), stylistId int);



* _**Project Structure**_




## Setup/Installation Requirements

* _.NET CORE_
* _Mono_

## Known Bugs

_No known bugs_

## Support and contact details

_Sheila Stephen_

## Technologies Used

* _C#_
* _.NET Core MVC Framework_
* _MS Test BDD WorkFlow(Unit Testing for Models and Controllers)_
* _Atom_
* _Command Line_
* _Github_

### License

*MIT*

Copyright (c) 2018 **_Sheila Stephen_**
