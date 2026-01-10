using System;

public class Potion : Item, IInteractable
{
    public Potion()
    {
        Symbol = "♥";
        Name = "회복 물약";
    }

    public void Interact(PlayerCharacter player)
    {
        player.AddItem(this);
    }

    public override void Use()
    {
        if (Owner != null && Owner.Health.Value < PlayerCharacter.MaxHealth)
        {
            Owner.Heal(1);
            if (Inventory != null) Inventory.Remove(this);
        }
    }
}
