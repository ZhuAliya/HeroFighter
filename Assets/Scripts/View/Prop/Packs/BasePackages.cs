/***
   *       Title: "英雄战神" 项目开发
   *       视图层：装备(背包)系统
   *                    定义父类
   *       Description:
   *                作用：定义装备系统的一般性操作，例如拖拽等。
   *                注意：必须给每一个道具，添加同样的标签（否则会出错）
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Kernal;
using Global;
using UnityEngine.EventSystems;                             //Unity的事件系统

namespace View
{
    public class BasePackages : MonoBehaviour
    {
        protected string strMoveToTargetGridName;   //"目标格子"名称
        private CanvasGroup _CanvasGroup;                //用于贴图的穿透处理
        private Vector3 _OriginalPosition;                    //原始位置
        private Transform _MyTransform;                    //本对象方位
        private RectTransform _MyReTransform;          //二维方位



        /// <summary>
        /// 运行本类实例，通过子类执行
        /// </summary>
        protected void RunInstanceByChildClass()
        {
            Base_Start();
        }

        /// <summary>
        /// 父类实例化
        /// </summary>
        void Base_Start()
        {
            //贴图穿透组件
            _CanvasGroup = this.GetComponent<CanvasGroup>();
            //二维方位
            _MyReTransform = this.transform as RectTransform;
            //本贴图方位
            _MyTransform = this.transform;

        }

        /// <summary>
        /// 拖拽前处理
        /// </summary>
        /// <param name="eventData"></param>
        public void Base_OnBeginDrag(PointerEventData eventData)
        {
            //忽略自身，（可以穿透）
            _CanvasGroup.blocksRaycasts = false;
            //保证当前贴图可见
            this.gameObject.transform.SetAsLastSibling();
            //获得原始方位
            _OriginalPosition = _MyTransform.position;
        }

        /// <summary>
        /// 拖拽中处理
        /// </summary>
        /// <param name="eventData"></param>
        public void Base_OnDrag(PointerEventData eventData)
        {
            Vector3 globalMousePosition;                     //当前鼠标的位置

            //屏幕坐标，转二维矩阵坐标
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(_MyReTransform, eventData.position, eventData.pressEventCamera, out globalMousePosition))
            {
                _MyReTransform.position = globalMousePosition; //二维方位位置=当前鼠标的位置
            }
        }

        /// <summary>
        /// 拖拽后处理
        /// </summary>
        /// <param name="eventData"></param>
        public void Base_OnEndDrag(PointerEventData eventData)
        {
            //当前鼠标经过的”格子名称“
            GameObject cur = eventData.pointerEnter;  //cur代表当前鼠标
            if (cur != null)
            {
                //移动到（符合条件）的物品格子上
                if (cur.name.Equals(strMoveToTargetGridName)) //"目标格子"名称 strMoveToTargetGridName; 
                {
                    //遇到了目标点
                    _MyTransform.position = cur.transform.position;
                    _OriginalPosition = _MyTransform.position;
                    //执行特定的装备方法
                    InvokeMethodByEndDrag();
                }
                //没有遇到目标点
                else
                {
                    //移动到背包系统的其他有效位置上

                    //如果是"同类背包"道具，则交换位置
                    if((cur.tag == eventData.pointerDrag.tag) && (cur.name != eventData.pointerDrag.name)) //标签名相同，但名字不同
                    {
                        //写”被覆盖贴图“位置与”当前贴图“位置的互换
                        Vector3 targetPosition = cur.transform.position;
                        cur.transform.position = _OriginalPosition;
                        _MyTransform.position = targetPosition;
                        //新的位置，确定为新的”原始位置“
                        _OriginalPosition = _MyTransform.position;
                    }
                    else
                    {
                        //拖拽到背包界面的其他对象上
                        //返回
                        _MyTransform.position = _OriginalPosition;
                    }
                    //阻止穿透，可以进行再次移动
                     _CanvasGroup.blocksRaycasts = true;
                }
            }
            //拖拽到空区域
            else
            {
                //返回
                _MyTransform.position = _OriginalPosition;
            }
        }

        /// <summary>
        /// (虚方法)执行特定的装备方法
        /// </summary>
        protected virtual void InvokeMethodByEndDrag()
        {
            print(GetType() + "/InvokeMethodByEndDrag()");
        }

    }//Class_end
}

