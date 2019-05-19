/***
   *       Title: "英雄战神" 项目开发
   *       模型层：全局参数数据
   *                    
   *       Description:
   *                作用：为了做“对象持久”服务
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using System.Collections;
using Kernal;
using Global;

namespace Model
{
    public class GlobalParameterData : MonoBehaviour
    {
        //下一场景名称
        private  ScenesEnum _NextScenesName;
        //玩家的姓名
        private  string _PlayerName;

        /* 属性定义 */
        public ScenesEnum NextScenesName
        {
            get
            {
                return NextScenesName;
            }

            set
            {
                NextScenesName = value;
            }
        }

        public string PlayerName
        {
            get
            {
                return _PlayerName;
            }

            set
            {
                _PlayerName = value;
            }
        }

        //无参构造函数
        private GlobalParameterData(){ }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="scenesName">场景名称</param>
        /// <param name="playerName">玩家姓名</param>
        public GlobalParameterData(ScenesEnum scenesName, string playerName)
        {
            _NextScenesName = scenesName;
            _PlayerName = playerName;
        }
    }
}

