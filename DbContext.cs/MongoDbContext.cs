﻿
using BlazorAppExcel.Models;
using MongoDB.Driver;

namespace BlazorAppExcel.API.DbContext;
public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    // Example: Define a property for a "Users" collection
    public IMongoCollection<TableExcel> ExcelTables => _database.GetCollection<TableExcel>("TableExcel");
}