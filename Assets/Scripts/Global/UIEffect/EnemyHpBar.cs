/***
   *      Title: "英雄战神" 项目开发
   *      公共层：敌人“血条”
   *      Description:
   *                功能：查看敌人当前生命值
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Kernal;
using Control;


namespace Global
{
    public class EnemyHpBar : MonoBehaviour
    {
        private GameObject _TargetEnemyObj;            //目标对象
        private Camera _WorldCamera;                        //世界坐标系
        private Camera _GUICamera;                            //UI坐标系
        private Slider _UISlider;                                     //显示控件
        public float FloHPPrefabLength = 2F;               //血条预设长度
        public float FloHPPrefabHeight = 1F;               //血条预设高度
        //敌人生命数值
        private float _FloCurrentHP;
        private float _FloMaxHp;


        /// <summary>
        /// 设置敌人的目标
        /// </summary>
        /// <param name="goEnemy"></param>
        public void SetTargetEnemy(GameObject goEnemy)
        {
            _TargetEnemyObj = goEnemy;
        }

        void Start()
        {
            //得到UI Slider控件
            _UISlider = this.gameObject.GetComponent<Slider>();
            //世界摄像机
            _WorldCamera = Camera.main.gameObject.GetComponent<Camera>();
            //UI 摄像机
            _GUICamera = GameObject.FindGameObjectWithTag(Tag.Tag_UICamera).GetComponent<Camera>();
            //参数检查
            if(_TargetEnemyObj == null)
            {
                Debug.LogError(GetType() + "/Start()/TargetEnemyObj == null");
                return;
            }
        }

        /// <summary>
        /// 计算敌人的血量
        /// </summary>
        void Update()
        {
            try
            {
                if (Time.frameCount % 2 == 0)
                {
                    //当前与最大的生命数值
                    _FloCurrentHP = _TargetEnemyObj.GetComponent<Ctrl_BaseEnemyProperty>()._FloCurrentHealth;
                    _FloCurrentHP = _TargetEnemyObj.GetComponent<Ctrl_BaseEnemyProperty>().MaxHealth;
                    //计算血量
                    _UISlider.value = _FloCurrentHP / _FloMaxHp;
                    //控件尺寸
                    this.transform.localScale = new Vector3(FloHPPrefabLength, FloHPPrefabHeight, 0);
                    //如何销毁
                    if (_FloCurrentHP <= (_FloMaxHp * 0.05))
                    {
                        Destroy(this.gameObject);
                    }
                }

            }
            catch
            {

            }
        }

        /// <summary>
        /// 血条三维坐标系与UI坐标系转换
        /// </summary>
        void LateUpdate()
        {
            if(_TargetEnemyObj != null)
            {
                if (Time.frameCount % 2 == 0)
                {
                    //获取目标物体屏幕坐标
                    Vector3 pos = _WorldCamera.WorldToScreenPoint(_TargetEnemyObj.transform.position);
                    //屏幕坐标转换为UI的世界坐标
                    pos = _GUICamera.ScreenToWorldPoint(pos);
                    //确定UI最终位置
                    pos.z = 0;
                    transform.position = new Vector3(pos.x, pos.y + 2F, pos.z);
                }                  
            }            
        } //LateUpdate_end

    }//Class_end
}

