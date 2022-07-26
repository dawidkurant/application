import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class CalculatorJava {

    private double total = 0.0;
    private double total2 = 0.0;
    private char math_operator;

    private JPanel CalculatorJava;
    private JTextField textDisplay;
    private JButton buttonDot;
    private JButton buttonFive;
    private JButton buttonEight;
    private JButton buttonTwo;
    private JButton buttonThree;
    private JButton buttonSix;
    private JButton buttonNine;
    private JButton buttonClear;
    private JButton buttonAdd;
    private JButton buttonDivide;
    private JButton buttonSub;
    private JButton buttonTimes;
    private JButton buttonEqual;
    private JButton buttonOne;
    private JButton buttonFour;
    private JButton buttonSeven;
    private JButton buttonZero;

    private void getOperator(String buttonText) {
        math_operator = buttonText.charAt(0);
        total = total + Double.parseDouble(textDisplay.getText());
        textDisplay.setText("");
    }

    public CalculatorJava() {
        buttonOne.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String buttonOneText = textDisplay.getText() + buttonOne.getText();
                textDisplay.setText(buttonOneText);
            }
        });
        buttonTwo.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String buttonTwoText = textDisplay.getText() + buttonTwo.getText();
                textDisplay.setText(buttonTwoText);
            }
        });

        buttonThree.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String buttonThreeText = textDisplay.getText() + buttonThree.getText();
                textDisplay.setText(buttonThreeText);
            }
        });
        buttonFour.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String buttonFourText = textDisplay.getText() + buttonFour.getText();
                textDisplay.setText(buttonFourText);
            }
        });
        buttonFive.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String buttonFiveText = textDisplay.getText() + buttonFive.getText();
                textDisplay.setText(buttonFiveText);
            }
        });
        buttonSix.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String buttonSixText = textDisplay.getText() + buttonSix.getText();
                textDisplay.setText(buttonSixText);
            }
        });
        buttonSeven.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String buttonSevenText = textDisplay.getText() + buttonSeven.getText();
                textDisplay.setText(buttonSevenText);
            }
        });
        buttonEight.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String buttonEightText = textDisplay.getText() + buttonEight.getText();
                textDisplay.setText(buttonEightText);
            }
        });
        buttonNine.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String buttonNineText = textDisplay.getText() + buttonNine.getText();
                textDisplay.setText(buttonNineText);
            }
        });
        buttonZero.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String buttonZeroText = textDisplay.getText() + buttonZero.getText();
                textDisplay.setText(buttonZeroText);
            }
        });
        buttonDot.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                if(textDisplay.getText().equals("")) {
                    textDisplay.setText("0.");
                }
                else if(textDisplay.getText().contains(".")){
                    buttonDot.setEnabled(false);
                } else {
                    String buttonDotText = textDisplay.getText() + buttonDot.getText();
                    textDisplay.setText(buttonDotText);
                }
                buttonDot.setEnabled(true);
            }
        });
        buttonClear.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                total2 = 0;
                textDisplay.setText("");
            }
        });
        buttonAdd.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String buttonAddText = buttonAdd.getText();
                getOperator(buttonAddText);
            }
        });
        buttonSub.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String buttonSubText = buttonSub.getText();
                getOperator(buttonSubText);
            }
        });
        buttonDivide.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String buttonDivideText = buttonDivide.getText();
                getOperator(buttonDivideText);
            }
        });
        buttonTimes.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String buttonMultiplyText = buttonTimes.getText();
                getOperator(buttonMultiplyText);
            }
        });
        buttonEqual.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                switch (math_operator) {
                    case '+':
                        total2 = total + Double.parseDouble(textDisplay.getText());
                        break;
                    case '-':
                        total2 = total - Double.parseDouble(textDisplay.getText());
                        break;
                    case '/':
                        total2 = total / Double.parseDouble(textDisplay.getText());
                        break;
                    case '*':
                        total2 = total * Double.parseDouble(textDisplay.getText());
                        break;
                }

                textDisplay.setText(Double.toString(total2));
                total = 0;
            }
        });
    }

    public static void main(String[] args) {
        JFrame frame = new JFrame("CalculatorJava");
        frame.setContentPane(new CalculatorJava().CalculatorJava);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.pack();
        frame.setVisible(true);
    }
}
