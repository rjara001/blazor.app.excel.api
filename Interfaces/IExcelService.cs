using BlazorAppExcel.Models;

namespace BlazorAppExcel.API.Interfaces;

public interface IExcelService
{
    Task<bool> save(TableExcel tableExcel);
}