package practicecode;

public class User {
    int idNo;
    String firstName;
    String middleName;
    String lastName;
    String course;

    public User(int idNo, String firstName, String middleName, String lastName, String course) {
        this.idNo = idNo;
        this.firstName = firstName;
        this.middleName = middleName;
        this.lastName = lastName;
        this.course = course;
    }
}