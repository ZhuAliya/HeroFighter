/***
   *        Title: "英雄战神" 项目开发
   *    控制层：按照一定时间销毁道具
   *      Description:
   *                [描述]
   *       Data:	[2018]
   *       Version: 0.1
 * */

using UnityEngine;
using System.Collections;


namespace Control
{
    public class DestoryObjByTime : BaseControl
    {
        public float floDestroyTime = 2F;                                       //销毁的时间段

        // Use this for initialization
        void Start()
        {
            Destroy(this.gameObject, floDestroyTime);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

