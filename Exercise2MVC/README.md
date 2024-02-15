# Shipping Cost Calculator - ASP.NET MVC Application

## Prerequisites

Ensure that you have the following software installed:

- .NET Framework (4.7.2)
- SQL Server (version 2022)
- Visual Studio 2022

## Web Application Setup

1. **Clone Repository**

2. **Open Solution:**
   - Open the solution file (`.sln`) in Visual Studio.

3. **Configure Connection String:**
   - Open the `Web.config` file in the web project.
   - Locate the connection string section and update it with your SQL Server details.

     ```xml
     <connectionStrings>
       <add name="DefaultConnection" connectionString="YourConnectionStringHere" providerName="System.Data.SqlClient" />
     </connectionStrings>
     **See below default connection string**
    <connectionStrings>
        <add name="Exercise2ConnectionString" connectionString="Data Source=.;Initial Catalog=Exercise2Db;Integrated Security=True; TrustServerCertificate=True;" providerName="System.Data.SqlClient" />
    </connectionStrings>
     ```

## Database Setup

### Database Restore

Database backup is provided, follow these steps:

1. **Restore Database:**
   - Restore the `Exercise2Db` database backup to your SQL Server instance.

## Running the Application

1. **Build and Run:**
   - Build the solution and run the web application.

2. **Access the Application:**
   - Running the application will open the browser and navigate to `https://localhost:port`.

## Usage Instructions

1. **Customer Management:**
   - Use the customer list to select, add, remove, and edit customer details.

2. **Parcel Management:**
   - Select a customer to view their list of parcels.
   - Add, edit, and delete parcels from the list.

3. **Parcel Item Management:**
   - Upon selecting a parcel, manage its parcel items - add, edit, and delete.

4. **Cost and Classification Calculation:**
   - The system will automatically recalculate the cost and classification based on the rules provided.

## SQL Reports

### Parcel Report

1. **Run SQL Query Report:**
   - Execute the stored procedure `GetParcelsReport` file using SQL Management Studio. Below is the sample execution.
   - `EXEC GetParcelsReport @InputDate = '01/20/2024'`

### Parcel Contents Report

1. **Run Stored Procedure Report:**
   - Execute the stored procedure `GetParcelItemReport` file using SQL Management Studio. Below is the sample execution.
   - `EXEC GetParcelItemReport @ParcelId = 1`

## Developers Instructions

- **ReadMe File:**
  - The ReadMe file contains important instructions and explanations for developers.
  
- **Version Information:**
  - The application is developed using .NET Framework 4.8 and SQL Server 2022.

By following these instructions, you should be able to set up and use the application successfully.