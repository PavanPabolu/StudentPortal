

Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.tools


1. Create ApplicationDBContext class
2. Create Student entity
3. Configure SQL data base connection string in appsettings.json file.
4. Perform Migration in PMC:
	PM> Add-Migration "Initial Migration"
5. Perform below cmd to create or sync/update the entities to the Database by looking on the previously created migration folder.
	PM> Update-Database
6. 












