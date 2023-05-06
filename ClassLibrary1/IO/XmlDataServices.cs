using Core.Entities;
using Core.Functional;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ClassLibrary1.IO
{
    public static class XmlDataServices
    {
        public const string ClientPath = "Clients.xml";
        public const string ApartmentPath = "Apartments.xml";
        public const string OfferPath = "Offers.xml";

        public static void SaveClients(List<Client> clients)
        {
            using (var stream = new FileStream(ClientPath, FileMode.Create))
            {
                var XML = new XmlSerializer(typeof(List<Client>));
                XML.Serialize(stream, clients);
            }
        }

        public static void SaveApartments(List<Apartment> apartments)
        {
            using (var stream = new FileStream(ApartmentPath, FileMode.Create))
            {
                var XML = new XmlSerializer(typeof(List<Apartment>));
                XML.Serialize(stream, apartments);
            }
        }

        public static void SaveOffers(List<Offer> offers)
        {
            using (var stream = new FileStream(OfferPath, FileMode.Create))
            {
                var XML = new XmlSerializer(typeof(List<Offer>));
                XML.Serialize(stream, offers);
            }
        }

        public static List<Client> LoadClients(List<Client> clients)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Client>));
            using (var stream = new FileStream(ClientPath, FileMode.OpenOrCreate))
            {
                return clients = (List<Client>)xs.Deserialize(stream);
            }

            //Console.WriteLine("\n" + "Завантажений список: \n");
            //MainFunctionals.ShowAllClients(clients);
        }

        public static List<Apartment> LoadApartments(List<Apartment> apartments)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Apartment>));
            using (var stream = new FileStream(ApartmentPath, FileMode.OpenOrCreate))
            {
                return apartments = (List<Apartment>)xs.Deserialize(stream);
            }

            //Console.WriteLine("\n" + "Завантажений список: \n");
            //MainFunctionals.ShowAllApartments(apartments);
        }

        public static List<Offer> LoadOffers(List<Offer> offers)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Offer>));
            using (var stream = new FileStream(OfferPath, FileMode.OpenOrCreate))
            {
                return offers = (List<Offer>)xs.Deserialize(stream);
            }

            //Console.WriteLine("\n" + "Завантажений список: \n");
            //MainFunctionals.ShowAllOffers(offers);
        }
    }
}
