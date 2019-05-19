/***
   *        Title: "英雄战神" 项目开发
   *    控制层：主角移动控制脚本(通过EasyTouch插件)
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
    public class Ctrl_HeroMovingCtrlByET : BaseControl
    {
//#if UNITY_ANDROID || UNITY_IPHONE
        public float Flo_HeroMovingSpeed = 5F;              //英雄移动的速度
        public float FloHeroAttackMovingSpeed = 10;     //英雄攻击移动速度
      //  public AnimationClip Ani_Idle;                           //动画剪辑_休闲
      //  public AnimationClip Ani_Runing;                      //动画剪辑_运动
        //摇杆的名称
        //private const string JOYSTICK_NAME = "Hero Joystick";

        private CharacterController CC;                    //角色控制器
        //角色控制器重力
        private float _FloGravity = 1F;//(重点***模拟重力***)


        #region 事件注册
        /// <summary>
        /// 游戏对象启用
        /// </summary>
        void OnEnable()
        {
            EasyJoystick.On_JoystickMove += OnJoystickMove;
            EasyJoystick.On_JoystickMoveEnd += OnJoystickMoveEnd;
        }

        /// <summary>
        /// 游戏对象的销毁
        /// </summary>
        public void OnDestroy()
        {
            EasyJoystick.On_JoystickMove -= OnJoystickMove;
            EasyJoystick.On_JoystickMoveEnd -= OnJoystickMoveEnd;
        }

        /// <summary>
        /// 游戏对象的禁用
        /// </summary>
        public void OnDisable()
        {

        }

        #endregion

        void Start()
        {
            //得到角色控制器
            CC = this.GetComponent<CharacterController>();
            //攻击移动
            StartCoroutine("AttackByMove");
        }

        /// <summary>
        /// 攻击移动
        /// </summary>
        /// <returns></returns>
        IEnumerator AttackByMove()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT5);
            while(true)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT5);
                if(Ctrl_HeroAnimationCtrl.Instance.CurrentActionState == HeroActionState.NormalAttack)
                {       //transform.forward局部坐标系往前 可以省略 this.GameObject
                    Vector3 vec = transform.forward * FloHeroAttackMovingSpeed / 2 * Time.deltaTime; //往后退所以写一个负号
                    CC.Move(vec); //主角攻击的移动，主动向前攻击移动
                }
            }
        }

        /// <summary>
        /// 移动摇杆中  
        /// </summary>
        /// <param name="move"></param>
        void OnJoystickMove(MovingJoystick move)
        {
            if (move.joystickName != GlobalParameter.JOYSTICK_NAME) //
            {
                return;
            }

            //获取摇杆中心偏移的坐标  
            float joyPositionX = move.joystickAxis.x;
            float joyPositionY = move.joystickAxis.y;

            if (joyPositionY != 0 || joyPositionX != 0)
            {
                //设置角色的朝向（朝向当前坐标+摇杆偏移量）  
                if(Ctrl_HeroAnimationCtrl.Instance.CurrentActionState != HeroActionState.MagicTrickB)
                {
                    transform.LookAt(new Vector3(transform.position.x - joyPositionX, transform.position.y, transform.position.z - joyPositionY));
                }               
                //移动玩家的位置（按朝向位置移动）  
                // transform.Translate(Vector3.forward * Time.deltaTime * 5);
                Vector3 movement = transform.forward * Time.deltaTime * Flo_HeroMovingSpeed; //移动方向
                //角色控制器增加模拟重力(重点***模拟重力***)
                movement.y -= _FloGravity;
                //角色控制器
                if(Ctrl_HeroAnimationCtrl.Instance.CurrentActionState ==HeroActionState.Idle ||
                    Ctrl_HeroAnimationCtrl.Instance.CurrentActionState == HeroActionState.Running)
                {
                    CC.Move(movement); //移动方向
                      //播放奔跑动画  
                      // GetComponent<Animation>().CrossFade(Ani_Runing.name);//被代替
                    if (UnityHelper.GetInstance().GetSmallTime(0.3F)) //0.1频率太密集了，改为0.2-0.3
                    {
                        //print("虚拟按键控制移动：跑动状态");
                        Ctrl_HeroAnimationCtrl.Instance.SetCurrentActionState(HeroActionState.Running);
                    }
                }
                          
            }
        }

        /// <summary>
        /// 移动摇杆结束  
        /// </summary>
        /// <param name="move"></param>
        void OnJoystickMoveEnd(MovingJoystick move)
        {
            //停止时，角色恢复idle  
            if (move.joystickName == GlobalParameter.JOYSTICK_NAME)//GlobalParameter.JOYSTICK_NAME重构后的摇杆名称
            {
                // print("虚拟按键控制移动：站立状态");
                //  GetComponent<Animation>().CrossFade(Ani_Idle.name);
                if (Ctrl_HeroAnimationCtrl.Instance.CurrentActionState == HeroActionState.Idle ||
                   Ctrl_HeroAnimationCtrl.Instance.CurrentActionState == HeroActionState.Running)
                {
                    Ctrl_HeroAnimationCtrl.Instance.SetCurrentActionState(HeroActionState.Idle);
                }                    
            }
        }
//#endif
    }

}
