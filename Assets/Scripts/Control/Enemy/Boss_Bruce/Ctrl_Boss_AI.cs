/***
   *        Title: "英雄战神" 项目开发
   *        控制层：Boss_Bruce AI系统
   *        说明：暂时不用了
   *       Description:
   *                [描述]
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using System.Collections;
using Kernal;
using Global;

namespace Control
{
    public class Ctrl_Boss_AI : BaseControl
    {

        public float FloMoveSpeed = 2F;                                       //移动的速度    
        public float FloRotateSpeed = 1F;                                      //旋转的速度   
        public float FloAttackDistance = 5F;                                //攻击距离
        public float FloCordonDistance = 15F;                              //警戒距离
        public float FloThinkInterval = 3F;                                    //思考的间隔时间               

        private GameObject _GoHero;                                           //主角
        private Transform _MyTransform;                                      //当前战士（敌人）方位
        private Ctrl_BaseEnemyProperty _MyProperty;                   //属性
        private CharacterController _cc;                                        //角色控制器 【敌人的移动使用CharacterController】要写移动的方法

        //void OnEnable()
        //{
        //    //开启“思考”协程
        //    StartCoroutine("ThinkProcess");
        //    //开启“移动”协程
        //    StartCoroutine("MovingProcess");
        //}

        //void OnDisable()
        //{
        //    //开启“思考”协程
        //    StopCoroutine("ThinkProcess");
        //    //开启“移动”协程
        //    StopCoroutine("MovingProcess");
        //}

        void Start()
        {
            //开启“思考”协程
            StartCoroutine("ThinkProcess");
            //开启“移动”协程
            StartCoroutine("MovingProcess");

            //当前方位
            _MyTransform = this.gameObject.transform;
            //得到主角
            _GoHero = GameObject.FindGameObjectWithTag(Tag.Player);
            //得到“属性实例 ”
            _MyProperty = this.gameObject.GetComponent<Ctrl_BaseEnemyProperty>();
            //得到角色控制器
            _cc = this.gameObject.GetComponent<CharacterController>();

            /*确定个体差异性参数 */
            FloMoveSpeed = UnityHelper.GetInstance().GetRandomNum(1, 3);            //移动速度随机1-2
            FloAttackDistance = UnityHelper.GetInstance().GetRandomNum(11, 15);       //攻击距离随机值1-3
            FloCordonDistance = UnityHelper.GetInstance().GetRandomNum(16, 25);   //警戒距离默认的随机值距离为4-15
            FloThinkInterval = UnityHelper.GetInstance().GetRandomNum(2, 4);         //思考的时间随机值1-3

        }

        /// <summary>
        /// “思考”协程
        /// </summary>
        /// <returns></returns>
        IEnumerator ThinkProcess()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_1);
            while (true)
            {
                yield return new WaitForSeconds(FloThinkInterval);//思考的间隔时间
                if (_MyProperty && _MyProperty.CurrentState != EnemyState.Death)
                {
                    //得到主角当前方位数值
                    Vector3 VecHero = _GoHero.transform.position;
                    //得到主角与当前（敌人）距离
                    float floDistance = Vector3.Distance(VecHero, _MyTransform.position);//敌我距离
                                                                                         //距离判断
                    if (floDistance < FloAttackDistance)//攻击距离
                    {
                        //攻击状态
                        _MyProperty.CurrentState = EnemyState.Attack;

                    }
                    else if (floDistance < FloCordonDistance)//警戒距离
                    {
                        //警戒（追击）
                        _MyProperty.CurrentState = EnemyState.Walking;
                    }
                    else
                    {
                        //敌人休闲状态
                        _MyProperty.CurrentState = EnemyState.Idle;
                    }

                    //小于警戒距离

                    //大于警戒距离

                }//if_end


            }
        }


        /// <summary>
        /// “移动”协程
        /// </summary>
        /// <returns></returns>
        IEnumerator MovingProcess()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_1);
            while (true)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0D0OT2);//0.02F
                //
                if (_MyProperty && _MyProperty.CurrentState != EnemyState.Death)
                {
                    //面向主角
                    FaceToHero();
                    //......
                    //移动 --要写移动的方法首先要得到CharacterController【敌人的移动使用CharacterController】
                    switch (_MyProperty.CurrentState)
                    {
                        //敌人的移动                  
                        case EnemyState.Walking:
                            Vector3 v = Vector3.ClampMagnitude((_GoHero.transform.position - _MyTransform.position), FloMoveSpeed * Time.deltaTime); //Vector3.ClampMagnitude(("英雄方位" - "当前敌人方位"), maxLength );
                            _cc.Move(v);
                            break;
                        //敌人受伤后退移动
                        case EnemyState.Hurt:
                            Vector3 vec = -transform.forward * FloMoveSpeed / 2 * Time.deltaTime; //往后退所以写一个负号
                            _cc.Move(vec);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 面向主角
        /// </summary>
        private void FaceToHero()
        {
            UnityHelper.GetInstance().FaceToHero(this.gameObject.transform, _GoHero.transform, FloRotateSpeed);//敌人面向主角（重构了的方法）
        }
    }//Class_end
}
