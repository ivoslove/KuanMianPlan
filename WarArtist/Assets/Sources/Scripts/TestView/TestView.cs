
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace App.UI
{
    public class TestView : BaseView
    {
        private Button _buttonA;
        private RawImage _image;


        /// <summary>
        /// 同步开启(创建或显示)
        /// </summary>
        protected override BaseView SyncOnOpen()
        {
            Debug.Log("33333");
            return this;
        }

        /// <summary>
        /// 异步开启(创建或显示)
        /// </summary>
        /// <returns></returns>
        protected override Task<BaseView> AsyncOnOpen()
        {
            return Task.Delay(TimeSpan.FromSeconds(5)).ContinueWith(t => this as BaseView);
        }
    }

    public class TestView2 : BaseView
    {
        private Button _buttonA;
        private RawImage _image;


        /// <summary>
        /// 同步开启(创建或显示)
        /// </summary>
        protected override BaseView SyncOnOpen()
        {
            Debug.Log("33333");
            return this;
        }

        /// <summary>
        /// 异步开启(创建或显示)
        /// </summary>
        /// <returns></returns>
        protected override Task<BaseView> AsyncOnOpen()
        {
            return Task.Delay(TimeSpan.FromSeconds(3)).ContinueWith(t => this as BaseView);
        }
    }
}

