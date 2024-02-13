using MongoDB.Driver;
using BlazorAppExcel.API.Interfaces;
using BlazorAppExcel.API.DbContext;
using BlazorAppExcel.Models;

namespace BlazorAppExcel.API.Repository;
public class ExcelTableMongoDb : IExcelRepository
{
    IConfigurationRoot configuration;

    List<TableExcel> _tables = new List<TableExcel>();
    private string connectionString = string.Empty;
    private string databaseName = "teo-db";

    public ExcelTableMongoDb()
    {
        this.configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Set the base path to the location of your appsettings.json
            .AddJsonFile("appsettings.json") // Load the appsettings.json file
            .Build();

        this.connectionString = this.configuration["ConnectionStrings:TeoConnection"] ?? "";

    }
    public async Task Add(TableExcel entity)
    {
        await this.InsertAsync(entity);
    }

    public async Task DeleteAsync(TableExcel entity)
    {
        MongoDbContext dbContext = new MongoDbContext(connectionString, databaseName);
        await dbContext.ExcelTables.DeleteOneAsync(_ => _.Id == entity.Id);
    }

    public void Edit(TableExcel entity)
    {
        throw new NotImplementedException();
    }

    public async Task<TableExcel> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public async Task InsertAsync(TableExcel entity)
    {
        MongoDbContext dbContext = new MongoDbContext(connectionString, databaseName);

        if (entity.Id.Count()<=0)
            entity.Id = Guid.NewGuid().ToString();

        var filter = Builders<TableExcel>.Filter.Empty;

        await dbContext.ExcelTables.InsertOneAsync(entity);
    }

    public async Task<IList<TableExcel>> ListAsync()
    {

        MongoDbContext dbContext = new MongoDbContext(connectionString, databaseName);

        var filter = Builders<TableExcel>.Filter.Empty;

        return await (await dbContext.ExcelTables.FindAsync(filter)).ToListAsync();
    }

    public async Task Update(TableExcel entity)
    {
        MongoDbContext dbContext = new MongoDbContext(connectionString, databaseName);

        var filter = Builders<TableExcel>.Filter.Eq("Id", entity.Id);

        var update = Builders<TableExcel>.Update
                .Set("Name", entity.Name)
                .Set("Rows", entity.Rows)
                .Set("Columns", entity.Columns);

        // Set the upsert option to true
        var options = new UpdateOptions { IsUpsert = true };

        // Perform the upsert operation
        await dbContext.ExcelTables.UpdateOneAsync(filter, update, options);

    }
}

