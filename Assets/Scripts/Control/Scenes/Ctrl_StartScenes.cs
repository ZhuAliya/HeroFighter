/***
   *        Title: "英雄战神" 项目开发
   *    控制层：开始场景      
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
    //  public class Ctrl_StartScenes : MonoBehaviour
    public class Ctrl_StartScenes : BaseControl
    {
        public static Ctrl_StartScenes Instance;//本类的实例
        public AudioClip AucBackground;         //背景音乐音频剪辑

        void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            //设置音频的音量
            AudioManager.SetAudioBackgroundVolumns(0.5F);
            AudioManager.SetAudioEffectVolumns(1F);
            //播放背景音乐
            //  AudioManager.PlayBackground("StartScenes");//配置音乐的第一种方式，音频直接加入到内存中
            AudioManager.PlayBackground(AucBackground);//配置音乐的第二种方式，定位适合比较大的音频

        }

        /// <summary>
        /// 点击“新的游戏”
        /// </summary>
        internal void ClickNewGame()
        {
            print(GetType() + "/ClickNewGame()");
            //进入“登陆关卡”
            StartCoroutine("EnterNewGame");
        }

        /// <summary>
        /// 点击“游戏继续”
        /// </summary>
        internal void ClickGameContinue()
        {
            print(GetType() + "/ClickGameContinue()");
            //读取游戏的“进度”
            StartCoroutine("EnterContinueGame");
        }

        // IEnumerator EnterNextScenes()
        /// <summary>
        /// 进入下一个场景
        /// </summary>
        /// <returns></returns>
        IEnumerator EnterNewGame()
        {
            //场景淡出（场景变暗）
            FadeInAndOut.Instance.SetScenesToBlack();//设置场景为淡出效果
            yield return new WaitForSeconds(1.5F);
            //转到下一个场景
            //GlobalParaMgr.NextScenesName = GlobalParameter.ScenesEnum.LoginScene;//转到登陆场景
            //Application.LoadLevel(ConvertEnumToStr.GetInstance().GetStrByEnumScenes(GlobalParameter.ScenesEnum.LoadingScene));
            base.EnterNextScenes(ScenesEnum.LoginScene);
        }

        /// <summary>
        /// 读取游戏的“进度”
        /// </summary>
        /// <returns></returns>
        IEnumerator EnterContinueGame()
        {
            //读取单机进度
            SaveAndLoading.GetInstance().LoadingGame_GlobalParameter();
            //场景淡出（场景变暗）
            FadeInAndOut.Instance.SetScenesToBlack();//设置场景为淡出效果
            yield return new WaitForSeconds(1.5F);
            //转到下一个场景
            base.EnterNextScenes(GlobalParaMgr.NextScenesName);
        }

    }//Class_end
}
