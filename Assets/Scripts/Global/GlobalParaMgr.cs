/***
   *        Title: "英雄战神" 项目开发
   *    公共层：全局参数管理器
   *      Description:
   *          作用：跨场景全局数值传递
   *               
   *                
   *       Data:	[2018]
   *       Version: 0.1
 * */

using UnityEngine;
using System.Collections;


namespace Global 
{
    public class GlobalParaMgr
    {
        //下一场景名称
        public static ScenesEnum NextScenesName = ScenesEnum.LoginScene;
        //玩家的姓名
        public static string PlayerName = "";
        //玩家的类型
        public static PlayerType PlayerTypes = PlayerType.SwordHero;
        //游戏类型（开始/继续）
        public static CurrentGameType CurGameType = CurrentGameType.NewGame;

    }
}

