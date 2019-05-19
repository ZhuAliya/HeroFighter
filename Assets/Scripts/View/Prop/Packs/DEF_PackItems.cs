﻿/***
   *       Title: "英雄战神" 项目开发
   *       视图层：装备(背包)系统
   *                    防御力道具
   *       Description:
   *                作用：
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Kernal;
using Global;
using UnityEngine.EventSystems;                             //Unity的事件系统
using Model;

namespace View
{
    public class DEF_PackItems : BasePackages, IBeginDragHandler, IDragHandler, IEndDragHandler
    {

        //定义”目标格子“名称
        public string StrTargetGridName = "Img_DEF";
        //主角增加防御力
        public float FloAddHeroMaxDEF = 15;

        void Start()
        {
            //赋值目标格子名称
            base.strMoveToTargetGridName = StrTargetGridName;
            //运行父类的初始化
            base.RunInstanceByChildClass();
        }

        /// <summary>
        /// 重载执行特定的装备方法
        /// </summary>
        protected override void InvokeMethodByEndDrag()
        {
            print(GetType() + "/InvokeMethodByEndDrag()");
            //主角增加防御力
            PlayerKernalDataProxy.GetInstance().IncreaseMaxDEF(FloAddHeroMaxDEF);
            PlayerKernalDataProxy.GetInstance().UpdateDEFValue();//更新防御力
        }

        /// <summary>
        /// 拖拽前处理
        /// </summary>
        /// <param name="eventData"></param>
        public void OnBeginDrag(PointerEventData eventData)
        {
            base.Base_OnBeginDrag(eventData);
        }

        /// <summary>
        /// 拖拽中处理
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrag(PointerEventData eventData)
        {
            base.Base_OnDrag(eventData);
        }

        /// <summary>
        /// 拖拽后处理
        /// </summary>
        /// <param name="eventData"></param>
        public void OnEndDrag(PointerEventData eventData)
        {
            base.Base_OnEndDrag(eventData);
        }
    }//Class_end

}
