/***
   *        Title: "英雄战神" 项目开发
   *       视图层：场景异步加载控制       
   *      Description:
   *                [描述]
   *       Data:	[2018]
   *       Version: 0.1
 * */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using Global;
using Kernal;

namespace View
{
    public class View_LoadingScenes : MonoBehaviour
    {
        public Slider SliLoadingProgress;   //进度条控制
        private float _FloProgressNumber;   //进度数值
        private AsyncOperation _AsyOper;
       
        IEnumerator Start()
        {

            //测试Log 日志系统
            //面向“接口编程”
            //IConfigManager configMgr = new ConfigManager(KernalParameter.SystemConfigInfo_LogPath, KernalParameter.SystemConfigInfo_LogRootNodeName);
            //string strLogPath = configMgr.AppSetting["LogPath"]; 
            //string strLogState = configMgr.AppSetting["LogState"]; 
            //string strLogMaxCapacity = configMgr.AppSetting["LogMaxCapacity"];
            //string strLogBufferNumber = configMgr.AppSetting["LogBufferNumber"];
            //print("log path =" + strLogPath);
            //print("Log State =" + strLogState);
            //print("Log Max Capacity =" + strLogMaxCapacity);
            //print("Log Buffer Number =" + strLogBufferNumber);

            //测试Log.cs类
            //Log.Write("我的企业日志系统开始运行了，第一次测试");
            //Log.Write("低等级调试语句", Log.Level.Low);
            //Log.Write("1低等级调试语句");
            //Log.Write("1中等级别调试语句", Log.Level.Special);
            //Log.Write("1高级与重要的调试语句", Log.Level.High);
            //Log.Write("2低等级调试语句");
            //Log.Write("2中等级别调试语句", Log.Level.Special);
            //Log.Write("2高级与重要的调试语句", Log.Level.High);
            //Log.SyncLogArrayToFile(); //同步一下（然后就把所有的数据都存入缓存中了）
            //Log.ClearLogFileAndBufferAllDate(); //清空Log日志
            //Log.Write("------1-------");
            //Log.Write("------2-------");
            //Log.Write("------3-------");
            //Log.Write("------4-------");
            //Log.Write("------5-------");
            //Log.Write("------6-------");
            //print("Log日志缓存中的数量=" + Log.QueryAllDateFromLogBuffer().Count); //output:Log日志缓存中的数量=6

            #region 测试代码
            ///*测试XML解析程序*/
            //参数赋值
            Log.ClearLogFileAndBufferAllDate(); //清空Log日志
            XMLDialogsDataAnalysisMgr.GetInstance().SetXMLPathAndRootNodeName(KernalParameter.GetDialogConfigXMLPath(), KernalParameter.GetDialogConfigXMLRootNodeName());
            yield return new WaitForSeconds(0.3F);  //因为设置xml路径也是在start方法里面，这里也是start方法，按照Unity生命周期这两个方法会同时执行，所以会报空指针，所以给个时间等待
            //得到XML中所有的数据
            List<DialogDataFormat> liDialogsDataArray = XMLDialogsDataAnalysisMgr.GetInstance().GetAllxmlDataArray();
            //测试给“对话数据管理器”加载数据
            bool boolResult = DialogDataMgr.GetInstance().LoadAllDialogData(liDialogsDataArray);

            if (!boolResult)
            {
                Log.Write(GetType() + "/Start()/ ' 对话数据管理器 ' 加载数据失败");
            }
            // GlobalParaMgr.NextScenesName = ScenesEnum.TestScenes;//进入测试关卡
            //调试进入指定的关卡 （第1关卡）
          //  GlobalParaMgr.NextScenesName = ScenesEnum.LevelOne; //进入第1关卡
            GlobalParaMgr.NextScenesName = ScenesEnum.MajorCity; //进入第4关卡,主场景
            #endregion
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_1);
            StartCoroutine("LoadingScenesProgress");
        }

        /// <summary>
        /// 异步加载
        /// </summary>
        /// <returns></returns>
        IEnumerator LoadingScenesProgress()
        {
            //_AsyOper = Application.LoadLevelAsync("2_LoginScene");
            _AsyOper = Application.LoadLevelAsync(ConvertEnumToStr.GetInstance().GetStrByEnumScenes(GlobalParaMgr.NextScenesName));
            _FloProgressNumber = _AsyOper.progress;
            yield return _AsyOper;
        }

       
        /// <summary>
        /// 显示进度条
        /// </summary>
        void Update()
        {
            if(_FloProgressNumber <= 1)
            {
                _FloProgressNumber += 0.01F;
            }
            SliLoadingProgress.value = _FloProgressNumber;
        }

   


    }
    
}
