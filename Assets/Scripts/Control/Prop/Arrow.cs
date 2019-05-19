/***
   *        Title: "英雄战神" 项目开发
   *        控制层：箭
   *        Description:
   *                功能：配合“射箭手”敌人，进行攻击。
   *                
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using System.Collections;
using Global;
using Kernal;

namespace Control
{
    public class Arrow : BaseControl{
        public float ArrowSpeed = 1F;                         //道具的速度
        public int ArrowATK = 40;                               //攻击力
        private Ctrl_HeroProperty _HeroProperty;        //英雄的属性


        void Start()
        {
            //得到英雄的属性脚本
            GameObject goHero = GameObject.FindGameObjectWithTag(Tag.Player);
            if(goHero)
            {
                _HeroProperty = goHero.GetComponent<Ctrl_HeroProperty>();
            }
        }

        void Update()
        {
            //道具的移动
            if(Time.frameCount%2 ==0)//每2帧执行一次
            {
                this.gameObject.transform.Translate(Vector3.forward * ArrowSpeed * Time.deltaTime);
            }
        }

       /// <summary>
       /// 触发检测
       /// </summary>
       /// <param name="con"></param>
        void OnTriggerEnter(Collider con)
        {
            if(con.gameObject.tag ==Tag.Player)
            {
                _HeroProperty.DecreaseHealthValues(ArrowATK);
                //销毁
                // Destroy(this.gameObject, 0.5F);
                PoolManager.PoolsArray["_ParticalSys"].RecoverGameObjectToPools(this.gameObject);
            }
        }
    }

}
