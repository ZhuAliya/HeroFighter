/***
   *        Title: "英雄战神" 项目开发
   *        视图层：NPC主城对话控制脚本
   *        Description:   
   *                        作用：
   *        Data:	[2018]
   *        Version: 0.1
 * */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Kernal;
using Global;


namespace View
{
    public class NPCDialogs_InMajorCity : MonoBehaviour
    {
        public GameObject goDialogsPlane;                //对话面板
        private Image _ImgBGDialogs;                         //背景对话贴图
        //当前“触发对话目标”（区分NPC1，NPC2）           
        private CommonTriggerType _CommonTriggerType = CommonTriggerType.None;

        void Start()
        {
            //背景贴图
            _ImgBGDialogs = this.transform.parent.Find("Background").GetComponent<Image>();
            //注册“触发器”，对话系统（目的是准备对话）
            RigisterTriggerDialog();
            //注册“背景贴图”（目的是发起对话）
            RigisterBGTexture();
            //设置“背景对话贴图”一开始不显示
            _ImgBGDialogs.gameObject.SetActive(false);
        }

        #region 对话准备阶段
        //注册“触发器”，对话系统
        private void RigisterTriggerDialog()
        {
            TriggerCommonEvent.eveCommonTrigger += StartDialogPrepare;
        }

        /// <summary>
        /// 开始对话准备
        /// </summary>
        /// <param name="CTT"></param>
        private void StartDialogPrepare(CommonTriggerType CTT)
        {
            switch (CTT)
            {
                case CommonTriggerType.None:
                    break;
                case CommonTriggerType.NPC1_Dialog:
                    ActiveNPC1_Dialog();
                    break;
                case CommonTriggerType.NPC2_Dialog:
                    ActiveNPC2_Dialog();
                    break;             
                default:
                    break;
            }
        }

        /// <summary>
        /// 激活NPC1对话
        /// </summary>
        private void ActiveNPC1_Dialog()
        {
            //给NPC1，动态加载贴图
            LoadNPC1_Texture();
            //赋值当前状态
            _CommonTriggerType = CommonTriggerType.NPC1_Dialog;
            //禁用ET
            View_PlayerInfoResponse.Instance.HideET();
            //显示对话UI面板
            goDialogsPlane.gameObject.SetActive(true);
            //显示首句对话
            DisplayNextDialog(5);

        }

        /// <summary>
        /// 激活NPC2对话
        /// </summary>
        private void ActiveNPC2_Dialog()
        {
            //给NPC2，动态加载贴图
            LoadNPC2_Texture();
            //赋值当前状态
            _CommonTriggerType = CommonTriggerType.NPC2_Dialog;
            //禁用ET
            View_PlayerInfoResponse.Instance.HideET();
            //显示对话UI面板
            goDialogsPlane.gameObject.SetActive(true);
            //显示首句对话
            DisplayNextDialog(6);
        }

        #endregion

        //给NPC1，动态加载贴图
        private void LoadNPC1_Texture()
        {
            DialogUIMgr._Instance.SprNPC_Right[0] = ResourcesMgr.GetInstance().LoadResource<Sprite>("Textures/BigScales/NPCTrue_1", true);
            DialogUIMgr._Instance.SprNPC_Right[1] = ResourcesMgr.GetInstance().LoadResource<Sprite>("Textures/BigScales/NPCBW_1", true);
        }

        //给NPC2，动态加载贴图
        private void LoadNPC2_Texture()
        {
            DialogUIMgr._Instance.SprNPC_Right[0] = ResourcesMgr.GetInstance().LoadResource<Sprite>("Textures/BigScales/NPCTrue_2", true);
            DialogUIMgr._Instance.SprNPC_Right[1] = ResourcesMgr.GetInstance().LoadResource<Sprite>("Textures/BigScales/NPCBW_2", true);
        }

        #region 正式对话阶段
        //注册“背景贴图”（目的是发起对话）
        private void RigisterBGTexture()
        {
            if(_ImgBGDialogs != null)
            {
                EventTriggerListener.Get(_ImgBGDialogs.gameObject).onClick += DisplayDialogByNpc;
            }
        }

        /// <summary>
        /// 显示NPC对话
        /// </summary>
        /// <param name="go"></param>
        private void DisplayDialogByNpc(GameObject go)
        {
            switch (_CommonTriggerType)
            {
                case CommonTriggerType.None:
                    break;
                case CommonTriggerType.NPC1_Dialog:
                    DisplayNextDialog(5);
                    break;
                case CommonTriggerType.NPC2_Dialog:
                    DisplayNextDialog(6);
                    break;           
                default:
                    break;
            }
        }

        /// <summary>
        /// 显示下一条对话信息
        /// </summary>
        /// <param name="sectionNum"></param>
        private void DisplayNextDialog(int sectionNum)
        {
            bool boolResult = DialogUIMgr._Instance.DisplayNextDialog(DialogType.DoubleDialogs, sectionNum);
            if(boolResult)
            {
                //对话结束，关闭对话面板
                goDialogsPlane.gameObject.SetActive(false);
                //启用ET
                View_PlayerInfoResponse.Instance.DisplayET();
            }
        }

        #endregion




    }

}
