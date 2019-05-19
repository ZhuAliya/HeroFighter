/***
   *        Title: "英雄战神" 项目开发
   *    模型层：玩家核心数值
   *      Description:
   *               功能：本类提供玩家核心数据的存取数值
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Global;

namespace Model
{
    public class PlayerKernalData 
    {
        //定义事件：玩家的核心数值
        public static event del_PlayerKernalModel evePlayerKernalData; //玩家的核心数值



        private float _FloHealth;                                                           //健康数值（血条）
        private float _FloMagic;                                                            //魔法数值
        private float _FloAttack;                                                            //攻击力
        private float _FloDefence;                                                         //防御力
        private float _FloDexterity;                                                         //敏捷度

        private float _FloMaxHealth;                                                       //最大健康数值（血条）
        private float _FloMaxMagic;                                                       //最大魔法数值
        private float _FloMaxAttack;                                                       //最大攻击力
        private float _FloMaxDefence;                                                   //最大防御力
        private float _FloMaxDexterity;                                                  //最大敏捷度

        private float _FloAttackByProp;                                                 //武器攻击力
        private float _FloDefenceByProp;                                             //武器防御力
        private float _FloDexterityByProp;                                            //道具敏捷度

        /*   属性信息   */
        public float Health
        {
            get
            {
                return _FloHealth;
            }

            set
            {
                _FloHealth = value;

                //事件调用
                 if(evePlayerKernalData != null)
                {
                    KeyValuesUpdate kv = new KeyValuesUpdate("Health", Health);
                    evePlayerKernalData(kv);  //调用委托
                }
            }
        }//Health_end

        public float Magic
        {
            get
            {
                return _FloMagic;
            }

            set
            {
                _FloMagic = value;

                //事件调用
                if (evePlayerKernalData != null)
                {
                    KeyValuesUpdate kv = new KeyValuesUpdate("Magic", Magic);
                    evePlayerKernalData(kv);  //调用委托
                }
            }
        }

        public float Attack
        {
            get
            {
                return _FloAttack;
            }

            set
            {
                _FloAttack = value;
                //事件调用
                if (evePlayerKernalData != null)
                {
                    KeyValuesUpdate kv = new KeyValuesUpdate("Attack", Attack);
                    evePlayerKernalData(kv);  //调用委托
                }
            }
        }

        public float Defence
        {
            get
            {
                return _FloDefence;
            }

            set
            {
                _FloDefence = value;

                //事件调用
                if (evePlayerKernalData != null)
                {
                    KeyValuesUpdate kv = new KeyValuesUpdate("Defence", Defence);
                    evePlayerKernalData(kv);  //调用委托
                }
            }
        }

        public float Dexterity
        {
            get
            {
                return _FloDexterity;
            }

            set
            {
                _FloDexterity = value;

                //事件调用
                if (evePlayerKernalData != null)
                {
                    KeyValuesUpdate kv = new KeyValuesUpdate("Dexterity", Dexterity);
                    evePlayerKernalData(kv);  //调用委托
                }
            }
        }



        public float MaxHealth
        {
            get
            {
                return _FloMaxHealth;
            }

            set
            {
                _FloMaxHealth = value;
                //事件调用
                if (evePlayerKernalData != null)
                {
                    KeyValuesUpdate kv = new KeyValuesUpdate("MaxHealth", MaxHealth);
                    evePlayerKernalData(kv);  //调用委托
                }
            }
        }

        public float MaxMagic
        {
            get
            {
                return _FloMaxMagic;
            }

            set
            {
                _FloMaxMagic = value;

                //事件调用
                if (evePlayerKernalData != null)
                {
                    KeyValuesUpdate kv = new KeyValuesUpdate("MaxMagic", MaxMagic);
                    evePlayerKernalData(kv);  //调用委托
                }
            }
        }

        public float MaxAttack
        {
            get
            {
                return _FloMaxAttack;
            }

            set
            {
                _FloMaxAttack = value;

                //事件调用
                if (evePlayerKernalData != null)
                {
                    KeyValuesUpdate kv = new KeyValuesUpdate("MaxAttack", MaxAttack);
                    evePlayerKernalData(kv);  //调用委托
                }
            }
        }

        public float MaxDefence
        {
            get
            {
                return _FloMaxDefence;
            }

            set
            {
                _FloMaxDefence = value;

                //事件调用
                if (evePlayerKernalData != null)
                {
                    KeyValuesUpdate kv = new KeyValuesUpdate("MaxDefence", MaxDefence);
                    evePlayerKernalData(kv);  //调用委托
                }
            }
        }

        public float MaxDexterity
        {
            get
            {
                return _FloMaxDexterity;
            }

            set
            {
                _FloMaxDexterity = value;

                //事件调用
                if (evePlayerKernalData != null)
                {
                    KeyValuesUpdate kv = new KeyValuesUpdate("MaxDexterity", MaxDexterity);
                    evePlayerKernalData(kv);  //调用委托
                }
            }
        }



        public float AttackByProp
        {
            get
            {
                return _FloAttackByProp;
            }

            set
            {
                _FloAttackByProp = value;

                //事件调用
                if (evePlayerKernalData != null)
                {
                    KeyValuesUpdate kv = new KeyValuesUpdate("AttackByProp", AttackByProp);
                    evePlayerKernalData(kv);  //调用委托
                }
            }
        }

        //道具的防御力
        public float DefenceByProp
        {
            get
            {
                return _FloDefenceByProp;
            }

            set
            {
                _FloDefenceByProp = value;


                //事件调用
                if (evePlayerKernalData != null)
                {
                    KeyValuesUpdate kv = new KeyValuesUpdate("DefenceByProp", DefenceByProp);
                    evePlayerKernalData(kv);  //调用委托
                }
            }
        }

        //道具的敏捷度
        public float DexterityByProp
        {
            get
            {
                return _FloDexterityByProp;
            }

            set
            {
                _FloDexterityByProp = value;

                //事件调用
                if (evePlayerKernalData != null)
                {
                    KeyValuesUpdate kv = new KeyValuesUpdate("DexterityByProp", DexterityByProp);
                    evePlayerKernalData(kv);  //调用委托
                }
            }
        }

        /// <summary>
        /// 定义私有默认构造函数
        /// </summary>
        private PlayerKernalData()
        {
             
        }

        //公共构造函数
        public PlayerKernalData (float health, float magic, float attack, float defence, float dexterity,
            float maxHealth, float maxMagic, float maxAttack, float maxDefence, float maxDexterity,
            float attackByPop, float defenceByProp, float dexterityByProp)
        {
            this._FloHealth = health;
            this._FloMagic = magic;
            this._FloAttack = attack;
            this._FloDefence = defence;
            this._FloDexterity = dexterity;

            this._FloMaxHealth = maxHealth;
            this._FloMaxMagic = maxMagic;
            this._FloMaxAttack = maxAttack;
            this._FloMaxDefence = maxDefence;
            this._FloMaxDexterity = maxDexterity;

            this._FloAttackByProp = attackByPop;
            this._FloDefenceByProp = defenceByProp;
            this._FloDexterityByProp = dexterityByProp;
        }

        
    }//class_end
}

