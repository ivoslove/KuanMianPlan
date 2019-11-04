
using System.Threading.Tasks;
using App.Dispatch;
using App.UI;
using UnityEditor.IMGUI.Controls;
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
        /// 开启窗口(同步)
        /// </summary>
        /// <typeparam name="TView">窗口类型</typeparam>
        /// <returns>窗口对象</returns>
        public TView SyncOpenView<TView>() where TView :BaseView,new()
        {
            InitView<TView>();
            return Dispatcher<BaseView>.DoWork("SyncOpenView") as TView;
        }

        /// <summary>
        /// 开启窗口(异步)
        /// </summary>
        /// <typeparam name="TView">窗口类型</typeparam>
        /// <returns>包含窗口对象的任务</returns>
        public Task<TView> AsyncOpenView<TView>() where TView : BaseView, new ()
        {
            InitView<TView>();
            return Dispatcher<Task<BaseView>>.DoWork("AsyncOpenView") as Task<TView>;
        }


        #endregion

        #region private funcs

        /// <summary>
        /// 创建窗口与实例化窗口对象
        /// </summary>
        /// <typeparam name="TView">窗口类型</typeparam>
        /// <returns>窗口对象</returns>
        private TView InitView<TView>() where TView : BaseView, new()
        {
            var viewCache = Resources.Load($"Views/{typeof(TView).Name}");
            var viewGameObject = GameObject.Instantiate(viewCache, Canvas) as GameObject;
            if (viewGameObject != null)
            {
                var rectTransform = viewGameObject.GetComponent<RectTransform>();
                rectTransform.anchoredPosition3D = Vector3.zero;
                rectTransform.localScale = Vector3.one;
            }
            return new TView();
        }

        #endregion
    }

}

