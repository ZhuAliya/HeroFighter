/***
   *     Title: "英雄战神" 项目开发
   *      视图层：新手引导模块--触发对话引导
   *      Description:
   *          作用：
   *                               
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using System.Collections;
using Global;
using Kernal;
using UnityEngine.UI;

namespace View
{
    public class TriggerDialogs : MonoBehaviour, IGuideTrigger
    {
        /// <summary>
        /// 对话状态
        /// </summary>
        public enum DialogStateStep
        {
            None,                                                           //
            Step1_DoublePersonDialog,                           //双人对话                   
            Step2_AliceSpeakET,                                     //Alice介绍ET
            Step3_AliceSpeakVirtualKey,                         //Alice介绍虚拟按键
            Step4_AliceLastWord,                                   //Alice最后祝福
        }

        public static TriggerDialogs Instance;               //本类实例
        public GameObject GoBackground;                 //背景游戏对象
        private bool _IsExistNextDialogsRecorder = false;   //是否存在下一条对话记录
        private Image _ImgBGDialogs;                          //背景对话贴图
        private DialogStateStep _DialogState = DialogStateStep.None; //（当前）对话状态

        void Awake()
        {
            Instance = this;

        }

        void Start()
        {
            Log.Write(GetType() + "---------Start");
            //当前状态
            _DialogState = DialogStateStep.Step1_DoublePersonDialog;
            //背景贴图
            _ImgBGDialogs = transform.parent.Find("Background").GetComponent<Image>();
            //注册”背景贴图“
            RigisterDialogs();
            //讲解第一句话
            DialogUIMgr._Instance.DisplayNextDialog(DialogType.DoubleDialogs, 1);
        }

        /// <summary>
        /// 注册”背景贴图“
        /// </summary>
        public void RigisterDialogs()
        {
            if(_ImgBGDialogs != null)
            {
                EventTriggerListener.Get(_ImgBGDialogs.gameObject).onClick += DisplayNextDialogRecord;
            }
        }

        /// <summary>
        /// 取消注册”背景贴图“
        /// </summary>
        private void UnRigisterDialogs()
        {
            if (_ImgBGDialogs != null)
            {
                EventTriggerListener.Get(_ImgBGDialogs.gameObject).onClick -= DisplayNextDialogRecord;
            }
        }


        /// <summary>
        /// 显示下一条对话记录
        /// </summary>
        /// <param name="go">注册的游戏对象</param>
        private void DisplayNextDialogRecord(GameObject go)
        {
            Log.Write(GetType() + "/DisplayNextDialogRecord");
            if(go == _ImgBGDialogs.gameObject)
            {
                _IsExistNextDialogsRecorder = true;
            }
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
            bool boolResult = false;                               //本方法运行是否结束
            bool boolCurrentDialogResult = false;          //当前对话是否结束标志位
            _IsExistNextDialogsRecorder = false;
            //业务逻辑判断
            switch (_DialogState)
            {
                case DialogStateStep.None:
                    break;
                case DialogStateStep.Step1_DoublePersonDialog:
                    boolCurrentDialogResult=DialogUIMgr._Instance.DisplayNextDialog(DialogType.DoubleDialogs, 1);
                    break;
                case DialogStateStep.Step2_AliceSpeakET:
                    boolCurrentDialogResult = DialogUIMgr._Instance.DisplayNextDialog(DialogType.SingleDialogs, 2);
                    break;
                case DialogStateStep.Step3_AliceSpeakVirtualKey:
                    boolCurrentDialogResult = DialogUIMgr._Instance.DisplayNextDialog(DialogType.SingleDialogs, 3);
                    break;
                case DialogStateStep.Step4_AliceLastWord:
                    boolCurrentDialogResult = DialogUIMgr._Instance.DisplayNextDialog(DialogType.SingleDialogs, 4);
                    break;
                default:
                    break;
            }

            //当前对话结束处理
            if(boolCurrentDialogResult)
            {
                switch (_DialogState)
                {
                    case DialogStateStep.None:
                        break;

                    case DialogStateStep.Step1_DoublePersonDialog:
                        //无。。
                        break;

                    case DialogStateStep.Step2_AliceSpeakET:  //Alice介绍ET完毕，发生后台处理
                        //显示“引导ET贴图”，控制权暂时转移到TriggerOperET脚本
                        TriggerOperET.Instance.DisplayGuideET();
                        //暂停会话
                        UnRigisterDialogs();
                        //。。。
                        break;

                    case DialogStateStep.Step3_AliceSpeakVirtualKey: //Alice介绍“虚拟按键”完毕
                        //显示“引导虚拟按键贴图”，控制权暂时转移到TriggerOperVirtualKey脚本
                        TriggerOperVitualKey.Instance.DisplayGuideVirtualKey();
                        //暂停会话
                        UnRigisterDialogs();
                        break;

                    case DialogStateStep.Step4_AliceLastWord: //Alice全部介绍完毕
                        //激活ET
                        View_PlayerInfoResponse.Instance.DisplayET();
                        //显示所有的“虚拟攻击按键”
                        View_PlayerInfoResponse.Instance.DisplayAllUIKey();
                        //显示英雄UI信息界面
                        View_PlayerInfoResponse.Instance.DisplayHeroUIInfo();
                        //允许生成敌人
                        GameObject.Find("_GameManager/_ScenesControl").GetComponent<View_LevelOneScenes>().enabled = true;
                        GameObject.Find("_GameManager/_ScenesControl").GetComponent<Control.Ctrl_LevelOneScenes>().enabled = true;
                        //隐藏本对话界面
                        GoBackground.SetActive(false);
                        boolResult = true;
                        break;
                    default:
                        break;
                }
                //进入下一个状态
                EnterNextState();
            }//if_end
            return boolResult;
          //  return false;
        }

        /// <summary>
        /// 进入下一个状态
        /// </summary>
        private void EnterNextState()
        {
            switch (_DialogState)
            {
                case DialogStateStep.None:
                    break;
                case DialogStateStep.Step1_DoublePersonDialog:
                    _DialogState = DialogStateStep.Step2_AliceSpeakET;
                    break;
                case DialogStateStep.Step2_AliceSpeakET:
                    _DialogState = DialogStateStep.Step3_AliceSpeakVirtualKey;
                    break;
                case DialogStateStep.Step3_AliceSpeakVirtualKey:
                    _DialogState = DialogStateStep.Step4_AliceLastWord;
                    break;
                case DialogStateStep.Step4_AliceLastWord: 
                    _DialogState = DialogStateStep.None;
                    break;
                default:
                    break;
            }
        }

    }//class_end

}