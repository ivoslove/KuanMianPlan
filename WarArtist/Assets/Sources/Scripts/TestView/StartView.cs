
using System.Threading.Tasks;
using App.Plugins;
using UnityEngine;
using UnityEngine.UI;

namespace App.UI
{
    public class TestView : BaseView
    {  
        private Button _startGameBtn;


        protected override Task<BaseView> AsyncOnOpen()
        {
            return base.AsyncOnOpen();
        }
    }

    
}

