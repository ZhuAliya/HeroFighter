/***
   *    Title: "英雄战神" 项目开发
   *                控制层：主场景控制
   *    Description:
   *                [描述]
   *    Data:	[2018]
   *    Version: 0.1
 * */
using UnityEngine;
using System.Collections;
using Global;
using Kernal;

namespace Control
{
    public class Ctrl_MajorCityScenes : BaseControl
    {
        public AudioClip AcBackground;                      //主城背景音乐

        IEnumerator Start()
        {
            //播放背景音乐
            if(AcBackground!= null)
            {
                AudioManager.PlayBackground(AcBackground);
            }
            //读取单机玩家数据进度
            if(GlobalParaMgr.CurGameType == CurrentGameType.Continue)
            {
                //读取进度
                yield return new WaitForSeconds(2F);
                SaveAndLoading.GetInstance().LoadingGame_PlayerData();
            }
        }
    }
}

