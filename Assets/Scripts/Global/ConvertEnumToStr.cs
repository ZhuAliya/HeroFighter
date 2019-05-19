/***
   *        Title: "英雄战神" 项目开发
   *    公共层：枚举类型转换字符串
   *      Description:
   *          （单例模式的应用）      
   *               
   *                
   *       Data:	[2018]
   *       Version: 0.1
 * */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
//using GlobalParameter;

namespace Global
{
    public class ConvertEnumToStr
    {

        private static ConvertEnumToStr _Instance;//本类实例

        //枚举场景类型集合
        private Dictionary<ScenesEnum, string> _DicScenesEnumLib;

        /// <summary>
        /// 构造函数
        /// </summary>
        private ConvertEnumToStr()
        {
            _DicScenesEnumLib = new Dictionary<ScenesEnum, string>();
            _DicScenesEnumLib.Add(ScenesEnum.StartScene, "1_StartScene");
            _DicScenesEnumLib.Add(ScenesEnum.LoadingScene, "LoadingScene");
            _DicScenesEnumLib.Add(ScenesEnum.LoginScene, "2_LoginScene");
            _DicScenesEnumLib.Add(ScenesEnum.LevelOne, "3_LevelOne");
            _DicScenesEnumLib.Add(ScenesEnum.MajorCity, "4_MajorCity");
            _DicScenesEnumLib.Add(ScenesEnum.LevelTwo, "5_LevelTwo");
            _DicScenesEnumLib.Add(ScenesEnum.TestScenes, "100_TestDialogsScenes");
        }

        /// <summary>
        /// 得到实例（单例模式的应用）
        /// </summary>
        /// <returns></returns>
        public static ConvertEnumToStr GetInstance()
        {
            if(_Instance == null)
            {
                _Instance = new ConvertEnumToStr();
            }
            return _Instance;
        }

        /// <summary>
        /// 得到字符串形式的场景名称
        /// </summary>
        /// <param name="sceneEnum">枚举类型的场景名称</param>
        /// <returns></returns>
        public string GetStrByEnumScenes(ScenesEnum sceneEnum)
        {
            if(_DicScenesEnumLib != null && _DicScenesEnumLib.Count >= 1)
            {
                return _DicScenesEnumLib[sceneEnum];
            }
            else
            {
                Debug.LogWarning(GetType() + "/GetStrByEnumScenes()/ _DicScenesEnumLib.Count <= 0! ,please check!");
                return null;
            }
        }

    }
}

