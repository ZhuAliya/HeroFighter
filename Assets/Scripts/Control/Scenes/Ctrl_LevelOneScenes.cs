/***
   *        Title: "英雄战神" 项目开发
   *    控制层：第一关卡场景控制处理
   *      Description:
   *            作用：
   *            1：负责第一关卡敌人的动态加载
   *            2：敌人的”多出生点“设计
   *       Data:	[2018]
   *       Version: 0.1
 * */

using UnityEngine;
using System.Collections;
using Global;
using Kernal;
using Model;

namespace Control
{
    public class Ctrl_LevelOneScenes : BaseControl
    {
        public AudioClip AcBackground;                      //背景音乐音频剪辑
        public Transform TraSpawnEnemysPosition_1;  //敌人出现的位置
        public Transform TraSpawnEnemysPosition_2;
        public Transform TraSpawnEnemysPosition_3;
        public Transform TraSpawnEnemysPosition_4;
        public Transform TraSpawnEnemysPosition_5;
        public Transform TraSpawnEnemysPosition_6;
        public Transform TraSpawnEnemysPosition_7;
        public Transform TraSpawnEnemysPosition_8;
        public Transform TraSpawnEnemysPosition_9;
        public Transform TraSpawnEnemysPosition_10;
        //单次开关
        public bool IsSingleTime = true;
        //对象缓冲池，复杂对象（敌人预设）
        public GameObject goWarriorPrefab_Green;

        void Awake()
        {
            //事件注册（等级提升[升级]）
            PlayerExtenData.evePlayerExtenalData += LevelUp;
        }

        IEnumerator Start()
        {
            //背景音乐播放
            AudioManager.SetAudioBackgroundVolumns(0.3F);//设置背景音乐声音小一点
            AudioManager.SetAudioEffectVolumns(1F); //音效大小，音量声音大一点，音量1F是最大
            AudioManager.PlayBackground(AcBackground);
            //敌人的动态加载（按照时间进行加载）
             StartCoroutine(SpawnEnemy(2));  //要求产生5个敌人
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_3);//每间隔3s钟
            StartCoroutine(SpawnEnemy(2));
            yield return new WaitForSeconds(2F);
            StartCoroutine(SpawnEnemy(4));
            yield return new WaitForSeconds(5F);
            StartCoroutine(SpawnEnemy(2));
            yield return new WaitForSeconds(3F);
            StartCoroutine(SpawnEnemy(5));
            yield return new WaitForSeconds(6F);
            StartCoroutine(SpawnEnemy(3));
        }

        /// <summary>
        /// 敌人的出生（传统方法）
        /// </summary>
        /// <param name="createEnemysNum">敌人的数量</param>
        /// <returns></returns>
        //IEnumerator SpawnEnemy(int createEnemysNum)//出生敌人  createEnemysNum:创建敌人的数量
        //{
        //    yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT5);//0.5s之后产生5个           
        //    for (int i = 1; i <= createEnemysNum; i++)
        //    {
        //        yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_1);//每间隔1s产生一个
        //        //动态调用资源(敌人”预设“)  //用”对象缓冲池“来加载资源，提高Resources.Load加载的效率，Resources.Load非常消耗资源。所以开发一个自己的资源管理器脚本插件
        //        //GameObject goEnemy = Resources.Load("Prefabs/Enemys/skeleton_warrior_green", typeof(GameObject)) as GameObject;
        //        //GameObject goEnemyClone = GameObject.Instantiate(goEnemy);//克隆敌人
        //        //GameObject goEnemyClone = ResourcesMgr.GetInstance().LoadAsset("Prefabs/Enemys/skeleton_warrior_green", true);
        //        GameObject goEnemyClone = ResourcesMgr.GetInstance().LoadAsset(GetRandomEnemyType(), true);
        //        //skeleton_warrior_red

        //        //定义克隆体随机出现的位置
        //        Transform TranEnemySpawnPosition = GetRandomEnemySpawnPosition();
        //        //克隆体的位置   
        //        //TraSpawnEnemysPosition_1敌人出现的位置。和敌人出现的位置的x、y、z都一样
        //        goEnemyClone.transform.position = new Vector3(TranEnemySpawnPosition.transform.position.x, TranEnemySpawnPosition.transform.position.y, TranEnemySpawnPosition.transform.position.z);//敌人出现的位置的位置
        //        //goEnemyClone.transform.position = new Vector3(TraSpawnEnemysPosition_1.transform.position.x, TraSpawnEnemysPosition_1.transform.position.y, TraSpawnEnemysPosition_1.transform.position.z);//敌人出现的位置的位置
        //        //克隆体在层级视图中的位置   克隆体在层级视图中的位置的父级和定义的敌人的父级一样
        //        goEnemyClone.transform.parent = TraSpawnEnemysPosition_1.transform.parent;//克隆体的父级和定义的从外面要赋值过来的对象的父级是一样的
        //        //克隆敌人出现特效
        //        EnemySpawnParticalEffect(goEnemyClone);
        //    }
        //}

        /// <summary>
        /// 敌人的出生（加入对象缓冲池技术）
        /// </summary>
        /// <param name="createEnemysNum">敌人的数量</param>
        /// <returns></returns>
        IEnumerator SpawnEnemy(int createEnemysNum)//出生敌人  createEnemysNum:创建敌人的数量
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT5);//0.5s之后产生5个           
            for (int i = 1; i <= createEnemysNum; i++)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_1);//每间隔1s产生一个
                //动态调用资源(敌人”预设“)  //用”对象缓冲池“来加载资源，提高Resources.Load加载的效率，Resources.Load非常消耗资源。所以开发一个自己的资源管理器脚本插件              
                //定义克隆体随机出现的位置
                Transform TranEnemySpawnPosition = GetRandomEnemySpawnPosition();
                //克隆体的位置   
                //TraSpawnEnemysPosition_1敌人出现的位置。和敌人出现的位置的x、y、z都一样
                goWarriorPrefab_Green.transform.position = new Vector3(TranEnemySpawnPosition.transform.position.x, TranEnemySpawnPosition.transform.position.y, TranEnemySpawnPosition.transform.position.z);//敌人出现的位置的位置
                //在“对象缓冲池”中激活指定的对象
                PoolManager.PoolsArray["_Enemys"].GetGameObjectByPool(goWarriorPrefab_Green, goWarriorPrefab_Green.transform.position, Quaternion.identity);
                //克隆敌人出现特效
                //EnemySpawnParticalEffect(goWarriorPrefab_Green);
            }
        }

        /// <summary>
        /// 得到敌人的多出生点
        /// </summary>
        /// <returns></returns>
        public Transform GetRandomEnemySpawnPosition()
        {
            Transform TranReturnEnemyPosition;//返回敌人的位置
            int intRandomNum = UnityHelper.GetInstance().GetRandomNum(1, 8);
            if(intRandomNum == 1)
            {
                TranReturnEnemyPosition = TraSpawnEnemysPosition_1;
            }
            else if(intRandomNum ==2 )
            {
                TranReturnEnemyPosition = TraSpawnEnemysPosition_2;
            }
            else if (intRandomNum ==3 )
            {
                TranReturnEnemyPosition = TraSpawnEnemysPosition_3;
            }
            else if (intRandomNum == 4)
            {
                TranReturnEnemyPosition = TraSpawnEnemysPosition_4;
            }
            else if (intRandomNum ==5 )
            {
                TranReturnEnemyPosition = TraSpawnEnemysPosition_5;
            }
            else if (intRandomNum ==6 )
            {
                TranReturnEnemyPosition = TraSpawnEnemysPosition_6;
            }
            else if (intRandomNum == 7)
            {
                TranReturnEnemyPosition = TraSpawnEnemysPosition_7;
            }
            else if (intRandomNum == 8)
            {
                TranReturnEnemyPosition = TraSpawnEnemysPosition_8;
            }
            else if (intRandomNum == 9)
            {
                TranReturnEnemyPosition = TraSpawnEnemysPosition_9;
            }
            else if (intRandomNum == 10)
            {
                TranReturnEnemyPosition = TraSpawnEnemysPosition_10;
            }
            else
            {
                TranReturnEnemyPosition = TraSpawnEnemysPosition_1;
            }

            return TranReturnEnemyPosition;
        }

        /// <summary>
        /// 得到敌人的种类(预设)路径
        /// </summary>
        /// <returns></returns>
        public string GetRandomEnemyType()
        {
            string strEnemyTypePath = "Prefabs/Enemys/skeleton_warrior_green";          //返回敌人种类路径            
            int intRandomNum = UnityHelper.GetInstance().GetRandomNum(1, 2);
            if (intRandomNum == 1)
            {
                strEnemyTypePath = "Prefabs/Enemys/skeleton_warrior_green";
            }
            else if (intRandomNum == 2)
            {
                strEnemyTypePath = "Prefabs/Enemys/skeleton_warrior_red";
            }
            else
            {
                strEnemyTypePath = "Prefabs/Enemys/skeleton_warrior_green";
            }

            return strEnemyTypePath;
        }

        /// <summary>
        /// 敌人出现粒子特效
        /// </summary>
        private void EnemySpawnParticalEffect(GameObject EnemyWarrior)
        {
            StartCoroutine(LoadParticalEffectPublicMethod(GlobalParameter.INTERVAL_TIME_0DOT1,
       "ParticleProps/EnemyDisplay", true, EnemyWarrior.transform.position + transform.TransformDirection(0F, 2F, 0F), transform.rotation,EnemyWarrior.transform, "EnemyDisplayEffect", 0));
        }

        //主角升级
        private void LevelUp(KeyValuesUpdate kv)
        {
            if (kv.Key.Equals("Level"))
            {
                if(IsSingleTime)
                {
                    IsSingleTime = false;
                }
                else
                {
                    HeroLevelUp();
                }                
            }
        }

        //主角升级
        private void HeroLevelUp()
        {
           // 提取升级粒子预设
            GameObject HeroLevelUp = ResourcesMgr.GetInstance().LoadAsset("ParticleProps/Hero_LvUp", true);
            //音效
            AudioManager.PlayAudioEffectA("LevelUp");
        }
    }//class_end
}


