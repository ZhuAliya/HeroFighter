/***
   *        Title: "英雄战神" 项目开发
   *    视图层：第一关卡场景
   *      Description:
   *                第一关卡场景的界面控制
   *       Data:	[2018]
   *       Version: 0.1
 * */

using UnityEngine;
using System.Collections;
using Kernal;
using Global;

namespace View
{
    public class View_LevelOneScenes : MonoBehaviour
    {
        public GameObject goUINormalATK;                                        //普通攻击
        public GameObject goUIMagicATK_A;                                      //大招A
        public GameObject goUIMagicATK_B;                                      //大招B
        public GameObject goUIMagicATK_C;                                      //大招C
        public GameObject goUIMagicATK_D;                                      //大招D

        IEnumerator Start()
        {
            //等待0.2s,因为下面启用的View_ATKButtonCDEffect.cs里面还有一个Start()，
            //如果View_ATKButtonCDEffect里面的start没有处理完，而先处理下面的EnableSelf()和DisableSelf就会冲突
            //所以必须先让<View_ATKButtonCDEffect>().EnableSelf()/DisableSelf()里面的start()启动起来再启动本脚本的EnableSelf()/DisableSelf()
            //所以用协程来调节时间
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT2);
            /* 大招是否启用控制 */
            goUIMagicATK_A.GetComponent<View_ATKButtonCDEffect>().EnableSelf();//启用
            goUIMagicATK_B.GetComponent<View_ATKButtonCDEffect>().EnableSelf();//启用
            goUIMagicATK_C.GetComponent<View_ATKButtonCDEffect>().DisableSelf();//不启用
            goUIMagicATK_D.GetComponent<View_ATKButtonCDEffect>().DisableSelf();//不启用
        }
    }
}

