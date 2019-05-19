/***
   *        Title: "英雄战神" 项目开发
   *        公共层：全局参数
   *        Description:
   *                1：定义整个项目的枚举类型
   *                2：定义整个项目的委托
   *                3：定义整个项目的系统常量
   *                4:   定义系统所有的Tag标签
   *       Data:	[2018]
   *       Version: 0.1
 * */

using UnityEngine;
using System.Collections;

namespace Global
{
    /* 定义项目系统常量 */
    public class GlobalParameter
    {
        /// <summary>
        /// EasyTouch 插件定义摇杆的名称
        /// </summary>
        public const string JOYSTICK_NAME = "Hero Joystick";
        /// <summary>
        /// 输入管理器定义_攻击名称_普通攻击
        /// </summary>
        public const string INPUT_MGR_ATTACKNAME_NORMAL = "NormalAttack";
        /// <summary>
        /// 输入管理器定义_攻击名称_大招A
        /// </summary>
        public const string INPUT_MGR_ATTACKNAME_MAGICTRICK_A = "MagicTrickA";
        /// <summary>
        /// 输入管理器定义_攻击名称_大招B
        /// </summary>
        public const string INPUT_MGR_ATTACKNAME_MAGICTRICK_B = "MagicTrickB";
        /// <summary>
        /// 输入管理器定义_攻击名称_大招C
        /// </summary>
        public const string INPUT_MGR_ATTACKNAME_MAGICTRICK_C = "MagicTrickC";
        /// <summary>
        /// 输入管理器定义_攻击名称_大招D
        /// </summary>
        public const string INPUT_MGR_ATTACKNAME_MAGICTRICK_D = "MagicTrickD";
        /// <summary>
        /// 间隔时间
        /// </summary>
        public const float INTERVAL_TIME_0D0OT2 = 0.2F;
        public const float INTERVAL_TIME_0DOT1 = 0.1F;
        public const float INTERVAL_TIME_0DOT2 = 0.2F;
        public const float INTERVAL_TIME_0DOT3 = 0.3F;
        public const float INTERVAL_TIME_0DOT5 = 0.5F;
        public const float INTERVAL_TIME_1 = 1F;
        public const float INTERVAL_TIME_1DOT5 = 1.5F;
        public const float INTERVAL_TIME_2 = 2F;
        public const float INTERVAL_TIME_2DOT5 = 2.5F;
        public const float INTERVAL_TIME_3 = 3F;

    }

    /* 项目Tag(标签)定义 */
    public class Tag
    {
        public static string Tag_Enemys = "Tag_Enemys";
        public static string Player = "Player";
        public static string Tag_MajorCity_Up = "Tag_MajorCity_Up";
        public static string Tag_MajorCity_Down = "Tag_MajorCity_Down";
        public static string Tag_PackageItems = "Tag_PackageItems";
        public static string Tag_UICamera = "Tag_UICamera";
        public static string Tag_UIPlayerInfo = "Tag_UIPlayerInfo";
    }

    #region 项目的枚举类型
    /// <summary>
    /// 游戏类型
    /// </summary>
    public enum CurrentGameType
    {
        None,                                                              //无
        NewGame,                                                      //新游戏
        Continue                                                         //游戏继续
    }

    /// <summary>
    /// 场景名称
    /// </summary>
    public enum ScenesEnum
    {
        TestScenes,                                                      //测试场景 
        StartScene,
        LoadingScene,
        LoginScene,
        LevelOne,
        LevelTwo,
        BaseScene,
        MajorCity                                                       //主城场景
    }

    /// <summary>
    /// 玩家的类型
    /// </summary>
    public enum PlayerType
    {
        SwordHero,      //少年剑侠
        MagicHero,      //魔杖真人
        Other
    }

    /// <summary>
    /// 主角的动作状态
    /// </summary>
    public enum HeroActionState
    {
        None,                                //无
        Idle,                                  //休闲
        Running,                            //跑动
        NormalAttack,                   //普通攻击
        MagicTrickA,                  //大招A
        MagicTrickB                  //大招 B
    }

    /// <summary>
    /// 普通攻击连招状态
    /// </summary>
    public enum NormalATKComboState
    {
        NormalATK1,
        NormalATK2,
        NormalATK3
    }

    /// <summary>
    /// 等级名称
    /// </summary>
    public enum LevelName
    {
        Level_0 = 0,
        Level_1 = 1,
        Level_2 = 2,
        Level_3 = 3,
        Level_4 = 4,
        Level_5 = 5,
        Level_6 = 6,
        Level_7 = 7,
        Level_8 = 8,
        Level_9 = 9,
        Level_10 = 10
    }


    public enum EnemyState
    {
        Idle,                                                                 //休闲
        Walking,                                                          //行走
        Attack,                                                            //攻击
        Hurt,                                                               //受伤
        Death                                                             //死亡
    }

    #endregion


    #region 项目的委托类型
    /// <summary>
    /// 委托：主角控制
    /// </summary>
    /// <param name="controlType">控制的类型</param>
    public delegate void del_PlayerControlWithStr(string controlType);
    /// <summary>
    /// 委托： 玩家核心模型数值
    /// </summary>
    /// <param name="kv"></param>
    public delegate void del_PlayerKernalModel(KeyValuesUpdate kv);

    /// <summary>
    /// 键值更新
    /// </summary>
    public class KeyValuesUpdate
    { 
        private string _Key;            //键
        private object _Values;     //值

        /*只读属性 */
        public string Key
        {
            get
            {
                return _Key;
            }
        }

        /*只读属性 */
        public object Values
        {
            get
            {
                return _Values;
            }
        }

        public KeyValuesUpdate(string key, object Values)
        {
            _Key = key;
            _Values = Values;
        }
    }


    #endregion
}

