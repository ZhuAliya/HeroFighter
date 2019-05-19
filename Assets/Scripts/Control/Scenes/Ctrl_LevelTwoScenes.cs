/***
   *        Title: "英雄战神" 项目开发
   *        控制层：副本：第二关卡
   *      Description:
   *            作用：副本：战斗场景
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
    public class Ctrl_LevelTwoScenes : BaseControl
    {
        //背景音乐与音效
        public AudioClip BackgroundMusic;                 //背景音乐
        public AudioClip BackgroundMusic_Fighting;   //战斗背景音乐
        public AudioClip AcPlayerLevelUp;                   //升级音效
        //标签：需要隐藏的对象
        public string[] TagNameByHideObject;
        /* 敌人预设 */
        public GameObject goArcher;
        public GameObject goMage;
        public GameObject goKing;
        public GameObject goWarrior;
        public GameObject goBoss_Bruce;

        /*敌人的产生地点*/
        //区域A
        public Transform[] TraSpawnEnemyPos_AreaA_Archer;
        public Transform[] TraSpawnEnemyPos_AreaA_Mage;
        //区域B
        public Transform[] TraSpawnEnemyPos_AreaB_Archer;
        public Transform[] TraSpawnEnemyPos_AreaB_Warrior;
        public Transform[] TraSpawnEnemyPos_AreaB_King;
        //区域C
        public Transform[] TraSpawnEnemyPos_AreaC_King;
        //区域D(Boss核心战斗区域)
        public Transform[] TraSpawnBoss;
        public Transform[] TraSpawnEnemyPos_AreaD_Archer;
        public Transform[] TraSpawnEnemyPos_AreaD_Warrior;
        public Transform[] TraSpawnEnemyPos_AreaD_Mage;
        public Transform[] TraSpawnEnemyPos_AreaD_King;

        /*敌人的单次出生控制*/
        private bool IsSingleSpawn_AreaA = true;
        private bool IsSingleSpawn_AreaB = true;
        private bool IsSingleSpawn_AreaC = true;
        private bool IsSingleSpawn_AreaD = true;
        private bool IsSingleSpawn_AreaE = true;
        //private bool _IsSingleBossSpawn = false; //Boss的单次出生
        //粒子墙 
        public GameObject goParticalWall;

        /// <summary>
        /// 动态产生敌人
        /// </summary>
        void Awake()
        {
            //敌人出生触发器
            TriggerCommonEvent.eveCommonTrigger += SpawnEnemy;
            //事件注册（等级提升[升级]）
            PlayerExtenData.evePlayerExtenalData += PlayerLevelUp;
        }

        /// <summary>
        /// 主角升级
        /// </summary>
        /// <param name="kv"></param>
        void PlayerLevelUp(KeyValuesUpdate kv)
        {
            base.LevelUp(kv, AcPlayerLevelUp);
        }
        /// <summary>
        /// 动态产生敌人
        /// </summary>
        /// <param name="CTT"></param>
        private void SpawnEnemy(CommonTriggerType CTT)
        {
            switch (CTT)
            {
                case CommonTriggerType.None:
                    break;               
                case CommonTriggerType.Enemy1_Dialog:
                    //第1区域动态加载产生敌人
                    if (IsSingleSpawn_AreaA)
                    {
                        IsSingleSpawn_AreaA = false;
                        SpawnEnemy_AtArea_A();
                    }                    
                    break;
                case CommonTriggerType.Enemy2_Dialog:
                    //第2区域动态加载产生敌人
                    if (IsSingleSpawn_AreaB)
                    {
                        IsSingleSpawn_AreaB = false;
                        SpawnEnemy_AtArea_B();
                    }
                    
                    break;
                case CommonTriggerType.Enemy3_Dialog:
                    //第3区域动态加载产生敌人
                    if (IsSingleSpawn_AreaC)
                    {
                        IsSingleSpawn_AreaC = false;
                        SpawnEnemy_AtArea_C();
                    }                    
                    break;
                case CommonTriggerType.Enemy4_Dialog:
                    //显示“粒子墙”
                    if (IsSingleSpawn_AreaD)
                    {
                        IsSingleSpawn_AreaD = false;
                        //显示粒子墙
                        DisplayParticalWall();
                    }
                    break;
                case CommonTriggerType.Enemy5_Dialog:
                    //核心Boss战斗系统
                    if (IsSingleSpawn_AreaE)
                    {
                        IsSingleSpawn_AreaE = false;
                        //SpawnEnemy_AtArea_C();
                        //产生核心Boss战斗
                        StartCoroutine("SpawnEnemy_AtBossArea");
                    }
                    break;
                default:
                    break;
            }
        }

        void Start()
        {
            //播放背景音乐
            AudioManager.SetAudioBackgroundVolumns(0.4F);
            AudioManager.SetAudioEffectVolumns(0.5F);
            AudioManager.PlayBackground(BackgroundMusic);
           // AudioManager.PlayBackground(BackgroundMusic_Fighting);
            //默认隐藏场景中非活动的区域
            //StartCoroutine("HideUnActiveArea");
            //粒子墙，默认禁用
            goParticalWall.SetActive(false);

        }

        /// <summary>
        /// 场景优化管理：默认隐藏不活动的区域
        /// </summary>
        /// <returns></returns>
        private IEnumerator HideUnActiveArea()
        {
            yield return new WaitForEndOfFrame();
            foreach(string tagNameHideObj in TagNameByHideObject)
            {
                //得到需要隐藏的游戏对象
                GameObject[] goHideObjArray = GameObject.FindGameObjectsWithTag(tagNameHideObj);
                foreach(GameObject item in goHideObjArray)
                {
                    item.SetActive(false);
                }
            }
        }

        #region 产生敌人
        /// <summary>
        /// A区域
        /// </summary>
        private void SpawnEnemy_AtArea_A()
        {
            //生成敌人
            if(goArcher && goMage)
            {
                //产生1个射箭手
                StartCoroutine(SpawnEnemy(goArcher, 1, TraSpawnEnemyPos_AreaA_Archer));
                //产生2个魔法小怪
                StartCoroutine(SpawnEnemy(goMage, 2, TraSpawnEnemyPos_AreaA_Mage));
            }
        }

        /// <summary>
        /// B区域
        /// </summary>
        private void SpawnEnemy_AtArea_B()
        {
            //生成敌人
            if (goArcher && goWarrior && goKing)
            {
                //产生2个射箭手
                StartCoroutine(SpawnEnemy(goArcher, 2, TraSpawnEnemyPos_AreaB_Archer));
                //产生2个战士怪物
                StartCoroutine(SpawnEnemy(goWarrior, 2, TraSpawnEnemyPos_AreaB_Warrior));
                //产生1个国王
                StartCoroutine(SpawnEnemy(goKing, 1, TraSpawnEnemyPos_AreaB_King));
            }
        }


        /// <summary>
        /// C区域
        /// </summary>
        private void SpawnEnemy_AtArea_C()
        {
            //生成敌人
            if (goKing)
            {
                //产生3个国王
                StartCoroutine(SpawnEnemy(goKing, 3, TraSpawnEnemyPos_AreaC_King, true));
            }
        }
        #endregion

        /// <summary>
        /// 显示粒子墙,更新背景音乐
        /// </summary>
        private void DisplayParticalWall()
        {
            //开启粒子墙，阻止玩家
            goParticalWall.SetActive(true);
            //播放背景音乐
            AudioManager.SetAudioBackgroundVolumns(0.6F);
            AudioManager.SetAudioEffectVolumns(0.8F);
            AudioManager.PlayBackground(BackgroundMusic_Fighting);//战斗背景音乐
        }

        /// <summary>
        /// 核心战斗
        /// </summary>
        /// <returns></returns>
        IEnumerator SpawnEnemy_AtBossArea()
        {
            //产生Boss
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT1);
            StartCoroutine(SpawnEnemy(goBoss_Bruce, 1, TraSpawnBoss, true));
            //if(_IsSingleBossSpawn)
            //{
            //    _IsSingleBossSpawn = false;
            //    StartCoroutine(SpawnEnemy(goBoss_Bruce, 1, TraSpawnBoss));
            //}
            //循环产生更多的敌人
            while (true)
            {
                yield return new WaitForSeconds(10F);
                //如果所有的敌人数量小于3个，则产生新的一批敌人
                if(CountEnemyNumberAtBossArea() <=3)
                {
                    yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_1);
                    StartCoroutine(SpawnEnemy(goArcher, 2, TraSpawnEnemyPos_AreaD_Archer, true));
                    StartCoroutine(SpawnEnemy(goKing, 1, TraSpawnEnemyPos_AreaD_King, true));
                    StartCoroutine(SpawnEnemy(goMage, 2, TraSpawnEnemyPos_AreaD_Mage, true));
                    StartCoroutine(SpawnEnemy(goWarrior, 1, TraSpawnEnemyPos_AreaD_Warrior, true));
                }
            }
        }

        /// <summary>
        /// 统计战斗敌人数量
        /// </summary>
        /// <returns></returns>
        private int CountEnemyNumberAtBossArea()
        {
            GameObject[] goEnemyArray = GameObject.FindGameObjectsWithTag(Tag.Tag_Enemys);
            if(goEnemyArray != null)
            {
                return goEnemyArray.Length;
            }
            else
            {
                return 0; 
            }
        }

    }//Class_end
}
