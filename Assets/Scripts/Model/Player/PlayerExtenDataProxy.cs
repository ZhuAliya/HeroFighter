/***
   *        Title: "英雄战神" 项目开发
   *    模型层：玩家扩展数值代理类
   *      Description:
   *                 功能：为了简化数值的开发，我们把数值的“直接存取”与复杂“操作计算”相分离
   *               （本质是“代理”设计模式的应用）
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using System.Collections;
using Global;


namespace Model
{
    public class PlayerExtenDataProxy : PlayerExtenData
    {
        public static PlayerExtenDataProxy _Instance = null;       //本类的实例

        /// <summary>
        /// 构造函数
        /// </summary>     
        public PlayerExtenDataProxy(int exp, int killNumber, int level, int gold, int diamonds):base(exp,killNumber, level, gold, diamonds)
        {
            if (_Instance == null)
            {
                _Instance = this;
            }
            else
            {
                Debug.LogError(GetType() + "/PlayerExtenDataProxy()/不允许构造函数重复实例化，请检查");
            }
        }


        /// <summary>
        /// 得到本类实例
        /// </summary>
        /// <returns></returns>
        public static PlayerExtenDataProxy GetInstance()
        {
            if (_Instance != null)
            {
                return _Instance;
            }
            else
            {
                Debug.LogWarning("GetInstance()/请先调用构造函数");
                return null;
            }
        }//GetInstance_end

        #region 经验值
        /// <summary>
        /// 增加经验值
        /// </summary>
        /// <param name="ExpValues">经验数值</param>
        public void AddExp(int ExpValues)  //经验值只有增加，没有减少的
        {
              base.Experience += ExpValues;
            //经验值到达一定阶段，会自动提升等级（升级）
            UpgradeRule.GetInstance().UpgradeCondition(base.Experience);
           
        }

        /// <summary>
        /// 得到经验值
        /// </summary>
        /// <returns></returns>
        public int GetExp()
        {
            return base.Experience;
        }
        #endregion

        #region   杀敌数量
        /// <summary>
        /// 增加杀敌数量
        /// </summary>
        public void AddKillNumber()  
        {
            ++base.KillNumber;
        }

        /// <summary>
        /// 得到"杀敌数量"
        /// </summary>
        /// <returns></returns>
        public int GetKillNumber()
        {
            return base.KillNumber;
        }

        #endregion

        #region  等级

        /// <summary>
        /// 增加 等级
        /// </summary>
        public void AddLevel()
        {
            ++base.Level;
            //等级提升，相应玩家的最大核心数值会进行增加
            UpgradeRule.GetInstance().UpgradeOperation((LevelName)base.Level);      //数值型转换为枚举类型
        }

        /// <summary>
        /// 得到“当前 等级”
        /// </summary>
        /// <returns></returns>
        public int GetLevel()
        {
            return base.Level;
        }
        #endregion

        #region  金币
        /// <summary>
        /// 增加金币
        /// </summary>
        public void AddGold(int GoldNumber)
        {
            base.Gold += Mathf.Abs(GoldNumber);
        }

        /// <summary>
        /// 减少金币
        /// </summary>
        /// <param name="goldNum">金币</param>
        /// <returns>
        /// true:操作成功
        /// </returns>
        public bool DecreaseGold(int goldNum)
        {
            bool boolHandleFlag = false;                       //处理结果

            //钻石的余额不能为负数
            if (GetGold() - Mathf.Abs(goldNum) >= 0)
            {
                base.Gold -= Mathf.Abs(goldNum);
                boolHandleFlag = true;
            }
            else
            {
                boolHandleFlag = false;
            }
            return boolHandleFlag;
        }


        /// <summary>
        /// 得到当前金币
        /// </summary>
        /// <returns></returns>
        public int GetGold()
        {
            return base.Gold;
        }

        #endregion

        #region 钻石
        /// <summary>
        /// 增加钻石
        /// </summary>
        public void AddDiamonds(int DiamondNumber)
        {
            base.Diamonds += Mathf.Abs(DiamondNumber);
        }

        /// <summary>
        /// 减少钻石数量
        /// </summary>
        /// <param name="diamondNum"></param>
        /// <returns>
        /// true:处理成功
        /// </returns>
        public bool DecreaseDiamonds(int diamondNum)
        {
            bool boolHandleFlag = false;                       //处理结果

            //钻石的余额不能为负数
            if(GetDiamonds() - Mathf.Abs(diamondNum) >=0)
            {
                base.Diamonds -= Mathf.Abs(diamondNum);
                boolHandleFlag = true;                       
            }
            else
            {
                boolHandleFlag = false;
            }
            return boolHandleFlag;
        }

        /// <summary>
        /// 得到当前钻石数量
        /// </summary>
        /// <returns></returns>
        public int GetDiamonds()
        {
            return base.Diamonds;
        }

        #endregion

        /// <summary>
        /// 显示所有初始数值
        /// </summary>
        public void DisplayAllOriginalValues()
        {
            base.Experience = base.Experience;
            base.KillNumber = base.KillNumber;
            base.Level = base.Level;
            base.Gold = base.Gold;
            base.Diamonds = base.Diamonds; 

        }

    }//class_end
}

