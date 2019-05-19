/***
   *      Title: "英雄战神" 项目开发
   *            核心层：对话数据管理器（类）
   *      Description:
   *                作用：根据“对话数据格式”（DialogDataFormat）定义，
   *                输入“段落编号”，输出给定的对话内容（对话的双方，人名，内容）
   *            
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Kernal
{
    /// <summary>
    /// 对话双方
    /// </summary>
    public enum DialogSide
    {
        None,                                                                   //无
        HeroSide,                                                              //英雄
        NPCSide                                                                //NPC
    }

    public class DialogDataMgr
    {
        private static DialogDataMgr _Instance;
        private static List<DialogDataFormat> _AllDialogDataArray;             //所有的对话数据集合
        private static List<DialogDataFormat> _CurrentDialogBufferArray;   //当前对话缓存集合
        private static int _IntIndexByDialogSection;                                        //对话序号（某个段落）
        //常量
        private const string XML_DEFINATION_HERO = "Hero";
        private const string XML_DEFINATION_NPC = "NPC";

        //原对话“段落编号”(Add Function: 后来增加的内容)
        private static int _OriginalDialogSectionNum = 1;

        private DialogDataMgr()
        {
            //实例化字段信息
            _AllDialogDataArray = new List<DialogDataFormat>();
            _CurrentDialogBufferArray = new List<DialogDataFormat>();
            _IntIndexByDialogSection = 0;
        }

        /// <summary>
        /// 得到本类实例
        /// </summary>
        /// <returns></returns>
        public static DialogDataMgr GetInstance()
        {
            if(_Instance==null)
            {
                _Instance = new DialogDataMgr();
            }
            return _Instance;
        }

        /// <summary>
        /// 加载外部数据集合
        /// </summary>
        /// <param name="diaDataArray">外部数据集合</param>
        /// <returns>
        /// true:表明数据加载成功
        /// false:表明数据加载失败
        /// </returns>
        public bool LoadAllDialogData(List<DialogDataFormat> diaDataArray)
        {
            //数据参数检查 
            if(diaDataArray == null || diaDataArray.Count == 0)
            {
                return false;
            }

            //加载数据
            if(_AllDialogDataArray != null && _AllDialogDataArray.Count == 0)
            {
                for(int i = 0; i < diaDataArray.Count; i++)
                {
                    _AllDialogDataArray.Add(diaDataArray[i]); //符合条件就一条条加载进来
                }
                return true;
            }
            else
            {
                return false;                                                  //不符合条件返回false
            }
        }//LoadAllDialogData_end

        /// <summary>
        /// 得到下一条记录
        /// </summary>
        /// <param name="diaSectionNum">输入：段落编号</param>
        /// <param name="diaSide">输出：对话方</param>
        /// <param name="strPersonName">输出：人名</param>
        /// <param name="strDialogContent">输出：对话内容</param>
        /// <returns>
        /// true:输出合法对话数据
        /// false:没有输出对话数据了
        /// </returns>
        public bool GetNextDialogInfoRecoder(int diaSectionNum,out DialogSide diaSide, out string strPersonName, out string strDialogContent)
        {
            diaSide = DialogSide.None;
            strPersonName = "[GetNextDialogInfoRecoder()/strPersonName]";
            strDialogContent= "[GetNextDialogInfoRecoder()/strDialogContent]";

            //输入参数检查
            if(diaSectionNum < 0)
            {
                return false;
            }

            //“段落编号”增大后,需要保留上一个“对话段落编号”，以方便后续逻辑处理
            if (diaSectionNum != _OriginalDialogSectionNum) //此处为当前对话段落不等于原始对话段落就执行（若是>=就往下执行,就会出现对话顺序的bug）
            {
                //重置“内部序号”
                _IntIndexByDialogSection = 0;
                //清空“对话缓存”。
                _CurrentDialogBufferArray.Clear();
                //把当前的“段落编号”记录下来。
                _OriginalDialogSectionNum = diaSectionNum;
            }

            //当前缓存不为空
            if (_CurrentDialogBufferArray != null && _CurrentDialogBufferArray.Count >=1)
            {
                if(_IntIndexByDialogSection < _CurrentDialogBufferArray.Count)//当前的序号如果是段落集合当中，小于缓存的长度(即<6)，那么就允许自增
                {
                    ++_IntIndexByDialogSection;
                }
                else
                {
                    return false;
                }
            }
            //当前缓存为空
            else
            {
                ++_IntIndexByDialogSection;
            }
            //得到对话信息
            GetDialogInfoRecoder(diaSectionNum, out diaSide, out strPersonName, out strDialogContent);
            Debug.Log(GetType() + "------GetNextDialogInfoRecoder----");
            return true;
        }

        /// <summary>
        /// 得到对话信息
        /// 开发思路：
        ///         对于输入的”段落编号“，首先在”当前对话数据集合“中进行查询，
        ///         如果找到，直接返回结果。如果不能找到则在”全部对话数据集合“中进行查询，
        ///         且把当前段落数据，加入当前的缓存集合。
        /// </summary>
        /// <param name="diaSectionNum">输入：段落编号</param>
        /// <param name="diaSide">输出：对话双方（正在说话的方）</param>
        /// <param name="strPersonName">输出：人名</param>
        /// <param name="strDialogContent">输出：对话的内容</param>
        /// <returns>
        /// true:数据有效
        /// false”数据无效
        /// </returns>
        private bool  GetDialogInfoRecoder(int diaSectionNum,  out DialogSide diaSide, out string strPersonName, out string strDialogContent)
        {
            Log.Write(GetType() + "/GetDialogInfoRecoder()/");
            diaSide = DialogSide.None;
            string strDialogSide = "[GetDialogInfoRecoder()/strDialogSide]";
            strPersonName = "[GetDialogInfoRecoder()/strPersonName]";
            strDialogContent = "[GetDialogInfoRecoder()/strDialogContent]";

            Debug.Log(GetType() + "------GetDialogInfoRecoder----");
            //输入参数检查
            if (diaSectionNum <= 0) //段落最小是从1开始的
            {
                return false;
            }
            Log.Write(GetType() + "/GetDialogInfoRecoder()/  ------ 1: 在当前缓存集合中查询    --------");
            // 1. 对于输入的”段落编号“，首先在”当前对话数据集合“中进行查询。
            if (_CurrentDialogBufferArray != null && _CurrentDialogBufferArray.Count >=1)
            {
                for(int i = 0; i < _CurrentDialogBufferArray.Count; i++)
                {
                    //段落编号相同
                    if(_CurrentDialogBufferArray[i].DialogSecNum == diaSectionNum)
                    {
                        //段内序号相同
                        if(_CurrentDialogBufferArray[i].SectionIndex == _IntIndexByDialogSection)
                        {
                            //找到数据，提取数据
                            strDialogSide = _CurrentDialogBufferArray[i].DialogSide;
                            if(strDialogSide.Trim().Equals(XML_DEFINATION_HERO))
                            {
                                diaSide = DialogSide.HeroSide;
                            }
                            else if(strDialogSide.Trim().Equals(XML_DEFINATION_NPC))
                            {
                                diaSide = DialogSide.NPCSide;
                            }
                            strPersonName = _CurrentDialogBufferArray[i].DialogPerson;
                            strDialogContent = _CurrentDialogBufferArray[i].DialogContent;

                            return true;
                        }
                    }
                }
            }

            // 2.如果不能找到则在”全部对话数据集合“中进行查询，且把当前段落数据，加入当前的缓存集合
            Debug.Log(GetType() + "/GetDialogInfoRecoder()/  ------ 2: 在全部记录集合中查询    --------");
            Log.Write(GetType() + "/GetDialogInfoRecoder()/  ------ 2: 在全部记录集合中查询    --------");
            if (_AllDialogDataArray != null && _AllDialogDataArray.Count >= 1)
            {
                for (int i = 0; i < _AllDialogDataArray.Count; i++)
                {
                    //段落编号相同
                    if (_AllDialogDataArray[i].DialogSecNum == diaSectionNum)
                    {
                        //段内序号相同
                        if (_AllDialogDataArray[i].SectionIndex == _IntIndexByDialogSection)
                        {
                            //找到数据，提取数据
                            strDialogSide = _AllDialogDataArray[i].DialogSide;
                            if (strDialogSide.Trim().Equals(XML_DEFINATION_HERO))
                            {
                                diaSide = DialogSide.HeroSide;
                            }
                            else if (strDialogSide.Trim().Equals(XML_DEFINATION_NPC))
                            {
                                diaSide = DialogSide.NPCSide;
                            }
                            strPersonName = _AllDialogDataArray[i].DialogPerson;
                            strDialogContent = _AllDialogDataArray[i].DialogContent;
                            //把当前段落编号中的数据，写入“当前段落缓存集合”
                            LoadToBufferArrayBySectionNum(diaSectionNum);
                            return true;
                        }
                    }
                } 
            }
            //根据当前段落编号，无法查询数据结果，则返回false。
            return false;
        }

        /// <summary>
        /// 把当前段落编号中的数据，写入“当前段落缓存集合”
        /// </summary>
        /// <param name="diaSectionNum">输入：当前段落编号</param>
        /// <returns>
        /// true:表示操作成功
        /// false:操作无效
        /// </returns>
        private bool LoadToBufferArrayBySectionNum(int diaSectionNum)
        {
            //输入参数检查
            if(diaSectionNum <=0)
            {
                return false;
            }

            if(_AllDialogDataArray != null && _AllDialogDataArray.Count >= 1)
            {
                //当前缓存集合，清空以前的数据
                _CurrentDialogBufferArray.Clear();

                for (int i = 0; i < _AllDialogDataArray.Count; i++)
                {
                    if(_AllDialogDataArray[i].DialogSecNum == diaSectionNum)
                    {
                        //当前缓存集合，加入新的数据
                        _CurrentDialogBufferArray.Add(_AllDialogDataArray[i]);
                    }
                }
                return true;
            }

            return false;//
        }

    }//Class_end
}

