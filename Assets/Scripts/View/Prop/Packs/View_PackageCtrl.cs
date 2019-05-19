/***
   *       Title: "英雄战神" 项目开发
   *       视图层：装备（背包）系统显示
   *       Description:
   *                作用：根据装备（背包）系统模型层后台的数据，显示背包系统的道具
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Kernal;
using Global;
using Model;

namespace View
{
    public class View_PackageCtrl : MonoBehaviour
    {
        //道具对象
        public GameObject goPropBloodBottle;           //血瓶
        public GameObject goPropMagicBottle;          //魔法瓶
        public GameObject goPropATK;                       //攻击力道具                 
        public GameObject goPropDEF;                       //防御力道具    
        public GameObject goPropDEX;                       //敏捷度道具  

        //道具数量
        public Text TxtPropBloodBottleNum;                //血瓶数量
        public Text TxtPropMagicBottleNum;                //魔法瓶数量




        void Awake()
        {
            //事件注册
            PlayerPackageData.evePlayPackageData += DisplayBloodBottle;
            PlayerPackageData.evePlayPackageData += DisplayMagicBottle;
            PlayerPackageData.evePlayPackageData += DisplayATKProp;
            PlayerPackageData.evePlayPackageData += DisplayDEFProp;
            PlayerPackageData.evePlayPackageData += DisplayDEXProp;
        }

         
        public void DisplayBloodBottle(KeyValuesUpdate kv)
        {
            if(kv.Key.Equals("BloodBottleNum"))
            {
                if(goPropBloodBottle && TxtPropBloodBottleNum)
                {
                    //如果道具数量大于等于1，则显示道具
                    if(System.Convert.ToInt32(kv.Values) >=1)
                    {
                        goPropBloodBottle.SetActive(true);
                        //显示血瓶的数量
                        TxtPropBloodBottleNum.text = kv.Values.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// 显示魔法瓶以及数量
        /// </summary>
        /// <param name="kv"></param>
        public void DisplayMagicBottle(KeyValuesUpdate kv)
        {
            if (kv.Key.Equals("MagicBottleNum"))
            {
                if (goPropMagicBottle && TxtPropMagicBottleNum)
                {
                    //如果道具数量大于等于1，则显示道具
                    if (System.Convert.ToInt32(kv.Values) >= 1)
                    {
                        goPropMagicBottle.SetActive(true);
                        //显示魔法瓶的数量
                        TxtPropMagicBottleNum.text = kv.Values.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// 显示攻击力道具
        /// </summary>
        /// <param name="kv"></param>
        public void DisplayATKProp(KeyValuesUpdate kv)
        {
            if (kv.Key.Equals("PropATKNum"))
            {
                if (goPropATK)
                {
                    //如果道具数量大于等于1，则显示道具
                    if (System.Convert.ToInt32(kv.Values) >= 1)
                    {
                        goPropATK.SetActive(true);
                    }
                }
            }
        }

        /// <summary>
        /// 防御力道具   
        /// </summary>
        /// <param name="kv"></param>
        public void DisplayDEFProp(KeyValuesUpdate kv)
        {
            if (kv.Key.Equals("PropDEFNum"))
            {
                if (goPropDEF)
                {
                    //如果道具数量大于等于1，则显示道具
                    if (System.Convert.ToInt32(kv.Values) >= 1)
                    {
                        goPropDEF.SetActive(true);
                    }
                }
            }
        }

        /// <summary> 
        /// 敏捷度道具   
        /// </summary>
        /// <param name="kv"></param>
        public void DisplayDEXProp(KeyValuesUpdate kv)
        {
            if (kv.Key.Equals("PropDEXNum"))
            {
                if (goPropDEX)
                {
                    //如果道具数量大于等于1，则显示道具
                    if (System.Convert.ToInt32(kv.Values) >= 1)
                    {
                        goPropDEX.SetActive(true);
                    }
                }
            }
        }

    }//Class_end
}
