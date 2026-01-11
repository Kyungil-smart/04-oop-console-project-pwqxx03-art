using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TitleScene : Scene
{
    private MenuList _titleMenu;

    public TitleScene()
    {
        _titleMenu = new MenuList(
            ("게임 시작", StartGame),
            ("게임 정보", ShowCredit),
            ("종료", ExitGame)
        );
    }

    public override void Enter()
    {
    }

    public override void Exit()
    {
    }

    public override void Render()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Clear();

        int leftMargin = 2;
        int currentY = 2;

        string[] logoLines = {
            @"           _____ __      __ ______  _   _  _______  _    _  _____   ______ ",
            @"     /\   |  __ \\ \    / /|  ____|| \ | ||__   __|| |  | ||  __ \ |  ____|",
            @"    /  \  | |  | |\ \  / / | |__   |  \| |   | |   | |  | || |__) || |__   ",
            @"   / /\ \ | |  | | \ \/ /  |  __|  | . ` |   | |   | |  | ||  _  / |  __|  ",
            @"  / ____ \| |__| |  \  /   | |____ | |\  |   | |   | |__| || | \ \ | |____ ",
            @" /_/    \_\_____/    \/    |______||_| \_|   |_|    \____/ |_|  \_\|______|"
        };

        Console.ForegroundColor = ConsoleColor.Green;

        foreach (string line in logoLines)
        {
            Console.SetCursorPosition(leftMargin, currentY++);
            Console.WriteLine(line);
        }

        currentY += 2;

        Console.ForegroundColor = ConsoleColor.White;
        string subTitle = "은진이의 ADVENTURE"; 
        Console.SetCursorPosition(leftMargin, currentY++);
        Console.WriteLine(subTitle);

        currentY += 2;

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.SetCursorPosition(leftMargin, currentY++);
        Console.WriteLine("↑↓: 이동, Enter: 선택");
        
        currentY += 1;

        _titleMenu.Render(leftMargin, currentY);
    }

    public override void Update()
    {
        if (InputManager.GetKey(ConsoleKey.UpArrow))
        {
            _titleMenu.SelectUp();
        }
        else if (InputManager.GetKey(ConsoleKey.DownArrow))
        {
            _titleMenu.SelectDown();
        }
        else if (InputManager.GetKey(ConsoleKey.Enter))
        {
            _titleMenu.Select();
        }
    }

    private void StartGame()
    {
        SceneManager.Change("Story");
    }

    private void ShowCredit()
    {
    }

    private void ExitGame()
    {
        GameManager.IsGameOver = true;
    }
}
