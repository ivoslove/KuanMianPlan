
using System.Threading.Tasks;
using LeanCloud;
using UnityEngine;

namespace App.Component
{
    /// <summary>
    /// 网络组件
    /// </summary>
    public class NetComponent : BaseComponent
    {
        #region private fields

        private readonly string _appId = "8aKTp1kEwkOV861hvjOh8gKK-9Nh9j0Va";          //AppId为该项目唯一标识符        

        private readonly string _appKey = "SnD2n9qKRgvtbW95t0VgEb8U";                  //AppKey 是公开的访问密钥，适用于在公开的客户端中使用。使用 AppKey 进行的访问受到 ACL 的限制。

        private readonly string _tempUrl = @"https://8aktp1ke.lc-cn-e1-shared.com";  //临时域名
        #endregion

        #region ctor

        public NetComponent()
        {
            AVClient.HttpLog(Debug.Log);
            AVClient.Initialize(_appId, _appKey, _tempUrl);
        }


        #endregion
    }

}
