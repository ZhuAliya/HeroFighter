/***
   *        Title: "英雄战神" 项目开发
   *        控制层：父类控制层
   *        Description:
   *                功能：
   *                控制层脚本中公共的部分，在本脚本继承
   *       Data:	[2018]
   *       Version: 0.1
 * */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Global;
using Kernal;

namespace Control
{
    public class BaseControl : MonoBehaviour
    {
        //单次开关
        public bool IsSingleTime_LevelUP = true;         //主角升级单次开关

        /// <summary>
        /// 进入下一个场景
        /// </summary>
        /// <param name="sceneEnumName">场景(枚举)名称</param>
        protected void EnterNextScenes(ScenesEnum sceneEnumName)
        {
            //转到下一个场景
            GlobalParaMgr.NextScenesName = sceneEnumName;
            Application.LoadLevel(ConvertEnumToStr.GetInstance().GetStrByEnumScenes(ScenesEnum.LoadingScene));
        }

        //重构攻击范围
        /// <summary>
        /// 公共方法：攻击敌人
        /// </summary>
        /// <param name="attackArea">攻击范围</param>
        /// <param name="attackPowerMutiple">攻击力度（倍率）</param>
        /// <param name="isDirection">攻击是否有方向性</param>
        protected void AttackEnemy(List<GameObject> lisEnemys, Transform traNearestEnemy, float attackArea, int attackPowerMutiple, bool isDirection = true)
        { //放在了父类当中，所以用protected
            //参数检查
            if (lisEnemys == null && lisEnemys.Count <= 0)
            {
                traNearestEnemy = null;
                return;
            }

            foreach (GameObject enemyItem in lisEnemys)
            {
                //   if(enemyItem.GetComponent<Ctrl_Enemy>().IsAlive)  //????? 原来存在的 bug......    如果敌人是活的才执行下面          
                if (enemyItem && enemyItem.GetComponent<Ctrl_BaseEnemyProperty>())
                {
                    if (enemyItem.GetComponent<Ctrl_BaseEnemyProperty>().CurrentState != EnemyState.Death)
                    {
                        print(GetType() + "/AttackEnemyByNormal()/foreach ");
                        //敌我距离
                        float floDistance = Vector3.Distance(this.gameObject.transform.position, enemyItem.transform.position);
                        //攻击具有方向性
                        if (isDirection)
                        {
                            //定义“主角与敌人”的方向
                            Vector3 dir = (enemyItem.transform.position - this.gameObject.transform.position).normalized;//向量减法，从主角到敌人的向量做归一化
                                                                                                                         //定义“主角与敌人”的夹角（用向量的“点乘”进行计算）
                            float floDirection = Vector3.Dot(dir, this.gameObject.transform.forward);
                            //如果主角与敌人在同一个方向，且在有效攻击范围内，则对敌人做伤害处理
                            if (floDirection > 0 && floDistance <= attackArea)
                            {
                                enemyItem.SendMessage("OnHurt", Ctrl_HeroProperty.Instance.GetCurrentATK() * attackPowerMutiple, SendMessageOptions.DontRequireReceiver);
                            }
                        }
                        //攻击无方向性
                        else
                        {
                            if (floDistance <= attackArea)
                            {
                                enemyItem.SendMessage("OnHurt", Ctrl_HeroProperty.Instance.GetCurrentATK() * attackPowerMutiple, SendMessageOptions.DontRequireReceiver);
                            }
                        }

                    }
                }
            }//foreach_end
        }//Method_end

        /// <summary>
        /// 粒子特效加载公共方法
        /// </summary>
        /// <param name="internalTime">间隔时间</param>
        /// <param name="strParticalEffectPath">路径</param>
        /// <param name="IsUseCache">是否用缓存</param>
        /// <param name="particalEffectPosition">位置</param>
        /// <param name="QuaParticalEffect">旋转</param>
        /// <param name="tranParent">父对象</param>
        /// <param name="strAudioEffect">音效</param>
        /// <param name="destroyTime">销毁时间</param>
        /// <returns></returns>
        protected IEnumerator LoadParticalEffectPublicMethod(float internalTime, string strParticalEffectPath, bool IsUseCache, 
            Vector3 particalEffectPosition, Quaternion QuaParticalEffect, Transform tranParent, string strAudioEffect = null, float destroyTime = 0)
        {
            //间隔时间
            yield return new WaitForSeconds(internalTime);
            //提取的粒子预设
            GameObject goParticalPrefab = ResourcesMgr.GetInstance().LoadAsset(strParticalEffectPath, IsUseCache);
            //粒子预设的位置
            goParticalPrefab.transform.position = particalEffectPosition;
            //粒子预设的旋转【新添加】
            goParticalPrefab.transform.rotation = QuaParticalEffect;
            //父子对象
            if(tranParent != null)
            {
                goParticalPrefab.transform.parent = tranParent;
            }
            //特效音频
            if(!string.IsNullOrEmpty(strAudioEffect))
            {
                AudioManager.PlayAudioEffectA(strAudioEffect);
            }
            //销毁时间
            if(destroyTime > 0)
            {
                Destroy(goParticalPrefab, destroyTime);
            }
           
        }

        /// <summary>
        /// 粒子特效缓存池加载
        /// </summary>
        /// <param name="internalTime">间隔时间</param>
        /// <param name="goParEffPrefab">粒子特效预设</param>
        /// <param name="pos">位置</param>
        /// <param name="qua">旋转</param>
        /// <param name="traParent">父节点</param>
        /// <param name="acAudioEff">音效（可选）</param>
        /// <returns></returns>
        protected IEnumerator LoadParticalEffect_UsePool(float internalTime, GameObject goParEffPrefab,
            Vector3 pos, Quaternion qua, Transform traParent, AudioClip acAudioEff = null)
        {
            //间隔时间
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT5);//0.5s之后产生5个           
            //在“对象缓冲池”中激活指定的对象
            GameObject goParEffClone = PoolManager.PoolsArray["_ParticalSys"].GetGameObjectByPool(goParEffPrefab, goParEffPrefab.transform.position, Quaternion.identity);
            if (goParEffClone != null)
            {
                //确定父节点
                if (traParent != null)
                {
                    goParEffClone.transform.parent = traParent;
                }
                //特效音频
                if (acAudioEff != null)
                {
                    AudioManager.PlayAudioEffectB(acAudioEff);
                }
            }
        }

        /// <summary>
        /// “漂字”特效缓冲池方法
        /// </summary>
        /// <param name="internalTime">间隔时间</param>
        /// <param name="goParEffPrefab">粒子特效预设</param>
        /// <param name="vecParticEff">位置</param>
        /// <param name="quaParEffect">旋转</param>
        /// <param name="goTargetObj">目标对象</param>
        /// <param name="displayNum">“漂字”显示数值</param>
        /// <param name="traParent">父节点</param>
        /// <param name="acAudioEffect">音频（可选）</param>
        /// <returns></returns>
        protected IEnumerator LoadParticalEffInPool_MoveUpLabel(float internalTime, GameObject goParEffPrefab, Vector3 vecParticEff,
            Quaternion quaParEffect,  GameObject goTargetObj, int displayNum, Transform  traParent, AudioClip acAudioEffect = null )
        {
            //间隔时间
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT5);//0.5s之后产生5个           

            //在“对象缓冲池”中激活指定的对象
            GameObject goParEffClone = PoolManager.PoolsArray["_ParticalSys"].GetGameObjectByPool(goParEffPrefab, goParEffPrefab.transform.position, Quaternion.identity);
            if(goParEffClone != null)
            {
                //参数赋值
                goParEffClone.GetComponent<MoveUpLabel>().SetTargetEnemy(goTargetObj);
                goParEffClone.GetComponent<MoveUpLabel>().SetReduceHPNumber(displayNum);
                //确定父节点
                if(traParent != null)
                {
                    goParEffClone.transform.parent = traParent;
                }
                //特效音频
                if(acAudioEffect!= null)
                {
                    AudioManager.PlayAudioEffectB(acAudioEffect);
                }
            }


            //yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT1);//每间隔1s产生一个
            //    //动态调用资源(敌人”预设“)  //用”对象缓冲池“来加载资源，提高Resources.Load加载的效率，Resources.Load非常消耗资源。所以开发一个自己的资源管理器脚本插件              
            //    //定义克隆体随机出现的位置
            //    Transform TranEnemySpawnPosition = GetRandomEnemySpawnPosition(enemySpawnPos);
            //    //克隆体的位置   
            //    //TraSpawnEnemysPosition_1敌人出现的位置。和敌人出现的位置的x、y、z都一样
            //    enemyPrefab.transform.position = new Vector3(TranEnemySpawnPosition.transform.position.x, TranEnemySpawnPosition.transform.position.y, TranEnemySpawnPosition.transform.position.z);//敌人出现的位置的位置
            //    //在“对象缓冲池”中激活指定的对象
            //    GameObject goObjClone = PoolManager.PoolsArray["_Enemys"].GetGameObjectByPool(enemyPrefab, enemyPrefab.transform.position, Quaternion.identity);
            //    /*敌人的血条*/
            //    if (IsCreateHpBar)
            //    {
            //        //调用预设
            //        GameObject goEnemyHP = ResourcesMgr.GetInstance().LoadAsset("Prefabs/UI/EnemyHPBar", true);
            //        //确定父节点
            //        goEnemyHP.transform.parent = GameObject.FindGameObjectWithTag(Tag.Tag_UIPlayerInfo).transform;
            //        //参数赋值
            //        goEnemyHP.GetComponent<EnemyHpBar>().SetTargetEnemy(goObjClone);
            //    }
            //    //克隆敌人出现特效
            //    //EnemySpawnParticalEffect(goWarriorPrefab_Green);

        }

        /// <summary>
        /// 敌人的出生（加入对象缓冲池技术）
        /// </summary>
        /// <param name="enemyPrefab">敌人预设</param>
        /// <param name="createEnemysNum">生成数量</param>
        /// <param name="enemySpawnPos">生成地点</param>
        /// <returns></returns>
        protected IEnumerator SpawnEnemy(GameObject enemyPrefab, int createEnemysNum, Transform[] enemySpawnPos, bool IsCreateHpBar=false)//出生敌人  createEnemysNum:创建敌人的数量
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT5);//0.5s之后产生5个           
            for (int i = 1; i <= createEnemysNum; i++)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT1);//每间隔1s产生一个
                //动态调用资源(敌人”预设“)  //用”对象缓冲池“来加载资源，提高Resources.Load加载的效率，Resources.Load非常消耗资源。所以开发一个自己的资源管理器脚本插件              
                //定义克隆体随机出现的位置
                Transform TranEnemySpawnPosition = GetRandomEnemySpawnPosition(enemySpawnPos);
                //克隆体的位置   
                //TraSpawnEnemysPosition_1敌人出现的位置。和敌人出现的位置的x、y、z都一样
                enemyPrefab.transform.position = new Vector3(TranEnemySpawnPosition.transform.position.x, TranEnemySpawnPosition.transform.position.y, TranEnemySpawnPosition.transform.position.z);//敌人出现的位置的位置
                //在“对象缓冲池”中激活指定的对象
                GameObject goObjClone = PoolManager.PoolsArray["_Enemys"].GetGameObjectByPool(enemyPrefab, enemyPrefab.transform.position, Quaternion.identity);
                /*敌人的血条*/
                if(IsCreateHpBar)
                {
                    //调用预设
                    GameObject goEnemyHP = ResourcesMgr.GetInstance().LoadAsset("Prefabs/UI/EnemyHPBar", true);
                    //确定父节点
                    goEnemyHP.transform.parent = GameObject.FindGameObjectWithTag(Tag.Tag_UIPlayerInfo).transform;
                    //参数赋值
                    goEnemyHP.GetComponent<EnemyHpBar>().SetTargetEnemy(goObjClone);                    
                }
                //克隆敌人出现特效
                //EnemySpawnParticalEffect(goWarriorPrefab_Green);
            }
        }

        /// <summary>
        /// 得到敌人的多出生点
        /// </summary>
        /// <param name="enemyCreatePos">敌人位置数组</param>
        /// <returns></returns>
        private Transform GetRandomEnemySpawnPosition(Transform[] enemyCreatePos)
        {
            int intRandomNum = UnityHelper.GetInstance().GetRandomNum(0, enemyCreatePos.Length -1);          
            return enemyCreatePos[intRandomNum];
        }

        //主角升级
        protected void LevelUp(KeyValuesUpdate kv, AudioClip acLevelUp)
        {
            if (kv.Key.Equals("Level"))
            {
                if (IsSingleTime_LevelUP)
                {
                    IsSingleTime_LevelUP = false;
                }
                else
                {
                    HeroLevelUp(acLevelUp);
                }
            }
        }

        //主角升级
        private void HeroLevelUp(AudioClip acLevelUp)
        {
            // 提取升级粒子预设
            GameObject HeroLevelUp = ResourcesMgr.GetInstance().LoadAsset("ParticleProps/Hero_LvUp", true);
            //音效
            AudioManager.PlayAudioEffectA("LevelUp");
        }

    }//Class_end
}

