/***
   *    Title: "英雄战神" 项目开发
   *     控制层：主城UI界面_内购商城控制层内部逻辑实现
   *    Description:
   *                [描述]
   *    Data:	[2018]
   *    Version: 0.1
 * */
using UnityEngine;
using System.Collections;
using Kernal;
using Global;
using Model;

namespace Control
{
    public class Ctrl_PanelMarket : BaseControl
    {
        public static Ctrl_PanelMarket Instance;           //本脚本实例

        void Awake()
        {
            Instance = this;
        }

        /// <summary>
        /// 10颗钻石充值
        /// </summary>
        /// <returns></returns>
        public bool Purchase10Diamond()
        {
            //说明：对接App Store 的收费SDK，进行实际玩家账户的扣费。（略）
            PlayerExtenDataProxy.GetInstance().AddDiamonds(10);
            return true;
        }

        /// <summary>
        /// 购买10枚金币
        /// </summary>
        /// <returns></returns>
        public bool Purchase10Gold()
        {
            bool boolResult =false;                                          //返回数值
            //购买10个金币，需要扣除你账户中的1颗钻石
            bool boolFlat = PlayerExtenDataProxy.GetInstance().DecreaseDiamonds(1);
            if(boolFlat)
            {
                PlayerExtenDataProxy.GetInstance().AddGold(10);
                boolResult = true;
            }
            else
            {
                boolResult = false;
            }
            return boolResult;
        }

        /// <summary>
        /// 购买5个血瓶
        /// </summary>
        /// <returns></returns>
        public bool Purchase5BloodBottle()
        {
            bool boolResult= false;                                //返回数值
            //购买5个血瓶，需要扣除你账户中的50个金币
            bool boolFlat = PlayerExtenDataProxy.GetInstance().DecreaseGold(50);
            if (boolFlat)
            {
                //需要编写专门的”背包系统“的模型层
                PlayerPackageDataProxy.GetInstance().IncreaseBloodBottleNum(5);
                boolResult = true;
            }
            else
            {
                boolResult = false;
            }
            return boolResult;
        }

        /// <summary>
        /// 5个魔法瓶
        /// </summary>
        /// <returns></returns>
        public bool Purchase5MagicBottle()
        {
            bool boolResult = false;                                //返回数值
            //购买5个魔法瓶，需要扣除你账户中的100个金币
            bool boolFlat = PlayerExtenDataProxy.GetInstance().DecreaseGold(100);
            if (boolFlat)
            {
                //需要编写专门的”背包系统“的模型层
                PlayerPackageDataProxy.GetInstance().IncreaseMagicNum(5);
                boolResult = true;
            }
            else
            {
                boolResult = false;
            }
            return boolResult;
        }

        /// <summary>
        /// 购买攻击力道具
        /// </summary>
        /// <returns></returns>
        public bool PurchaseATK()
        {
            bool boolResult = false;                                //返回数值
            //购买1个攻击力道具，需要扣除你账户中的50个金币
            bool boolFlat = PlayerExtenDataProxy.GetInstance().DecreaseGold(50);
            if (boolFlat)
            {
                //需要编写专门的”背包系统“的模型层
                PlayerPackageDataProxy.GetInstance().IncreaseATKPropNum(1);
                boolResult = true;
            }
            else
            {
                boolResult = false;
            }
            return boolResult;
        }


        /// <summary>
        /// 购买防御力道具
        /// </summary>
        /// <returns></returns>
        public bool PurchaseDEF()
        {
            bool boolResult = false;                                //返回数值
            //购买1个攻击力道具，需要扣除你账户中的50个金币
            bool boolFlat = PlayerExtenDataProxy.GetInstance().DecreaseGold(30);
            if (boolFlat)
            {
                //需要编写专门的”背包系统“的模型层
                PlayerPackageDataProxy.GetInstance().IncreaseDEFPropNum(1);
                boolResult = true;
            }
            else
            {
                boolResult = false;
            }
            return boolResult;
        }

        /// <summary>
        /// 购买敏捷度道具
        /// </summary>
        /// <returns></returns>
        public bool PurchaseDEX()
        {
            bool boolResult = false;                                //返回数值
            //购买1个攻击力道具，需要扣除你账户中的50个金币
            bool boolFlat = PlayerExtenDataProxy.GetInstance().DecreaseGold(20);
            if (boolFlat)
            {
                //需要编写专门的”背包系统“的模型层
                PlayerPackageDataProxy.GetInstance().IncreaseDEXPropNum(1);
                boolResult = true;
            }
            else
            {
                boolResult = false;
            }
            return boolResult;
        }
    }
}

