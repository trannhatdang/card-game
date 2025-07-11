using System;
public class Suit
{
    private int number = -1;
    public Suit(int num = -1)
    {
        number = num;
    }

    public String GetSuit()
    {
        if(number < 0 || number > 53)
        {
            return "";
        }

        String ans = "";
        if(number / 13 == 0)
        {
            ans += "S";
        }
        else if(number / 13 == 1)
        {
            ans += "C";
        }
        else if(number / 13 == 2)
        {
            ans += "D";
        }
        else 
        {
            ans += "H";
        }

        ans += number % 13;

        return ans;
    }
}