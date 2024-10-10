//Author:Samruddhi Kadam
//RollNo:2441
//Title:Parliament of India
//Start Date:24 July 2024
//Modified Date:26 July 2024
//Description:This program is implementing the working of parliament of India. It contains various classes to add members to Rajya Sabha and Lok Sabha.

using System;
using System.Collections.Generic;
using System.Linq;

namespace ParliamentSystem
{
    // Member class definition
    class Member
    {
        public string Name { get; private set; }
        public string House { get; private set; }

        public Member(string name, string house)
        {
            Name = name;
            House = house;
        }

        public void UpdateDetails(string name, string house)
        {
            Name = name;
            House = house;
        }

        public override string ToString()
        {
            return $"Name: {Name} | House: {House}";
        }
    }

    // Parliament class definition
    class Parliament
    {
        private List<Member> members = new List<Member>();

        public void AddMember(string name, string house)
        {
            if (house == "Lok Sabha" || house == "Rajya Sabha")
            {
                members.Add(new Member(name, house));
                Console.WriteLine("Member added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid house name. Please enter 'Lok Sabha' or 'Rajya Sabha'.");
            }
        }

        public void ListMembers()
        {
            if (members.Count == 0)
            {
                Console.WriteLine("No members are added.");
            }
            else
            {
                Console.WriteLine("List of Members:");
                foreach (var member in members)
                {
                    Console.WriteLine(member);
                }
            }
        }

        public void UpdateMember(string name, string newName, string newHouse)
        {
            var member = members.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (member != null)
            {
                member.UpdateDetails(newName, newHouse);
                Console.WriteLine("Member details updated successfully.");
            }
            else
            {
                Console.WriteLine("Member not found.");
            }
        }

        public void DeleteMember(string name)
        {
            var member = members.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (member != null)
            {
                members.Remove(member);
                Console.WriteLine("Member deleted successfully.");
            }
            else
            {
                Console.WriteLine("Member not found.");
            }
        }

        public void DisplayLokSabhaDetails()
        {
            Console.WriteLine("Lok Sabha: House of the People");
            Console.WriteLine("Total members: 543");
            Console.WriteLine("Term: 5 years");
            Console.WriteLine("Presiding Officer: Speaker");
        }

        public void DisplayRajyaSabhaDetails()
        {
            Console.WriteLine("Rajya Sabha: Council of States");
            Console.WriteLine("Total members: 250");
            Console.WriteLine("Term: 6 years");
            Console.WriteLine("Presiding Officer: Vice President");
        }
    }

    // ParliamentMenu class definition
    class ParliamentMenu
    {
        private Parliament parliament = new Parliament();

        public void DisplayMenu()
        {
            int choice;

            do
            {
                Console.WriteLine("Indian Parliament Information System");
                Console.WriteLine("1. Display Lok Sabha Details");
                Console.WriteLine("2. Display Rajya Sabha Details");
                Console.WriteLine("3. Add Member");
                Console.WriteLine("4. List Members");
                Console.WriteLine("5. Update Member Details");
                Console.WriteLine("6. Delete Member");
                Console.WriteLine("7. Exit");

                Console.Write("Enter your choice: ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice. Try again.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        parliament.DisplayLokSabhaDetails();
                        break;
                    case 2:
                        parliament.DisplayRajyaSabhaDetails();
                        break;
                    case 3:
                        AddMember();
                        break;
                    case 4:
                        parliament.ListMembers();
                        break;
                    case 5:
                        UpdateMember();
                        break;
                    case 6:
                        DeleteMember();
                        break;
                    case 7:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            } while (choice != 7);
        }

        private void AddMember()
        {
            Console.Write("Enter the member name: ");
            string name = Console.ReadLine();
            Console.Write("Enter the house (Rajya Sabha / Lok Sabha): ");
            string house = Console.ReadLine();
            parliament.AddMember(name, house);
        }

        private void UpdateMember()
        {
            Console.Write("Enter the name of the member to update: ");
            string name = Console.ReadLine();
            Console.Write("Enter the new name: ");
            string newName = Console.ReadLine();
            Console.Write("Enter the new house (Lok Sabha / Rajya Sabha): ");
            string newHouse = Console.ReadLine();
            parliament.UpdateMember(name, newName, newHouse);
        }

        private void DeleteMember()
        {
            Console.Write("Enter the name of the member to delete: ");
            string name = Console.ReadLine();
            parliament.DeleteMember(name);
        }
    }

    // Main method
    class Program
    {
        static void Main(string[] args)
        {
            ParliamentMenu menu = new ParliamentMenu();
            menu.DisplayMenu();
        }
    }
}
