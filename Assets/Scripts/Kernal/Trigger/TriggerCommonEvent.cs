/***
   *    Title: "英雄战神" 项目开发
   *                核心层：通用触发脚本
   *    Description:
   *                功能：1：NPC/敌人触发对话。
   *                          2：存盘/继续
   *                          3：加载与启用特定的脚本（例如：产生敌人）
   *                          4：触发UI“对话/确认框”等。
   *    Data:	[2018]
   *    Version: 0.1
 * */
using UnityEngine;
using System.Collections;
using Kernal;
using Global;

namespace Kernal
{
    public enum CommonTriggerType
    {
        None,
        NPC1_Dialog,                                              //  NPC1对话
        NPC2_Dialog,
        NPC3_Dialog,
        NPC4_Dialog,
        NPC5_Dialog,
        Enemy1_Dialog,                                           //敌人对话
        Enemy2_Dialog,
        Enemy3_Dialog,
        Enemy4_Dialog,
        Enemy5_Dialog,
        SaveDataOrScenes,                                      //存盘
        LoadDataOrScenes,                                     //调用
        EnableScript1,                                              //加载或者启用特定的脚本
        EnableScript2,
        ActiveConfirmWindows,                               //触发确认窗体
        ActiveDialogWindows,                                 //触发对话窗体
    }

    /// <summary>
    /// 委托：通用触发
    /// </summary>
    /// <param name="CTT"></param>
    public delegate void del_CommonTrigger(CommonTriggerType CTT);

    public class TriggerCommonEvent : MonoBehaviour
    {
        //定义事件
        public static event del_CommonTrigger eveCommonTrigger;
        //对话类型
        public CommonTriggerType TriggerType = CommonTriggerType.None;
        //英雄标签名称
        public string TagNameByHero = "Player";

        /// <summary>
        /// 触发进入检测
        /// </summary>
        /// <param name="con"></param>
        void OnTriggerEnter(Collider con)
        {
            if(con.gameObject.tag == TagNameByHero)
            {
                //事件调用
                if(eveCommonTrigger != null)
                {
                    eveCommonTrigger(TriggerType);
                }
            }
        }

      

    }
}

