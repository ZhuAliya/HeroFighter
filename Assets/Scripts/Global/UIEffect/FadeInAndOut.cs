/***
   *       Title: "英雄战神" 项目开发
   *       公共层：场景的淡入淡出      
   *       Description:
   *                [描述]
   *       Data:	[2018]
   *       Version: 0.1
 * */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;


namespace Global
{
    public class FadeInAndOut : MonoBehaviour
    {
        public static FadeInAndOut Instance;        //本类实例
        public GameObject goRawImage;            //RawImage对象
        private RawImage _RawImage;                //RawImage组件
        public float FloColorChangeSpeed = 1F;//颜色变化的速度
        private bool _BoolScenesToClear = true; //屏幕逐渐清晰
        private bool _BoolScenesToBlack =false;//屏幕逐渐暗淡

        void Awake()
        {
            //得到本类的实例
            Instance = this;
            if(goRawImage)
            {
                _RawImage = goRawImage.GetComponent<RawImage>();
            }
        }

        /// <summary>
        /// 设置场景的淡入
        /// </summary>
        public void SetScenesToClear()
        {
            _BoolScenesToClear = true;
            _BoolScenesToBlack = false;
        }

        /// <summary>
        /// 设置场景的淡出
        /// </summary>
        public void SetScenesToBlack()
        {          
            _BoolScenesToClear = false;
            _BoolScenesToBlack = true;
        }

        /// <summary>
        /// 淡入（屏幕逐渐清晰）
        /// </summary>
        private void FadeToClear()
        {
            //运用Color的插值
            _RawImage.color = Color.Lerp(_RawImage.color, Color.clear, FloColorChangeSpeed *Time.deltaTime);
        }

        /// <summary>
        /// 淡出（屏幕逐渐暗淡）
        /// </summary>
        private void FadeToBlack()
        {
            //运用Color的插值
            _RawImage.color = Color.Lerp(_RawImage.color, Color.black, FloColorChangeSpeed * Time.deltaTime);
        }

        /// <summary>
        /// 屏幕淡入
        /// </summary>
        private void ScenesToClear()
        {
            FadeToClear();
            if(_RawImage.color.a <= 0.05)
            {
                _RawImage.color = Color.clear;
                _RawImage.enabled = false; //禁用
                _BoolScenesToClear = false;
            }
        }

        /// <summary>
        /// 屏幕淡出
        /// </summary>
        private void ScenesToBlack()
        {
            _RawImage.enabled = true;
            FadeToBlack();
            if(_RawImage.color.a >= 0.95)
            {
                _RawImage.color = Color.black;
             //   _RawImage.enabled = false;
                _BoolScenesToBlack = false;
            }
        }

        void Update()
        {
            if(_BoolScenesToClear)
            {
                // 屏幕淡入
                ScenesToClear();
            }
            else if(_BoolScenesToBlack)
            {
                //屏幕淡出
                ScenesToBlack();
            }
        }//Update_end

    }//Class_end
}//

