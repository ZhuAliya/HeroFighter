/***
   *       Title: "英雄战神" 项目开发
   *       视图层：背包系统的拖拽基本原理
   *       Description:
   *                [描述]：本脚本为测试脚本
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Kernal;
using Global;
using UnityEngine.EventSystems;                             //Unity的事件系统

namespace Test
{
    public class TestPackageDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private CanvasGroup _CanvasGroup;                //用于贴图的穿透处理
        private Vector3 _OriginalPosition;                    //原始方位
        private RectTransform _MyReTransform;          //二维方位

    
        void Start()
        {
            //贴图穿透组件
            _CanvasGroup = this.GetComponent<CanvasGroup>();
            //二维方位
            _MyReTransform = this.transform as RectTransform;
            //获得原始方位
            _OriginalPosition = _MyReTransform.position;

        }

        /// <summary>
        /// 拖拽处理
        /// </summary>
        /// <param name="eventData"></param>
        public void OnBeginDrag(PointerEventData eventData)
        {
            //忽略自身，（可以穿透）
            _CanvasGroup.blocksRaycasts = false;
            //保证当前贴图可见
            this.gameObject.transform.SetAsLastSibling();
        }

        /// <summary>
        /// 拖拽中处理
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrag(PointerEventData eventData)
        {
            Vector3 globalMousePosition;                     //当前鼠标的位置

            //屏幕坐标，转二维矩阵坐标
            if(RectTransformUtility.ScreenPointToWorldPointInRectangle(_MyReTransform, eventData.position, eventData.pressEventCamera, out  globalMousePosition))
            {
                _MyReTransform.position = globalMousePosition; //二维方位位置=当前鼠标的位置
            }
        }

        /// <summary>
        /// 拖拽后处理
        /// </summary>
        /// <param name="eventData"></param>
        public void OnEndDrag(PointerEventData eventData)
        {
            //当前鼠标经过的”格子名称“
            GameObject cur = eventData.pointerEnter;
            if(cur != null)
            {
                if(cur.name.Equals("ImgGoalPosition"))
                {
                    //遇到了目标点
                    _MyReTransform.position = cur.transform.position;
                    _OriginalPosition = _MyReTransform.position;
                }
                else //没有遇到目标点
                {
                    //返回
                    _MyReTransform.position = _OriginalPosition;
                    //组织穿透，可以进行再次移动
                    _CanvasGroup.blocksRaycasts = true;
                }
            }
            //拖拽到空区域
            else
            {
                //返回
                _MyReTransform.position = _OriginalPosition;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

