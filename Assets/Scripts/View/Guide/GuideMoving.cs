/***
   *     Title: "英雄战神" 项目开发
   *            视图层：新手引导移动动画效果
   *      Description:
   *            作用：
   *                               
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Kernal;

namespace View
{
    public class GuideMoving : MonoBehaviour
    {
        public GameObject goMovingGoal;                           //移动的目标对象
        
        void Start()
        {
            iTween.MoveTo(this.gameObject,
                iTween.Hash("position", goMovingGoal.transform.position,
                "time", 1F,
                "looptype", iTween.LoopType.loop
                )
                );
                
        }

       
    } 
}

