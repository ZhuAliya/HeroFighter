/***
   *        Title: "英雄战神" 项目开发
   *        控制层：Boss Bruce动画控制
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
    public class Ctrl_Boss_Animation : BaseControl
    {
        private Ctrl_BaseEnemyProperty _MyProperty;                              //本身属性
        private Ctrl_HeroProperty _HeroProperty;                                    //英雄属性
        private Animator _Animator;                                                       //战士的动画状态机
        private bool _IsSingleTimes = true;                                             //单次开关
        /*音效处理*/
        public AudioClip acBruce_NormalAttack;                                    //普通攻击
        public AudioClip acBruce_JumpAttack;                                      //跳跃攻击      
        public AudioClip acBruce_Blare;                                                //出场大吼
        public AudioClip acBruce_Dead;                                                //死亡            
        //“打击粒子”预设
        public GameObject goHurtEffectPrefab;


        void Start()
        {
            //播放动画A部分(休闲、走路、攻击)
            StartCoroutine("PlayAnimation_A");
            //播放动画B部分（受伤、死亡）
            StartCoroutine("PlayAnimation_B");
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
            yield return new WaitForEndOfFrame();                                   //WaitForEndOfFrame 把整个画面都渲染完之后，再执行
            //出场音效。播放吼叫的音效
            AudioManager.PlayAudioEffectA(acBruce_Blare);                     
            yield return new WaitForSeconds(acBruce_Blare.length);          //播放音效的长度
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
        /// 攻击主角_普通攻击
        /// </summary>
        IEnumerator AnimationEvent_AttackHeroByBruce()
        {
            //攻击音效
            AudioManager.PlayAudioEffectA(acBruce_NormalAttack);
            yield return new WaitForSeconds(acBruce_NormalAttack.length);
            //主角减少血量
            _HeroProperty.DecreaseHealthValues(_MyProperty.ATK);//掉血 _MyProperty.IntATK当前敌人的攻击力调用掉血(减少生命数值)
                                                                //播放粒子效果
                                                                //StartCoroutine(LoadParticalEffectPublicMethod(GlobalParameter.INTERVAL_TIME_0DOT1,
                                                                //"ParticleProps/Enemy_HurtedEffect", true, transform.position +transform.TransformDirection(new Vector3(0, 0, 5F)), transform.rotation, transform, null, 1));
            StartCoroutine(LoadParticalEffect_UsePool(GlobalParameter.INTERVAL_TIME_0DOT1, goHurtEffectPrefab,
                transform.position, Quaternion.identity, null, null));
            yield break;
        }

        /// <summary>
        /// 攻击主角_跳跃攻击
        /// </summary>
        IEnumerator AnimationEvent_JumpAttackHeroByBruce()
        {
            //攻击音效
            AudioManager.PlayAudioEffectA(acBruce_JumpAttack);
            yield return new WaitForSeconds(acBruce_JumpAttack.length);
            //主角减少血量
            _HeroProperty.DecreaseHealthValues(_MyProperty.ATK *2);//掉血 _MyProperty.IntATK当前敌人的攻击力调用掉血(减少生命数值)
            //播放粒子效果
            StartCoroutine(LoadParticalEffectPublicMethod(GlobalParameter.INTERVAL_TIME_0DOT1,
            "ParticleProps/Boss_Skill", true, transform.position + transform.TransformDirection(new Vector3(0, 0, -10F)), transform.rotation, transform, null, 1));
            yield break;
        }

        /// <summary>
        /// （Boss）受伤动画效果
        /// </summary>
        /// <returns></returns>
        IEnumerator AnimationEvent_BossHurt()
        {
            StartCoroutine(LoadParticalEffectPublicMethod(GlobalParameter.INTERVAL_TIME_0DOT1,
    "ParticleProps/Enemy_HurtedEffect", true, transform.position, transform.rotation, transform, null, 1));
            yield break;
        }

        /// <summary>
        /// Boss死亡动画
        /// </summary>
        /// <returns></returns>
        IEnumerator AnimationEvent_BruceDead()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT1);
            //攻击音效
            AudioManager.PlayAudioEffectA(acBruce_Dead);
            yield return new WaitForSeconds(acBruce_Dead.length);

        }
    }

}
