
using App.UI;
using UnityEngine;

namespace App.Component
{
    /// <summary>
    /// UI组件
    /// </summary>
    public sealed class UIComponent : BaseComponent
    {
        private RepositoryComponent<string, BaseView> _cache;

        /// <summary>
        /// 画布
        /// </summary>
        public Transform Canvas { get; }
        #region ctor

        public UIComponent()
        {
            _cache = new RepositoryComponent<string, BaseView>();
            Canvas = GameObject.Find("Canvas").transform;
        }

        #endregion

        #region public funcs

        /// <summary>
        /// 开启窗口
        /// </summary>
        /// <typeparam name="TView">窗口类型</typeparam>
        public void OpenView<TView>() where TView :BaseView,new()
        {
            var viewCache = Resources.Load($"Views/{typeof(TView).Name}");
            var viewGameObject = GameObject.Instantiate(viewCache,Canvas);
            BaseView view = new TView();
        }

        #endregion


    }
}

