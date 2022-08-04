namespace IW4M_ChatGames.Games;

public class QuickMaths
{
    public string Init()
    {
        var rnd = new Random();
        var game = (MathOperator) rnd.Next(0, 4);
        var num1 = rnd.Next(1, 100);
        var num2 = rnd.Next(1, 100);
        var mathOperator = string.Empty;
        var answer = 0;
        
        switch (game)
        {
            case MathOperator.Division:
                answer = num1 / num2;
                mathOperator = "divide";
                break;
            case MathOperator.Multiplication:
                answer = num1 * num2;
                mathOperator = "multiply";
                break;
            case MathOperator.Addition:
                answer = num1 + num2;
                mathOperator = "add";
                break;
            case MathOperator.Subtraction:
                answer = num1 - num2;
                mathOperator = "subtract";
                break;
            case MathOperator.Modulo:
                answer = num1 % num2;
                mathOperator = "modulo";
                break;
        }
        
        Plugin.GameManager.MessageAllServers($"(Color::Yellow)Quick Maffs: (Color::Accent){num1} {mathOperator} {num2}");

        return answer.ToString();
    }
}

public enum MathOperator
{
    Division,
    Multiplication,
    Addition,
    Subtraction,
    Modulo
} 
