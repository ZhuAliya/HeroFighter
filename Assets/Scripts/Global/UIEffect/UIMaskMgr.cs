/***
   *    Title: "英雄战神" 项目开发
   *                公共层：UI遮罩管理器
   *    Description:
   *               作用：实现弹出“模态窗体”。
   *    Data:	[2018]
   *    Version: 0.1
 * */

using Kernal;
using UnityEngine;
using System.Collections;

namespace Global
{
    public class UIMaskMgr : MonoBehaviour
    {
        public GameObject goTopPlane;                      //顶层面板
        public GameObject goMaskPlane;                   //遮罩面板
        private Camera _UICamera;                             //UI摄像机
        private float _OriginalUICameraDepth;             //原始UI摄像机的层深

        void Start()
        {
            //得到UI摄像机的原始“深层”
            _UICamera = this.gameObject.transform.parent.FindChild("UICamera").GetComponent<Camera>();
            if(_UICamera != null)
            {
                _OriginalUICameraDepth = _UICamera.depth;
            }
            else
            {
                Debug.Log(GetType() + "/Start()/_UICamera is Null, please Check!");
            }
        }

        /// <summary>
        /// 设置遮罩窗体
        /// </summary>
        /// <param name="goDisplayPlane">需要显示的窗体</param>
        public void SetMaskWindow(GameObject goDisplayPlane)
        {
            //顶层窗体下移
            goTopPlane.transform.SetAsLastSibling();
            //启用遮罩窗体
            goMaskPlane.SetActive(true);
            //遮罩窗体下移
            goMaskPlane.transform.SetAsLastSibling();
            //显示窗体下移
            goDisplayPlane.transform.SetAsLastSibling();
            //增加当前UI摄像机的“层深”
            if(_UICamera != null)
            {
                _UICamera.depth = _UICamera.depth + 20;
            }
        }

        /// <summary>
        /// 取消遮罩窗体
        /// </summary>
        public void CancelMaskWindow()
        {
            //顶层窗体上移
            goTopPlane.transform.SetAsFirstSibling();
            //禁用遮罩窗体
            goMaskPlane.SetActive(false);
            //恢复UI摄像机的原理的“层深”
            _UICamera.depth = _OriginalUICameraDepth;
        }
    }//Class_end
}
