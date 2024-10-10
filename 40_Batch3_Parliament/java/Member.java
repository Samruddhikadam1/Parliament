//Author:Samruddhi Kadam
//RollNo:2441
//Title:Parliament of India
//Start Date:9 July 2024
//Modified Date:23 July 2024
//Description:This program is implementing the working of parliament of India. It contains various classes to add members to Rajya Sabha and Lok Sabha.

package workspace;
public class Member {
    String name;
    String house;

    public Member(String name, String house) {
        this.name = name;
        this.house = house;
    }

    public void updateDetails(String name, String house) {
        this.name = name;
        this.house = house;
    }
}