import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.Scanner;

public class Note extends JFrame {

    private JTextField nazwaPliku;
    private JTextArea poleTekstu;
    private JButton zapisz, wczytaj;

    public Note() {

        nazwaPliku = new JTextField();
        poleTekstu = new JTextArea();

        JPanel panelPrzyciskow = new JPanel();

        zapisz = new JButton("Zapisz");
        wczytaj = new JButton("Wczytaj");

        NoteButtonListener buttonListener = new NoteButtonListener();

        zapisz.addActionListener(buttonListener);
        wczytaj.addActionListener(buttonListener);

        panelPrzyciskow.add(zapisz);
        panelPrzyciskow.add(wczytaj);


        this.setLayout(new BorderLayout());

        add(nazwaPliku, BorderLayout.NORTH);
        add(poleTekstu, BorderLayout.CENTER);
        add(panelPrzyciskow, BorderLayout.SOUTH);

        setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);

        setPreferredSize(new Dimension(500, 500));
        pack();
        setVisible(true);
    }

    private String pobierzNazwePliku() {
        return nazwaPliku.getText();
    }

    private void czytajPlik(String fileName) {
        Scanner wPliku = null;

        try {
            wPliku = new Scanner(new FileReader(fileName));

            poleTekstu.setText("");

            while (wPliku.hasNextLine()) {
                poleTekstu.append(wPliku.nextLine());
            }

        } catch (IOException ioe) {
            ioe.printStackTrace();
            System.out.println("Nie znaleziono pliku!");
        } finally {
            if (wPliku != null) {
                wPliku.close();
            }
        }
    }

    private void writeFile(String nazwaPliku) {
        PrintWriter outFile = null;

        try {
            outFile = new PrintWriter(new FileWriter(nazwaPliku));

            outFile.print(poleTekstu.getText());

        } catch (IOException ioe) {
            ioe.printStackTrace();
            System.out.println("Nie znaleziono pliku!");
        } finally {
            if (outFile != null) {
                outFile.close();
            }
        }
    }

    class NoteButtonListener implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            JButton sourceButton = (JButton) e.getSource();
            if (sourceButton.equals(wczytaj)) {
                czytajPlik(pobierzNazwePliku());
            } else if (sourceButton.equals(zapisz)) {
                writeFile(pobierzNazwePliku());
            }
        }
    }

    public static void main(String[] args) {
        new Note();
    }
}