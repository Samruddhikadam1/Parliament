//Author:Samruddhi Kadam
//RollNo:2441
//Title:Parliament of India
//Start Date:9 July 2024
//Modified Date:23 July 2024
//Description:This program is implementing the working of parliament of India. It contains various classes to add members to Rajya Sabha and Lok Sabha.

package workspace;
import java.util.Scanner;

public class Parliamentmenu {
    private Parliament parliament = new Parliament();
    private Scanner scanner = new Scanner(System.in);

    public void displayMenu() {
        int choice;

        do {
            System.out.println("Indian Parliament Information System");
            System.out.println("1. Display Lok Sabha Details");
            System.out.println("2. Display Rajya Sabha Details");
            System.out.println("3. Add Member");
            System.out.println("4. List Members");
            System.out.println("5. Update Member Details");
            System.out.println("6. Delete Member");
            System.out.println("7. Exit");

            System.out.print("Enter your choice: \n");
            choice = scanner.nextInt();
            scanner.nextLine();

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
                    System.out.println("Exiting...");
                    break;
                default:
                    System.out.println("Invalid choice. Try again.");
            }
        } while (choice != 7);

        scanner.close();
    }

    private void addMember() {
        System.out.print("Enter the member name: \n");
        String name = scanner.nextLine();
        System.out.print("Enter the house (Rajya Sabha / Lok Sabha): \n");
        String house = scanner.nextLine();
        if(house.equals("Loksabha") ||house.equals("Rajyasabha")){
            parliament.addMember(name, house);
        } else {
            System.out.println("Entered the wrong House name\n");
        }
    }
    private void updateMember() {
        System.out.print("Enter the name of the member to update: ");
        String name = scanner.nextLine();
        System.out.print("Enter the new name: ");
        String newName = scanner.nextLine();
        System.out.print("Enter the house (Lok Sabha / Rajya Sabha): ");
        String newHouse = scanner.nextLine();
        parliament.updateMember(name, newName, newHouse);
    }

    private void deleteMember() {
        System.out.print("Enter the name of the member to delete: ");
        String name = scanner.nextLine();
        parliament.deleteMember(name);
    }

    public static void main(String[] args) {
        Parliamentmenu menu = new Parliamentmenu();
        menu.displayMenu();
    }
}