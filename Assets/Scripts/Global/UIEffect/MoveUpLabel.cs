/***
   *        Title: "英雄战神" 项目开发
   *        公共层："漂字"特效
   *        Description:
   *                1：表示特定对象（主角/敌人），失血数值显示
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
    public class MoveUpLabel : MonoBehaviour
    {
        private GameObject _TargetEnemyObj;             //目标对象
        private Camera _WorldCamera;                         //世界坐标系
        private Camera _GUICamera;                            //UI坐标系
        private Text _UIText;                                         //显示控件
        public float FloPrefabLength = 2F;                   //"漂字"预设长度
        public float FloPrefabHeight = 1F;                   //"漂字"预设高度
        private float FloPosOffset = 2F;                        //"漂字"位置的偏移量
        //敌人生命数值
        private float _IntCurrentReduceHpNumber = -99999;    //减少的生命数值
        //漂字速度
        public float FloLabelMoveSpeed = 0.02F;



        /// <summary>
        /// 设置敌人的目标
        /// </summary>
        /// <param name="goEnemy"></param>
        public void SetTargetEnemy(GameObject goEnemy)
        {
            _TargetEnemyObj = goEnemy;
        }

        /// <summary>
        /// 设置减少生命数值
        /// </summary>
        /// <param name="intNumber">生命数值</param>
        public void SetReduceHPNumber(int intNumber)
        {
            _IntCurrentReduceHpNumber = -Mathf.Abs(intNumber);
        }

        void Start()
        {
            //得到UI Slider控件
            _UIText = this.gameObject.GetComponent<Text>();
            //世界摄像机
            _WorldCamera = Camera.main.gameObject.GetComponent<Camera>();
            //UI 摄像机
            _GUICamera = GameObject.FindGameObjectWithTag(Tag.Tag_UICamera).GetComponent<Camera>();
            //参数检查
            if (_TargetEnemyObj == null)
            {
                Debug.LogError(GetType() + "/Start()/TargetEnemyObj == null");
                return; 
            }
            if (_IntCurrentReduceHpNumber == 99999)
            {
                Debug.LogError(GetType() + "/Start()/_IntCurrentReduceHpNumber 非法");
                return;
            }
        }

        /// <summary>
        /// 计算失血数值
        /// </summary>
        void Update()
        {
            if(Time.frameCount %3 ==0)//Time.frameCount %3 ==0，表示每3帧运行一次
            {
                //控件显示血量
                _UIText.text = _IntCurrentReduceHpNumber.ToString();
                //控件尺寸
                this.transform.localScale = new Vector3(FloPrefabLength, FloPrefabHeight, 0);
                //位置的偏移量（向上移动）
                FloPosOffset += FloLabelMoveSpeed;
                //本预设销毁，由缓存池负责(略)

            }


        }

        /// <summary>
        /// "漂字"特效三维坐标系与UI坐标系转换
        /// </summary>
        void LateUpdate()
        {
            if (_TargetEnemyObj != null)
            {
                if (Time.frameCount % 3 == 0)//做降帧处理
                {
                    //获取目标物体屏幕坐标
                    Vector3 pos = _WorldCamera.WorldToScreenPoint(_TargetEnemyObj.transform.position);
                    //屏幕坐标转换为UI的世界坐标
                    pos = _GUICamera.ScreenToWorldPoint(pos);
                    //确定UI最终位置
                    pos.z = 0;
                    transform.position = new Vector3(pos.x, pos.y + FloPosOffset, pos.z);
                }
            }
        }//LateUpdate_end
    }//Class_end
}
