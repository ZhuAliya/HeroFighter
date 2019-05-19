/***
   *     Title: "英雄战神" 项目开发
   *      视图层：新手引导模块--触发虚拟摇杆（ET）
   *      Description:
   *          作用：
   *                               
   *       Data:	[2018]
   *       Version: 0.1
 * */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Global;
using Kernal;

namespace View
{
    public class TriggerOperET : MonoBehaviour, IGuideTrigger
    {

        public static TriggerOperET Instance;               //本类实例
        public GameObject GoBackground;                 //背景游戏对象(对话界面)
        private bool _IsExistNextDialogsRecorder = false;   //是否存在下一条对话记录
        private Image _ImgGuideET;                            //引导ET贴图
        void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            //引导ET贴图
            _ImgGuideET = transform.parent.Find("ImgET").GetComponent<Image>();
            //注册”引导ET贴图“
            RigisterGuideET();
        }

        /// <summary>
        /// 检查触发条件
        /// </summary>
        /// <returns>
        /// true:表示条件成立，触发后续业务逻辑
        /// </returns>
        public bool CheckCondition()
        {
            Log.Write(GetType() + "/CheckCondition");
            if(_IsExistNextDialogsRecorder)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 运行业务逻辑
        /// </summary>
        /// <returns>
        /// true:表示业务逻辑执行完毕
        /// </returns>
        public bool RunOperation()
        {
            Log.Write(GetType() + "/RunOperation");
            _IsExistNextDialogsRecorder = false;
            //隐藏对话界面
            GoBackground.SetActive(false);
            //隐藏“引导ET贴图”
            _ImgGuideET.gameObject.SetActive(false);
            //激活ET        
            View_PlayerInfoResponse.Instance.DisplayET();
            //恢复对话系统，继续会话
            StartCoroutine("ResumeDialogs");
            return true;
        }

        /// <summary>
        /// 显示“引导ET贴图”
        /// </summary>
        public void DisplayGuideET()
        {
            _ImgGuideET.gameObject.SetActive(true);
        }

        /// <summary>
        ///注册”引导ET贴图“ 
        /// </summary>
        private void RigisterGuideET()
        {
            if (_ImgGuideET != null)
            {
                EventTriggerListener.Get(_ImgGuideET.gameObject).onClick += GuideETOperation;
            }
        }

        /// <summary>
        /// 引导ET操作
        /// </summary>
        /// <param name="go"></param>
        private void GuideETOperation(GameObject go)
        {
            if(go == _ImgGuideET.gameObject)
            {
                _IsExistNextDialogsRecorder = true;
            }
        }

        /// <summary>
        /// 恢复对话系统，继续会话
        /// </summary>
        /// <returns></returns>
        IEnumerator ResumeDialogs()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_3);
            //隐藏ET
            View_PlayerInfoResponse.Instance.HideET();
            //注册会话系统，允许继续会话
            TriggerDialogs.Instance.RigisterDialogs();
            //运行对话系统，直接显示下一条对话
            TriggerDialogs.Instance.RunOperation();
            //显示对话界面
            GoBackground.SetActive(true);

        }
    }
}
