using BlazorAppExcel.Models;
using System.Linq;

namespace BlazorAppExcel.API.Interfaces
{

    public interface IExcelRepository : IRepository<Models.TableExcel>
    {
        async Task<bool> ExistsAsync(TableExcel value)
        {
            var item = (await this.ListAsync()).FirstOrDefault(_=>_.Name == value.Name);    

            return item != null;

        }

        async Task SaveAsync(TableExcel value)
        {
            if (await this.ExistsAsync(value))
                await this.Update(value);
            else
                await this.InsertAsync(value);
        }
    }
}
