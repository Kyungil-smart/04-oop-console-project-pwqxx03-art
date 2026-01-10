using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 게임 전체를 관리하는 매니저 클래스
public class GameManager
{
    public static bool IsGameOver { get; set; }  // 게임 종료 플래그
    public const string GameName = "아무튼 RPG";
    private PlayerCharacter _player;

    // 게임 메인 루프
    public void Run()
    {
        Init();

        while (!IsGameOver)
        {
            Console.Clear();
            SceneManager.Render();      // 화면 렌더링
            InputManager.GetUserInput(); // 입력 처리

            if (InputManager.GetKey(ConsoleKey.L))
            {
                SceneManager.Change("Log");
            }

            SceneManager.Update();       // 로직 업데이트
        }
    }

    // 게임 초기화
    private void Init()
    {
        IsGameOver = false;
        
        SceneManager.OnChangeScene += InputManager.ResetKey;
        
        _player = new PlayerCharacter();

        // 씬 등록
        SceneManager.AddScene("Title", new TitleScene());
        SceneManager.AddScene("Story", new StoryScene());
        SceneManager.AddScene("Town", new TownScene(_player));
        SceneManager.AddScene("Log", new LogScene());

        SceneManager.Change("Title");

        Debug.Log("게임 데이터 초기화 완료");
    }
}
