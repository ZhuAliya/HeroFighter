/***
   *        Title: "英雄战神" 项目开发
   *    控制层：英雄的展示
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
    public class Ctrl_DisplayHero : MonoBehaviour
    {
        public AnimationClip AniIdle;                            //动画剪辑_休闲
        public AnimationClip AniRuning;
        public AnimationClip AniAttack;
        private Animation _AniCurrentAnimation;      //当前动画
        private float _FloIntervalTime = 3F;                 //间隔的时间
        private int _IntRandomPlayNum;                     //随机动作编号

        void Start()
        {
            _AniCurrentAnimation = this.GetComponent<Animation>();
        }

        /// <summary>
        /// 算法：间隔3秒钟，随机播放一个人物动画
        /// </summary>
        void Update()
        {
            _FloIntervalTime -= Time.deltaTime;
            if(_FloIntervalTime <= 0)
            {
                _FloIntervalTime = 3F;
                //得到随机数
                _IntRandomPlayNum = Random.Range(1, 4);
                DisplayHeroPlaying(_IntRandomPlayNum);
            }
        }

        /// <summary>
        /// 展示动作
        /// </summary>
        /// <param name="intPlayingNum">动作编号</param>
        internal void DisplayHeroPlaying(int intPlayingNum)
        {
            switch(intPlayingNum)
            {
                case 1:
                    DisplayIdle();
                    break;
                case 2:
                    DisplayRuning();
                    break;
                case 3:
                    DisplayAttack();
                    break;
                default:
                    break;

            }
        }


        /// <summary>
        /// 展示休闲动作
        /// </summary>
        internal void DisplayIdle()
        {
            if(_AniCurrentAnimation)
            {
               // _AniCurrentAnimation.Play(AniIdle.name);
                _AniCurrentAnimation.CrossFade(AniIdle.name);
            }
        }

        /// <summary>
        /// 展示跑动作
        /// </summary>
        internal void DisplayRuning()
        {
            _AniCurrentAnimation.CrossFade(AniRuning.name);
        }

        /// <summary>
        /// 展示攻击动作
        /// </summary>
        internal void DisplayAttack()
        {
            _AniCurrentAnimation.CrossFade(AniAttack.name);
        }

      
    }

}
