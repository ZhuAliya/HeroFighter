/***
   *        Title: "英雄战神" 项目开发
   *        控制层：射箭手属性
   *        说明：暂时不用了
   *       Description:
   *                [描述]
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using System.Collections;
using Kernal;
using Global;

namespace Control
{
    public class Ctrl_Archer_Property : Ctrl_BaseEnemyProperty
    {

        public int IntHeroExperience = 10;                     //给英雄的经验数值
        public int IntATK = 0;                                       //攻击力（实际攻击力在道具上）
        public int IntDEF = 5;                                       //防御力
        public int IntMaxHealth = 10;                          //最大的生命数值

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

