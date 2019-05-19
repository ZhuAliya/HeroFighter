/***
   *        Title: "英雄战神" 项目开发
   *    控制层：主角动画控制
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
    public class Ctrl_HeroAnimationCtrl : BaseControl
    {
        public static Ctrl_HeroAnimationCtrl Instance;//本类的实例
        //主角的动画状态
        private HeroActionState _CurrentActionState = HeroActionState.None;//一开始主角的状态为none
        //定义动画剪辑
        public AnimationClip Ani_Idle;                             //休闲
        public AnimationClip Ani_Running;                     //跑动
        public AnimationClip Ani_NormalAttack1;         //普通攻击1
        public AnimationClip Ani_NormalAttack2;         //普通攻击2
        public AnimationClip Ani_NormalAttack3;         //普通攻击3
        public AnimationClip Ani_MagicTrickA;             //大招A
        public AnimationClip Ani_MagicTrickB;             //大招B
        //定义主角跑动音效剪辑
        public AudioClip AcHeroRunning;
        //动画句柄
        private Animation _AnimationHandle;
        //定义动画单次开关
        private bool _IsSinglePlay = true;                  //定义单次播放动画
        //定义动画连招
        private NormalATKComboState _CurATKCombo = NormalATKComboState.NormalATK1; //默认为第一招
        /*  属性：当前（主角）动作状态  */
        public HeroActionState CurrentActionState
        {
            get
            {
                return _CurrentActionState;
            }
        }
        //对象缓冲池：主角剑法粒子特效
        public GameObject goHeroNormalParticalEffect1;  //左右剑法粒子特效
        public GameObject goHeroNormalParticalEffect2; //剑法的中间劈砍粒子特效
        //主角音效剪辑
        public AudioClip BeiJi_DaoJian_3;
        public AudioClip BeiJi_DaoJian_2;
        public AudioClip BeiJi_DaoJian_1;
        public AudioClip SwordHero_MagicA;
        public AudioClip SwordHero_MagicB;





        void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            //默认动作状态
            _CurrentActionState = HeroActionState.Idle;
            //得到动画句柄实例
            _AnimationHandle = this.GetComponent<Animation>();
            //启动协程，控制主角动画状态
            StartCoroutine("ControlHeroAnimationState");
            //加快普通连招的播放速度
            _AnimationHandle[Ani_NormalAttack1.name].speed = 2.5F;
            _AnimationHandle[Ani_NormalAttack2.name].speed = 2.5F;
            _AnimationHandle[Ani_NormalAttack3.name].speed = 2F;
            //定义主角出现特效
            HeroDisplayParticalEffect();

        }

        // Update is called once per frame
        //void Update()
        //{
        //    //主角动画控制
        //    ControlHeroAnimationState(_CurrentActionState);
        //}

        /// <summary>
        /// 设置当前(动画)状态
        /// </summary>
        /// <param name="currentActionState"></param>
        public void SetCurrentActionState(HeroActionState currentActionState)
        {
            _CurrentActionState = currentActionState;
        }

        /// <summary>
        /// 主角的动画控制
        /// </summary>
        IEnumerator ControlHeroAnimationState()
        {
            print("-------------------------------------");
            //这里替代Update的功能，实现不断更新功能，所以用了 while/true的死循环
            while (true)
            {
                yield return new WaitForSeconds(0.1F);//每隔0.1s循环一次

                switch (CurrentActionState)
                {
                    case HeroActionState.None:
                        break;
                    case HeroActionState.Idle:
                        //播放动画
                        _AnimationHandle.CrossFade(Ani_Idle.name);//这里可以使用Play，但CrossFade有淡入淡出的效果
                         break;
                    case HeroActionState.Running:
                        //播放动画
                        _AnimationHandle.CrossFade(Ani_Running.name);
                        //处理主角跑动音效
                        AudioManager.PlayAudioEffectB(AcHeroRunning);
                        yield return new WaitForSeconds(AcHeroRunning.length);//加一个时间，正好是音效播放时长
                        break;
                    case HeroActionState.NormalAttack:
                        /* 攻击连招处理（自动状态转换）  */  //第一招到第二招到第三招
                        switch (_CurATKCombo)
                        {
                            case NormalATKComboState.NormalATK1:
                                _CurATKCombo = NormalATKComboState.NormalATK2;
                                _AnimationHandle.CrossFade(Ani_NormalAttack1.name);
                                AudioManager.PlayAudioEffectA(BeiJi_DaoJian_3);
                                yield return new WaitForSeconds(Ani_NormalAttack1.length / 2.5F);
                                _CurrentActionState = HeroActionState.Idle;
                                break; 
                            case NormalATKComboState.NormalATK2:
                                _CurATKCombo = NormalATKComboState.NormalATK3;
                                _AnimationHandle.CrossFade(Ani_NormalAttack2.name);
                                AudioManager.PlayAudioEffectA(BeiJi_DaoJian_2);
                                yield return new WaitForSeconds(Ani_NormalAttack2.length / 2.5F);
                                _CurrentActionState = HeroActionState.Idle;
                                break;
                            case NormalATKComboState.NormalATK3:
                                _CurATKCombo = NormalATKComboState.NormalATK1;                              
                                _AnimationHandle.CrossFade(Ani_NormalAttack3.name);
                                AudioManager.PlayAudioEffectA(BeiJi_DaoJian_1);
                                yield return new WaitForSeconds(Ani_NormalAttack3.length / 2F);
                                _CurrentActionState = HeroActionState.Idle;
                                break;
                            default:
                                break;
                        }
                        break;
                    case HeroActionState.MagicTrickA:                      
                        _AnimationHandle.CrossFade(Ani_MagicTrickA.name);
                        AudioManager.PlayAudioEffectA(SwordHero_MagicA);
                        yield return new WaitForSeconds(Ani_MagicTrickA.length);
                        _CurrentActionState = HeroActionState.Idle;
                        break;
                    case HeroActionState.MagicTrickB:
                        //播放动画
                        _AnimationHandle.CrossFade(Ani_MagicTrickB.name);
                        AudioManager.PlayAudioEffectA(SwordHero_MagicB);                      
                        yield return new WaitForSeconds(Ani_MagicTrickB.length);
                        _CurrentActionState = HeroActionState.Idle;
                        break;
                    default:
                        break;
                }//switch_end
            }//while_end
        }//IEnumerator_end

        /// <summary>
        /// 动画事件_主角大招A
        /// </summary>
        /// <returns></returns>
        public IEnumerator AnimationEvent_HeroMagicA()
        {

            StartCoroutine(LoadParticalEffectPublicMethod(GlobalParameter.INTERVAL_TIME_0DOT1,
                "ParticleProps/Hero_MagicA(bruceSkill)", true,transform.position, transform.rotation, transform,null, 0 ));
             yield break; //(相当于方法中的return null)

           
        }

        /// <summary>
        /// 动画事件_主角大招B
        /// </summary>
        /// <returns></returns>
        public IEnumerator AnimationEvent_HeroMagicB()
        {
            StartCoroutine(LoadParticalEffectPublicMethod(GlobalParameter.INTERVAL_TIME_0DOT1,
                "ParticleProps/Hero_MagicB(groundBrokeRed)", true, transform.position+ transform.TransformDirection(new Vector3(0F, 0F, 5F)), transform.rotation,transform, null, 0));
            yield break; //(相当于方法中的return null)

        }

        /// <summary>
        /// 普通剑法粒子特效（主角左右劈砍）
        /// </summary>
        /// <returns></returns>
        public IEnumerator AnimationEvent_HeroNormalATK_A()
        {
            /* 传统方式，没有使用对象缓冲池*/
            //StartCoroutine(LoadParticalEffectPublicMethod(GlobalParameter.INTERVAL_TIME_0DOT1,
            //    "ParticleProps/Hero_NormalATK1", true, transform.position + transform.TransformDirection(new Vector3(0F, 0F, 1F)), transform, null, 0));
            //    yield break; //(相当于方法中的return null)

            //定义粒子特效的位置(主角前方5米的位置)
            goHeroNormalParticalEffect1.transform.position = transform.position + transform.TransformDirection(new Vector3(0F, 0F, 1F));
            /* 使用对象缓冲池技术 */
            //在缓冲池中，得到一个指定的预设”激活体“。
            PoolManager.PoolsArray["_ParticalSys"].GetGameObjectByPool(goHeroNormalParticalEffect1, goHeroNormalParticalEffect1.transform.position, Quaternion.identity);
            yield break;
        }

        /// <summary>
        /// 普通剑法粒子特效（主角中间刺入）
        /// </summary>
        /// <returns></returns>
        public IEnumerator AnimationEvent_HeroNormalATK_B()
        {
            /* 传统方式 */
            StartCoroutine(LoadParticalEffectPublicMethod(GlobalParameter.INTERVAL_TIME_0DOT1,
                "ParticleProps/Hero_NormalATK2", true, transform.position + transform.TransformDirection(new Vector3(0F, 0F, 1F)), transform.rotation ,transform, null, 0.5F));
            yield break;

            ////定义粒子特效的位置(主角前方5米的位置)
            //goHeroNormalParticalEffect1.transform.position = transform.position + transform.TransformDirection(new Vector3(0F, 0F, 1F));
            ///* 使用对象缓冲池技术 */
            ////在缓冲池中，得到一个指定的预设”激活体“。
            //PoolManager.PoolsArray["_ParticalSys"].GetGameObjectByPool(goHeroNormalParticalEffect2, goHeroNormalParticalEffect2.transform.position, Quaternion.identity);
            //yield break;
        }

        /// <summary>
        /// 主角登场特效
        /// </summary>
        private void HeroDisplayParticalEffect()
        {
            StartCoroutine(LoadParticalEffectPublicMethod(GlobalParameter.INTERVAL_TIME_0DOT1,
                "ParticleProps/Hero_Display", true, transform.position, transform.rotation, transform, null, 0));
         
        }
    }
}

