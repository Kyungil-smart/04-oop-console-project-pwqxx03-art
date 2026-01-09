using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



// 아이템 기본 클래스
public class Item : GameObject
{
    public string Name { get; set; }           // 아이템 이름
    public PlayerCharacter Owner { get; set; }  // 소유자
    public Inventory Inventory { get; set; }    // 소속 인벤토리

    public Item()
    {
        Symbol = "I";
    }

    // 아이템 사용 (자식 클래스에서 override)
    public virtual void Use()
    {
    }
    
}



