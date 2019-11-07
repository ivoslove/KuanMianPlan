using App.Component;
using App.UI;
using UnityEngine;

namespace Game
{
    public class GameStart : MonoBehaviour
    {
        private void Start()
        {
           var uiComponent = World.CreateComponent<UIComponent>();
           uiComponent.SyncOpenView<StartView>();
        }
    }
}

