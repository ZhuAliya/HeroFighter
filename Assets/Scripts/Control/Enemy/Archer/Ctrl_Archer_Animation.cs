/***
   *        Title: "英雄战神" 项目开发
   *        控制层：射箭手-动画系统
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
    public class Ctrl_Archer_Animation : BaseControl
    {
        public GameObject goArrayPropByArcher;                                 //射箭手弓箭
        private Ctrl_BaseEnemyProperty _MyProperty;                           //本身属性
        private Ctrl_HeroProperty _HeroProperty;                                //英雄属性
        private Animator _Animator;                                                   //战士的动画状态机
        private bool _IsSingleTimes = true;                                          //单次开关
        //“箭”道具预设
        public GameObject goArrowPrefab;
        //“箭”道具初始方位对象
        public GameObject goArrowOriginalInfo;

        void OnEnable()
        {
            //播放战士动画A部分(休闲、走路、攻击)
            StartCoroutine("PlayAnimation_A");
            //播放战士动画B部分（受伤、死亡）
            StartCoroutine("PlayAnimation_B");
            //开启单次模式
            _IsSingleTimes = true;
        }

        void OnDisable()
        {
            //播放战士动画A部分(休闲、走路、攻击)
            StopCoroutine("PlayAnimation_A");
            //播放战士动画B部分（受伤、死亡）
            StopCoroutine("PlayrAnimation_B");
            //敌人的状态恢复为“站立”状态
            if (_Animator != null)
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
            if (goHero)
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
        IEnumerator PlayAnimation_A()
        {
            yield return new WaitForEndOfFrame(); //WaitForEndOfFrame 把整个画面都渲染完之后，再执行。
            while (true)
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
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator PlayAnimation_B()
        {
            yield return new WaitForEndOfFrame(); //WaitForEndOfFrame 把整个画面都渲染完之后，再执行。
            while (true)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT5);//每间隔0.5s执行一次
                switch (_MyProperty.CurrentState)
                {
                    case EnemyState.Hurt:
                        _Animator.SetTrigger("Hurt");
                        break;
                    case EnemyState.Death:
                        if (_IsSingleTimes)
                        {
                            _IsSingleTimes = false;
                            _Animator.SetTrigger("Dead");
                        }
                        break;
                    default:
                        break;
                }
            }//while_end
        }

        /// <summary>
        /// 攻击主角（动画事件）
        /// 功能：放箭
        /// </summary>
        public IEnumerator AnimationEvent_AttackHero()
        {
            StartCoroutine(LoadParticalEffectPublicMethod(GlobalParameter.INTERVAL_TIME_0DOT1,
                         "Prefabs/Prop/Arrow", true, goArrayPropByArcher.transform.position, goArrayPropByArcher.transform.rotation, transform.parent, null, 15));//transform.parent目的是箭和父对象作为平级对象，不要作为父对象的子节点
            yield break;
        }


        /// <summary>
        /// 受伤动画效果
        /// </summary>
        /// <returns></returns>
        public IEnumerator AnimationEvent_ArcherHurt()
        {
            //StartCoroutine(LoadParticalEffectPublicMethod(GlobalParameter.INTERVAL_TIME_0DOT1,
            //            "ParticleProps/Enemy_HurtedEffect", true, transform.position, transform.rotation, transform,null, 1));

            //用缓冲池
            StartCoroutine(LoadParticalEffect_UsePool(GlobalParameter.INTERVAL_TIME_0DOT1, goArrowPrefab,
    goArrowOriginalInfo.transform.position, goArrowOriginalInfo.transform.rotation, null, null));
            yield break;
        }


    }//Class_end
}

