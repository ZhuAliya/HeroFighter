/***
   *        Title: "英雄战神" 项目开发
   *    控制层：敌人战士（属性）
   *      Description:
   *                [描述] 敌人的各种属性
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using System.Collections;
using Kernal;
using Global;

namespace Control
{
    public class Ctrl_Warrior_Property : Ctrl_BaseEnemyProperty
    {
        public int IntHeroExperience = 5;                     //英雄的经验数值
        public int IntATK = 2;                                       //攻击力
        public int IntDEF = 2;                                       //防御力
        public int IntMaxHealth = 20;                          //最大的生命数值

        void Start()
        {
            base.HeroExperience = IntHeroExperience;
            base.ATK = IntATK;
            base.DEF = IntDEF;
            base.MaxHealth = IntMaxHealth;
            //调用父类方法
            base.RunMethodInChildren();  
        }
    }
}

