/***
   *     Title: "英雄战神" 项目开发
   *      视图层：新手引导模块--“新手引导管理器”
   *      Description:
   *          作用：控制与协调所有具体的新手引导业务脚本的检查与执行。
   *                               
   *       Data:	[2018]
   *       Version: 0.1
 * */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Global;
using Kernal;

namespace View
{
    public class GuideMgr : MonoBehaviour
    {
        //所有“新手引导”业务逻辑脚本集合。
        private List<IGuideTrigger> _LiGuideTrigger = new List<IGuideTrigger>();

        IEnumerator Start()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0D0OT2);
            //加入所有的“业务逻辑”脚本
            IGuideTrigger iTri_1 = TriggerDialogs.Instance;
            IGuideTrigger iTri_2 = TriggerOperET.Instance;
            IGuideTrigger iTri_3 = TriggerOperVitualKey.Instance;
            _LiGuideTrigger.Add(iTri_1);
            _LiGuideTrigger.Add(iTri_2);
            _LiGuideTrigger.Add(iTri_3);
            //启动业务逻辑脚本的检查
            StartCoroutine("CheckGuideState");
        }


        /// <summary>
        /// 检查引导状态
        /// </summary>
        /// <returns></returns>
        IEnumerator CheckGuideState()
        {
            Log.Write(GetType() + "/CheckGuideState");
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT2);
            while(true)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT5);
                for (int i = 0; i < _LiGuideTrigger.Count; i++)
                {
                    IGuideTrigger iTrigger = _LiGuideTrigger[i];
                    //检查每个业务脚本，是否可以运行
                    if (iTrigger.CheckCondition())
                    {
                        //每个业务脚本，执行业务逻辑
                        if (iTrigger.RunOperation())
                        {
                            Log.Write(GetType() + "/CheckGuideState()/编号为：" + i + "业务逻辑执行完毕，即将在集合中移除。");
                            _LiGuideTrigger.Remove(iTrigger);
                        }
                    }
                }
            }
        }//CheckGuideState_end

    }//Class_end
}
