
# Foodle C# CMS with threading

A project for the C# Threading module by Rob Smit at NHL Stenden.


## Authors

- [Ramon Gonzalez](https://www.github.com/Lonely-Taco)
- [Thomas Koops](https://www.github.com/ThomasK24a)
- [Christof Du Toit](https://www.github.com/Christof145)
- [Ramon Brakels](https://www.github.com/Ramonb2)
- [Carla Redmond](https://www.github.com/red-carla)

# Run locally
Clone the project into Visual Studio

```bash
  git clone https://github.com/Lonely-Taco/CMS-with-Threading
```

Go to the project directory

Create secrets

Install the database (see below)

Create connection in Visual Studio

Build solution

## Database Installation

Open SQL Server Management Studio > Create new database named Foodle

Run the file foodle.sql found in the root.

Windows Firewall > Advanced Settings > New Inboud Rule > Port >TCP, 1433 > Allow the connection >Next >> Finish

SQL Configuration Manager > SQL Server Network Configuration Dropdown > Protocols for MSSQLSERVER > Enable TCP/IP

SQL Configuration Manager > SQL Server Services > make sure all running

If not all running - open Services, find the services and start them.

Right click server > Properties > Security > Select SQL Server and Windows Authentication mode
Connections tab > Select allow remote connections to this server

In Visual Studio
Search through the code and replace the phrase "(your PC name here)" with your server name. There are 3 instances of (your PC name here) in the project.

Add connection > MSSQL Server > Choose server > SQL Login > Foodle

Replace the phrase (your PC name here) with your server name. There are 3 instances of (your PC name here) in the project.


