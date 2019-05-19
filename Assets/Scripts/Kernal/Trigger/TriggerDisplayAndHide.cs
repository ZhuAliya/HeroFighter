/***
   *    Title: "英雄战神" 项目开发
   *                核心层：触发游戏对象显示与隐藏
   *    Description:
   *                功能：即手工版的“遮挡剔除”
   *    Data:	[2018]
   *    Version: 0.1
 * */
using UnityEngine;
using System.Collections;

namespace Kernal
{
    public class TriggerDisplayAndHide : MonoBehaviour
    {
        public string TagNameByHero = "Player";                                         //标签（Tag）：英雄
        public string TagNameByDisplayObject = "TagNameDisplayName"; //标签：需要显示的对象
        public string TagNameByHideObject = "TagNameHideName";         //标签：需要隐藏的对象

        private GameObject[] GoDisplayObjectArray;      //需要显示的对象集合
        private GameObject[] GoHideObjectArray;          //需要隐藏的对象集合

        void Start()
        {
            //得到需要显示的游戏对象
            GoDisplayObjectArray = GameObject.FindGameObjectsWithTag(TagNameByDisplayObject);
            //得到需要隐藏的游戏对象
            GoHideObjectArray = GameObject.FindGameObjectsWithTag(TagNameByHideObject);
        }

        /// <summary>
        /// 进入触发检测
        /// </summary>
        /// <param name="con"></param>
        void OnTriggerEnter(Collider con)
        {
            //发现英雄
            if(con.gameObject.tag == TagNameByHero)
            {
                foreach(GameObject goItem in GoDisplayObjectArray)
                {
                    goItem.SetActive(true);
                }
            }
        }

        /// <summary>
        /// 离开触发检测
        /// </summary>
        /// <param name="con"></param>
        void OnTriggerExit(Collider con)
        {
            //发现英雄
            if (con.gameObject.tag == TagNameByHero)
            {
                foreach (GameObject goItem in GoHideObjectArray)
                {
                    goItem.SetActive(false);
                }
            }
        }

    }//Class_end
}

