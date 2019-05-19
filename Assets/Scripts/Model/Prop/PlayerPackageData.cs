/***
   *       Title: "英雄战神" 项目开发
   *       模型层：玩家背包数据核心类
   *                    
   *       Description:
   *                作用：
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using System.Collections;
using Kernal;
using Global;

namespace Model
{
    public class PlayerPackageData 
    {
        //定义事件
        public static del_PlayerKernalModel evePlayPackageData;    //玩家背包数据事件
        private int _IntBloodBottleNum;                                          //血瓶数量
        private int _IntMagicNum;                                                   //魔法瓶数量
        private int _IntPropATKNum;                                               //攻击力道具数量
        private int _IntPropDEFNum;                                               //防御力道具数量
        private int _IntPropDEXNum;                                               //敏捷度道具数量

        /*属性定义*/
        public int BloodBottleNum
        {
            get { return _IntBloodBottleNum; }
            set {
                _IntBloodBottleNum = value;
                //事件调用
                if(evePlayPackageData != null)
                {
                    Log.Write(GetType() + "/BloodBottleNum", Log.Level.Special);
                    KeyValuesUpdate kv = new KeyValuesUpdate("BloodBottleNum", BloodBottleNum);
                    evePlayPackageData(kv);
                }
            }

        }

        public int MagicBottleNum
        {
            get { return _IntMagicNum; }
            set {
                _IntMagicNum = value;
                //事件调用
                if (evePlayPackageData != null)
                {
                    Log.Write(GetType() + "/MagicBottleNum", Log.Level.Special);
                    KeyValuesUpdate kv = new KeyValuesUpdate("MagicBottleNum", MagicBottleNum);
                    evePlayPackageData(kv);
                }

            }
        }

        public int PropATKNum
        {
            get { return _IntPropATKNum; }
            set {
                _IntPropATKNum = value;
                //事件调用
                if (evePlayPackageData != null)
                {
                    KeyValuesUpdate kv = new KeyValuesUpdate("PropATKNum", PropATKNum);
                    evePlayPackageData(kv);
                }
            }
        }

        public int PropDEFNum
        {
            get { return _IntPropDEFNum; }
            set {
                _IntPropDEFNum = value;
                //事件调用
                if (evePlayPackageData != null)
                {
                    KeyValuesUpdate kv = new KeyValuesUpdate("PropDEFNum", PropDEFNum);
                    evePlayPackageData(kv);
                }
            }
        }

        public int PropDEXNum
        {
            get { return _IntPropDEXNum; }
            set {
                _IntPropDEXNum = value;
                //事件调用
                if (evePlayPackageData != null)
                {
                    KeyValuesUpdate kv = new KeyValuesUpdate("PropDEXNum", PropDEXNum);
                    evePlayPackageData(kv);
                }
            }
        }




        //定义私有的构造函数
        private PlayerPackageData() { }

        //公共构造函数
        public PlayerPackageData(int bloodBottleNum, int magicBottleNum, int ATKNum, int DEFNum, int DEXNum)
        {
            this._IntBloodBottleNum = bloodBottleNum;
            this.MagicBottleNum = magicBottleNum;
            this._IntPropATKNum = ATKNum;
            this._IntPropDEFNum = DEFNum;
            this._IntPropDEXNum = DEXNum;

        }

    }//Class_end
}

