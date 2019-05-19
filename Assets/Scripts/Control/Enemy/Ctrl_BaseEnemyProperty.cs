/***
   *        Title: "英雄战神" 项目开发
   *    控制层：敌人属性父类
   *      Description:
   *                1. 运用“重构”的思想，来构造更加灵活与低耦合度的系统
   *                2. 包含所有敌人的公共属性
   *       Data:	[2018]
   *       Version: 0.1
 * */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Global;
using Kernal;


namespace Control
{
    public class Ctrl_BaseEnemyProperty : BaseControl
    {
        public int HeroExperience = 0;                     //英雄的经验数值
        public int ATK = 0;                                       //攻击力
        public int DEF = 0;                                       //防御力
        public int MaxHealth = 0;                          //最大的生命数值
        public float _FloCurrentHealth = 0;                 //当前生命数值
        private EnemyState _CurrentState = EnemyState.Idle; //当前状态



        /// <summary>
        /// 属性：当前的状态
        /// </summary>
        public EnemyState CurrentState
        {
            get
            {
                return _CurrentState;
            }

            set
            {
                _CurrentState = value;
            }
        }

        void OnEnable()
        {
            //判断是否生命存活
            StartCoroutine("CheckLifeContinue");
        }

        void OnDisable()
        {
            //判断是否生命存活
            StopCoroutine("CheckLifeContinue");
        }

        /// <summary>
        /// 在子类中运行的方法
        /// </summary>
        public void RunMethodInChildren()
        {
            _FloCurrentHealth = MaxHealth;
            //判断是否生命存活
           // StartCoroutine("CheckLifeContinue");
        }

        //判断是否生命存活
        IEnumerator CheckLifeContinue()
        {
            while (true)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_1);//每隔两秒检查一次生命是否存活
                if (_FloCurrentHealth <= MaxHealth * 0.01) //当前的健康值小于最大健康值的0.01时，判断为死亡
                {
                    //  _IsAlive = false;
                    _CurrentState = EnemyState.Death;
                    //关于英雄增加相关数值
                    //增加经验值
                    Ctrl_HeroProperty.Instance.AddExp(HeroExperience);
                    //增加杀敌数量
                    Ctrl_HeroProperty.Instance.AddKillNumber();
                    //死亡状态
                    _CurrentState = EnemyState.Death;
                    //销毁对象
                    //Destroy(this.gameObject, 3F);// 3s的死亡延迟
                    //回收对象
                    StartCoroutine("RecoverEnemys");
                }
            }
        }

        /// <summary>
        /// 伤害处理
        /// </summary>
        /// <param name="hurtValue"></param>
        public void OnHurt(int hurtValue)  //这里伤害值永远都是正数
        {
            print("伤害处理受到了！！！");
            int hurtValues = 0;
            //受伤状态
            _CurrentState = EnemyState.Hurt; //敌人受伤
            //Mathf.Abs()取绝对值
            hurtValues = Mathf.Abs(hurtValue);
            if (hurtValue > 0)  //伤害值大于0
            {
                _FloCurrentHealth -= hurtValue; //当前生命值递减
            }
        }


        /// <summary>
        /// 回收对象
        /// </summary>
        /// <returns></returns>
        IEnumerator RecoverEnemys()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_3);//指定3s中之后回收
            //敌人回收前状态重置，即生命值要加满，并且处于闲置状态
            _FloCurrentHealth = MaxHealth;
            _CurrentState = EnemyState.Idle;
            //回收对象
            PoolManager.PoolsArray["_Enemys"].RecoverGameObjectToPools(this.gameObject);//this.gameObject指这个脚本所指的对象
        }

    }//Class_end

}
