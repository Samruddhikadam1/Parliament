//Author:Samruddhi Kadam
//RollNo:2441
//Title:Parliament of India
//Start Date:9 July 2024
//Modified Date:23 July 2024
//Description:This program is implementing the working of parliament of India. It contains various classes to add members to Rajya Sabha and Lok Sabha.
package workspace;
import java.util.ArrayList;

public class Parliament {
    private ArrayList<Member> members = new ArrayList<>();

    public void addMember(String name, String house) {
        members.add(new Member(name, house));
        System.out.println("Member added successfully.\n");
    }

    public void listMembers() {
        if (members.isEmpty()) {
            System.out.println("No members are added ;)");
        } else {
            System.out.println("List of Members:");
            for (Member member : members) {
                System.out.println("Name: " + member.name + " | House: " + member.house);
            }
        }
    }

    public void updateMember(String name, String newName, String newHouse) {
        Member member = findMember(name);
        if (member != null) {
            member.updateDetails(newName, newHouse);
            System.out.println("Member details updated successfully.");
        } else {
            System.out.println("Member not found.");
        }
    }

    public void deleteMember(String name) {
        Member member = findMember(name);
        if (member != null) {
            members.remove(member);
            System.out.println("Member deleted successfully.");
        } else {
            System.out.println("Member not found.");
        }
    }

    private Member findMember(String name) {
        for (Member member : members) {
            if (member.name.equalsIgnoreCase(name)) {
                return member;
            }
        }
        return null;
    }

    public void displayLokSabhaDetails() {
        System.out.println("Lok Sabha: House of the People");
        System.out.println("Total members: 543");
        System.out.println("Term: 5 years");
        System.out.println("Presiding Officer: Speaker\n");
    }

    public void displayRajyaSabhaDetails() {
        System.out.println("Rajya Sabha: Council of States");
        System.out.println("Total members: 250");
        System.out.println("Term: 6 years");
        System.out.println("Presiding Officer: Vice President\n");
    }
}