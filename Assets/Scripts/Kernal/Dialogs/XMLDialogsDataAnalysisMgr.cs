/***
   *      Title: "英雄战神" 项目开发
   *            核心层："XML对话数据解析管理器"脚本
   *      Description:
   *                功能：
   *                对于对话XML，做数据解析。
   *            
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using System.Collections; 
using System.Collections.Generic;
using System;
using System.IO;
using System.Xml;

namespace Kernal
{
    public class XMLDialogsDataAnalysisMgr : MonoBehaviour
    {
        private static XMLDialogsDataAnalysisMgr _Instance;                     //本类实例
        private List<DialogDataFormat> _LiDialogDataArray;                      //对话数据集合
        private string _StrXMLPath;                                                             //Xml路径
        private string _StrXMLRootNodeName;                                           //Xml根节点名称
        //常量定义 
        private const float TIME_DELAY = 0.1F;                                          //延迟时间
        private const string XML_ATTRIBUTE_1 = "DialogSecNum";            //XML文件属性字符串
        private const string XML_ATTRIBUTE_2 = "DialogSecName";                                  
        private const string XML_ATTRIBUTE_3 = "SectionIndex";                                   
        private const string XML_ATTRIBUTE_4 = "DialogSide";                                   
        private const string XML_ATTRIBUTE_5 = "DialogPerson";                                   
        private const string XML_ATTRIBUTE_6 = "DialogContent";                                  




        /// <summary>
        /// 构造函数
        /// </summary>
        private XMLDialogsDataAnalysisMgr()
        {
            _LiDialogDataArray = new List<DialogDataFormat>();
        }

        /// <summary>
        /// 得到本类实例
        /// </summary>
        /// <returns></returns>
        public static XMLDialogsDataAnalysisMgr GetInstance()
        {
            if(_Instance == null)
            {
                //_Instance = new XMLDialogsDataAnalysisMgr();
                //把自己的脚本类挂载到自己的游戏对象上
                 _Instance = new GameObject("_XMLDialogsDataAnalysisMgr").AddComponent<XMLDialogsDataAnalysisMgr>();//自动挂上脚本，不需手动挂载到对象上
                print("----XMLDialogsDataAnalysisMgr----------------------");
                //_Instance = new GameObject("_XMLD").AddComponent<XMLDialogsDataAnalysisMgr>();//自动挂上脚本，不需手动挂载到对象上
            }
            return _Instance;
        }

        /// <summary>
        /// 设置XML路径与根节点的名称
        /// </summary>
        /// <param name="xmlPath">xml路径</param>
        /// <param name="xmlRootNodeName">xml根节点的名称</param>
        public void SetXMLPathAndRootNodeName(string xmlPath, string xmlRootNodeName)
        {
            if(!string.IsNullOrEmpty(xmlPath) && !string.IsNullOrEmpty(xmlRootNodeName))
            {
                _StrXMLPath = xmlPath;
                _StrXMLRootNodeName = xmlRootNodeName;
            }
        }

        /// <summary>
        /// 得到本脚本数据集合
        /// </summary>
        /// <returns></returns>
        public List<DialogDataFormat> GetAllxmlDataArray()
        {
            if(_LiDialogDataArray!= null &&_LiDialogDataArray.Count >= 1)
            {
                return _LiDialogDataArray;
            }
            else
            {
                return null;
            }
        }

        IEnumerator Start()
        {
            //等待关于XML路径与XML根节点名称，进行赋值
            yield return new WaitForSeconds(TIME_DELAY);
            if(!string.IsNullOrEmpty(_StrXMLPath) && !string.IsNullOrEmpty(_StrXMLRootNodeName))
            {
                StartCoroutine("ReadXMLConfigByWWW");
            }
            else
            {
                Debug.LogError(GetType() + "/Start()/_StrXMLPath or _StrXMLRootNodeName is null! please check!");
            }         
        }//Start_end


        /// <summary>
        /// 使用WWW读取xml配置文件
        /// </summary>
        /// <returns></returns>
        IEnumerator ReadXMLConfigByWWW()
        {
            WWW www = new WWW(_StrXMLPath);
            while(!www.isDone)
            {
                yield return www;
                //初始化XML配置
                InitXMLConfig(www, _StrXMLRootNodeName);
            }
        }

        /// <summary>
        /// 初始化XML配置
        /// </summary>
        /// <param name="www"></param>
        /// <param name="rootNodeName"></param>
        private void InitXMLConfig(WWW www, string rootNodeName)
        {
            //参数检查
            if(_LiDialogDataArray==null || string.IsNullOrEmpty(www.text))
            {
                Debug.LogError(GetType() + "/InitXMLConfig()/_LiDialogDataArray==null or rootNodeName is null! please check!");
                return;
            }

            //XML解析程序
            XmlDocument xmlDoc = new XmlDocument();
            // xmlDoc.LoadXml(www.text);   //发现这种方式，发布到Android手机端，不能正确的输出中文

            /*以下4行代码，来代替上面注释掉的内容，解决正确在发布手机端解析输出中文问题*/
            System.IO.StringReader stringReader = new System.IO.StringReader(www.text);
            stringReader.Read();
            System.Xml.XmlReader reader = System.Xml.XmlReader.Create(stringReader);
            xmlDoc.LoadXml(stringReader.ReadToEnd());

            XmlNodeList nodes = xmlDoc.SelectSingleNode(_StrXMLRootNodeName).ChildNodes;
            foreach(XmlElement xe in nodes)
            {
                //实例化“XML解析实例类”
                DialogDataFormat data = new DialogDataFormat();
                //段落编号
                data.DialogSecNum = Convert.ToInt32(xe.GetAttribute(XML_ATTRIBUTE_1));
                //段落名称
                data.DialogSecName = xe.GetAttribute(XML_ATTRIBUTE_2);
                //段落序列号
                data.SectionIndex = Convert.ToInt32(xe.GetAttribute(XML_ATTRIBUTE_3));
                //段落双方
                data.DialogSide = xe.GetAttribute(XML_ATTRIBUTE_4);
                //段落人名
                data.DialogPerson = xe.GetAttribute(XML_ATTRIBUTE_5);
                //段落内容
                data.DialogContent = xe.GetAttribute(XML_ATTRIBUTE_6);
                //加入集合
                _LiDialogDataArray.Add(data);
            }// foreach_end
        }//InitXMLConfig_end

    }//class_end
}
