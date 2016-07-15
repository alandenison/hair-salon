# _Hair Salon_

#### _A database which takes the names of hair stylists and lists their clients, 7/15/2016_

#### By _**Alan Denison**_

## Description
This program will allow the user to create names of individual stylists working at a hair salon, then a list of clients for each of the stylists.

## Setup/Installation Requirements
Instructions for Windows PC.
Get windows here: (http://www.mono-project.com/docs/getting-started/install/windows/)

1. From Powershell, clone this repository using the command 'git clone https://github.com/alandenison/hair-salon.git'
2. Navigate to project directory
3. Run the command 'dnu restore' to get dependencies
4. Use the command 'dnx kestrel' to run the kestrel server
5. Open a browser and go to: localhost:5004

DATABASE INSTRUCTIONS
in SQLCMD use these commands to set up a database:
CREATE DATABASE hair_salon;
GO
USE DATABASE hair_salon;
GO
CREATE TABLE stylists(id INT IDENTITY (1,1), name VARCHAR(255));
GO
CREATE TABLE clients(id INT IDENTITY(1,1), name VARCHAR(255), stylist_id INT);
GO


## Technologies Used

C#, Razor, Nancy, Xunit, SQLCMD
### License
MIT/open source license


Copyright (c) 2016 **_Alan Denison_**
