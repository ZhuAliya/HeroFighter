/***
   *        Title: "英雄战神" 项目开发
   *    模型层：玩家核心数值代理类
   *      Description:
   *               功能：为了简化数值的开发，我们把数值的“直接存取”与
   *               复杂“操作计算”相分离
   *              （本质是“代理”设计模式的应用）
   *               
   *               本类必须设计为带有构造函数的“单例”模式
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Model
{
    public class PlayerKernalDataProxy : PlayerKernalData
    {
       
        public static PlayerKernalDataProxy _Instance = null;       //本类的实例
        public const int ENEMY_MIN_ATK = 1;                             //敌人最低攻击力

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="health"></param>
        /// <param name="magic"></param>
        /// <param name="ATK"></param>
        /// <param name="DEF"></param>
        /// <param name="DEX"></param>
        /// <param name="maxHealth"></param>
        /// <param name="maxMagic"></param>
        /// <param name="maxATK"></param>
        /// <param name="maxDEF"></param>
        /// <param name="maxDEX"></param>
        /// <param name="ATKByProp"></param>
        /// <param name="DEFByProp"></param>
        /// <param name="DEXByProp"></param>
        public PlayerKernalDataProxy(float health, float magic, float ATK, float DEF, float DEX, 
            float maxHealth, float maxMagic, float maxATK, float maxDEF, float maxDEX, float ATKByProp,
            float DEFByProp, float DEXByProp ):base(health, magic, ATK, DEF, DEX, maxHealth, maxMagic, maxATK,
                maxDEF, maxDEX, ATKByProp,DEFByProp, DEXByProp)
        {
            if(_Instance ==null)
            {
                _Instance = this;
            }
            else
            {
                Debug.LogError(GetType() + "/PlayerKernalDataProxy()/不允许构造函数重复实例化，请检查");
            }
        }


        /// <summary>
        /// 得到本类实例
        /// </summary>
        /// <returns></returns>
        public static PlayerKernalDataProxy GetInstance()
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

        #region 生命数值操作（5个方法）
        /// <summary>
        /// 减少生命数值（典型应用场景：被敌人攻击）
        /// 公式： _Health =_Health -(敌人的攻击力 - 主角的防御力 - 主角武器防御力)；
        /// </summary>
        /// <param name="enemyAttackValue">敌人的攻击力</param>
        public void DecreaseHealthValues(float enemyAttackValue)
        {
            float enemyReallyATK = 0F;                                                      //敌人真实的攻击力
            enemyReallyATK = enemyAttackValue - base.Defence - base.DefenceByProp;
            if(enemyReallyATK > 0)
            {
                base.Health -= enemyReallyATK;
            }
            else
            {
                base.Health -= ENEMY_MIN_ATK;                                       //敌人最低攻击力
            }
            //更新攻击力、防御力、敏捷度
            this.UpdateATKValue();
            this.UpdateDEFValue();
            this.UpdateDEXValue();
        }

        /// <summary>
        /// 增加生命数值（典型应用场景：获得["吃"]血包）
        /// </summary>
        /// <param name="healthValue"></param>
        public void IncreaseHealthValues(float healthValue)
        {
            float floReallyIncreaseHealValues = 0F;         //真实的增加量

            floReallyIncreaseHealValues = base.Health + healthValue;

            if(floReallyIncreaseHealValues < base.MaxHealth)    //吃血包的时候不能超过它的最大值
            {
                base.Health += healthValue;
            }
            else
            {
                base.Health = base.MaxHealth;  //增加的血包最大的时候不能超过它当前最大值的生命值
            }

            //更新攻击力、防御力、敏捷度
            this.UpdateATKValue();
            this.UpdateDEFValue();
            this.UpdateDEXValue();
        }

        /// <summary>
        /// 得到当前主角的生命数值
        /// </summary>
        /// <returns></returns>
        public float GetCurrentHealth()
        {
            return base.Health;
        }



        /// <summary>
        /// 增加最大生命数值（应用场景：等级提升[即：升级]）
        /// </summary>
        /// <param name="increaseHealth">增量健康数值</param>
        public void IncreaseMaxHealth(float increaseHealth)
        {
            base.MaxHealth += Mathf.Abs(increaseHealth);
        }

        /// <summary>
        /// 得到最大生命数值
        /// </summary>
        /// <returns></returns>
        public float GetMaxHealth()
        {
            return 0F;
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
            float reallyMagicValueResult = 0F;              //实际的剩余魔法数值
            reallyMagicValueResult = base.Magic - magicValue;
            if(reallyMagicValueResult > 0)
            {
                base.Magic -= Mathf.Abs(magicValue);
            }
            else
            {
                base.Magic = 0;
            }
            base.Magic -= Mathf.Abs(magicValue);
        }

        /// <summary>
        /// 增加魔法数值（典型应用场景：获得["吃"]魔法包）
        /// </summary>
        /// <param name="magicValue">魔法增量</param>
        public void IncreaseMagicValues(float magicValue)
        {
            float floReallyIncreaseMagicValues = 0F;         //真实的魔法增加量

            floReallyIncreaseMagicValues = base.Magic + magicValue;
            if (floReallyIncreaseMagicValues < base.MaxMagic)
            {
                base.Magic += magicValue;
            }
            else
            {
                base.Magic = base.MaxMagic;
            }
        }

        /// <summary>
        /// 得到当前主角的魔法数值
        /// </summary>
        /// <returns></returns>
        public float GetCurrentMagic()
        {
            return base.Magic;
        }

        /// <summary>
        /// 增加最大魔法数值（应用场景：等级提升[即：升级]）
        /// </summary>
        /// <param name="increaseHealth">增加健康数值</param>
        public void IncreaseMaxMagic(float increaseMagic)
        {
            base.MaxMagic += Mathf.Abs(increaseMagic);
        }

        /// <summary>
        /// 得到最大魔法数值
        /// </summary>
        /// <returns></returns>
        public float GetMaxMagic()
        {
            return base.MaxMagic;
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
                float reallyATKValues = 0F;                                 //实际的攻击数值
            //没有获取新的武器道具
                if (newWeaponValues == 0)
            {
                reallyATKValues = base.MaxAttack / 2 * (base.Health / base.MaxHealth) + base.AttackByProp;
            }
            //获取了武器道具
            else if(newWeaponValues > 0)
            {
                reallyATKValues = base.MaxAttack / 2 * (base.Health / base.MaxHealth) + newWeaponValues;
                base.AttackByProp = newWeaponValues;//新的值加到数值里面
            }
                //数值有效性验证
                if(reallyATKValues > base.MaxAttack)
            {
                base.Attack = base.MaxAttack;
            }
              else
            {
                base.Attack = reallyATKValues; //当前的攻击力等于实际的攻击力
            }
        }

        /// <summary>
        /// 得到当前主角的攻击力数值
        /// </summary>
        /// <returns></returns>
        public float GetCurrentATK()
        {
            return base.Attack;
        }

        /// <summary>
        /// 增加最大攻击力数值（应用场景：等级提升[即：升级]）
        /// </summary>
        /// <param name=" IncreaseMaxATK">增加攻击力增量数值</param>
        public void IncreaseMaxATK(float increaseATK)
        {
            base.MaxAttack += Mathf.Abs(increaseATK);
        }

        /// <summary>
        /// 得到最大攻击力数值
        /// </summary>
        /// <returns></returns>
        public float GetMaxATK()
        {
            return base.MaxAttack;
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
            float reallyDEFValues = 0F;                                 //实际的防御数值
             //没有获取新的武器道具
            if (newWeaponDEFValues == 0)
            {
                reallyDEFValues = base.MaxDefence / 2 * (base.Health / base.MaxHealth) + base.DefenceByProp;
            }
            //获取了武器道具
            else if (newWeaponDEFValues > 0)
            {
                reallyDEFValues = base.MaxDefence / 2 * (base.Health / base.MaxHealth) + newWeaponDEFValues;
                base.DefenceByProp = newWeaponDEFValues;//新的值加到数值里面
            }
            //数值有效性验证
            if (reallyDEFValues > base.MaxDefence)
            {
                base.Defence = base.MaxDefence;
            }
            else
            {
                base.Defence = reallyDEFValues;
            }
        }

        /// <summary>
        /// 得到当前主角的防御力数值
        /// </summary>
        /// <returns></returns>
        public float GetCurrentDEF()
        {
            return base.Defence;
        }

        /// <summary>
        /// 增加最大防御力数值（应用场景：等级提升[即：升级]）
        /// </summary>
        /// <param name=" IncreaseMaxDEF">增加防御力增量数值</param>
        public void IncreaseMaxDEF(float increaseDEF)
        {
            base.MaxDefence += Mathf.Abs(increaseDEF);
        }

        /// <summary>
        /// 得到最大防御力数值
        /// </summary>
        /// <returns></returns>
        public float GetMaxDEF()
        {
            return base.MaxDefence;
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
            float reallyDEXValues = 0F;                                 //实际的敏捷度数值
            //没有获取新的武器道具
            if (newWeaponValues == 0)
            {
                reallyDEXValues = base.MaxDexterity / 2 * (base.Health / base.MaxHealth) - base.Defence + base.DexterityByProp;
            }
            //获取了武器道具
            else if (newWeaponValues > 0)
            {
                reallyDEXValues = base.MaxDexterity / 2 * (base.Health / base.MaxHealth) - base.Defence + newWeaponValues;
                base.DexterityByProp = newWeaponValues;//新的值加到数值里面
            }
            //数值有效性验证
            if (reallyDEXValues > base.MaxDexterity)
            {
                base.Dexterity = base.MaxDexterity;
            }
            else
            {
                base.Dexterity = reallyDEXValues;
            }
        }

        /// <summary>
        /// 得到当前主角的敏捷度数值
        /// </summary>
        /// <returns></returns>
        public float GetCurrentDEX()
        {
            return base.Dexterity;
        }

        /// <summary>
        /// 增加最大敏捷度数值（应用场景：等级提升[即：升级]）
        /// </summary>
        /// <param name="IncreaseMaxDEX">增加敏捷度增量数值</param>
        public void IncreaseMaxDEX(float increaseDEX)
        {
            base.MaxDexterity += Mathf.Abs(increaseDEX);
        }

        /// <summary>
        /// 得到最大敏捷度数值
        /// </summary>
        /// <returns></returns>
        public float GetMaxDEX()
        {
            return base.MaxDexterity;
        }
        #endregion

        /// <summary>
        /// 显示所有的初始值
        /// </summary>
        public void DisplayAllOriginalValues()
        {
            base.Health = base.Health;
            base.Magic = base.Magic;
            base.Attack = base.Attack; 
            base.Defence = base.Defence;
            base.Dexterity = base.Dexterity;

            base.MaxHealth = base.MaxHealth;
            base.MaxMagic = base.MaxMagic;
            base.MaxAttack = base.MaxAttack;
            base.MaxDefence = base.MaxDefence;
            base.MaxDexterity = base.MaxDexterity;

            base.AttackByProp = base.AttackByProp;          //道具攻击
            base.DexterityByProp = base.DexterityByProp;    //道具敏捷度
            base.DefenceByProp = base.DefenceByProp;        //道具防御
        }

    }//class_end  
}

