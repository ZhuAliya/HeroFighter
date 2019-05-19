/***
   *        Title: "英雄战神" 项目开发
   *    测试类：测试模型数据使用
   *      Description:
   *                
   *       Data:	[2018]
   *       Version: 0.1
 * */

using UnityEngine;
using System.Collections;
using Global;
using Model;
using UnityEngine.UI;


namespace View
{
    public class TestModelLayer : MonoBehaviour
    {
        public Text TxtHP;
        public Text TxtMaxHP;
        public Text TxtMP;
        public Text TxtMaxMP;
        public Text TxtATK;
        public Text TxtMaxATK;
        public Text TxtDEF;
        public Text TxtMaxDEF;
        public Text TxtDEX;
        public Text TxtMaxDEX;

        //扩展数值
        public Text TxtExp;
        public Text TxtKillNum;
        public Text TxtLevel;
        public Text TxtGold;
        public Text TxtDiamond;


        void Awake()    
        {
            //核心数值事件注册
            PlayerKernalData.evePlayerKernalData += DisplayHP;
            PlayerKernalData.evePlayerKernalData += DisplayMaxHP;              
            PlayerKernalData.evePlayerKernalData += DisplayMP;
            PlayerKernalData.evePlayerKernalData += DisplayMaxMP;
            PlayerKernalData.evePlayerKernalData += DisplayATK;
            PlayerKernalData.evePlayerKernalData += DisplayMaxATK;
            PlayerKernalData.evePlayerKernalData += DisplayDEF;
            PlayerKernalData.evePlayerKernalData += DisplayMaxDEF;
            PlayerKernalData.evePlayerKernalData += DisplayDEX;
            PlayerKernalData.evePlayerKernalData += DisplayMaxDEX;

            //扩展数值事件注册
            PlayerExtenData.evePlayerExtenalData += DisplayExp;
            PlayerExtenData.evePlayerExtenalData +=DisplayKillNumber ;
            PlayerExtenData.evePlayerExtenalData += DisplayLevel;
            PlayerExtenData.evePlayerExtenalData += DisplayGold;
            PlayerExtenData.evePlayerExtenalData += DisplayDiamonds;
        }



        void Start()
        {
            PlayerKernalDataProxy playerKernalDataObj = new PlayerKernalDataProxy(100, 100, 10, 5, 45,
                100, 100, 10, 5, 50, 0, 0, 0);  //核心数值初始化
            PlayerExtenDataProxy playerExternalDataObj = new PlayerExtenDataProxy(0, 0, 0, 0, 0);//扩展数值初始化
            //显示所有的初始值 
            PlayerKernalDataProxy.GetInstance().DisplayAllOriginalValues();
            PlayerExtenDataProxy.GetInstance().DisplayAllOriginalValues();
        }
        
        #region 事件用户点击
        public void IncreaseHP() //增加生命值
        {
            //调用模型层的方法
            PlayerKernalDataProxy.GetInstance().IncreaseHealthValues(30);
        }

        public void decreaseHP() //减少生命值
        {
            //调用模型层的方法
            PlayerKernalDataProxy.GetInstance().DecreaseHealthValues(10);
        }

        public void IncreaseMagic()
        {
            //调用模型层的方法
            PlayerKernalDataProxy.GetInstance().IncreaseMagicValues(30);
        }

        public void  DecreaseMagic()
        {
            //调用模型层的方法
            PlayerKernalDataProxy.GetInstance().DecreaseMagicValues(15);
        }

        public void IncreaseExp()
        {
            //调用模型层的方法
            PlayerExtenDataProxy.GetInstance().AddExp(30);
        }


        #endregion

        #region  事件注册的方法
        /* 核心数值*/
        private void DisplayHP(KeyValuesUpdate kv)
        {
            if(kv.Key.Equals("Health"))
            {
                TxtHP.text = kv.Values.ToString();
            }
        }

        private void DisplayMaxHP(KeyValuesUpdate kv)
        {
            if (kv.Key.Equals("MaxHealth"))
            {
                TxtMaxHP.text = kv.Values.ToString();
            }
        }

        private void DisplayMP(KeyValuesUpdate kv)
        {
            if (kv.Key.Equals("Magic"))
            {
                TxtMP.text = kv.Values.ToString();
            }
        }

        private void DisplayMaxMP(KeyValuesUpdate kv)
        {
            if (kv.Key.Equals("MaxMagic"))
            {
                TxtMaxMP.text = kv.Values.ToString();
            }
        }

        private void DisplayATK(KeyValuesUpdate kv)
        {
            if (kv.Key.Equals("Attack"))
            {
                TxtATK.text = kv.Values.ToString();
            }
        }

        private void DisplayMaxATK(KeyValuesUpdate kv)
        {
            if (kv.Key.Equals("MaxAttack"))
            {
                TxtMaxATK.text = kv.Values.ToString();
            }
        }


        private void DisplayDEF(KeyValuesUpdate kv)
        {
            if (kv.Key.Equals("Defence"))
            {
                TxtDEF.text = kv.Values.ToString();
            }
        }

        private void DisplayMaxDEF(KeyValuesUpdate kv)
        {
            if (kv.Key.Equals("MaxDefence"))
            {
                TxtMaxDEF.text = kv.Values.ToString();
            }
        }

        private void DisplayDEX(KeyValuesUpdate kv)
        {
            if (kv.Key.Equals("Dexterity"))
            {
                TxtDEX.text = kv.Values.ToString();
            }
        }

        private void DisplayMaxDEX(KeyValuesUpdate kv)
        {
            if (kv.Key.Equals("MaxDexterity"))
            {
                TxtMaxDEX.text = kv.Values.ToString();
            }
        }

        /* 扩展数值*/
        void DisplayExp(KeyValuesUpdate kv)
        {
            if (kv.Key.Equals("Experience"))
            {
                TxtExp.text = kv.Values.ToString();
            }
        }

        void DisplayKillNumber(KeyValuesUpdate kv)
        {
            if (kv.Key.Equals("KillNumber"))
            {
                TxtKillNum.text = kv.Values.ToString();
            }
        }

        void DisplayLevel(KeyValuesUpdate kv)
        {
            if (kv.Key.Equals("Level"))
            {
                TxtLevel.text = kv.Values.ToString();
            }
        }

        void DisplayGold(KeyValuesUpdate kv)
        {
            if (kv.Key.Equals("Gold"))
            {
                TxtGold.text = kv.Values.ToString();
            }
        }

        void DisplayDiamonds(KeyValuesUpdate kv)
        {
            if (kv.Key.Equals("Diamonds"))
            {
                TxtDiamond.text = kv.Values.ToString();
            }
        }
        #endregion
    }
}

