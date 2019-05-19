/***
   *        Title: "英雄战神" 项目开发
   *    模型层：玩家扩展数值
   *      Description:
   *                  功能：本类提供玩家扩展数据的存取数值
   *       Data:	[2018]
   *       Version: 0.1
 * */

using UnityEngine;
using System.Collections;
using Global;


namespace Model
{
    public class PlayerExtenData 
    {
        //定义事件：玩家的扩展数值
        public static event del_PlayerKernalModel evePlayerExtenalData; //玩家的扩展数值


        private int _IntExperience;                                //  经验值
        private int _IntKillNumber;                               //  杀敌的数量
        private int _IntLevel;                                         //  等级(当前等级)
        private int _IntGold;                                         //  金币
        private int _IntDiamonds;                                 //  钻石

        /*   属性信息   */
        /// <summary>
        /// 经验值
        /// </summary>
        public int Experience
        {
            get
            {
                return IntExperience;
            }

            set
            {
                IntExperience = value;

                //事件调用
                if (evePlayerExtenalData != null)
                {
                    KeyValuesUpdate kv = new KeyValuesUpdate("Experience", Experience);
                    evePlayerExtenalData(kv);  //调用委托
                }
            }
        }

        /// <summary>
        /// 杀敌数量
        /// </summary>
        public int KillNumber
        {
            get
            {
                return _IntKillNumber;
            }

            set
            {
                _IntKillNumber = value;
                //事件调用
                if (evePlayerExtenalData != null)
                {
                    KeyValuesUpdate kv = new KeyValuesUpdate("KillNumber", KillNumber);
                    evePlayerExtenalData(kv);  //调用委托
                }
            }
        }

        /// <summary>
        /// 等级
        /// </summary>
        public int Level
        {
            get
            {
                return _IntLevel;
            }

            set
            {
                _IntLevel = value;
                //事件调用
                if (evePlayerExtenalData != null)
                {
                    KeyValuesUpdate kv = new KeyValuesUpdate("Level", Level);
                    evePlayerExtenalData(kv);  //调用委托
                }
            }
        }

        /// <summary>
        /// 金币
        /// </summary>
        public int Gold
        {
            get
            {
                return _IntGold;
            }

            set
            {
                _IntGold = value;
                //事件调用
                if (evePlayerExtenalData != null)
                {
                    KeyValuesUpdate kv = new KeyValuesUpdate("Gold", Gold);
                    evePlayerExtenalData(kv);  //调用委托
                }
            }
        }

        /// <summary>
        /// 钻石
        /// </summary>
        public int Diamonds
        {
            get
            {
                return _IntDiamonds;
            }

            set
            {
                _IntDiamonds = value;
                //事件调用
                if (evePlayerExtenalData != null)
                {
                    KeyValuesUpdate kv = new KeyValuesUpdate("Diamonds", Diamonds);
                    evePlayerExtenalData(kv);  //调用委托
                }
            }
        }

        public int IntExperience
        {
            get
            {
                return _IntExperience;
            }

            set
            {
                _IntExperience = value;
            }
        }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public PlayerExtenData()
        {

        }

        /// <summary>
        /// 带参构造函数
        /// </summary>
        /// <param name="experience"></param>
        /// <param name="killNum"></param>
        /// <param name="level"></param>
        /// <param name="gold"></param>
        /// <param name="diamond"></param>
        public PlayerExtenData(int experience, int killNum, int level, int gold, int diamond)
        {
            IntExperience = experience;
            _IntKillNumber = killNum;
            _IntLevel = level;
            _IntGold = gold;
            _IntDiamonds = diamond;
        }

    }//class_end

}
