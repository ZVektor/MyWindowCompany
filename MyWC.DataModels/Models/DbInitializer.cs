using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWC.DataModels.Models
{
    internal class DbInitializer
    {
        public static void Initialize(MyWcdbContext context)
        {
            context.Database.EnsureCreated();

            // Есть ли вообще персоны 
            if (context.People.Any())
            {
                return;
            }

            var persons = new Person[]
            {
            new Person{FirstName="Денис",LastName="Хорошевский",City="Кемерово"},
            new Person{FirstName="Ольга",LastName="Корнелюк",City="Омск"},
            new Person{FirstName="Вадим",LastName="Сапрыгин",City="Томск"},
            new Person{FirstName="Александр",LastName="Великий",City="Орск"},
            new Person{FirstName="Виктория",LastName="Дайнеко",City="Оренбург"},
            new Person{FirstName="Демис",LastName="Карибидис",City="Москва"},
            new Person{FirstName="Сергей",LastName="Силиванов",City="Кемерово"},
            new Person{FirstName="Тимур",LastName="Спайкин",City="Красноярск"},
            new Person{FirstName="Ксения",LastName="Ловачева",City="Новокузнецк"},
            new Person{FirstName="Ольга",LastName="Реснина",City="Прокопьевск"},
            new Person{FirstName="Вячеслав",LastName="Степной",City="Иркутск"},
            };
            foreach (Person s in persons)
            {
                context.People.Add(s);
            }
            context.SaveChanges();

            var phones = new Phone[]
            {
            new Phone{PhoneNumber="89132996666",PeopleId=1},
            new Phone{PhoneNumber="89231234567",PeopleId=2},
            new Phone{PhoneNumber="89230254567",PeopleId=3},
            new Phone{PhoneNumber="89236204567",PeopleId=4},
            new Phone{PhoneNumber="89231223567",PeopleId=5},
            new Phone{PhoneNumber="89231254567",PeopleId=6},
            new Phone{PhoneNumber="89233814567",PeopleId=7},
            new Phone{PhoneNumber="89231200567",PeopleId=8},
            new Phone{PhoneNumber="89231241567",PeopleId=9},
            new Phone{PhoneNumber="89231226567",PeopleId=10},
            new Phone{PhoneNumber="89832171511",PeopleId=11},
            new Phone{PhoneNumber="89832171511",PeopleId=1},
            };
            foreach (Phone e in phones)
            {
                context.Phones.Add(e);
            }
            context.SaveChanges();
        }
    }
}
