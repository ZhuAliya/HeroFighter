/***
   *    Title: "英雄战神" 项目开发
   *                公共层：层消隐技术
   *    Description:
   *                说明：小物件远距离消隐，近距离显示
   *    Data:	[2018]
   *    Version: 0.1
 * */
using UnityEngine;
//using UnityEngine.UI;
using System.Collections;
using Kernal;

namespace Global
{
    public class SmallObjLayerCtrl : MonoBehaviour
    {
        public int intDisappearDistance = 10;               //消隐距离
        private float[] distanceArray = new float[32];

        void Start()
        {
            distanceArray[8] = intDisappearDistance;
            Camera.main.layerCullDistances = distanceArray;
        }
    }
}
