/***
   *        Title: 核心层帮助类
   *        目的：集成大量通用算法
   *      Description:
   *                [描述] 此类为单例类
   *       Data:	[2018]
   *       Version: 0.1
 * */

using UnityEngine;
using System.Collections;

namespace Kernal
{
    public class UnityHelper 
    {
        private static UnityHelper _Instance = null;       //本类实例
        private float floDeltaTime;         //累加时间

        private UnityHelper()
        {

        }

        /// <summary>
        /// 得到本类实例
        /// </summary>
        /// <returns></returns>
        public static UnityHelper GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new UnityHelper();
            }
            return _Instance;
        }

        /// <summary>
        /// 间隔指定时间段，返回布尔值
        /// </summary>
        /// <param name="smallIntervalTime">指定的时间段间隔(0.1-3F之间)</param>
        /// <returns>
        /// true:表示指定时间段到了
        /// </returns>
        public bool GetSmallTime(float smallIntervalTime)
        {
            floDeltaTime += Time.deltaTime;                                 // Time.deltaTime 帧的间隔时间
            if(floDeltaTime >= smallIntervalTime)                           //如果时间间隔大于或等于我们定义的最小时间间隔
            {
                floDeltaTime = 0;
                return true;
            }
            else
            {
                return false;
            }
        }//GetSmallTime_end


        /// <summary>
        /// (基于角色的)面向指定目标旋转
        /// </summary>
        /// <param name="self">本身</param>
        /// <param name="goal">目标</param>
        /// <param name="rotateSpeed">旋转速度</param>
        public void FaceToHero(Transform self, Transform goal, float rotateSpeed)
        {
            self.rotation = Quaternion.Slerp(self.rotation, Quaternion.LookRotation(new Vector3(goal.position.x, 0, goal.position.z) -
                                                                              new Vector3(self.position.x, 0, self.position.z)), rotateSpeed
                                                                             );
        }

        /// <summary>
        /// 得到指定范围的随机整数
        /// </summary>
        /// <param name="minNum">最小数值</param>
        /// <param name="MaxNum">最大数值</param>
        /// <returns></returns>
        public int GetRandomNum(int minNum, int maxNum)
        {
            int randomNumResult = 0;
            if(minNum == maxNum)//如果输入的最大值等于最小值，则得到最小值
            {
                randomNumResult = minNum;
            }
            randomNumResult = Random.Range(minNum, maxNum+1); //包含最小值，不包含最大值。因为不包含本身所以要+1
            return randomNumResult;
        }

    }//class_end
}

