/***
   *        Title: "英雄战神" 项目开发
   *    控制层：主角攻击输入，通过键盘方式
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
    public class Ctrl_HeroAttackInputByKey : BaseControl
    {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR
        //事件：主角控制
        public static event del_PlayerControlWithStr evePlayerControl;

        void Start()
        {

        }


        void Update()
        {
            //普通攻击用Input.GetButtonDown不合适，应该改为Input.GetButton，即按住J键不动，它一直返回攻击
            if (Input.GetButtonDown(GlobalParameter.INPUT_MGR_ATTACKNAME_NORMAL))
            {
                // print("NormalAttack, 您按了INPUT_MGR_ATTACKNAME_NORMAL");
                if (evePlayerControl != null)
                {
                    evePlayerControl(GlobalParameter.INPUT_MGR_ATTACKNAME_NORMAL);
                }
            }
            else if(Input.GetButtonDown(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICK_A))
            {
              //  print("MagicTrickA, 您按了K键");
                if (evePlayerControl != null)
                {
                    evePlayerControl(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICK_A);
                }
            }
            else if(Input.GetButtonDown(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICK_B))
            {
               // print("MagicTrickB, 您按了L键");
                if (evePlayerControl != null)
                {
                    evePlayerControl(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICK_B);
                }
            }
#endif
        }//Update_end
    }//Class_end
}

