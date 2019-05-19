/***
   *       Title: "英雄战神" 项目开发
   *       模型层：玩家背包数据代理类
   *                    
   *       Description:
   *                作用：封装核心背包数据，向外提供各种方法（增加、减少、查询相关数值）
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using System.Collections;
using Kernal;
using Global;

namespace Model
{
    public class PlayerPackageDataProxy: PlayerPackageData
    {
        private static PlayerPackageDataProxy _Instance = null;  //本类的实例

        /*带参构造函数*/
        public PlayerPackageDataProxy(int bloodBottleNum, int magicBottleNum, int atkNum, int defNum, int dexNum):base
          (bloodBottleNum, magicBottleNum, atkNum, defNum, dexNum)
        {
            if(_Instance == null)
            {
                _Instance = this;
            }
            else
            {
                Debug.LogError(GetType() + "/PlayerPackageDataProxy()/不允许构造函数的重复实例化");
            }
        }

        /// <summary>
        /// 得到本类的实例
        /// </summary>
        /// <returns></returns>
        public static PlayerPackageDataProxy GetInstance()
        {
            if(_Instance != null)
            {
                return _Instance;
            }
            else
            {
                Debug.LogError("PlayerPackageDataProxy.cs/GetInstance()/请先调用构造函数！");
                return null;
            }
        }

        /*血瓶数量*/
        #region 血瓶数量
        /// <summary>
        /// 增加血瓶数量
        /// </summary>
        /// <param name="bloodNum"></param>
        public void IncreaseBloodBottleNum(int bloodNum)
        {
            base.BloodBottleNum += Mathf.Abs(bloodNum);
        }

        /// <summary>
        /// 减少当前血瓶数量
        /// </summary>
        /// <param name="bloodNum"></param>
        public void DecreaseBloodBottleNum(int bloodNum)
        {
            if (base.BloodBottleNum - Mathf.Abs(bloodNum) >= 0)
            {
                base.BloodBottleNum += Mathf.Abs(bloodNum);
            }
        }

        /// <summary>
        /// 显示当前血瓶数量
        /// </summary>
        /// <param name="bloodNum"></param>
        public int DisplayBloodBottleNum()
        {
            return base.BloodBottleNum;
        }
        #endregion

        /*魔法瓶数量*/
        #region 魔法瓶数量
        /// <summary>
        /// 增加魔法瓶数量
        /// </summary>
        /// <param name="magicNum"></param>
        public void IncreaseMagicNum(int magicNum)
        {
            base.MagicBottleNum += Mathf.Abs(magicNum);
        }

        /// <summary>
        /// 减少当前魔法瓶数量
        /// </summary>
        /// <param name="magicNum"></param>
        public void DecreaseMagicNum(int magicNum)
        {
            if (base.MagicBottleNum - Mathf.Abs(magicNum) >= 0)
            {
                base.MagicBottleNum += Mathf.Abs(magicNum);
            }
        }

        /// <summary>
        ///  显示当前魔法瓶数量
        /// </summary>
        /// <returns></returns>
        public int DisplayMagicNum()
        {
            return base.MagicBottleNum;
        }
        #endregion

        /*攻击力道具数量*/
        #region 攻击力道具数量
        /// <summary>
        ///  增加攻击力道具数量
        /// </summary>
        /// <param name="atkNum"></param>
        public void IncreaseATKPropNum(int atkNum)
        {
            base.PropATKNum += Mathf.Abs(atkNum);
        }

        /// <summary>
        ///  减少攻击力道具数量
        /// </summary>
        /// <param name="atkNum"></param>
        public void DecreaseATKPropNum(int atkNum)
        {
            if (base.PropATKNum - Mathf.Abs(atkNum) >= 0)
            {
                base.PropATKNum += Mathf.Abs(atkNum);
            }
        }

        /// <summary>
        /// 显示攻击力道具数量
        /// </summary>
        /// <returns></returns>
        public int DisplayATKPropNum()
        {
            return base.PropATKNum;
        }

        #endregion

        /*防御力道具数量*/
        #region 防御力道具数量
        /// <summary>
        /// 增加防御力道具数量
        /// </summary>
        /// <param name="defNum"></param>
        public void IncreaseDEFPropNum(int defNum)
        {
            base.PropDEFNum += Mathf.Abs(defNum);
        }

        /// <summary>
        /// 减少防御力道具数量
        /// </summary>
        /// <param name="defNum"></param>
        public void DecreaseDEFPropNum(int defNum)
        {
            if (base.PropDEFNum - Mathf.Abs(defNum) >= 0)
            {
                base.PropDEFNum += Mathf.Abs(defNum);
            }
        }

        /// <summary>
        /// 显示防御力道具数量
        /// </summary>
        /// <returns></returns>
        public int DisplayDEFPropNum()
        {
            return base.PropDEFNum;
        }

        #endregion

        /*敏捷度道具数量*/
        #region 敏捷度道具数量
        /// <summary>
        /// 增加敏捷度道具数量
        /// </summary>
        /// <param name="dexNum"></param>
        public void IncreaseDEXPropNum(int dexNum)
        {
            base.PropDEXNum += Mathf.Abs(dexNum);
        }

        /// <summary>
        /// 减少敏捷度道具数量
        /// </summary>
        /// <param name="dexNum"></param>
        public void DecreaseDEXPropNum(int dexNum)
        {
            if (base.PropDEXNum - Mathf.Abs(dexNum) >= 0)
            {
                base.PropDEXNum += Mathf.Abs(dexNum);
            }
        }

        /// <summary>
        /// 显示敏捷度道具数量
        /// </summary>
        /// <returns></returns>
        public int DisplayDEXPropNum()
        {
            return base.PropDEXNum;
        }

        #endregion
    }//Class_end
}

