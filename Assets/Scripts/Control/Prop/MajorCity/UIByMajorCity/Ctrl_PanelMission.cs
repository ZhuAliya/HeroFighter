/***
   *    Title: "英雄战神" 项目开发
   *     控制层：主城UI界面_任务系统的功能实现
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
    public class Ctrl_PanelMission : BaseControl
    {
        public static Ctrl_PanelMission Instance;          //脚本实例

        void Awake()
        {
            Instance = this;
        }

        /// <summary>
        /// 副本：进入第二关卡
        /// </summary>
        public void EnterLevelTwo()
        {           
            base.EnterNextScenes(ScenesEnum.LevelTwo);
        }


    }

}
