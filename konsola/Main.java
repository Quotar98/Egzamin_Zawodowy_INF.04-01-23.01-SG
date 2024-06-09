import java.util.Scanner;

public class Main {
    /**
     * nazwa funkcji: nwd
     * opis funkcji: Funkcja oblicza największy wspólny dzielnik (NWD) dwóch dodatnich liczb całkowitych za pomocą algorytmu Euklidesa
     * parametry: a - pierwsza dodatnia liczba całkowita, której NWD ma zostać obliczony
     *            b - druga dodatnia liczba całkowita, której NWD ma zostać obliczony
     * zwracany typ i opis: int - największy wspólny dzielnik (NWD) dwóch podanych liczb całkowitych
     * autor: 000000000000
     * **/
    public static int nwd (int a, int b){
        while (a != b){
            if(a>b){
                a = a-b;
            }
            else{
                b= b - a;
            }
        }
        return a;
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int a, b;
        do {
            System.out.println("Wprowadź pierwszą dodatnią liczbę całkowitą: ");
            while (!scanner.hasNextInt()){
                System.out.println("To nie jest prawidłowa liczba!");
                scanner.next();
            }
            a = scanner.nextInt();
        }
        while (a <= 0);

        do {
            System.out.println("Wprowadź drugą dodatnią liczbę całkowitą: ");
            while (!scanner.hasNextInt()){
                System.out.println("To nie jest prawidłowa liczba!");
                scanner.next();
            }
            b = scanner.nextInt();
        }
        while (b <= 0);

        scanner.close();

        int wynikNwd = nwd(a, b);

        System.out.println("Największy wspólny dzielnik liczb " + a + " i " + b + " to: " + wynikNwd);
    }
}