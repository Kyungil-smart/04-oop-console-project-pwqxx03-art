using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 플레이어 캐릭터 클래스
public class PlayerCharacter : GameObject
{
    public const int MaxHealth = 5;
    public ObservableProperty<int> Health = new ObservableProperty<int>(MaxHealth);
    public ObservableProperty<int> Mana = new ObservableProperty<int>(5);

    public Tile[,] Field { get; set; } // 현재 맵
    private Inventory _inventory;
    public bool IsActiveControl { get; private set; }  // 조작 가능 여부

    public PlayerCharacter() => Init();

    // 초기화
    public void Init()
    {
        IsActiveControl = true;
        _inventory = new Inventory(this);
    }

    // 매 프레임 키 입력 처리
    public void Update()
    {
        if (InputManager.GetKey(ConsoleKey.I)) HandleControl();

        if (InputManager.GetKey(ConsoleKey.UpArrow))
        {
            Move(Vector.Up);
            _inventory.SelectUp();
        }
        if (InputManager.GetKey(ConsoleKey.DownArrow))
        {
            Move(Vector.Down);
            _inventory.SelectDown();
        }
        if (InputManager.GetKey(ConsoleKey.LeftArrow)) Move(Vector.Left);
        if (InputManager.GetKey(ConsoleKey.RightArrow)) Move(Vector.Right);
        
        if (InputManager.GetKey(ConsoleKey.Enter)) _inventory.Select();

        if (InputManager.GetKey(ConsoleKey.T))
        {
            if (Health.Value > 0) Health.Value--;
        }
    }

    // 인벤토리 토글
    public void HandleControl()
    {
        _inventory.IsActive = !_inventory.IsActive;
        IsActiveControl = !_inventory.IsActive;
    }

    // 이동 처리
    private void Move(Vector direction)
    {
        if (Field == null || !IsActiveControl) return;

        Vector nextPos = Position + direction;

        // 맵 범위 체크
        if (nextPos.X < 0 || nextPos.X >= Field.GetLength(1)) return;
        if (nextPos.Y < 0 || nextPos.Y >= Field.GetLength(0)) return;

        GameObject target = Field[nextPos.Y, nextPos.X].OnTileObject;

        // 아이템 줍기
        if (target is Item) 
        {
            _inventory.Add(target as Item);
            Field[nextPos.Y, nextPos.X].OnTileObject = null;
        }
        
        // 위치 이동
        Field[Position.Y, Position.X].OnTileObject = null;
        Position = nextPos;
        Field[Position.Y, Position.X].OnTileObject = this;
    }

    // 화면에 그리기
    public override void Render()
    {
        DrawHUD();
        DrawCharacter();
        _inventory.Render();
    }

    // 체력바 그리기
    private void DrawHUD()
    {
        int hudX = 2;
        int hudY = 1;

        Console.SetCursorPosition(hudX, hudY);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("HP: ");

        Console.Write("[");
        for (int i = 0; i < MaxHealth; i++)
        {
            if (i < Health.Value)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("■");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("□");
            }
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($"] ({Health.Value}/{MaxHealth})   ");
    }

    // 캐릭터(이모지) 그리기
   private void DrawCharacter()
{
    string avatar = "X_X"; // 기본값 (사망 시 눈 X_X 느낌)
    
    double ratio = (double)Health.Value / MaxHealth;

    if (ratio > 0.7)      avatar = "(^0^)"; // 건강할 때 (웃는 눈)
    else if (ratio > 0.4) avatar = "(._.)"; // 보통일 때 (동그란 눈)
    else if (ratio > 0.0) avatar = "(>_<)"; // 아플 때 (찡그린 눈)
    
    // 좌표 설정 (기존 로직 유지)
    int screenX = Position.X * 2 + 2;
    int screenY = Position.Y + 3;
    
    Console.SetCursorPosition(screenX, screenY);
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write(avatar);
}

    // 아이템 추가
    public void AddItem(Item item)
    {
        _inventory.Add(item);
    }

    // 체력 회복
    public void Heal(int value)
    {
        Health.Value += value;
        if (Health.Value > MaxHealth) Health.Value = MaxHealth;
    }
}
