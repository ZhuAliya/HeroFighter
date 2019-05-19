/***
   *     Title: "英雄战神" 项目开发
   *      视图层：全局参数管理器
   *      Description:
   *          作用：仅测试使用
   *               
   *                
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Kernal;

namespace View
{
    public class TestDialogsInfo : MonoBehaviour
    {
        public Text TxtSide;
        public Text TxtPersonName;
        public Text TxtPersonContent;
          
        /// <summary>
        /// 得到下一条对话信息
        /// </summary>
        public void DisplayNextDialogInfo()
        {
            Log.Write(GetType() + "/DisplayNextDialogInfo()");
            DialogSide diaSide = DialogSide.None;
            string strDialogPersonName;
            string strDialogPersonContent;

            bool  boolResult= DialogDataMgr.GetInstance().GetNextDialogInfoRecoder(2, out diaSide, out strDialogPersonName, out strDialogPersonContent);
            if (boolResult)
            {
                switch (diaSide)
                {
                    case DialogSide.None:
                        break;
                    case DialogSide.HeroSide:
                        TxtSide.text = "英雄";
                        break;
                    case DialogSide.NPCSide:
                        TxtSide.text = "NPC";
                        break;
                    default:
                        break;
                }
                TxtPersonName.text = strDialogPersonName;
                TxtPersonContent.text = strDialogPersonContent;
            }
            else
            {
                TxtPersonName.text = "没有输出数据了";
                TxtPersonContent.text = "没有输出数据了";
                print("----------------TestDialogsInfo------");
            }
            Log.SyncLogArrayToFile();//同步到文件中
        }

    }
}
