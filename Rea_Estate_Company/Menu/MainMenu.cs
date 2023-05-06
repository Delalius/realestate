using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary1.IO;
using Core.Entities;
using Core.Functional;

namespace Rea_Estate_Company.Menu
{
    public class MainMenu
    {
        private int id;
        private bool IsExit = true;
        //Тестовые данные
        private List<Client> Clients = new List<Client>();
        private List<Apartment> Apartments = new List<Apartment>();
        private List<Offer> Offers = new List<Offer>();
            
        
        //Конструктор который вызывает меню
        public MainMenu()
        {
            Clients = XmlDataServices.LoadClients(Clients);
            Apartments = XmlDataServices.LoadApartments(Apartments);
            Offers = XmlDataServices.LoadOffers(Offers);

            Menu();
        }
        // Меню - Пользовательский интерфейс
        private void Menu()
        {
            while (IsExit)
            {
                Console.Clear();
                Console.WriteLine("\tРіелтерська фірма: надання послуг по здаванню або продажу квартир");
                Console.WriteLine("\n\n" + "Управління клієнтами"
                    + "\n 0. Вийти з програми"
                    + "\n 1. Додати клієнта"
                    + "\n 2. Видалити клієнта"
                    + "\n 3. Реагувати дані про клієнта"
                    + "\n 4. Переглянути список всіх клієнтів"
                    + "\n 5. Додати пропозицію у обране");
                Console.WriteLine("\nУправління даними про нерухомість"
                    + "\n 6. Додати об'єкт нерухомусті"
                    + "\n 7. Видалити об'єкт нерухомусті"
                    + "\n 8. Редагувати дані об'єкта нерухомусті"
                    + "\n 9. Переглянути список всіх об'єкт нерухомусті");
                Console.WriteLine("\n Управління пропозиціями нерухомості "
                    + "\n 10. Переглянути список пропозицій"
                    + "\n 11. Додати пропозицію"
                    + "\n 12. Відхилити пропозицію");
                Console.WriteLine("\n Сортування"
                    + "\n 13. Сортування за прізвищем"
                    + "\n 14. Сортування за ім'ям"
                    + "\n 15. Сортування за номером картки"
                    + "\n 16. Сортування за кількістю кімнат"
                    + "\n 17. Сортування за вартіст'ю об'єкта"
                    + "\n 18. Сортування за типом об'єкта");
                Console.WriteLine("\n Пошук"
                    + "\n 19. Пошук клієнта за ім'ям"
                    + "\n 20. Пошук клієнта за прізвищем"
                    + "\n 21. Пошук клієнта за номером картки"
                    + "\n 22. Пошук об'єкта нерухомості за адресою");    
                
                id = Entering.EnterInt32("\n\n\t Введіть номер команди", 0, 22);

                switch (id)
                {
                    case 0:
                        
                        IsExit = false;
                        break;
                    case 1:
                        Console.WriteLine("\tЗаповніть форму");
                        string surname = Entering.EnterString("Прізвище:", 2, 20);
                        string name = Entering.EnterString("Ім'я:", 2, 20);
                        string card = Entering.EnterString("Номер картки:", 16);
                        Clients.Add(MainFunctionals.AddClient(surname, name, card));
                        break;
                    case 2:
                        MainFunctionals.ShowAllClients(Clients);
                        id = Entering.EnterInt32("\t Введіть номер клієнта", 0, Clients.Count-1);
                        MainFunctionals.DeleteClient(Clients, Clients[id]);
                        break;
                    case 3:
                        MainFunctionals.ShowAllClients(Clients);
                        id = Entering.EnterInt32("\t Введіть номер клієнта", 0, Clients.Count - 1);
                        Console.WriteLine("\tЗаповніть форму");
                        surname = Entering.EnterString("Прізвище:", 2, 20);
                        name = Entering.EnterString("Ім'я:", 2, 20);
                        card = Entering.EnterString("Номер картки:", 16);
                        MainFunctionals.ChangeClient(Clients[id], surname, name, card);
                        break;
                    case 4:
                        Console.WriteLine("\tВсі клієнти");
                        MainFunctionals.ShowAllClients(Clients);
                        break;
                    case 5:
                        MainFunctionals.ShowAllClients(Clients);
                        int i = Entering.EnterInt32("\t Введіть номер клієнта", 0, Clients.Count - 1);
                        MainFunctionals.ShowAllOffers(Offers);
                        id = Entering.EnterInt32("\t Введіть номер пропозиції", 0, Offers.Count - 1);
                        Clients[i].Offers.Add(Offers[id]);
                        break;
                    case 6:
                        Console.WriteLine("\tЗаповніть форму");
                        string addres = Entering.EnterString("Адресса:", 2, 20);
                        int cost = Entering.EnterInt32("Ціна", 100, 1000000);
                        int countOfRoom = Entering.EnterInt32("Кількість кімнат", 1, 4);
                        bool privatePlot = Entering.StringToBool("Приватна ділянка ?");
                        Apartments.Add(MainFunctionals.AddApartment(addres, cost, countOfRoom, privatePlot));
                        break;
                    case 7:
                        MainFunctionals.ShowAllApartments(Apartments);
                        id = Entering.EnterInt32("\t Введіть номер об'єкт нерухомусті", 0, Apartments.Count - 1);
                        MainFunctionals.DeleteApartment(Apartments, Apartments[id]);
                        break;
                    case 8:
                        MainFunctionals.ShowAllApartments(Apartments);
                        id = Entering.EnterInt32("\t Введіть номер об'єкт нерухомусті", 0, Apartments.Count - 1);
                        Console.WriteLine("\tЗаповніть форму");
                        addres = Entering.EnterString("Адресса:", 2, 20);
                        cost = Entering.EnterInt32("Ціна", 100, 1000000);
                        countOfRoom = Entering.EnterInt32("Кількість кімнат", 1, 4);
                        privatePlot = Entering.StringToBool("Приватна дылянка ?");
                        MainFunctionals.ChangeApartment(Apartments[id], addres, cost, countOfRoom, privatePlot);
                        break;
                    case 9:
                        Console.WriteLine("\tВсі об'єкти нерухомості");
                        MainFunctionals.ShowAllApartments(Apartments);
                        break;
                    case 10:
                        Console.WriteLine("\tВсі пропозиції");
                        MainFunctionals.ShowAllOffers(Offers);
                        break;
                    case 11:
                        Console.WriteLine("\tЗаповніть форму");
                        name = Entering.EnterString("Введіть номер (назву) пропозиції", 8, 50);
                        MainFunctionals.ShowAllApartments(Apartments);
                        id = Entering.EnterInt32("\t Введіть номер об'єкт нерухомусті", 0, Apartments.Count - 1);
                        Offers.Add(MainFunctionals.AddOffer(name, Apartments[id]));
                        break;
                    case 12:
                        MainFunctionals.ShowAllOffers(Offers);
                        id = Entering.EnterInt32("\t Введіть номер пропозиції", 0, Offers.Count - 1);
                        MainFunctionals.DeleteOffer(Offers, Offers[id]);
                        break;
                    case 13:
                        var clients = Clients.OrderBy(e => e.Surname);
                        foreach(Client c in clients)
                        {
                            Console.WriteLine("Прізвище: " + c.Surname + " Ім'я: " + c.Name + " Картка: " + c.CardNamber);
                        }
                        break;
                    case 14:
                        clients = Clients.OrderBy(e => e.Name);
                        foreach (Client c in clients)
                        {
                            Console.WriteLine("Прізвище: " + c.Surname + " Ім'я: " + c.Name + " Картка: " + c.CardNamber);
                        }
                        break;
                    case 15:
                        clients = Clients.OrderBy(e => e.CardNamber);
                        foreach (Client c in clients)
                        {
                            Console.WriteLine("Прізвище: " + c.Surname + " Ім'я: " + c.Name + " Картка: " + c.CardNamber);
                        }
                        break;
                    case 16:
                        var apartments = Apartments.OrderBy(e => e.CountOfRoom);
                        foreach (Apartment a in apartments)
                        {
                            Console.WriteLine("Адреса: " + a.Addres + " Ціна: " + a.CostApartment + " Кількість кімнат: " + a.CountOfRoom + " Приватна ділянка: " + Entering.BoolToString(a.PrivatePlot));
                        }
                        break;
                    case 17:
                        apartments = Apartments.OrderBy(e => e.CostApartment);
                        foreach (Apartment a in apartments)
                        {
                            Console.WriteLine("Адреса: " + a.Addres + " Ціна: " + a.CostApartment + " Кількість кімнат: " + a.CountOfRoom + " Приватна ділянка: " + Entering.BoolToString(a.PrivatePlot));
                        }
                        break;
                    case 18:
                        apartments = Apartments.OrderBy(e => e.PrivatePlot);
                        foreach (Apartment a in apartments)
                        {
                            Console.WriteLine("Адреса: " + a.Addres + " Ціна: " + a.CostApartment + " Кількість кімнат: " + a.CountOfRoom + " Приватна ділянка: " + Entering.BoolToString(a.PrivatePlot));
                        }
                        break;
                    case 19:
                        string mainWord = Entering.EnterString("Введіть ім'я клієнта");
                        try
                        {
                            var FindClient = Clients.Find(x => x.Name.Contains(mainWord));
                            Console.WriteLine("Прізвище: {0}  Ім'я: {1} Картка: {2}", FindClient.Surname, FindClient.Name, FindClient.CardNamber);
                        }
                        catch
                        {
                            Console.WriteLine("Такого клієєнта немає");
                        }
                        break;
                    case 20:
                        mainWord = Entering.EnterString("Введіть прізвище клієнта");
                        try
                        {
                            var FindClient = Clients.Find(x => x.Surname.Contains(mainWord));
                            Console.WriteLine("Прізвище: {0}  Ім'я: {1} Картка: {2}", FindClient.Surname, FindClient.Name, FindClient.CardNamber);
                        }
                        catch
                        {
                            Console.WriteLine("Такого клієєнта немає");
                        }
                        break;
                    case 21:
                        mainWord = Entering.EnterString("Введіть номер картки клієнта");
                        try
                        {
                            var FindClient = Clients.Find(x => x.CardNamber.Contains(mainWord));
                            Console.WriteLine("Прізвище: {0}  Ім'я: {1} Картка: {2}", FindClient.Surname, FindClient.Name, FindClient.CardNamber);
                        }
                        catch
                        {
                            Console.WriteLine("Такого клієєнта немає");
                        }
                        break;
                    case 22:
                        mainWord = Entering.EnterString("Введіть адресу об'єкта нерухомості");
                        try
                        {
                            var FindApartment = Apartments.Find(x => x.Addres.Contains(mainWord));
                            Console.WriteLine("Адреса: {0}  Ціна: {1} Кількість кцімнат: {2} Приватна ділянка? {3}", FindApartment.Addres, FindApartment.CostApartment, FindApartment.CountOfRoom, Entering.BoolToString(FindApartment.PrivatePlot));
                        }
                        catch
                        {
                            Console.WriteLine("Такого об'єкта немає");
                        }
                        break;
        
                }
                XmlDataServices.SaveClients(Clients);
                XmlDataServices.SaveApartments(Apartments);
                XmlDataServices.SaveOffers(Offers);
                Console.WriteLine("\nДля продовження натисніть будь яку клавішу");
                Console.ReadLine();
            } 
        }
    }
}
