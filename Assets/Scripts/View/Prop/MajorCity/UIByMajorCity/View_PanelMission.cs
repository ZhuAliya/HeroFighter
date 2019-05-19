/***
   *       Title: "英雄战神" 项目开发
   *       视图层：主城UI界面_任务系统      
   *      Description:
   *                [描述]
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using System.Collections;
using Kernal;
using Global;
using Control;

namespace View
{
    public class View_PanelMission : MonoBehaviour
    {
        /// <summary>
        /// 任务1：进入第二关卡
        /// </summary>
        public void EnterNextLevelTwo()
        {
            //调用控制层
            Ctrl_PanelMission.Instance.EnterLevelTwo();
        }

    }
}
