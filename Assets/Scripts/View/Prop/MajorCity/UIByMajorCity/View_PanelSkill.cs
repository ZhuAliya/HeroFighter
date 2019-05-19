/***
   *        Title: "英雄战神" 项目开发
   *        视图层：英雄技能窗体
   *        Description:        
   *        Data:	[2018]
   *        Version: 0.1
 * */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Global;
using Kernal;

namespace View
{
    public class View_PanelSkill : MonoBehaviour
    {
        //查看的项目
        public Image ImgNormalATK;                          //普通攻击
        public Image ImgCloseATK;                             //近距离攻击大招
        public Image ImgJumpATK;                             //跳跃大招
        public Image ImgFireATK;                                //火攻大招
        public Image ImgThunderATK;                         //雷电大招

        //显示文字控件
        public Text TxtSkillName;                                 //技能名称
        public Text TxtSkillDescription;                         //技能描述

        void Awake()
        { 
            //"攻击贴图"注册
            RigisterAttack();
        }

        void Start()
        {
            //默认显示“普通攻击”技能介绍
            TxtSkillName.text = "普通技能";
            TxtSkillDescription.text = "普通连招打击，当升级不同等级时候，给敌人的打击会相应提高！";
        }

        /// <summary>
        /// "攻击贴图"注册
        /// </summary>
        public void RigisterAttack()
        {
            if(ImgNormalATK != null)
            {
                EventTriggerListener.Get(ImgNormalATK.gameObject).onClick += NormalATK;
            }
            if (ImgCloseATK != null)
            {
                EventTriggerListener.Get(ImgCloseATK.gameObject).onClick += CloseATK;
            }
            if (ImgJumpATK != null)
            {
                EventTriggerListener.Get(ImgJumpATK.gameObject).onClick += JumpATK;
            }
            if (ImgFireATK != null)
            {
                EventTriggerListener.Get(ImgFireATK.gameObject).onClick += FireATK;
            }
            if (ImgThunderATK != null)
            {
                EventTriggerListener.Get(ImgThunderATK.gameObject).onClick += ThunderATK;
            }
        }

        /// <summary>
        /// “普通攻击 ”技能介绍
        /// </summary>
        /// <param name="go"></param>
        private void NormalATK(GameObject go)
        {
            if(go == ImgNormalATK.gameObject)
            {
                Log.Write(GetType() + "/NormalATK()", Log.Level.Special);
                TxtSkillName.text = "普通技能";
                TxtSkillDescription.text = "普通连招打击，当升级不同等级时候，给敌人的打击会相应提高！";
            }
        }

        /// <summary>
        /// “近距离大招 ”技能介绍
        /// </summary>
        /// <param name="go"></param>
        private void CloseATK(GameObject go)
        {
            if (go == ImgCloseATK.gameObject)
            {
                Log.Write(GetType() + "/CloseATK()", Log.Level.Special);
                TxtSkillName.text = "近距离技能大招";
                TxtSkillDescription.text = "近距离技能大招，给敌人以激烈打击，没有方向性！";
            }
        }

        /// <summary>
        /// “跳跃大招 ”技能介绍
        /// </summary>
        /// <param name="go"></param>
        private void JumpATK(GameObject go)
        {
            if (go == ImgJumpATK.gameObject)
            {
                Log.Write(GetType() + "/JumpATK()", Log.Level.Special);
                TxtSkillName.text = "跳跃大招技能";
                TxtSkillDescription.text = "跳跃大招，给敌人非常强烈的攻击，但是有方向性！";
            }
        }


        /// <summary>
        /// “火攻大招 ”技能介绍
        /// </summary>
        /// <param name="go"></param>
        private void FireATK(GameObject go)
        {
            if (go == ImgFireATK.gameObject)
            {
                Log.Write(GetType() + "/FireATK()", Log.Level.Special);
                TxtSkillName.text = "火攻大招技能";
                TxtSkillDescription.text = "火攻大招技能！";
            }
        }

        /// <summary>
        /// “雷电大招 ”技能介绍
        /// </summary>
        /// <param name="go"></param>
        private void ThunderATK(GameObject go)
        {
            if (go == ImgThunderATK.gameObject)
            {
                Log.Write(GetType() + "/ThunderATK()", Log.Level.Special);
                TxtSkillName.text = "雷电大招技能";
                TxtSkillDescription.text = "雷电大招技能";
            }
        }

    }
}

