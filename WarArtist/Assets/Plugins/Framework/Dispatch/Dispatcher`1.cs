using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Component;

namespace App.Dispatch
{
    /// <summary>
    /// 调度者
    /// </summary>
    public sealed class Dispatcher<TResult> : Dispatcher
    {

        #region delegates

        /// <summary>
        /// 工作
        /// </summary>
        public new delegate TResult Work();

        /// <summary>
        /// 工作
        /// </summary>
        /// <typeparam name="TArg1">参数类型1</typeparam>
        /// <param name="arg1">参数1</param>
        public new delegate TResult Work<in TArg1>(TArg1 arg1);

        /// <summary>
        /// 工作
        /// </summary>
        /// <typeparam name="TArg1">参数类型1</typeparam>
        /// <typeparam name="TArg2">参数类型2</typeparam>
        /// <param name="arg1">参数1</param>
        /// <param name="arg2">参数2</param>
        public new delegate TResult Work<in TArg1, in TArg2>(TArg1 arg1, TArg2 arg2);

        /// <summary>
        /// 工作
        /// </summary>
        /// <typeparam name="TArg1">参数类型1</typeparam>
        /// <typeparam name="TArg2">参数类型2</typeparam>
        /// <typeparam name="TArg3">参数类型3</typeparam>
        /// <param name="arg1">参数1</param>
        /// <param name="arg2">参数2</param>
        /// <param name="arg3">参数3</param>
        public new delegate TResult Work<in TArg1, in TArg2, in TArg3>(TArg1 arg1, TArg2 arg2, TArg3 arg3);

        /// <summary>
        /// 工作
        /// </summary>
        /// <typeparam name="TArg1">参数类型1</typeparam>
        /// <typeparam name="TArg2">参数类型2</typeparam>
        /// <typeparam name="TArg3">参数类型3</typeparam>
        /// <typeparam name="TArg4">参数类型4</typeparam>
        /// <param name="arg1">参数1</param>
        /// <param name="arg2">参数2</param>
        /// <param name="arg3">参数3</param>
        /// <param name="arg4">参数4</param>
        public new delegate TResult Work<in TArg1, in TArg2, in TArg3, in TArg4>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4);

        /// <summary>
        /// 工作
        /// </summary>
        /// <typeparam name="TArg1">参数类型1</typeparam>
        /// <typeparam name="TArg2">参数类型2</typeparam>
        /// <typeparam name="TArg3">参数类型3</typeparam>
        /// <typeparam name="TArg4">参数类型4</typeparam>
        /// <typeparam name="TArg5">参数类型5</typeparam>
        /// <param name="arg1">参数1</param>
        /// <param name="arg2">参数2</param>
        /// <param name="arg3">参数3</param>
        /// <param name="arg4">参数4</param>
        /// <param name="arg5">参数5</param>
        public new delegate TResult Work<in TArg1, in TArg2, in TArg3, in TArg4, in TArg5>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5);

        /// <summary>
        /// 工作
        /// </summary>
        /// <typeparam name="TArg1">参数类型1</typeparam>
        /// <typeparam name="TArg2">参数类型2</typeparam>
        /// <typeparam name="TArg3">参数类型3</typeparam>
        /// <typeparam name="TArg4">参数类型4</typeparam>
        /// <typeparam name="TArg5">参数类型5</typeparam>
        /// <typeparam name="TArg6">参数类型6</typeparam>
        /// <param name="arg1">参数1</param>
        /// <param name="arg2">参数2</param>
        /// <param name="arg3">参数3</param>
        /// <param name="arg4">参数4</param>
        /// <param name="arg5">参数5</param>
        /// <param name="arg6">参数6</param>
        public new delegate TResult Work<in TArg1, in TArg2, in TArg3, in TArg4, in TArg5, in TArg6>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6);

        #endregion


        #region public static funcs

        #region Listener


        /// <summary>
        /// 监听工作
        /// </summary>
        /// <typeparam name="TArg1">参数类型1</typeparam>
        /// <param name="workId">工作ID</param>
        /// <param name="work">工作事务</param>
        public static void Listener<TArg1>(string workId, Work<TArg1> work)
        {
            var handle = _cache.Get(workId);
            if (handle == null)
            {
                _cache.Set(workId, null);
            }
            var value = (Work<TArg1>)_cache.Get(workId) + work;
            _cache.Set(workId, value);
        }

        #endregion

        #region DoWork

        /// <summary>
        /// 执行工作
        /// </summary>
        /// <param name="workId">工作ID</param>
        public new static TResult DoWork(string workId)
        {
            var handle = _cache.Get(workId);
            return ((Work) handle).Invoke();
        }

        /// <summary>
        /// 执行工作
        /// </summary>
        /// <typeparam name="TArg1">参数类型1</typeparam>
        /// <param name="workId">工作ID</param>
        /// <param name="arg1">参数1</param>
        public new static TResult DoWork<TArg1>(string workId, TArg1 arg1)
        {
            var handle = _cache.Get(workId);
            return ((Work<TArg1>) handle).Invoke(arg1);
        }

        /// <summary>
        /// 执行工作
        /// </summary>
        /// <typeparam name="TArg1">参数类型1</typeparam>
        /// <typeparam name="TArg2">参数类型2</typeparam>
        /// <param name="workId">工作ID</param>
        /// <param name="arg1">参数1</param>
        /// <param name="arg2">参数2</param>
        public new static TResult DoWork<TArg1, TArg2>(string workId, TArg1 arg1, TArg2 arg2)
        {
            var handle = _cache.Get(workId);
            return ((Work<TArg1, TArg2>) handle).Invoke(arg1, arg2);
        }

        /// <summary>
        /// 执行工作
        /// </summary>
        /// <typeparam name="TArg1">参数类型1</typeparam>
        /// <typeparam name="TArg2">参数类型2</typeparam>
        /// <typeparam name="TArg3">参数类型3</typeparam>
        /// <param name="workId">工作ID</param>
        /// <param name="arg1">参数1</param>
        /// <param name="arg2">参数2</param>
        /// <param name="arg3">参数3</param>
        public new static TResult DoWork<TArg1, TArg2, TArg3>(string workId, TArg1 arg1, TArg2 arg2,
            TArg3 arg3)
        {
            var handle = _cache.Get(workId);
            return ((Work<TArg1, TArg2, TArg3>) handle).Invoke(arg1, arg2, arg3);
        }

        /// <summary>
        /// 执行工作
        /// </summary>
        /// <typeparam name="TArg1">参数类型1</typeparam>
        /// <typeparam name="TArg2">参数类型2</typeparam>
        /// <typeparam name="TArg3">参数类型3</typeparam>
        /// <typeparam name="TArg4">参数类型4</typeparam>
        /// <param name="workId">工作ID</param>
        /// <param name="arg1">参数1</param>
        /// <param name="arg2">参数2</param>
        /// <param name="arg3">参数3</param>
        /// <param name="arg4">参数4</param>
        public new static TResult DoWork<TArg1, TArg2, TArg3, TArg4>(string workId, TArg1 arg1, TArg2 arg2,
            TArg3 arg3, TArg4 arg4)
        {
            var handle = _cache.Get(workId);
            return ((Work<TArg1, TArg2, TArg3, TArg4>) handle).Invoke(arg1, arg2, arg3, arg4);
        }

        /// <summary>
        /// 执行工作
        /// </summary>
        /// <typeparam name="TArg1">参数类型1</typeparam>
        /// <typeparam name="TArg2">参数类型2</typeparam>
        /// <typeparam name="TArg3">参数类型3</typeparam>
        /// <typeparam name="TArg4">参数类型4</typeparam>
        /// <typeparam name="TArg5">参数类型5</typeparam>
        /// <param name="workId">工作ID</param>
        /// <param name="arg1">参数1</param>
        /// <param name="arg2">参数2</param>
        /// <param name="arg3">参数3</param>
        /// <param name="arg4">参数4</param>
        /// <param name="arg5">参数5</param>
        public new static TResult DoWork<TArg1, TArg2, TArg3, TArg4, TArg5>(string workId, TArg1 arg1, TArg2 arg2,
            TArg3 arg3, TArg4 arg4, TArg5 arg5)
        {
            var handle = _cache.Get(workId);
            return ((Work<TArg1, TArg2, TArg3, TArg4, TArg5>) handle).Invoke(arg1, arg2, arg3, arg4, arg5);
        }

        /// <summary>
        /// 执行工作
        /// </summary>
        /// <typeparam name="TArg1">参数类型1</typeparam>
        /// <typeparam name="TArg2">参数类型2</typeparam>
        /// <typeparam name="TArg3">参数类型3</typeparam>
        /// <typeparam name="TArg4">参数类型4</typeparam>
        /// <typeparam name="TArg5">参数类型5</typeparam>
        /// <typeparam name="TArg6">参数类型6</typeparam>
        /// <param name="workId">工作ID</param>
        /// <param name="arg1">参数1</param>
        /// <param name="arg2">参数2</param>
        /// <param name="arg3">参数3</param>
        /// <param name="arg4">参数4</param>
        /// <param name="arg5">参数5</param>
        /// <param name="arg6">参数6</param>
        public new static TResult DoWork<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string workId, TArg1 arg1, TArg2 arg2,
            TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
        {
            var handle = _cache.Get(workId);
            return ((Work<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>) handle).Invoke(arg1, arg2, arg3, arg4, arg5, arg6);
        }

        /// <summary>
        /// 执行工作
        /// </summary>
        /// <typeparam name="TArg1">参数类型1</typeparam>
        /// <param name="workId">工作ID</param>
        /// <param name="arg1">参数1</param>
        public new static Task<TResult> AsycnDoWork<TArg1>(string workId, TArg1 arg1)
        {
            var handle = _cache.Get(workId);
            return Task.FromResult(((Work<TArg1>)handle).Invoke(arg1));
        }

        #endregion

        #endregion

    }
}

