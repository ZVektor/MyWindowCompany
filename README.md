# MyWindowCompany
<h1>Здравствуйте!</h1>
Здесь я разрабатываю сайт для оконной компании.<br>
Подразумевается что здесь будет вестись вся база заказов, клиентов и других справочников.<br>
<br>
<h2>Как запустить:</h2>
Решение состоит из 4 проектов.<br>
MyWС.DataModels - (Библиотека)Отвечает за подключение и работу с базой данных.<br>
MyWC.Logic - (Библиотека)Содержит сервисы для работы с данными.<br>
MyWC.Api - (WebApi Asp.Net Core) Организована выдача данных в формате JSON, по запросу.<br>
MyWC.Web - (Blazor Server) Собственно сам сайт на Blazer. Данные берет из Api.<br>
<br>
Для теста надо запустить MyWC.Api и MyWC.Web. Для этого зайдите в свойства решения, далее в Общих свойствах выбрать запускаемый проект и отметить "запускать" MyWC.Api и MyWC.Web<br>
<br>
Функционал пока исполнен только на странице Тест<br>
<br>
<h2>Планируется:</h2>
-Добавить в справочнике "Тест" в форму добавление телефона<br>
-Добавить в справочнике "Тест" в таблицу колонку с телефонами<br>
-Добавить выдачу в таблице по странично<br>
-Сделать справочник "клиенты" из тестовой<br>
-Сделать справочник "телефонные номера"<br>
<br>
<h2>Используется:</h2>
-Net 7.0<br>
-EntityFrameworkCore 7.0.2<br>
-WebBlazer<br>
<br>
