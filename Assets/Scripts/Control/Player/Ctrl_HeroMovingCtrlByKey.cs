/***
   *        Title: "英雄战神" 项目开发
   *    控制层：主角移动通过键盘方式
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
    public class Ctrl_HeroMovingCtrlByKey : BaseControl
    {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR
        public float Flo_HeroMovingSpeed = 5F;      //英雄移动的速度
                                                    //  public AnimationClip Ani_Idle;                        //动画剪辑_休闲
                                                    //  public AnimationClip Ani_Runing;                  //动画剪辑_运动
                                                    //摇杆的名称
                                                    //private const string JOYSTICK_NAME = "Hero Joystick";

        private CharacterController CC;                    //角色控制器
        //角色控制器重力
        private float _FloGravity = 1F;//(重点***模拟重力***)
    

        void Start()
        {
            //得到角色控制器
            CC = this.GetComponent<CharacterController>();
        }

        void Update()
        {
                ControlMoving();           
        }

        /// <summary>
        /// 控制主角移动
        /// </summary>
        void ControlMoving( )
        {

            //点击键盘按键，获取水平与垂直偏移量
            //float joyPositionX = move.joystickAxis.x;
            //float joyPositionY = move.joystickAxis.y;
           float floMovingXPos = Input.GetAxis("Horizontal");//从-1到1的偏移量
            float floMovingYPos = Input.GetAxis("Vertical");

            if (floMovingXPos != 0 || floMovingYPos != 0)
            {
                //设置角色的朝向（朝向当前坐标+摇杆偏移量）
                if (Ctrl_HeroAnimationCtrl.Instance.CurrentActionState != HeroActionState.MagicTrickB)
                {
                    transform.LookAt(new Vector3(transform.position.x - floMovingXPos, transform.position.y, transform.position.z - floMovingYPos));
                }

                //移动玩家的位置（按朝向位置移动）  
                // transform.Translate(Vector3.forward * Time.deltaTime * 5);
                Vector3 movement = transform.forward * Time.deltaTime * Flo_HeroMovingSpeed; //移动方向
                //角色控制器增加模拟重力(重点***模拟重力***)
                movement.y -= _FloGravity;
                if (Ctrl_HeroAnimationCtrl.Instance.CurrentActionState == HeroActionState.Idle ||
                  Ctrl_HeroAnimationCtrl.Instance.CurrentActionState == HeroActionState.Running)
                {
                    //角色控制器
                    CC.Move(movement); //移动方向
                    //播放奔跑动画  
                    // GetComponent<Animation>().CrossFade(Ani_Runing.name);//被代替
                    if (UnityHelper.GetInstance().GetSmallTime(0.3F))//0.2
                    {
                        Ctrl_HeroAnimationCtrl.Instance.SetCurrentActionState(HeroActionState.Running);
                    }
                }
                           
            }
            //else
            //{
            //    //print("没有按键。。。");
            //    //Ctrl_HeroAnimationCtrl.Instance.SetCurreentActionState(HeroActionState.Idle); //一秒钟打印了太多次了，休闲状态导致按键其他攻击技能时延迟
            // /*  控制主角移动的时候，没有动键盘，这一块会发送大量的代码，会造成拥堵*/  
            ////if (UnityHelper.GetInstance().GetSmallTime(0.2F))
            //    //{
            //    //   Ctrl_HeroAnimationCtrl.Instance.SetCurreentActionState(HeroActionState.Idle);
            //    //}
            //}
        }
#endif
    }//class_end

}

