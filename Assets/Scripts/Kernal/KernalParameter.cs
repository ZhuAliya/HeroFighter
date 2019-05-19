/***
   *      Title: "英雄战神" 项目开发
   *            核心层：核心层的参数列表
   *      Description:
   *                作用：
   *            
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Kernal
{
    public class KernalParameter
    {
        //暂时不用
//#if UNITY_STANDALONE_WIN
//         //系统配置信息_日志路径
//        internal static readonly string SystemConfigInfo_LogPath ="file://"+Application.dataPath+"/StreamingAssets/SystemConfigInfo.xml";
//        //系统配置信息_日志根节点名称
//         internal static readonly string SystemConfigInfo_LogRootNodeName ="SystemConfigInfo";

//        //对话系统XML路径
//         internal static readonly string DialogsXMLConfig_XmlPath ="file://"+Application.dataPath+"/StreamingAssets/SystemDialogsInfo.xml";
//        //对话系统根节点名称
//         internal static readonly string DialogsXMLConfigInfo_XmlRootNodeName ="Dialogs_CN";

//#elif UNITY_ANDROID
//         //系统配置信息_日志路径
//        internal static readonly string SystemConfigInfo_LogPath =Application.dataPath+"!/Assets/SystemConfigInfo.xml";
//        //系统配置信息_日志根节点名称
//         internal static readonly string SystemConfigInfo_LogRootNodeName ="SystemConfigInfo";

//        //对话系统XML路径
//         internal static readonly string DialogsXMLConfig_XmlPath =+Application.dataPath+"!/Assets/SystemDialogsInfo.xml";
//        //对话系统根节点名称
//         internal static readonly string DialogsXMLConfigInfo_XmlRootNodeName ="Dialogs_CN";

//#elif UNITY_IPHONE
//        //系统配置信息_日志路径
//        internal static readonly string SystemConfigInfo_LogPath =Application.dataPath+"/Raw/SystemConfigInfo.xml";
//        //系统配置信息_日志根节点名称
//         internal static readonly string SystemConfigInfo_LogRootNodeName ="SystemConfigInfo";

//        //对话系统XML路径
//         internal static readonly string DialogsXMLConfig_XmlPath = Application.dataPath+"/Raw/SystemDialogsInfo.xml";
//        //对话系统根节点名称
//         internal static readonly string DialogsXMLConfigInfo_XmlRootNodeName ="Dialogs_CN";
//#endif


        /// <summary>
        /// 得到日志路径
        /// </summary>
        /// <returns></returns>
        public static string GetLogPath()
        {
            string logPath = null;

            //Android或者Iphone环境
            if (Application.platform == RuntimePlatform.Android ||Application.platform == RuntimePlatform.IPhonePlayer)
            {
                logPath = Application.streamingAssetsPath + "/SystemConfigInfo.xml";
            }
            else
            {
                logPath = "file://"+Application.streamingAssetsPath + "/SystemConfigInfo.xml";
            }

            return logPath;
        }

        /// <summary>
        /// 得到日志根节点名称
        /// </summary>
        /// <returns></returns>
        public static string GetLogRootNodeName()
        {
            string strReturnXMLRootNodeName = null;
            strReturnXMLRootNodeName = "SystemConfigInfo";
            return strReturnXMLRootNodeName;
        }

        /// <summary>
        /// 得到对话配置XML路径
        /// </summary>
        /// <returns></returns>
        public static string GetDialogConfigXMLPath()
        {
            string dialogConfigXMLPath = null;

            //Android或者Iphone环境
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                dialogConfigXMLPath = Application.streamingAssetsPath + "/SystemDialogsInfo.xml";
            }
            else
            {
                dialogConfigXMLPath = "file://" + Application.streamingAssetsPath + "/SystemDialogsInfo.xml";
            }

            return dialogConfigXMLPath;
        }

        /// <summary>
        /// 得到对话XML根节点名称
        /// </summary>
        /// <returns></returns>
        public static string GetDialogConfigXMLRootNodeName()
        {
            string strReturnDialogRootNodeName = null;
            strReturnDialogRootNodeName = "Dialogs_CN";
            return strReturnDialogRootNodeName;
        }

    }
}

