using App.Component;
using App.UI;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 游戏启动器
    /// </summary>
    public class GameStart : MonoBehaviour
    {
        private void Start()
        {
           var uiComponent = World.CreateComponent<UIComponent>();
           uiComponent.SyncOpenView<LoginView>();

           var netComponent = World.CreateComponent<NetComponent>();
        }
    }
}

