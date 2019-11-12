
using System;
using System.Threading.Tasks;
using App.Component;
using LeanCloud;
using UnityEngine;
using UnityEngine.UI;

namespace App.UI
{
    /// <summary>
    /// 用户登录窗口
    /// </summary>
    public class LoginView : BaseView
    {
        #region private fields

        #region ui

        private Transform _loginEmpty;
        private Transform _registerEmpty;

        private Text _loginErrorText;
        private Text _registerErrorText;

        private Toggle _rememberPasswordToggle;

        private InputField _accountInput;
        private InputField _passwordInput;
        private InputField _captchaInput;

        private Button _loginBtn;
        private Button _registerBtn;
        private Button _forgetPasswordBtn;
        private Button _captchaBtn;
        private Button _registerConfirmBtn;
        private Button _registerBackBtn;


        #endregion

        #region other

        [Inject]
        private UIComponent _uiComponent;             //UI组件

        private readonly string IsRememberPassword = "IsRememberPassword";          //是否记住密码,1：记住   0：不记住

        #endregion

        #endregion

        #region BaseView

        /// <summary>
        /// 初始化窗口(仅当窗口建立时执行,且最先执行)
        /// </summary>
        /// <returns></returns>
        protected override void OnAwake()
        {
            _loginErrorText.text = "";
            _registerErrorText.text = "";
            _registerEmpty.gameObject.SetActive(false);
            _rememberPasswordToggle.SetIsOnWithoutNotify(PlayerPrefs.GetInt(IsRememberPassword) == 1);
        }

        /// <summary>
        /// 添加监听
        /// </summary>
        protected override void AddDelegates()
        {
            _loginBtn.onClick.AddListener(OnLoginBtnClick);
            _registerBtn.onClick.AddListener(OnRegisterBtnClick);
            _registerBackBtn.onClick.AddListener(OnRegisterBackBtnClick);
            _registerConfirmBtn.onClick.AddListener(OnRegisterConfirmBtnClick);
        }


        /// <summary>
        /// 同步开启(窗口每次显示都会执行)
        /// </summary>
        protected override void SyncOnOpen()
        {
            if (_rememberPasswordToggle.isOn)
            {
                //TODO
                return;    
            }
        }

        #endregion

        #region private funcs

        /// <summary>
        /// 点击登录按钮
        /// </summary>
        private void OnLoginBtnClick()
        {
            if (string.IsNullOrEmpty(_accountInput.text) || string.IsNullOrEmpty(_passwordInput.text))
            {
                _loginErrorText.text = "账号或密码不能为空!";
                return;
            }

            //是否存在该用户
            AVUser.Query.WhereEqualTo("username", _accountInput.text).CountAsync().ContinueWith(t =>
            {
                if (t.Result == 0)
                {
                    return;
                }
                Login(_accountInput.text, _passwordInput.text);
            });
        }

        /// <summary>
        /// 点击注册按钮
        /// </summary>
        private void OnRegisterBtnClick()
        {
            _loginErrorText.text = "";
            _registerErrorText.text = "";
            _loginEmpty.gameObject.SetActive(false);
            _registerEmpty.gameObject.SetActive(true);
        }

        /// <summary>
        /// 点击返回登录按钮
        /// </summary>
        private void OnRegisterBackBtnClick()
        {
            _loginErrorText.text = "";
            _registerErrorText.text = "";
            _loginEmpty.gameObject.SetActive(true);
            _registerEmpty.gameObject.SetActive(false);
        }

        /// <summary>
        /// 点击确认注册按钮
        /// </summary>
        private void OnRegisterConfirmBtnClick()
        {
            if (string.IsNullOrEmpty(_accountInput.text) || string.IsNullOrEmpty(_passwordInput.text))
            {
                _registerErrorText.text = "账号或密码不能为空!";
                return;
            }
            //是否存在该用户
            AVUser.Query.WhereEqualTo("username", _accountInput.text).CountAsync().ContinueWith(t =>
            {
                if (t.Result != 0)
                {
                    _registerErrorText.text = "该账号已注册!";
                    return;
                }
                //存在该用户，进行登录
                var user = new AVUser()
                {
                    Username = _accountInput.text,
                    Password = _passwordInput.text
                };
                user.SignUpAsync().ContinueWith(p => { Login(_accountInput.text, _passwordInput.text); });
            });

        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        private Task Login(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                _loginErrorText.text = "账号或密码不能为空";
                return Task.FromResult(0);
            }

            //存在该用户，进行登录
            return AVUser.LogInAsync(_accountInput.text, _passwordInput.text).ContinueWith(p =>
            {
                if (p.IsFaulted)
                {
                    //TODO
                    return Task.FromException(p.Exception);
                }
                Debug.Log("登录成功!");
                return Task.FromResult(0);
            });
        }

        #endregion
    }
}

