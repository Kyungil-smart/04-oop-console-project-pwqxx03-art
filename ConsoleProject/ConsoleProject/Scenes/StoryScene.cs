using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StoryScene : Scene
{
    public override void Enter()
    {
    }

    public override void Update()
    {
        if (InputManager.GetKey(ConsoleKey.Enter))
        {
            SceneManager.Change("Town");
        }
    }

    public override void Exit()
    {
    }
    public override void Render()
    {
        int x = 2;
        int y = 2;

        Console.Clear();
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(x, y++);
        Console.WriteLine("--------------------------------");
        Console.SetCursorPosition(x, y++);
        Console.WriteLine("프롤로그: 가족을 위하여");
        Console.SetCursorPosition(x, y++);
        Console.WriteLine("--------------------------------");
        
        y++;

        Console.SetCursorPosition(x, y++);
        Console.WriteLine("어느 날 동생이 갑자기 쓰러졌다.");
        
        y++;

        Console.SetCursorPosition(x, y++);
        Console.WriteLine("의사 선생님이 말씀하셨다.");
        
        Console.SetCursorPosition(x, y++);
        Console.WriteLine("\"이 병을 고칠 방법은 딱 하나뿐이네...\"");

        y++;

        Console.SetCursorPosition(x, y++);
        Console.Write("그것은 전설의 ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("[대왕벌의 침]");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("이다.");

}
