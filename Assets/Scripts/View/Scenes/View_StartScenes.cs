/***
   *        Title: "英雄战神" 项目开发
   *       视图层：开始场景
       
   *      Description:
   *                [描述]
   *       Data:	[2018]
   *       Version: 0.1
 * */


using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Control;


namespace View{
    public class View_StartScenes : MonoBehaviour {

        /// <summary>
        /// 新的游戏
        /// </summary>
        public void ClickNewGame()
        {
            //GetType表示类的命名空间和类
            print(GetType() + "/ClickNewGame");//GetType表示类的命名空间和类+方法名
            //调用控制层的“开始场景”方法，进入“新的传奇”
            Ctrl_StartScenes.Instance.ClickNewGame();
        }
	    
        /// <summary>
        /// 游戏继续
        /// </summary>
        public void ClickGameContinue()
        {
            print(GetType() + "/ClickGameContinue");
            Ctrl_StartScenes.Instance.ClickGameContinue();
        }
    }
}





