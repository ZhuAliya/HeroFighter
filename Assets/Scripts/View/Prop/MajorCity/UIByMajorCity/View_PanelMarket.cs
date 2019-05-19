/***
   *       Title: "英雄战神" 项目开发
   *       视图层：主城UI界面_内购商城
   *       Description:
   *                [描述]
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Kernal;
using Global;
using Control;


namespace View
{
    public class View_PanelMarket : MonoBehaviour
    {
        //道具说明显示
        public Text Txt_10_Diamonds;                          //10颗钻石
        public Text Txt_10_Golds;                                 //10给金币
        public Text Txt_5_BloodBottle;                          //5个血瓶
        public Text Txt_5_MagicBottle;                          //5个魔法瓶
        public Text Txt_1_AttackProp;                           //攻击力道具
        public Text Txt_1_DefenceProp;                        //防御力道具
        public Text Txt_1_DexterityProp;                       //敏捷度道具
        //响应的案件
        public Button Btn_10_Diamonds;                      //10颗钻石
        public Button Btn_10_Golds;                            //10给金币
        public Button Btn_5_BloodBottle;                     //5个血瓶
        public Button Btn_5_MagicBottle;                    //5个魔法瓶
        public Button Btn_1_AttackProp;                      //攻击力道具
        public Button Btn_1_DefenceProp;                   //防御力道具
        public Button Btn_1_DexterityProp;                  //敏捷度道具
        //得到道具的文字说明
        public Text TxtGoodsDescription;                       //具体商品的描述




        void Awake()
        {
            RigisterTxtAndBtn();
        }


        /// <summary>
        /// 注册相关按钮
        /// </summary>
       private void RigisterTxtAndBtn()
        {
            /*文字的注册*/
            if(Txt_10_Diamonds != null)
            {
                EventTriggerListener.Get(Txt_10_Diamonds.gameObject).onClick += Display_10Diamonds;
            }

            if (Txt_10_Golds != null)
            {
                EventTriggerListener.Get(Txt_10_Golds.gameObject).onClick += Display_10Golds;
            }

            if (Txt_5_BloodBottle != null)
            {
                EventTriggerListener.Get(Txt_5_BloodBottle.gameObject).onClick += Display_5BloodBottle;
            }

            if (Txt_5_MagicBottle != null)
            {
                EventTriggerListener.Get(Txt_5_MagicBottle.gameObject).onClick += Display_5MagicBottle;
            }

            if (Txt_1_AttackProp != null)
            {
                EventTriggerListener.Get(Txt_1_AttackProp.gameObject).onClick += Display_AttackProp;
            }

            if (Txt_1_DefenceProp != null)
            {
                EventTriggerListener.Get(Txt_1_DefenceProp.gameObject).onClick += Display_DefenceProp;
            }

            if (Txt_1_DexterityProp != null)
            {
                EventTriggerListener.Get(Txt_1_DexterityProp.gameObject).onClick += Display_DexterityProp;
            }

            /*按键的注册*/
            if (Btn_10_Diamonds != null)
            {
                EventTriggerListener.Get(Btn_10_Diamonds.gameObject).onClick += Purchase10Diamond;
            }

            if (Btn_10_Golds != null)
            {
                EventTriggerListener.Get(Btn_10_Golds.gameObject).onClick += Purchase10Golds;
            }
            if (Btn_5_BloodBottle != null)
            {
                EventTriggerListener.Get(Btn_5_BloodBottle.gameObject).onClick += Purchase5BloodBottle;
            }
            if (Btn_5_MagicBottle != null)
            {
                EventTriggerListener.Get(Btn_5_MagicBottle.gameObject).onClick += Purchase5MagicBottle;
            }
            if (Btn_1_AttackProp != null)
            {
                EventTriggerListener.Get(Btn_1_AttackProp.gameObject).onClick += PurchaseAttackProp;
            }
            if (Btn_1_DefenceProp != null)
            {
                EventTriggerListener.Get(Btn_1_DefenceProp.gameObject).onClick += PurchaseDefenceProp;
            }
            if (Btn_1_DexterityProp != null)
            {
                EventTriggerListener.Get(Btn_1_DexterityProp.gameObject).onClick += PurchaseDexterityProp;
            }

        }

        #region 商品的显示信息
        //10颗钻石
        private void Display_10Diamonds(GameObject go)
        {
            if(go== Txt_10_Diamonds.gameObject)
            {
                TxtGoodsDescription.text = "充值10颗钻石，1颗钻石等于1人民币。";
            }
        }

        //10个金币
        private void Display_10Golds(GameObject go)
        {
            if (go == Txt_10_Golds.gameObject)
            {
                TxtGoodsDescription.text = "1颗钻石，可以购买10金币。";
            }
        }

        //5个血瓶
        private void Display_5BloodBottle(GameObject go)
        {
            if (go == Txt_5_BloodBottle.gameObject)
            {
                TxtGoodsDescription.text = "5个血瓶，需要50个金币！";
            }
        }

        //5个魔法瓶
        private void Display_5MagicBottle(GameObject go)
        {
            if (go == Txt_5_MagicBottle.gameObject)
            {
                TxtGoodsDescription.text = "5个魔法瓶，需要100个金币！";
            }
        }

        //攻击力道具
        private void Display_AttackProp(GameObject go)
        {
            if (go == Txt_1_AttackProp.gameObject)
            {
                TxtGoodsDescription.text = "倚天剑，需要50金币！";
            }
        }
        //防御力道具
        private void Display_DefenceProp(GameObject go)
        {
            if (go == Txt_1_DefenceProp.gameObject)
            {
                TxtGoodsDescription.text = "超级护盾，需要30金币！";
            }
        }
        //敏捷度道具
        private void Display_DexterityProp(GameObject go)
        {
            if (go == Txt_1_DexterityProp.gameObject)
            {
                TxtGoodsDescription.text = "千里\"金靴\",需要20金币！";
            }
        }
        #endregion

        #region  商品的点击响应
        /// <summary>
        /// 充值10颗钻石
        /// </summary>
        /// <param name="go"></param>
        private void Purchase10Diamond(GameObject go)
        {
            if(go == Btn_10_Diamonds.gameObject)
            {
                //返回结果
                bool boolResult = false;
                //调用商城的逻辑层脚本
                boolResult = Ctrl_PanelMarket.Instance.Purchase10Diamond();
                if(boolResult)
                {
                    TxtGoodsDescription.text = "10颗钻石，充值成功";
                }
                else
                {
                    TxtGoodsDescription.text = "10颗钻石充值不成功，请联系运营人员！";
                }                 
            }
        }
        //购买10个金币
        private void Purchase10Golds(GameObject go)
        {
            if (go == Btn_10_Golds.gameObject)
            {
                //返回结果
                bool boolResult = false;
                //调用商城的逻辑层脚本
                boolResult = Ctrl_PanelMarket.Instance.Purchase10Gold();
                if (boolResult)
                {
                    TxtGoodsDescription.text = "购买10枚金币成功";
                }
                else
                {
                    TxtGoodsDescription.text = "购买10枚金币不成功，请联系运营人员！";
                }
            }
        }

        /// <summary>
        /// 购买5个血瓶
        /// </summary>
        /// <param name="go"></param>
        private void Purchase5BloodBottle(GameObject go)
        {
            if (go == Btn_5_BloodBottle.gameObject)
            {
                //返回结果
                bool boolResult = false;
                //调用商城的逻辑层脚本
                boolResult = Ctrl_PanelMarket.Instance.Purchase5BloodBottle();
                if (boolResult)
                {
                    TxtGoodsDescription.text = "购买5个血瓶成功";
                }
                else
                {
                    TxtGoodsDescription.text = "购买5个血瓶不成功，请联系运营人员！";
                }
            }
        }

        /// <summary>
        /// 购买5个魔法瓶
        /// </summary>
        /// <param name="go"></param>
        private void Purchase5MagicBottle(GameObject go)
        {
            if (go == Btn_5_MagicBottle.gameObject)
            {
                //返回结果
                bool boolResult = false;
                //调用商城的逻辑层脚本
                boolResult = Ctrl_PanelMarket.Instance.Purchase5MagicBottle();
                if (boolResult)
                {
                    TxtGoodsDescription.text = "购买5个魔法瓶成功";
                }
                else
                {
                    TxtGoodsDescription.text = "购买5个魔法瓶不成功，请联系运营人员！";
                }
            }
        }

        /// <summary>
        /// 购买攻击力道具
        /// </summary>
        /// <param name="go"></param>
        private void PurchaseAttackProp(GameObject go)
        {
            if (go == Btn_1_AttackProp.gameObject)
            {
                //返回结果
                bool boolResult = false;
                //调用商城的逻辑层脚本
                boolResult = Ctrl_PanelMarket.Instance.PurchaseATK();
                if (boolResult)
                {
                    TxtGoodsDescription.text = "购买攻击力道具成功";
                }
                else
                {
                    TxtGoodsDescription.text = "购买攻击力道具不成功，请联系运营人员！";
                }
            }
        }

        /// <summary>
        /// 购买防御力道具
        /// </summary>
        /// <param name="go"></param>
        private void PurchaseDefenceProp(GameObject go)
        {
            if (go == Btn_1_DefenceProp.gameObject)
            {
                //返回结果
                bool boolResult = false;
                //调用商城的逻辑层脚本
                boolResult = Ctrl_PanelMarket.Instance.PurchaseDEF();
                if (boolResult)
                {
                    TxtGoodsDescription.text = "购买防御力道具成功";
                }
                else
                {
                    TxtGoodsDescription.text = "购买防御力道具不成功，请联系运营人员！";
                }
            }
        }

        /// <summary>
        /// 购买敏捷度道具
        /// </summary>
        /// <param name="go"></param>
        private void PurchaseDexterityProp(GameObject go)
        {
            if (go == Btn_1_DexterityProp.gameObject)
            {
                //返回结果
                bool boolResult = false;
                //调用商城的逻辑层脚本
                boolResult = Ctrl_PanelMarket.Instance.PurchaseDEX();
                if (boolResult)
                {
                    TxtGoodsDescription.text = "购买敏捷度道具成功";
                }
                else
                {
                    TxtGoodsDescription.text = "购买敏捷度道具不成功，请联系运营人员！";
                }
            }
        }
        #endregion
    }//Class_end
}

