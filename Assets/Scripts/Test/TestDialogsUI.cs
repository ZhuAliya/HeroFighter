/***
   *     Title: "英雄战神" 项目开发
   *      视图层：测试对话系统的UI
   *      Description:
   *          作用：仅测试使用
   *               
   *                
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using System.Collections;
using Kernal;
using Global;

namespace View
{
    public class TestDialogsUI : MonoBehaviour
    {

        void Start()
        {
             DialogUIMgr._Instance.DisplayNextDialog(DialogType.DoubleDialogs, 1);
           // DialogUIMgr._Instance.DisplayNextDialog(DialogType.SingleDialogs, 2);//单人对话
        }

        /// <summary>
        /// 显示下一条对话信息
        /// </summary>
        public void DisplayNextDialogInfo()
        {
            bool boolResult = DialogUIMgr._Instance.DisplayNextDialog(DialogType.DoubleDialogs, 1);//双人对话
           // bool boolResult = DialogUIMgr._Instance.DisplayNextDialog(DialogType.SingleDialogs, 2);//单人对话
            if (boolResult)
            {
                Log.Write(GetType() + "/DisplayNextDialogInfo()/对话结束");
            }
            Log.SyncLogArrayToFile();
        }
    }

}
