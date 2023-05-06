using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Functional
{
    public static class MainFunctionals
    {
        public static Client AddClient(string surname, string name, string cardNamber)
        {
            return new Client() { Surname = surname, Name = name, CardNamber = cardNamber };
        }
        public static void DeleteClient(List<Client> clients, Client client)
        {
            clients.Remove(client);
        }
        public static void ShowAllClients(List<Client> clients)
        {
            for(int i = 0; i < clients.Count(); i++)
            {
                Console.WriteLine(i + " Прізвище: " + clients[i].Surname + " Ім'я: " + clients[i].Name + " Картка: " + clients[i].CardNamber);
            }
        }
        public static Apartment AddApartment(string addres, int costApartment, int countOfRoom, bool privatePlot)
        {
            return new Apartment() { Addres = addres, CostApartment = costApartment, CountOfRoom = countOfRoom, PrivatePlot = privatePlot };
        }
        public static void DeleteApartment(List<Apartment> apartments, Apartment apartment)
        {
            apartments.Remove(apartment);
        }
        public static void ShowAllApartments(List<Apartment> apartments)
        {
            for (int i = 0; i < apartments.Count(); i++)
            {
                Console.WriteLine(i + " Адреса: " + apartments[i].Addres + " Ціна: " + apartments[i].CostApartment + " Кількість кімнат: " + apartments[i].CountOfRoom + " Приватна ділянка: " + Entering.BoolToString(apartments[i].PrivatePlot));
            }
        }
        public static Offer AddOffer(string name, Apartment apartment)
        {
            return new Offer() { OfferName = name, Apartment = apartment };
        }

        public static void DeleteOffer(List<Offer> offers, Offer offer)
        {
            offers.Remove(offer);
        }
        public static void ShowAllOffers(List<Offer> offers)
        {
            for (int i = 0; i < offers.Count(); i++)
            {
                Console.WriteLine("Номер пропозиції: " + offers[i].OfferName);
                Console.WriteLine(i + " Адресса: " + offers[i].Apartment.Addres + " Ціна: " + offers[i].Apartment.CostApartment + " Кількість кімнат: " + offers[i].Apartment.CountOfRoom + " Приватна ділянка: " + 
                    Entering.BoolToString(offers[i].Apartment.PrivatePlot));
            }
        }

        public static void ChangeClient(Client client, string surname, string name, string cardNamber)
        {
            client.Surname = surname;
            client.Name = name;
            client.CardNamber = cardNamber;
        }
        public static void ChangeApartment(Apartment apartment, string addres, int costApartment, int countOfRoom, bool privatePlot)
        {
            apartment.Addres = addres;
            apartment.CostApartment = costApartment;
            apartment.CountOfRoom = countOfRoom;
            apartment.PrivatePlot = privatePlot;
        }
    }
}
