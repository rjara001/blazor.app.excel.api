using BlazorAppExcel.API.Interfaces;
using BlazorAppExcel.Models;
using System.Linq;

namespace BlazorAppExcel.API.Services;

public class ExcelService : IExcelService
{
    private IRepository<TableExcel> _respository;

    public ExcelService(IRepository<TableExcel> repository)
    {
        this._respository = repository;
    }

    public async Task<bool> save(TableExcel tableExcel)
    {

        await _respository.InsertAsync(tableExcel);
        
        return true;
    }

}
