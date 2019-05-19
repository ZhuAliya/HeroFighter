/***
   *    Title: "英雄战神" 项目开发
   *                控制层：玩家UI界面响应处理
   *    Description:
   *                [描述]
   *    Data:	[2018]
   *    Version: 0.1
 * */
using UnityEngine;
using System.Collections;
using Kernal;
using Global;

namespace Control
{
    public class Ctrl_PlayerUIResponse : BaseControl
    {
        public static Ctrl_PlayerUIResponse Instance;

        void Awake()
        {
            Instance = this;
        }

        /// <summary>
        /// 退出游戏
        /// </summary>
        public void ExitGame()
        {
            StartCoroutine("HandleSavingGame");
        }

        /// <summary>
        /// 处理退出游戏
        /// </summary>
        /// <returns></returns>
        IEnumerator HandleSavingGame()
        {
            SaveAndLoading.GetInstance().SaveGameProcess();
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT5);
            Application.Quit();
        }
    }
}

