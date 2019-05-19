/***
   *        Title: "英雄战神" 项目开发
   *    核心层：资源动态加载管理器
   *      Description:
   *                功能：
   *                1.属于”脚本插件“，适用于任何项目
   *                2.目的：开发出具备”对象缓冲“功能的资源加载脚本
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using System.Collections;

namespace Kernal
{
    public class ResourcesMgr : MonoBehaviour //通用的脚本插件所以继承MonoBehaviour
    {
        private static ResourcesMgr _Instance;              //本脚本私有单例实例
        private Hashtable ht = null;                              //容器键值对集合

        private ResourcesMgr()
        {
            ht = new Hashtable();
        }

        /// <summary>
        /// 得到本脚本实例
        /// </summary>
        /// <returns></returns>
        public static ResourcesMgr GetInstance()
        {
            if(_Instance ==null)
            {
                _Instance = new GameObject("_ResourcesMgr").AddComponent<ResourcesMgr>();
            }
            return _Instance;
        }

        /// <summary>
        /// 调用资源（带对象缓冲技术）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="isCatch"></param>
        /// <returns></returns>
        public T LoadResource<T>(string path, bool isCatch) where T:UnityEngine.Object    //LoadResource<T>通用资源，LoadResource是特指资源
        {
            if(ht.Contains(path))  //用hashtable做了一个对象缓冲
            {
                return ht[path] as T;
            }

            T TResource = Resources.Load<T>(path);
            if(TResource == null)
            {
                Debug.LogWarning(GetType() + "/GetInstance()/TResource 提取的资源找不到，请检查 path" + path);
            }
            else if(isCatch)
            {
                ht.Add(path, TResource);
            }
            return TResource;
        }

        /// <summary>
        /// 调用资源（带对象缓冲技术）
        /// </summary>
        /// <param name="_path"></param>
        /// <param name="isCatch"></param>
        /// <returns></returns>
        public GameObject LoadAsset(string path, bool isCatch)  //专门针对于GameObject资源的方法， 更加泛指的资源
        {
            GameObject goObj = LoadResource<GameObject>(path, isCatch);
            GameObject goObjClone = GameObject.Instantiate<GameObject>(goObj);
            if(goObjClone == null)
            {
                Debug.LogWarning(GetType() + "/LoadAsset()/克隆(实例化)资源不成功，请检查 path =" + path);
            }
            return goObjClone;
        }
    }//Class_end
}

