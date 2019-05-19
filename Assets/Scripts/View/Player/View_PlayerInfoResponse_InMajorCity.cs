/***
   *        Title: "英雄战神" 项目开发
   *        视图层：玩家主城信息响应
   *        Description:   
   *                        作用：主城场景中，关于玩家各种面板的显示与隐藏处理。     （任务系统、背包系统等）
   *        Data:	[2018]
   *        Version: 0.1
 * */
using UnityEngine;
using System.Collections;
using Kernal;
using Global;

namespace View
{
    public class View_PlayerInfoResponse_InMajorCity : MonoBehaviour
    {
        public GameObject goPlayerSkillPanel;             //玩家的技能系统
        public GameObject goPlayerMissionPanel;        //玩家的任务系统
        public GameObject goPlayerMarketPanel;        //玩家的商城系统
        public GameObject goPlayerPackagePanel;      //玩家的装备系统


        /// <summary>
        /// 显示英雄的角色
        /// </summary>
        public void DisplayRoles()
        {

            //View_PlayerInfoResponse.Instance.DisplayOrHidePlayerDetailInfoPanel();
            View_PlayerInfoResponse.Instance.DisplayPlayerRoles();
        }

        /// <summary>
        /// 隐藏英雄的角色
        /// </summary>
        public void HidePlayRoles()
        {
            // View_PlayerInfoResponse.Instance.DisplayOrHidePlayerDetailInfoPanel();
            View_PlayerInfoResponse.Instance.HidePlayerRoles();
        }

        /// <summary>
        /// 显示英雄的技能信息
        /// </summary>
        public void DisplayPlaySkillInfo()
        {
            //预先处理
            if(goPlayerSkillPanel!= null)
            {
                BeforeOpenWindow(goPlayerSkillPanel);
            }
            goPlayerSkillPanel.SetActive(true);
        }

        /// <summary>
        /// 隐藏英雄的技能信息
        /// </summary>
        public void HidePlaySkillInfo()
        {
            //预先处理
            if (goPlayerSkillPanel != null)
            {
                BeforeCloseWindow();
            }
            goPlayerSkillPanel.SetActive(false);
        }

        /// <summary>
        /// 显示英雄的任务信息
        /// </summary>
        public void DisplayPlayMission()
        {
            //预先处理
            if (goPlayerMissionPanel != null)
            {
                BeforeOpenWindow(goPlayerMissionPanel);
            }
            goPlayerMissionPanel.SetActive(true);
        }

        /// <summary>
        /// 隐藏英雄的任务信息
        /// </summary>
        public void HidePlayMission()
        {
            //预先处理
            if (goPlayerMissionPanel != null)
            {
                BeforeCloseWindow();
            }
            goPlayerMissionPanel.SetActive(false);
        }

        /// <summary>
        /// 显示英雄的商城信息
        /// </summary>
        public void DisplayPlayMarker()
        {
            //预先处理
            if (goPlayerMarketPanel != null)
            {
                BeforeOpenWindow(goPlayerMarketPanel);
            }
            goPlayerMarketPanel.SetActive(true);
        }

        /// <summary>
        /// 隐藏英雄的商城信息
        /// </summary>
        public void HidePlayMarker()
        {
            //预先处理
            if (goPlayerMarketPanel != null)
            {
                BeforeCloseWindow();
            }
            goPlayerMarketPanel.SetActive(false);
        }

        /// <summary>
        /// 显示英雄的背包信息
        /// </summary>
        public void DisplayPlayPackage()
        {
            //预先处理
            if (goPlayerPackagePanel != null)
            {
                BeforeOpenWindow(goPlayerPackagePanel);
            }
            goPlayerPackagePanel.SetActive(true);
        }

        /// <summary>
        /// 隐藏英雄的背包信息
        /// </summary>
        public void HidePlayPackage()
        {
            //预先处理
            if (goPlayerPackagePanel != null)
            {
                BeforeCloseWindow();
            }
            goPlayerPackagePanel.SetActive(false);
        }


        /// <summary>
        /// 打开窗体之前的预处理
        /// </summary>
        /// <param name="goNeedDisplayPanel"></param>
        private void BeforeOpenWindow(GameObject goNeedDisplayPanel)
        {
            //禁用ET
            View_PlayerInfoResponse.Instance.HideET();
            //窗体的模态化
            this.gameObject.GetComponent<UIMaskMgr>().SetMaskWindow(goNeedDisplayPanel);
        }

        /// <summary>
        /// 关闭窗体之前的预处理
        /// </summary>
        private void BeforeCloseWindow()
        {
            //开启ET
            View_PlayerInfoResponse.Instance.DisplayET();
            //取消窗体的模态化
            this.gameObject.GetComponent<UIMaskMgr>().CancelMaskWindow();
        }
    }
}

