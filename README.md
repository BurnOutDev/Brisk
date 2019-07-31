# Famous Quote Quiz
A quiz game for testing purposes.

## UPDATE:
In ClientApp I added: 
  - Authentication with user and password.
  - Page /play, where game starts.
  - Settings where you can change game mode and question count. On this page are quote management and user management pages (User achievements and reviews page is not finished yet).

I created .NET Core API project with EF Core and added JWT Authentication for client applications. 

API project has dependencies of Brisk.Domain, where my models and entities are and Brisk.Application where I put Services and it's interfaces. 

In solution there is also a project Brisk.Web (Razor Pages), where I made just user interface, because I was planning UI first. After created client app on Angular, but didn't finish that part

Here are UI design images: https://cutt.ly/ACHZrX

Generated Database script is BriskDb.sql.
