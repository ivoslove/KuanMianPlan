using System;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace App.UI
{
    /// <summary>
    /// UI窗体基类
    /// </summary>
    public abstract class BaseView
    {
        #region events
        public class AsyncOnOpenHandle : UnityEvent<Task<BaseView>> { }

        public AsyncOnOpenHandle AsyncOnOpenEvent { get; } = new AsyncOnOpenHandle();

        public class SyncOnOpenHandle : UnityEvent<BaseView> { }

        public SyncOnOpenHandle SyncOnOpenEvent { get; } = new SyncOnOpenHandle();
        #endregion

        private void OnAwake()
        {
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

        }
    }
}

