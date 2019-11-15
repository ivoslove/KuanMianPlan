using App.Component;
using UnityEngine;
using UnityEngine.UI;

namespace App.UI
{
    /// <summary>
    /// 房间大厅窗口
    /// </summary>
    public class GameLobbyView :BaseView
    {
        #region private fields

        #region ui

        private Transform _roomItem;
        private Transform _grid;
        private InputField _searchInput;

        private Button _backBtn;
        private Button _createBtn;
        private Button _renovateBtn;
        private Button _searchBtn;


        #endregion

        #region other

        [Inject]
        private UIComponent _uiComponent;

        #endregion

        #endregion


        #region BaseView

        /// <summary>
        /// 同步开启(窗口每次显示都会执行)
        /// </summary>
        protected override void SyncOnOpen()
        {
            for (int i = 0; i < _grid.childCount; i++)
            {
                _grid.GetChild(i).gameObject.SetActive(false);
            }
        }


        /// <summary>
        /// 添加监听
        /// </summary>
        protected override void AddDelegates()
        {
            _backBtn.onClick.AddListener(OnBackBtnClick);
        }

        #endregion

        #region private funcs

        /// <summary>
        /// 点击返回按钮
        /// </summary>
        private void OnBackBtnClick()
        {
            _uiComponent.CloseView<GameLobbyView>();
            _uiComponent.SyncOpenView<LeisurePattenView>();
        }

        /// <summary>
        /// 点击刷新按钮
        /// </summary>
        private void OnRenovateBtnClick()
        {

        }

        #endregion
    }
}


