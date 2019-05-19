/***
   *        Title: "英雄战神" 项目开发
   *                控制层：登录场景      
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
    //public class Ctrl_LoginScenes : MonoBehaviour
    public class Ctrl_LoginScenes : BaseControl
    {
        public static Ctrl_LoginScenes Instance;    //本类的实例
        public AudioClip aucBackgroundMusic;    //登陆场景背景音乐
        void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            //确定音频的音量
            AudioManager.SetAudioBackgroundVolumns(0.5F);
            AudioManager.SetAudioEffectVolumns(1F);
            //播放背景音乐
            AudioManager.PlayBackground(aucBackgroundMusic);
        }

        /// <summary>
        /// 播放少年剑侠的转换声音
        /// </summary>
        public void PlayAudioEffectBySword()
        {
            //AudioManager.PlayAudioEffectA("1_LightRoar_SwordHero");
            AudioManager.PlayAudioEffectA("SwordHero_MagicA");
            
        }

        /// <summary>
        /// 播放魔杖真人的转换声音
        /// </summary>
        public void PlayAudioEffectByMagic()
        {
            AudioManager.PlayAudioEffectA("2_FireBallEffect_MagicHero");
        }

        /// <summary>
        /// 转到下一个场景 
        /// </summary>
        public void EnterNextScenes()
        {
            //转到下一个场景
            //GlobalParaMgr.NextScenesName = GlobalParameter.ScenesEnum.LevelOne;      
            //Application.LoadLevel(ConvertEnumToStr.GetInstance().GetStrByEnumScenes(GlobalParameter.ScenesEnum.LoadingScene));
            base.EnterNextScenes(ScenesEnum.LevelOne);
        }


        void Update()
        {

        }
    }
}

