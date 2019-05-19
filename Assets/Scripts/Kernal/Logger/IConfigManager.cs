/***
   *      Title: "英雄战神" 项目开发
   *            接口：配置管理器
   *      Description:
   *                作用：读取系统核心XML配置信息
   *            
   *       Data:	[2018]
   *       Version: 0.1
 * */

using System.Collections;
using System.Collections.Generic;

namespace Kernal
{
    //接口可定义属性、方法，不可定义字段
    public interface IConfigManager
    {
        /// <summary>
        /// 属性：应用设置
        /// </summary>
        Dictionary<string, string> AppSetting { get; }

        /// <summary>
        /// 得到AppSetting的最大数量
        /// </summary>
        int GetAppSettingMaxNumber();
    }

}
