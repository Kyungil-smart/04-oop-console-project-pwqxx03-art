using System;
using System.Threading;

public class RandomBox : Item
{


public RandomBox()
    {
        Symbol = "★"; 
        Name = "의문의 상자";
    }

    public override void Use()
    {
         Console.Clear();
         Console.WriteLine("\n\n");
         Console.WriteLine("반짝이는 아이템상자를 여는증...");

          Random rand = new Random();
        int chance = 0; 
    }




    
}      
    
      