using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWC.Logic.Services
{
    public enum SortState
    {
        IdAsk,              // по Id по возрастанию
        IdDesk,             // по Id по убыванию
        FistNameAsc,        // по имени по возрастанию
        FistNameDesc,       // по имени по убыванию
        LastNameAsc,        // по фамилии по возрастанию
        LastNameDesc,       // по фамилии по убыванию
        CityAsc,            // по городу по возрастанию
        CityDesc            // по городу по убыванию
    }
}
