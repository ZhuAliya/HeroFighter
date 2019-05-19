/***
   *    Title: "英雄战神" 项目开发
   *                控制层：场景异步加载，后台逻辑处理      
   *    Description:
   *                [描述]
   *    Data:	[2018]
   *    Version: 0.1
 * */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Global;
using Kernal;

namespace Control
{
    public class Ctrl_LoadingScenes : BaseControl
    {
        
        IEnumerator Start()
        {
            Log.Write(GetType() + "/Start()");
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT1);
            //关卡预处理逻辑
            StartCoroutine("ScenesPreProgressing");
            //垃圾收集
            StartCoroutine("HandleGC");
        }

        //关卡预处理逻辑
        IEnumerator ScenesPreProgressing()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT1);
            switch (GlobalParaMgr.NextScenesName)
            {
                case ScenesEnum.TestScenes:
                    break;
                case ScenesEnum.StartScene:
                    break;
                case ScenesEnum.LoginScene:
                    break;
                    //第1关卡
                case ScenesEnum.LevelOne:
                    StartCoroutine("ScenesPreProgressing_LevelOne");
                    break;
                case ScenesEnum.LevelTwo:
                    break;
                case ScenesEnum.BaseScene:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 预处理第一关卡
        /// </summary>
        /// <returns></returns>
        IEnumerator ScenesPreProgressing_LevelOne()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT1);
            //参数赋值
            XMLDialogsDataAnalysisMgr.GetInstance().SetXMLPathAndRootNodeName(KernalParameter.GetDialogConfigXMLPath(), KernalParameter.GetDialogConfigXMLRootNodeName());
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT3);  //因为设置xml路径也是在start方法里面，这里也是start方法，按照Unity生命周期这两个方法会同时执行，所以会报空指针，所以给个时间等待
             //得到XML中所有的数据
            List<DialogDataFormat> liDialogsDataArray = XMLDialogsDataAnalysisMgr.GetInstance().GetAllxmlDataArray();
            //测试给“对话数据管理器”加载数据
            bool boolResult = DialogDataMgr.GetInstance().LoadAllDialogData(liDialogsDataArray);
            if (!boolResult)
            {
                Log.Write(GetType() + "/Start()/ ' 对话数据管理器 ' 加载数据失败", Log.Level.High);
            }
        }

        /// <summary>
        /// 垃圾资源收集
        /// </summary>
        /// <returns></returns>
        IEnumerator HandleGC()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT1);
            //卸载无用的资源
            Resources.UnloadUnusedAssets();
            //强制垃圾收集
            System.GC.Collect();
        }


    }//Class_end

}
