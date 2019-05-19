/***
   *        Title: "英雄战神" 项目开发
   *        控制层：敌人战士动画系统
   *      Description:
   *                [描述]
   *                1.敌人动画
   *                2.敌人特技处理
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using System.Collections;
using Global;
using Kernal;


namespace Control
{
    public class Ctr_Warrior_Animation : BaseControl
    {
        private Ctrl_BaseEnemyProperty _MyProperty;                              //本身属性
        private Ctrl_HeroProperty _HeroProperty;                                //英雄属性
        private Animator _Animator;                                                   //战士的动画状态机
        private bool _IsSingleTimes = true;                                          //单次开关
        //“打击粒子”预设
        public GameObject goHurtEffectPrefab;

        void OnEnable()
        {
            //播放战士动画A部分(休闲、走路、攻击)
            StartCoroutine("PlayWarriorAnimation_A");
            //播放战士动画B部分（受伤、死亡）
            StartCoroutine("PlayWarriorAnimation_B");
            //开启单次模式
            _IsSingleTimes = true;
        }

        void OnDisable()
        {
            //播放战士动画A部分(休闲、走路、攻击)
            StopCoroutine("PlayWarriorAnimation_A");
            //播放战士动画B部分（受伤、死亡）
            StopCoroutine("PlayWarriorAnimation_B");
            //敌人的状态恢复为“站立”状态
            if(_Animator!=null)
            {
                _Animator.SetTrigger("RecoverLife");
            }
        }

        void Start()
        {
            //得到本身的属性
            _MyProperty = this.gameObject.GetComponent<Ctrl_BaseEnemyProperty>();
            //得到动画状态机
            _Animator = this.gameObject.GetComponent<Animator>();
            //得到英雄属性脚本
            GameObject goHero = GameObject.FindGameObjectWithTag(Tag.Player);
            if(goHero)
            {
                _HeroProperty = goHero.GetComponent<Ctrl_HeroProperty>();
            }
            ////播放战士动画A部分(休闲、走路、攻击)
            //StartCoroutine("PlayWarriorAnimation_A");
            ////播放战士动画B部分（受伤、死亡）
            //StartCoroutine("PlayWarriorAnimation_B");
        }

        /// <summary>
        /// 播放战士动画A部分
        /// </summary>
        /// <returns></returns>
        IEnumerator PlayWarriorAnimation_A()
        {
            yield return new WaitForEndOfFrame(); //WaitForEndOfFrame 把整个画面都渲染完之后，再执行。
            while(true)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT1);//每间隔0.1s执行一次
                switch (_MyProperty.CurrentState)
                {
                    case EnemyState.Idle:
                        _Animator.SetFloat("MoveSpeed", 0);
                        _Animator.SetBool("Attack", false);
                        break;
                    case EnemyState.Walking:
                        _Animator.SetFloat("MoveSpeed", 1);
                        _Animator.SetBool("Attack", false);
                        break;
                    case EnemyState.Attack:
                        _Animator.SetFloat("MoveSpeed", 0);
                        _Animator.SetBool("Attack", true);                     
                        break;
                    //case EnemyState.Hurt:
                    //    _Animator.SetTrigger("Hurt");
                    //    break;
                    //case EnemyState.Death:
                    //    _Animator.SetTrigger("Death");
                    //    break;
                    default:
                        break;
                }
            }//while_end
        }

        /// <summary>
        /// 播放战士动画B部分
        /// </summary>
        /// <returns></returns>
        IEnumerator PlayWarriorAnimation_B()
        {
            yield return new WaitForEndOfFrame(); //WaitForEndOfFrame 把整个画面都渲染完之后，再执行。
            while (true)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT5);//每间隔0.5s执行一次
                switch (_MyProperty.CurrentState)
                {
                    //case EnemyState.Idle:
                    //    _Animator.SetFloat("MoveSpeed", 0);
                    //    _Animator.SetBool("Attack", false);
                    //    break;
                    //case EnemyState.Walking:
                    //    _Animator.SetFloat("MoveSpeed", 1);
                    //    _Animator.SetBool("Attack", false);
                    //    break;
                    //case EnemyState.Attack:
                    //    _Animator.SetFloat("MoveSpeed", 0);
                    //    _Animator.SetBool("Attack", true);
                    //    break;
                    case EnemyState.Hurt:
                        _Animator.SetTrigger("Hurt");
                        break;
                    case EnemyState.Death:
                        if(_IsSingleTimes)
                        {
                            _IsSingleTimes = false;
                            _Animator.SetTrigger("Death");
                        }
                        break;
                    default:
                        break;
                }
            }//while_end
        }

        /// <summary>
        /// 攻击主角（动画事件）
        /// </summary>
        public void AttackHeroByAnimationEvent()
        {
            _HeroProperty.DecreaseHealthValues(_MyProperty.ATK);//掉血 _MyProperty.IntATK当前敌人的攻击力调用掉血(减少生命数值)
        }


        /// <summary>
        /// 战士受伤动画效果
        /// </summary>
        /// <returns></returns>
        public IEnumerator AnimationEvent_WarriorHurt()
        {
            StartCoroutine(LoadParticalEffectPublicMethod(GlobalParameter.INTERVAL_TIME_0DOT1,
    "ParticleProps/Enemy_HurtedEffect", true, transform.position, transform.rotation, transform, null, 1));
            yield break;

            //yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT1);
            //print("ParticleProps/Hero_MagicB(groundBrokeRed)");
            //GameObject WarriorHurtEffect = ResourcesMgr.GetInstance().LoadAsset("ParticleProps/Enemy_HurtedEffect", true);
            ////定义粒子特效的位置（在主角前方5米的位置）
            //WarriorHurtEffect.transform.position = transform.position;
            ////定义特效的父子对象（作为Warrior对象的子对象）
            //WarriorHurtEffect.transform.parent = transform;//这个粒子特效WarriorHurtEffect的父对象就是敌人，也就是这个特效是敌人内部的子节点
            ////定义特效音频
            ////...
            ////销毁时间
            //Destroy(WarriorHurtEffect, 1F);
        }

    }
}