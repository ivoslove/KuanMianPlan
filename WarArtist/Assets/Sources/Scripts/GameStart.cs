using App.Component;
using App.LeanCloud;
using App.UI;
using LeanCloud;
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
            var netComponent = World.CreateComponent<NetComponent>();
            AVObject.RegisterSubclass<Player>();
            var uiComponent = World.CreateComponent<UIComponent>();
            uiComponent.SyncOpenView<LoginView>();

          
        }
    }
}

