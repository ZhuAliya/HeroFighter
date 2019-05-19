/***
   *        Title: "英雄战神" 项目开发
   *       视图层：登录场景
       
   *      Description:
   *                [描述]
   *       Data:	[2018]
   *       Version: 0.1
 * */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Global;
using Kernal;
using Control;

namespace View
{
    public class View_LoginScenes : MonoBehaviour
    {
        public GameObject goSwordHero;                   //少年剑侠对象
        public GameObject goMagicHero;                   //魔杖真人对象
        public GameObject goUISwordHeroInfo;         //少年剑侠UI面板
        public GameObject goUIMagicHeroInfo;          //魔杖真人UI面板
        public InputField inpUserName;                       //用户的名称

        void Start()
        {
            //获取玩家的类型()
            GlobalParaMgr.PlayerTypes = PlayerType.SwordHero;
            inpUserName.text = "小豆豆";
        }

        /// <summary>
        /// 选择少年剑侠
        /// </summary>
        public void ChangeToSwordHero()
        {
            //显示对象
            goSwordHero.SetActive(true);
            goMagicHero.SetActive(false);
            //显示UI
            goUISwordHeroInfo.SetActive(true);
            goUIMagicHeroInfo.SetActive(false);
            //获取玩家的类型
            //  GlobalParaMgr.PlayerTypes = GlobalParameter.PlayerType.SwordHero;
            //播放音效
            Ctrl_LoginScenes.Instance.PlayAudioEffectBySword();
        }

        /// <summary>
        /// 选择魔杖真人
        /// </summary>
        public void ChangeToMagicHero()
        {
            //显示对象
            goMagicHero.SetActive(true);
            goSwordHero.SetActive(false);
            //显示UI
            goUIMagicHeroInfo.SetActive(true);
            goUISwordHeroInfo.SetActive(false);
            //获取玩家的类型
           GlobalParaMgr.PlayerTypes = PlayerType.MagicHero;
            //播放音效
            Ctrl_LoginScenes.Instance.PlayAudioEffectByMagic();
        }

        /// <summary>
        /// 提交信息
        /// </summary>
        public void SubmitInfo()
        {
            //获取用户名
            GlobalParaMgr.PlayerName = inpUserName.text;
            //跳转下一个场景
            //(控制层方法)
            Ctrl_LoginScenes.Instance.EnterNextScenes();
        }
        
    }
}

