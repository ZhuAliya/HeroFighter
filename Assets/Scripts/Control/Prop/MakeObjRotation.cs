/***
   *        Title: "英雄战神" 项目开发
   *    控制层：使得道具旋转
   *      Description:
   *                [描述]
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using System.Collections;

namespace Control
{
    public class MakeObjRotation : BaseControl
    {
        //旋转的速度
        public float floRotateSpeed = 1F;                                       

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            this.gameObject.transform.Rotate(Vector3.up, floRotateSpeed);
        }
    }

}
