using System;
using System.Threading.Tasks;
using App.Dispatch;

namespace App.UI
{
    /// <summary>
    /// UI窗体基类
    /// </summary>
    public abstract class BaseView
    {
        protected BaseView()
        {
            Dispatcher<BaseView>.Listener("SyncOpenView", SyncOnOpen);
            Dispatcher<Task<BaseView>>.Listener("AsyncOpenView", AsyncOnOpen);
            Dispatcher.Listener("CloseView",Close);
            Dispatcher.Listener("DestroyView", OnDestroy);
        }

        /// <summary>
        /// 同步开启(创建或显示)
        /// </summary>
        protected virtual BaseView SyncOnOpen(){return this;}

        /// <summary>
        /// 异步开启(创建或显示)
        /// </summary>
        /// <returns></returns>
        protected virtual Task<BaseView> AsyncOnOpen() { return Task.FromResult(this);}

        /// <summary>
        /// 关闭(仅隐藏)
        /// </summary>
        protected virtual void Close()
        {

        }

        /// <summary>
        /// 销毁(删除)
        /// </summary>
        protected virtual void OnDestroy()
        {
            Dispatcher<BaseView>.Remove("SyncOpenView", SyncOnOpen);
            Dispatcher<Task<BaseView>>.Remove("AsyncOpenView", AsyncOnOpen);
            Dispatcher.Remove("CloseView", Close);
            Dispatcher.Remove("DestroyView", OnDestroy);
        }
    }
}

