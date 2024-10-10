#Author:Samruddhi Kadam
#RollNo:2441
#Title:Parliament of India
#Start Date:25 July 2024
#Modified Date:27 July 2024
#Description:This program is implementing the working of parliament of India. It contains various classes to add members to Rajya Sabha and Lok Sabha.

class Member:
    def __init__(self, name, house):
        self.name = name
        self.house = house

    def update_details(self, name, house):
        self.name = name
        self.house = house

    def __str__(self):
        return f"Name: {self.name} | House: {self.house}"


class Parliament:
    def __init__(self):
        self.members = []

    def add_member(self, name, house):
        if house in ["Loksabha", "Rajyasabha"]:
            self.members.append(Member(name, house))
            print("Member added successfully.")
        else:
            print("Invalid house name. Please enter 'Loksabha' or 'Rajyasabha'.")

    def list_members(self):
        if not self.members:
            print("No members are added.")
        else:
            print("List of Members:")
            for member in self.members:
                print(member)

    def update_member(self, name, new_name, new_house):
        member = self.find_member(name)
        if member:
            member.update_details(new_name, new_house)
            print("Member details updated successfully.")
        else:
            print("Member not found.")

    def delete_member(self, name):
        member = self.find_member(name)
        if member:
            self.members.remove(member)
            print("Member deleted successfully.")
        else:
            print("Member not found.")

    def find_member(self, name):
        for member in self.members:
            if member.name.lower() == name.lower():
                return member
        return None

    def display_lok_sabha_details(self):
        print("Lok Sabha: House of the People")
        print("Total members: 543")
        print("Term: 5 years")
        print("Presiding Officer: Speaker\n")

    def display_rajya_sabha_details(self):
        print("Rajya Sabha: Council of States")
        print("Total members: 250")
        print("Term: 6 years")
        print("Presiding Officer: Vice President\n")


class ParliamentMenu:
    def __init__(self):
        self.parliament = Parliament()

    def display_menu(self):
        choice = 0

        while choice != 7:
            print("\nIndian Parliament Information System")
            print("1. Display Lok Sabha Details")
            print("2. Display Rajya Sabha Details")
            print("3. Add Member")
            print("4. List Members")
            print("5. Update Member Details")
            print("6. Delete Member")
            print("7. Exit")
                
            choice = int(input("Enter your choice: \n"))

            if choice == 1:
                self.parliament.display_lok_sabha_details()
            elif choice == 2:
                self.parliament.display_rajya_sabha_details()
            elif choice == 3:
                self.add_member()
            elif choice == 4:
                self.parliament.list_members()
            elif choice == 5:
                self.update_member()
            elif choice == 6:
                self.delete_member()
            elif choice == 7:
                print("Exiting...")
            else:
                print("Invalid choice. Try again.")

    def add_member(self):
        name = input("Enter the member name: ")
        house = input("Enter the house (Rajya Sabha / Lok Sabha): ")
        self.parliament.add_member(name, house)

    def update_member(self):
        name = input("Enter the name of the member to update: ")
        new_name = input("Enter the new name: ")
        new_house = input("Enter the new house (Lok Sabha / Rajya Sabha): ")
        self.parliament.update_member(name, new_name, new_house)

    def delete_member(self):
        name = input("Enter the name of the member to delete: ")
        self.parliament.delete_member(name)


if __name__ == "__main__":
    menu = ParliamentMenu()
    menu.display_menu()
