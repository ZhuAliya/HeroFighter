/***
   *        Title: "英雄战神" 项目开发
   *    控制层：使用”对象缓冲池“技术，做按指定时间，回收对象
   *      Description:
   *                [描述]
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using System.Collections;
using Global;
using Kernal;

namespace Control
{
    public class RecoveredObjByTime : BaseControl
    {
        //回收时间
        public float FloRecoverTime = 1F;       
                     
        void OnEnable()
        {
            //主要防止出现回收对象溢出的bug
            StartCoroutine("RecoveredGameObjectByTime");//启用回收粒子特效
        }

        void OnDisable()
        {
            StopCoroutine("RecoveredGameObjectByTime");//禁用回收粒子特效
        }


        /// <summary>
        /// 回收对象，根据指定的时间点
        /// </summary>
        /// <returns></returns>
        IEnumerator RecoveredGameObjectByTime()
        {
            yield return new WaitForSeconds(FloRecoverTime);
            PoolManager.PoolsArray["_ParticalSys"].RecoverGameObjectToPools(this.gameObject);//回收对象的池子一定要和激活对象的池子一致 _ParticalSys，即同一个池子
        }

    }
}

