/***
   *      Title: "英雄战神" 项目开发
   *            核心层：实体类_对话数据
   *      Description:
   *                作用：
   *            
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using System.Collections;


namespace Kernal
{
    public class DialogDataFormat
    {
        /// <summary>
        /// 对话段落编号
        /// </summary>
        public int DialogSecNum { set; get; }

        /// <summary>
        /// 对话段落名称
        /// </summary>
        public string DialogSecName { set; get; }

        /// <summary>
        /// 段落序号
        /// </summary>
        public int SectionIndex { set; get; }

        /// <summary>
        /// 对话双方
        /// </summary>
        public string DialogSide { set; get; }

        /// <summary>
        /// 对话人名
        /// </summary>
        public string DialogPerson { set; get; }

        /// <summary>
        /// 对话内容
        /// </summary>
        public string DialogContent { set; get; }
    }
}
