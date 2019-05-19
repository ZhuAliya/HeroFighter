/***
   *        Title: "英雄战神" 项目开发
   *    控制层：主角攻击控制
   *      Description:
   *            开发思路：
   *            1>把附件的所有敌人放入“敌人数组”。
   *                1.1>得到所有的敌人，放入“敌人集合”。
   *                1.2>判断“敌人集合”，然后找出最近的敌人。
   *            
   *            2>主角在一定范围内，开始自动“注视”最近的敌人
   *            
   *            3>响应输入攻击信号，对于主角“正面”的敌人给予一定的伤害处理。
   *                
   *       Data:	[2018]F:\UnityAllProjects\DungeonFighter\Assets\Scripts\Control\Player\Ctrl_HeroAttack.cs
   *       Version: 0.1
 * */
using UnityEngine;
using System.Collections;
using Global;
using Kernal;
using System.Collections.Generic;



namespace Control
{
    public class Ctrl_HeroAttack : BaseControl
    {
        public float FloMinAttackDistance = 5;                                    //最小攻击距离（关注）
        public float FloHeroRotationSpeed = 1F;                                 //主角旋转速率
        public float FloRealAttackArea = 2F;                                        //主角实际有效攻击距离
        //关于大招攻击参数定义
        public float FloAttackAreaByMagicA = 4F;                                //大招A的攻击范围
        public float FloAttackAreaByMagicB = 8F;                                //大招B的攻击范围
        public int IntAttackPowerMultipleByMagicA = 5;                      //大招A的攻击倍率
        public int IntAttackPowerMultipleByMagicB = 20;                    //大招B的攻击倍率

        private List<GameObject> _ListEnemys;                                   //敌人集合
        private Transform _TraNearestEnemy;                                      //最近的敌人方位
        private float _FloMaxDistance = 10;                                         //敌我最大距离

       


        void Awake()
        {
            //事件注册(多播委托):主角攻击输入(键盘的事件：即键盘的输入)
#if UNITY_STANDALONE_WIN || UNITY_EDITOR
            Ctrl_HeroAttackInputByKey.evePlayerControl += ResponseNormalAttack;
            Ctrl_HeroAttackInputByKey.evePlayerControl += ResponseMagicTrickA;
            Ctrl_HeroAttackInputByKey.evePlayerControl += ResponseMagicTrickB;
#endif
            //主角攻击输入(虚拟按键的事件)
//#if UNITY_ANDROID || UNITY_IPHONE
            Ctrl_HeroAttackInputByET.evePlayerControl += ResponseNormalAttack;
            Ctrl_HeroAttackInputByET.evePlayerControl += ResponseMagicTrickA;
            Ctrl_HeroAttackInputByET.evePlayerControl += ResponseMagicTrickB;
//#endif
        }

        void Start()
        {
            //集合类型初始化
            _ListEnemys = new List<GameObject>();
            //把附近的所有敌人放入“敌人数组”
            StartCoroutine("RecordNearbyEnemysToArray");
            //主角在一定范围内，开始自动“注视”最近的敌人
            StartCoroutine("HeroRotationEnemy");
        }

        /// <summary>
        /// 把附近的所有敌人放入“敌人数组”
        /// </summary>
        /// <returns></returns>
        IEnumerator RecordNearbyEnemysToArray()
        {
            while(true)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_2);    //2F是常量要处理？？？
                //得到所有的敌人，放入“敌人集合”
                GetEnemysToArray();
                //判断“敌人集合”，然后找出最近的敌人
                GetNearestEnemy();
            }
        }

        /// <summary>
        ///  得到所有（活着）的敌人，放入“敌人集合”
        /// </summary>
        private void GetEnemysToArray()
        {
            //清空敌人集合
            _ListEnemys.Clear();
            GameObject[] GoEnemys = GameObject.FindGameObjectsWithTag(Tag.Tag_Enemys);
            foreach(GameObject goItem in GoEnemys)
            {
                //判断敌人是否存活
                //  Ctrl_Enemy enemy = goItem.GetComponent<Ctrl_Enemy>();
                Ctrl_BaseEnemyProperty enemy = goItem.GetComponent<Ctrl_BaseEnemyProperty>();
               // if (enemy && enemy.IsAlive)  //enemy不等于null， 并且是存活的
                    if (enemy&&enemy.CurrentState != EnemyState.Death)
                    {
                    //注意此次是Add(goItem)，即存gameObject游戏对象，不是enemy，
                    _ListEnemys.Add(goItem); //enemy不等于null， 并且是存活的，才能把敌人加入到集合里面
                }
            }//foreach_end
        }//GetEnemysToArray_end

        /// <summary>
        /// 判断“敌人集合”，然后找出最近的敌人 
        /// </summary>
        public void GetNearestEnemy()
        {
            //敌人不为空，并且要大于或等于1个
            if(_ListEnemys  != null&& (_ListEnemys.Count >= 1))
            {
                foreach(GameObject goEnemys in _ListEnemys)
                {
                    float floDistance = Vector3.Distance(this.gameObject.transform.position, goEnemys.transform.position);//主角的距离和敌人的距离
                    if(floDistance < _FloMaxDistance)//floDistance小于敌我最大距离
                    {
                        _FloMaxDistance = floDistance;//最大距离就等于floDistance
                        _TraNearestEnemy = goEnemys.transform;//找出的最近敌人
                    }
                }//foreach_end
            }
        }//GetNearestEnemy()_end

        /// <summary>
        /// //主角在一定范围内，开始自动“注视”最近的敌人
        /// </summary>
        /// <returns></returns>
        IEnumerator HeroRotationEnemy()
        {
            while(true)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT5);
                if(_TraNearestEnemy != null &&Ctrl_HeroAnimationCtrl.Instance.CurrentActionState == HeroActionState.Idle) //最近的敌人不为空，并且当前动画状态是休闲的时候
                {
                    float floDistance = Vector3.Distance(this.gameObject.transform.position, _TraNearestEnemy.transform.position);
                    if(floDistance <FloMinAttackDistance)//最小攻击距离（关注）
                    {
                        UnityHelper.GetInstance().FaceToHero(this.gameObject.transform, _TraNearestEnemy, FloHeroRotationSpeed);
                    }
                }
            }
        }//HeroRotationEnemy_end


#region   响应攻击输入
        /// <summary>
        /// 响应普通攻击
        /// </summary>
        /// <param name="controlType"></param>
        public void ResponseNormalAttack(string controlType)
        {
            //print(GetType() + "/ResponseNormalAttack() ");
            if (controlType == "NormalAttack")
            {
                Log.Write(GetType() + "/ResponseNormalAttack()/响应普通攻击");
                //播放攻击动画
                Ctrl_HeroAnimationCtrl.Instance.SetCurrentActionState(HeroActionState.NormalAttack);
                //给特定敌人以伤害处理
                AttackEnemyByNormal();              
            }
        }

        /// <summary>
        /// 响应大招A
        /// </summary>
        public void ResponseMagicTrickA(string controlType)
        {
            if (controlType == "MagicTrickA")
            {            
                //播放攻击动画
                Ctrl_HeroAnimationCtrl.Instance.SetCurrentActionState(HeroActionState.MagicTrickA);
                //给特定敌人以伤害处理
                StartCoroutine("AttackEnemyByMagicA");
            }
        }

        /// <summary>
        /// 响应大招B
        /// </summary>
        public void ResponseMagicTrickB(string controlType)
        {
            if (controlType == "MagicTrickB")
            {
                //播放攻击动画
                Ctrl_HeroAnimationCtrl.Instance.SetCurrentActionState(HeroActionState.MagicTrickB);
                //给特定敌人以伤害处理
                StartCoroutine("AttackEnemyByMagicB");
            }
}
        #endregion

        //给特定的敌人以伤害处理。
        /// <summary>
        /// 攻击敌人_普通招式
        /// </summary>
        private void AttackEnemyByNormal()
        {
            AttackEnemy(_ListEnemys, _TraNearestEnemy,FloRealAttackArea, 1, true);//此处true可不写，然后默认为true
        }//AttackEnemyByNormal_end

        /// <summary>
        /// 使用大招A，攻击敌人
        /// 功能：主角周边范围，都造成一定的伤害
        /// </summary>
        IEnumerator  AttackEnemyByMagicA()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_1);
            base.AttackEnemy(_ListEnemys,_TraNearestEnemy, FloAttackAreaByMagicA, IntAttackPowerMultipleByMagicA, false);
        }//AttackEnemyByMagicA_end

        /// <summary>
        /// 使用大招B，攻击敌人
        /// 功能：主角的正对面方向，造成较大的伤害
        /// </summary>
        IEnumerator AttackEnemyByMagicB()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_1);
            base.AttackEnemy(_ListEnemys, _TraNearestEnemy,FloAttackAreaByMagicB, IntAttackPowerMultipleByMagicB); //这里true不写就是默认为true
           
        }//AttackEnemyByMagicB_end

       

    }//class_end
}

