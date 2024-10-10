//Author:Samruddhi Kadam
//RollNo:2441
//Title:Parliament of India
//Start Date:25 July 2024
//Modified Date:27 July 2024
//Description:This program is implementing the working of parliament of India. It contains various classes to add members to Rajya Sabha and Lok Sabha.

#include <iostream>
#include <vector>
#include <string>
#include <algorithm>

using namespace std;

// Member class definition
class Member {
private:
    string name;
    string house;

public:
    Member(const string& name, const string& house) : name(name), house(house) {}

    string getName() const {
        return name;
    }

    string getHouse() const {
        return house;
    }

    void updateDetails(const string& name, const string& house) {
        this->name = name;
        this->house = house;
    }

    string toString() const {
        return "Name: " + name + " | House: " + house;
    }
};

// Parliament class definition
class Parliament {
private:
    vector<Member> members;

    Member* findMember(const string& name) {
        for (auto& member : members) {
            if (member.getName() == name) {
                return &member;
            }
        }
        return nullptr;
    }

public:
    void addMember(const string& name, const string& house) {
        if (house == "Loksabha" || house == "Rajyasabha") {
            members.emplace_back(name, house);
            cout << "Member added successfully.\n";
        } else {
            cout << "Invalid house name. Please enter 'Loksabha' or 'Rajyasabha'.\n";
        }
    }

    void listMembers() const {
        if (members.empty()) {
            cout << "No members are added.\n";
        } else {
            cout << "List of Members:\n";
            for (const auto& member : members) {
                cout << member.toString() << "\n";
            }
        }
    }

    void updateMember(const string& name, const string& newName, const string& newHouse) {
        Member* member = findMember(name);
        if (member) {
            member->updateDetails(newName, newHouse);
            cout << "Member details updated successfully.\n";
        } else {
            cout << "Member not found.\n";
        }
    }

    void deleteMember(const string& name) {
        auto it = remove_if(members.begin(), members.end(),
                            [&name](const Member& member) { return member.getName() == name; });
        if (it != members.end()) {
            members.erase(it, members.end());
            cout << "Member deleted successfully.\n";
        } else {
            cout << "Member not found.\n";
        }
    }

    void displayLokSabhaDetails() const {
        cout << "Lok Sabha: House of the People\n";
        cout << "Total members: 543\n";
        cout << "Term: 5 years\n";
        cout << "Presiding Officer: Speaker\n";
    }

    void displayRajyaSabhaDetails() const {
        cout << "Rajya Sabha: Council of States\n";
        cout << "Total members: 250\n";
        cout << "Term: 6 years\n";
        cout << "Presiding Officer: Vice President\n";
    }
};

// ParliamentMenu class definition
class ParliamentMenu {
private:
    Parliament parliament;

    void addMember() {
        string name, house;
        cout << "Enter the member name: ";
        getline(cin, name);
        cout << "Enter the house (Rajya Sabha / Lok Sabha): ";
        getline(cin, house);
        parliament.addMember(name, house);
    }

    void updateMember() {
        string name, newName, newHouse;
        cout << "Enter the name of the member to update: ";
        getline(cin, name);
        cout << "Enter the new name: ";
        getline(cin, newName);
        cout << "Enter the new house (Lok Sabha / Rajya Sabha): ";
        getline(cin, newHouse);
        parliament.updateMember(name, newName, newHouse);
    }

    void deleteMember() {
        string name;
        cout << "Enter the name of the member to delete: ";
        getline(cin, name);
        parliament.deleteMember(name);
    }

public:
    void displayMenu() {
        int choice;

        do {
            cout << "Indian Parliament Information System\n";
            cout << "1. Display Lok Sabha Details\n";
            cout << "2. Display Rajya Sabha Details\n";
            cout << "3. Add Member\n";
            cout << "4. List Members\n";
            cout << "5. Update Member Details\n";
            cout << "6. Delete Member\n";
            cout << "7. Exit\n";

            cout << "Enter your choice: ";
            cin >> choice;
            cin.ignore(); // Consume newline

            switch (choice) {
                case 1:
                    parliament.displayLokSabhaDetails();
                    break;
                case 2:
                    parliament.displayRajyaSabhaDetails();
                    break;
                case 3:
                    addMember();
                    break;
                case 4:
                    parliament.listMembers();
                    break;
                case 5:
                    updateMember();
                    break;
                case 6:
                    deleteMember();
                    break;
                case 7:
                    cout << "Exiting...\n";
                    break;
                default:
                    cout << "Invalid choice. Try again.\n";
            }
        } while (choice != 7);
    }
};

// Main function
int main() {
    ParliamentMenu menu;
    menu.displayMenu();
    return 0;
}
