using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 씬(장면) 전환 및 관리
public static class SceneManager
{
    public static Action OnChangeScene;              // 씬 변경 시 호출되는 이벤트
    public static Scene Current { get; private set; } // 현재 씬
    private static Scene _prev;                       // 이전 씬


    private static Dictionary<string, Scene> _scenes = new Dictionary<string, Scene>();

    public static void AddScene(string key, Scene state)
    {
        if (_scenes.ContainsKey(key)) return;

        _scenes.Add(key, state);
    }

    public static void ChangePrevScene()
    {
        Change(_prev);
    }

    // 상태 바꾸는 기능
    public static void Change(string key)
    {
        if (!_scenes.ContainsKey(key)) return;

        Change(_scenes[key]);
    }

    public static void Change(Scene scene)
    {
        Scene next = scene;

        if (Current == next) return;

        Current?.Exit();
        next.Enter();

        _prev = Current;
        Current = next;
        OnChangeScene?.Invoke();
    }

    public static void Update()
    {
        Current?.Update();
    }

    public static void Render()
    {
        Current?.Render();
    }
}
