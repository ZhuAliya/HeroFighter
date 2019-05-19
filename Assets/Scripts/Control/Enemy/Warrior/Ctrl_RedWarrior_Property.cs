/***
   *        Title: "英雄战神" 项目开发
   *    控制层：红色 （敌人）战士属性
   *      Description:
   *                [描述]
   *       Data:	[2018]
   *       Version: 0.1
 * */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Kernal;
using Global;

namespace Control
{
    public class Ctrl_RedWarrior_Property : Ctrl_BaseEnemyProperty
    {

        public int IntHeroExperience = 20;                     //英雄的经验数值
        public int IntATK = 10;                                       //攻击力
        public int IntDEF = 3;                                       //防御力
        public int IntMaxHealth = 50;                          //最大的生命数值

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

