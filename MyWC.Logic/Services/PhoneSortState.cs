using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWC.Logic.Services
{
    public enum PhoneSortState
    {
        IdAsk,              // по Id по возрастанию
        IdDesk,             // по Id по убыванию
        PhoneAsc,        // по номеру по возрастанию
        PhoneDesc,       // по номеру по убыванию
        PersonIdAsc,        // по ссылкеId по возрастанию
        PersonIdDesc,       // по ссылкеId по убыванию
    }
}
