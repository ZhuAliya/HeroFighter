/***
   *        Title: "英雄战神" 项目开发
   *        控制层：英雄属性脚本
   *      Description:
   *                1.实例化对应模型层且初始化数据
   *                2.整个模型层关于“玩家”（Player）模块的核心方法，供本控制层其他脚本调用
   *       Data:	[2018]
   *       Version: 0.1
 * */

using UnityEngine;
using System.Collections;
using Global;
using Model;
namespace Control
{
    public class Ctrl_HeroProperty :BaseControl
    {
        public static Ctrl_HeroProperty Instance;                                                       //本类实例

        //玩家核心数值
        public float FloPlayerCurrentHP = 1000F;//100;                                                         // 当前生命值
        public float FloPlayerMaxHP = 1000;// 100;                                                              //最大生命值    
        public float FloPlayerCurrentMP = 1000;//100;                                                         //当前魔法值        
        public float FloPlayerMaxMP = 1000;//100;                                                                //最大魔法值
        public float FloPlayerCurrentATK = 10;                                                         // 当前攻击力   
        public float FloPlayerMaxATK =10;                                                               // 最大攻击力        
        public float FloPlayerCurrentDEF =5;                                                           // 当前防御力
        public float FloPlayerMaxDEF = 5;                                                               // 最大防御力   
        public float FloPlayerCurrentDEX = 45;                                                       // 当前敏捷度        
        public float FloPlayerMaxDEX = 50;                                                            //最大敏捷度 

        public float FloATKByProp = 0F;                                                                 //道具攻击力
        public float FloDEFByProp = 0F;                                                                //道具防御力
        public float FloDEXByProp = 0F;                                                               //道具敏捷度               

        //玩家扩展数值
        public int IntEXP = 0;                                                                                    //经验值
        public int IntLevel = 0;                                                                                   //等级
        public int IntKillNum = 0;                                                                               //杀敌数量
        public int IntGold = 0;                                                                                    //金币
        public int IntDiamond = 0;                                                                            //钻石

        //玩家背包数值
        public int IntBooldBottleNum = 0;                                      //血瓶数量
        public int IntMagicBottleNum = 0;                                      //魔法瓶数值
        public int IntATKNum = 0;                                              //攻击力道具数量
        public int IntDEFNum = 0;                                              //防御力道具数量
        public int IntDEXNum = 0;                                              //敏捷度道具数量

        void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            //初始化模型层数据
            PlayerKernalDataProxy playerKernalDataObj = new PlayerKernalDataProxy(FloPlayerCurrentHP, FloPlayerCurrentMP, FloPlayerCurrentATK, FloPlayerCurrentDEF, FloPlayerCurrentDEX,
           FloPlayerMaxHP, FloPlayerMaxMP, FloPlayerMaxATK, FloPlayerMaxDEF, FloPlayerMaxDEX, FloATKByProp, FloDEFByProp, FloDEXByProp);  //核心数值初始化
            PlayerExtenDataProxy playerExternalDataObj = new PlayerExtenDataProxy(IntEXP, IntKillNum, IntLevel, IntGold, IntDiamond);//扩展数值初始化

            //Add By 2019.05
            //英雄背包数据的实例化
            PlayerPackageDataProxy playerPackageData = new PlayerPackageDataProxy(IntBooldBottleNum, IntMagicBottleNum, IntATKNum, IntDEFNum, IntDEXNum);
        }

        #region 生命数值操作（5个方法）
        /// <summary>
        /// 减少生命数值（典型应用场景：被敌人攻击）
        /// 公式： _Health =_Health -(敌人的攻击力 - 主角的防御力 - 主角武器防御力)；
        /// </summary>
        /// <param name="enemyAttackValue">敌人的攻击力</param>
        public void DecreaseHealthValues(float enemyAttackValue)
        {
            if(enemyAttackValue > 0)
            {
                PlayerKernalDataProxy.GetInstance().DecreaseHealthValues(enemyAttackValue);
            }            
        }

        /// <summary>
        /// 增加生命数值（典型应用场景：获得["吃"]血包）
        /// </summary>
        /// <param name="healthValue"></param>
        public void IncreaseHealthValues(float healthValue)
        {
            if(healthValue >0)
            {
                PlayerKernalDataProxy.GetInstance().IncreaseHealthValues(healthValue);
            }            
        }

        /// <summary>
        /// 得到当前主角的生命数值
        /// </summary>
        /// <returns></returns>
        public float GetCurrentHealth()
        {
            return PlayerKernalDataProxy.GetInstance().GetCurrentHealth();
        }

        /// <summary>
        /// 增加最大生命数值（应用场景：等级提升[即：升级]）
        /// </summary>
        /// <param name="increaseHealth">增量健康数值</param>
        public void IncreaseMaxHealth(float increaseHealth)
        {
            // base.MaxHealth += Mathf.Abs(increaseHealth);
            if(increaseHealth >0)
            {
                PlayerKernalDataProxy.GetInstance().IncreaseMaxHealth(increaseHealth);
            }           
        }

        /// <summary>
        /// 得到最大生命数值
        /// </summary>
        /// <returns></returns>
        public float GetMaxHealth()
        {
            return PlayerKernalDataProxy.GetInstance().GetMaxHealth();
        }

        #endregion

        #region 魔法数值操作 （5个方法）
        /// <summary>
        /// 减少魔法数值(典型应用场景：释放“大招”)   【释放大招减少魔法值】
        /// 公式： _Magic = _Magic(释放一次“特定魔法”的损耗)
        /// </summary>
        /// <param name="magicValue">魔法数值损耗</param>
        public void DecreaseMagicValues(float magicValue)
        {
            if(magicValue > 0)
            {
                PlayerKernalDataProxy.GetInstance().DecreaseMagicValues(magicValue);
            }           
        }

        /// <summary>
        /// 增加魔法数值（典型应用场景：获得["吃"]魔法包）
        /// </summary>
        /// <param name="magicValue">魔法增量</param>
        public void IncreaseMagicValues(float magicValue)
        {
            if(magicValue >0)
            {
                PlayerKernalDataProxy.GetInstance().IncreaseMagicValues(magicValue);
            }          
        }

        /// <summary>
        /// 得到当前主角的魔法数值
        /// </summary>
        /// <returns></returns>
        public float GetCurrentMagic()
        {
            return PlayerKernalDataProxy.GetInstance().GetCurrentMagic();
        }

        /// <summary>
        /// 增加最大魔法数值（应用场景：等级提升[即：升级]）
        /// </summary>
        /// <param name="increaseHealth">增加健康数值</param>
        public void IncreaseMaxMagic(float increaseMagic)
        {
            if(increaseMagic > 0)
            {
                PlayerKernalDataProxy.GetInstance().IncreaseMaxMagic(increaseMagic);
            }                
        }

        /// <summary>
        /// 得到最大魔法数值
        /// </summary>
        /// <returns></returns>
        public float GetMaxMagic()
        {
            return PlayerKernalDataProxy.GetInstance().GetMaxMagic();
        }
        #endregion

        #region  攻击力数值操作 （4个方法）
        /// <summary>
        /// _AttackForce =MaxATK/2*(_Health/MaxHealth)+[武器攻击力“];
        /// 更新攻击力（典型应用场景：当主角健康数值改变，或者取得了新的武器道具）
        /// </summary>
        /// <param name="newWeaponValues">新武器（道具）数值</param>
        public void UpdateATKValue(float newWeaponValues = 0)
        {
             PlayerKernalDataProxy.GetInstance().UpdateATKValue(newWeaponValues);
        }

        /// <summary>
        /// 得到当前主角的攻击力数值
        /// </summary>
        /// <returns></returns>
        public float GetCurrentATK()
        {
            return PlayerKernalDataProxy.GetInstance().GetCurrentATK();
        }

        /// <summary>
        /// 增加最大攻击力数值（应用场景：等级提升[即：升级]）
        /// </summary>
        /// <param name=" IncreaseMaxATK">增加攻击力增量数值</param>
        public void IncreaseMaxATK(float increaseATK)
        {
            if(increaseATK > 0)
            {
                PlayerKernalDataProxy.GetInstance().IncreaseMaxATK(increaseATK);
            }           
        }

        /// <summary>
        /// 得到最大攻击力数值
        /// </summary>
        /// <returns></returns>
        public float GetMaxATK()
        {
            return PlayerKernalDataProxy.GetInstance().GetMaxATK();
        }
        #endregion

        #region  防御力数值操作  （4个方法）
        //公式：_Defence = MaxDEF/2 *(_Health/MaxHealth) +[武器防御力]；
        /// <summary>
        /// 更新防御力（典型应用场景：当主角健康数值改变，或者取得了新的武器道具）
        /// </summary>
        /// <param name="newWeaponValues">新防御武器（道具）数值</param>
        public void UpdateDEFValue(float newWeaponDEFValues = 0)
        {
            if(newWeaponDEFValues > 0)
            {
                PlayerKernalDataProxy.GetInstance().UpdateDEFValue();
            }           
        }

        /// <summary>
        /// 得到当前主角的防御力数值
        /// </summary>
        /// <returns></returns>
        public float GetCurrentDEF()
        {
            return PlayerKernalDataProxy.GetInstance().GetCurrentDEF();
        }

        /// <summary>
        /// 增加最大防御力数值（应用场景：等级提升[即：升级]） 
        /// </summary>
        /// <param name=" IncreaseMaxDEF">增加防御力增量数值</param>
        public void IncreaseMaxDEF(float increaseDEF)
        {
            if(increaseDEF > 0)
            {
                PlayerKernalDataProxy.GetInstance().IncreaseMaxDEF(increaseDEF);
            }           
        }

        /// <summary>
        /// 得到最大防御力数值
        /// </summary>
        /// <returns></returns>
        public float GetMaxDEF()
        {
            return PlayerKernalDataProxy.GetInstance().GetMaxDEF();
        }

        #endregion

        #region  敏捷度数值操作  （4个方法）
        //公式：_MoveSpeed = MaxMoveSpeed/2 *(_Health/MaxHealth) - _Defence+[道具敏捷力]
        /// <summary>
        /// 更新敏捷度（典型应用场景：当主角健康数值、防御力改变，或者取得了新的武器道具）
        /// </summary>
        /// <param name="newWeaponValues">新武器（道具）数值</param>
        public void UpdateDEXValue(float newWeaponValues = 0)
        {
            PlayerKernalDataProxy.GetInstance().UpdateDEXValue(newWeaponValues);
        }

        /// <summary>
        /// 得到当前主角的敏捷度数值
        /// </summary>
        /// <returns></returns>
        public float GetCurrentDEX()
        {
            return PlayerKernalDataProxy.GetInstance().GetCurrentDEX();
        }

        /// <summary>
        /// 增加最大敏捷度数值（应用场景：等级提升[即：升级]）
        /// </summary>
        /// <param name="IncreaseMaxDEX">增加敏捷度增量数值</param>
        public void IncreaseMaxDEX(float increaseDEX)
        {
            if(increaseDEX > 0)
            {
                PlayerKernalDataProxy.GetInstance().IncreaseMaxDEX(increaseDEX);
            }           
        }

        /// <summary>
        /// 得到最大敏捷度数值
        /// </summary>
        /// <returns></returns>
        public float GetMaxDEX()
        {
            return PlayerKernalDataProxy.GetInstance().GetMaxDEX();
        }
        #endregion

        #region 经验值
        /// <summary>
        /// 增加经验值
        /// </summary>
        /// <param name="ExpNumber">经验数值</param>
        public void AddExp(int ExpValues)  //经验值只有增加，没有减少的
        {
            if(ExpValues > 0)
            {
                PlayerExtenDataProxy.GetInstance().AddExp(ExpValues);
            }           
        }

        /// <summary>
        /// 得到经验值
        /// </summary>
        /// <returns></returns>
        public int GetExp()
        {
            return PlayerExtenDataProxy.GetInstance().GetExp();
        }
        #endregion

        #region   杀敌数量
        /// <summary>
        /// 增加杀敌数量
        /// </summary>
        public void AddKillNumber()
        {
            PlayerExtenDataProxy.GetInstance().AddKillNumber();
        }

        /// <summary>
        /// 得到"杀敌数量"
        /// </summary>
        /// <returns></returns>
        public int GetKillNumber()
        {
            return PlayerExtenDataProxy.GetInstance().GetKillNumber();
        }

        #endregion

        #region  等级

        /// <summary>
        /// 增加 等级
        /// </summary>
        public void AddLevel()
        {
            PlayerExtenDataProxy.GetInstance().AddLevel();
        }

        /// <summary>
        /// 得到“当前 等级”
        /// </summary>
        /// <returns></returns>
        public int GetLevel()
        {
            return PlayerExtenDataProxy.GetInstance().GetLevel();
        }
        #endregion

        #region  金币
        /// <summary>
        /// 增加金币
        /// </summary>
        public void AddGold(int GoldNumber)
        {
            if(GoldNumber > 0)
            {
                PlayerExtenDataProxy.GetInstance().AddGold(GoldNumber);
            }            
        }

        /// <summary>
        /// 得到当前金币
        /// </summary>
        /// <returns></returns>
        public int GetGold()
        {
            return PlayerExtenDataProxy.GetInstance().GetGold();
        }

        #endregion

        #region 钻石
        /// <summary>
        /// 增加钻石
        /// </summary>
        public void AddDiamonds(int DiamondNumber)
        {
            PlayerExtenDataProxy.GetInstance().AddDiamonds(DiamondNumber);
        }

        /// <summary>
        /// 得到当前钻石数量
        /// </summary>
        /// <returns></returns>
        public int GetDiamonds()
        {
            return PlayerExtenDataProxy.GetInstance().GetDiamonds();
        }

        #endregion

    }//Class_end
}


