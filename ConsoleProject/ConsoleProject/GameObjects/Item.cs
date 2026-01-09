using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




public class Item : GameObject
{
    public string Name { get; set; }           
    public PlayerCharacter Owner { get; set; }  
    public Inventory Inventory { get; set; }    

    public Item()
    {
        Symbol = "I";
    }

    
    public virtual void Use()
    {
    }

}



