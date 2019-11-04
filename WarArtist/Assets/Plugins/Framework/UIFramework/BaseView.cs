using System;
using System.Threading.Tasks;
using App.Dispatch;
using UnityEngine.Events;

namespace App.UI
{
    /// <summary>
    /// UI窗体基类
    /// </summary>
    public abstract class BaseView
    {

        #region ctor

        protected BaseView()
        {
            Dispatcher<BaseView>.Listener("InitView",OnInit);
            Dispatcher<BaseView>.Listener("SyncOpenView",SyncOnOpen);
            Dispatcher<Task<BaseView>>.Listener("AsyncOpenView",AsyncOnOpen);
        }

        #endregion

        /// <summary>
        /// 初始化窗口(仅当窗口建立时执行,且最先执行)
        /// </summary>
        /// <returns></returns>
        protected virtual BaseView OnInit(){ return this; }

        /// <summary>
        /// 同步开启(窗口每次显示都会执行)
        /// </summary>
        protected virtual BaseView SyncOnOpen(){ return this; }

        /// <summary>
        /// 异步开启(窗口每次开启都会执行)
        /// </summary>
        /// <returns></returns>
        protected virtual Task<BaseView> AsyncOnOpen() { return Task.FromResult(this);}


        /// <summary>
        /// 关闭(仅隐藏)
        /// </summary>
        protected virtual void Close()
        {
            Dispatcher<BaseView>.Remove("InitView", OnInit);
        }

        /// <summary>
        /// 销毁(删除)
        /// </summary>
        protected virtual void OnDestroy()
        {
            Dispatcher<BaseView>.Remove("SyncOpenView", SyncOnOpen);
            Dispatcher<Task<BaseView>>.Remove("AsyncOpenView", AsyncOnOpen);
        }
    }
}

