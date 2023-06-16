using System;
using System.Collections.Generic;

namespace VenueManagementSystem
{
    class Venue
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Info { get; set; }

        public Venue(string name, string address, string info)
        {
            Name = name;
            Address = address;
            Info = info;
        }
    }

    class Program
    {
        static List<Venue> venues = new List<Venue>();

        static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("==== Venue Management System ====");
                Console.WriteLine("1. Add Venue");
                Console.WriteLine("2. View Venues");
                Console.WriteLine("3. Search Venue");
                Console.WriteLine("4. Update Venue");
                Console.WriteLine("5. Delete Venue");
                Console.WriteLine("6. Exit");
                Console.WriteLine("===================================");

                Console.Write("Enter your choice: ");
                string choiceInput = Console.ReadLine();
                Console.WriteLine();

                if (string.IsNullOrWhiteSpace(choiceInput))
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
                }

                if (!int.TryParse(choiceInput, out int choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a valid number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddVenue();
                        break;
                    case 2:
                        ViewVenues();
                        break;
                    case 3:
                        SearchVenue();
                        break;
                    case 4:
                        UpdateVenue();
                        break;
                    case 5:
                        DeleteVenue();
                        break;
                    case 6:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
				
			}
			
		}

        static void AddVenue()
        {
            Console.WriteLine("==== Add Venue ====");
            Console.Write("Enter venue name: ");
            string name = Console.ReadLine();
            Console.Write("Enter venue address: ");
            string address = Console.ReadLine();
            Console.Write("Enter venue info: ");
            string info = Console.ReadLine();

            Venue venue = new Venue(name, address, info);
            venues.Add(venue);

            Console.WriteLine("Venue added successfully.");
        }

        static void ViewVenues()
        {
            Console.WriteLine("==== View Venues ====");
            if (venues.Count == 0)
            {
                Console.WriteLine("No venues found.");
            }
            else
            {
                foreach (var venue in venues)
                {
                    Console.WriteLine($"Name: {venue.Name}, Address: {venue.Address}, Info: {venue.Info}");
                }
            }
        }

        static void SearchVenue()
        {
            Console.WriteLine("==== Search Venue ====");
            Console.Write("Enter venue name: ");
            string searchQuery = Console.ReadLine();

            Venue venue = venues.Find(s => s.Name.Equals(searchQuery));
            if (venue == null)
            {
                Console.WriteLine("Venue not found.");
            }
            else
            {
                Console.WriteLine($"Name: {venue.Name}, Address: {venue.Address}, Info: {venue.Info}");
            }
        }

        static void UpdateVenue()
        {
            Console.WriteLine("==== Update Venue ====");
            Console.Write("Enter venue name: ");
            string searchQuery = Console.ReadLine();

            Venue venue = venues.Find(s => s.Name.Equals(searchQuery));
            if (venue == null)
            {
                Console.WriteLine("Venue not found.");
            }
            else
            {
                Console.WriteLine($"Current Name: {venue.Name}, Address: {venue.Address}, Info: {venue.Info}");
                Console.WriteLine("Enter new details:");

                Console.Write("Enter new name: ");
                string newName = Console.ReadLine();
                Console.Write("Enter new address: ");
                string newAddress = Console.ReadLine();
                Console.Write("Enter new info: ");
                string newInfo = Console.ReadLine();

                venue.Name = newName;
                venue.Address = newAddress;
                venue.Info = newInfo;

                Console.WriteLine("Venue details updated successfully.");
            }
        }

        static void DeleteVenue()
        {
            Console.WriteLine("==== Delete Venue ====");
            Console.Write("Enter venue name: ");
            string searchQuery = Console.ReadLine();

            Venue venue = venues.Find(s => s.Name.Equals(searchQuery));
            if (venue == null)
            {
                Console.WriteLine("Venue not found.");
            }
            else
            {
                venues.Remove(venue);
                Console.WriteLine("Venue deleted successfully.");
            }
        }
	}
}
