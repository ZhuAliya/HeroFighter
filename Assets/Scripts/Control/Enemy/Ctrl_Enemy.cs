/***
   *        Title: "英雄战神" 项目开发
   *        控制层：敌人（属性）
   *        说明：暂时不用了
   *      Description:
   *                [描述]
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using System.Collections;
using Global;
using Kernal;

namespace Control
{
    //public class Ctrl_Enemy : BaseControl
    //{
        //public int IntHeroExperience = 5;           //英雄的经验数值
        //private bool _IsAlive = true;                    //是否生存
        //public int IntMaxHealth = 20;                  //最大的生命数值
        //private float _FloCurrentHealth = 0;      //当前生命数值

        ///*  属性：是否存活*/
        //public bool IsAlive  //IsAlive1只能取值，不能设置值，所以属性只有get
        //{
        //    get
        //    {
        //        return _IsAlive;
        //    }
        //}

        //void Start()
        //{
        //    _FloCurrentHealth = IntMaxHealth;
        //    //判断是否生命存活
        //    StartCoroutine("CheckLifeContinue");
        //}

        ////判断是否生命存活
        //IEnumerator CheckLifeContinue()
        //{
        //    while(true)
        //    {
        //        yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_1);//每隔两秒检查一次生命是否存活
        //        if (_FloCurrentHealth <= IntMaxHealth * 0.01) //当前的健康值小于最大健康值的0.01时，判断为死亡
        //        {
        //            _IsAlive = false;
        //            //关于英雄增加相关数值
        //            //增加经验值
        //            Ctrl_HeroProperty.Instance.AddExp(IntHeroExperience);
        //            //增加杀敌数量
        //            Ctrl_HeroProperty.Instance.AddKillNumber();
        //            //销毁对象
        //            Destroy(this.gameObject);
        //        }
        //    }           
        //}

        ///// <summary>
        ///// 伤害处理
        ///// </summary>
        ///// <param name="hurtValue"></param>
        //public void OnHurt(int hurtValue)  //这里伤害值永远都是正数
        //{
        //    print("伤害处理受到了！！！");
        //    int hurtValues = 0;
        //    //Mathf.Abs()取绝对值
        //    hurtValues = Mathf.Abs(hurtValue);
        //    if(hurtValue > 0)  //伤害值大于0
        //    {
        //        _FloCurrentHealth -= hurtValue; //当前生命值递减
        //    }
        //}

        
    //}//class_end

}
