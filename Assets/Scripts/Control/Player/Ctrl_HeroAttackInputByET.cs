/***
   *        Title: "英雄战神" 项目开发
   *    控制层：主角攻击输入
   *      Description:
   *                [描述]
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Kernal;
using Global;
using Model;

namespace Control
{
    public class Ctrl_HeroAttackInputByET : BaseControl
    {
//#if UNITY_ANDROID || UNITY_IPHONE
        public static Ctrl_HeroAttackInputByET Instance;        //本类实例
        //事件：主角控制
        public static event del_PlayerControlWithStr evePlayerControl;

        void Awake()
        {
            Instance = this;
        }

        /// <summary>
        /// 响应普通攻击
        /// </summary>
        public void ResponseATKByNormal()
        {
            if (evePlayerControl != null)
            {
                evePlayerControl(GlobalParameter.INPUT_MGR_ATTACKNAME_NORMAL);
            }
        }
        /// <summary>
        /// 响应大招A
        /// </summary>
        public void ResponseATKByMagicA()
        {
            if (evePlayerControl != null)
            {
                evePlayerControl(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICK_A);
            }
        }

        /// <summary>
        /// 响应大招B
        /// </summary>
        public void ResponseATKByMagicB()
        {
            if (evePlayerControl != null)
            {
                evePlayerControl(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICK_B);
            }
        }

        /// <summary>
        /// 响应大招C
        /// </summary>
        public void ResponseATKByMagicC()
        {
            if (evePlayerControl != null)
            {
                evePlayerControl(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICK_C);
            }
        }

        /// <summary>
        /// 响应大招D
        /// </summary>
        public void ResponseATKByMagicD()
        {
            if (evePlayerControl != null)
            {
                evePlayerControl(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICK_D);
            }
        }

         ////普通攻击用Input.GetButtonDown不合适，应该改为Input.GetButton，即按住J键不动，它一直返回攻击
         //   if (Input.GetButtonDown(GlobalParameter.INPUT_MGR_ATTACKNAME_NORMAL))
         //   {
         //       // print("NormalAttack, 您按了INPUT_MGR_ATTACKNAME_NORMAL");
         //       if (evePlayerControl != null)
         //       {
         //           evePlayerControl(GlobalParameter.INPUT_MGR_ATTACKNAME_NORMAL);
         //       }   
         //   }

//#endif
    }
}

