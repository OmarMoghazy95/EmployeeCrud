# 🌐 Full Stack App – .NET 8 Web API + Angular 19

This project is a full-stack application using ASP.NET Core 8 for the backend and Angular 19 for the frontend.

---

## 📁 Solution Structure

- **/Rentsas.Api** --> .NET 8 Web API Project  

- **/rentsas-client** --> Angular 19 Project  
 

   
Follow these exact steps to run the entire project locally.

---

1. Install .NET SDK 8 from https://dotnet.microsoft.com/download/dotnet/8.0  
2. Install Node.js (preferably LTS) from https://nodejs.org  
3. Open a terminal and install Angular CLI globally:  
   `npm install -g @angular/cli`  
4. Clone this repository to your local machine:  
   `git clone https://github.com/OmarMoghazy95/EmployeeCrud.git`  
5. Navigate into the project root folder:  
   `cd EmployeeCrud`  
6. Open a terminal and navigate to the backend project folder:  
   `cd Rentsas.Api`  
7. Restore .NET packages:  
   `dotnet restore`  
8. Run the Api Project (https://localhost:7179):  
   `dotnet run`  
9. Api Project Should be running and migrations are applied Automaticaly to SQLITE DB
   
10. Open a new terminal window or tab, then navigate to the frontend folder:
`cd rentsas-client`
11. Install Angular dependencies:
`npm i`
12. Run The Client Side App (http://localhost:4200):
`ng s -o`

---

## 🐞 Troubleshooting

- **HTTPS issues**  
  If you're facing https certificates error, it might be because the development certificate is not trusted.

  ✅ To trust the HTTPS development certificate on your machine, run:

  ```bash
  dotnet dev-certs https --trust
