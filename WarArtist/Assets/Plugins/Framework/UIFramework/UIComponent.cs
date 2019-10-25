
using System.Threading.Tasks;
using App.Dispatch;
using App.UI;
using UnityEngine;

namespace App.Component
{
    /// <summary>
    /// UI组件
    /// </summary>
    public sealed class UIComponent : BaseComponent
    {

        #region private fields

        private RepositoryComponent<string, BaseView> _cache;

        #endregion

        #region public properties

        /// <summary>
        /// 画布
        /// </summary>
        public Transform Canvas { get; }

        #endregion

        #region ctor

        public UIComponent()
        {
            _cache = new RepositoryComponent<string, BaseView>();
            Canvas = GameObject.Find("Canvas").transform;
        }

        #endregion

        #region public funcs

        /// <summary>
        /// 同步开启窗口
        /// </summary>
        /// <typeparam name="TView">窗口类型</typeparam>
        /// <returns>开启的窗口对象</returns>
        public TView SyncOpenView<TView>() where TView :BaseView,new()
        {
            CreateView<TView>();
            var baseView = new TView();
            var openedView = Dispatcher<BaseView>.DoWork("SyncOpenView");
            return openedView as TView;
        }

        /// <summary>
        /// 异步开启窗口
        /// </summary>
        /// <typeparam name="TView">窗口类型</typeparam>
        /// <returns>开启的窗口对象</returns>
        public Task<TView> AsyncOpenView<TView>() where TView : BaseView, new()
        {
            CreateView<TView>();
            var baseView = new TView();
            return Dispatcher<Task<BaseView>>.DoWork("AsyncOpenView").ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    Debug.LogError($"开启窗口{typeof(TView)}失败,原因:{t.Exception}");
                    return baseView;
                }
                return t.Result as TView;
            });
        }

        /// <summary>
        /// 关闭一个View
        /// </summary>
        /// <typeparam name="TView"></typeparam>
        public void CloseView<TView>() where TView : BaseView, new()
        {
            Dispatcher.DoWork("OnClose",typeof(TView));
        }


        #endregion

        #region private funcs

        /// <summary>
        /// 创建窗口至画布中
        /// </summary>
        /// <typeparam name="TView">窗口类型</typeparam>
        /// <returns>窗口Transform</returns>
        private Transform CreateView<TView>() where TView:BaseView,new()
        {
            var viewCache = Resources.Load($"Views/{typeof(TView).Name}") as GameObject;
            var view = GameObject.Instantiate(viewCache, Canvas)?.transform;
            var rect = view.GetComponent<RectTransform>();
            rect.anchoredPosition3D = Vector3.zero;
            rect.localScale = Vector3.one;
            return view;
        }

        #endregion
    }
}

