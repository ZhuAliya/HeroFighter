/***
   *        Title: "英雄战神" 项目开发
   *    模型层：升级规则
   *      Description:
   *           1.  项目中升级的规则
   *          2.按照设计模式中：有“开放-封闭原则”、 “单一职责原则”    来定义本类的所有功能 
   *       Data:	[2018]
   *       Version: 0.1
 * */


using UnityEngine;
using System.Collections;
using Global;

namespace Model
{
    public class UpgradeRule
    {
        private static UpgradeRule _Instance;               //本类实例

        private UpgradeRule()
        {

        }

        public static UpgradeRule GetInstance()
        {
            if(_Instance ==null)
            {
                _Instance = new UpgradeRule();
            }
            return _Instance;
        }

        /// <summary>
        /// [等级提升]升级条件
        /// </summary>
        /// <param name="experience">经验值</param>
        public void UpgradeCondition(int experience)
        {
            int currentLevel = 0;                                                                                   //当前的等级
            currentLevel = PlayerExtenDataProxy.GetInstance().GetLevel();
            if (experience >= 100 && experience< 300 && currentLevel == 0)
            {
                PlayerExtenDataProxy.GetInstance().AddLevel();
            }else if(experience >= 300 && experience < 500 && currentLevel == 1)
            {
                PlayerExtenDataProxy.GetInstance().AddLevel();
            }
            else if (experience >= 500 && experience < 1000 && currentLevel == 2)
            {
                PlayerExtenDataProxy.GetInstance().AddLevel();
            }
            else if (experience >= 1000 && experience < 1500 && currentLevel == 3)
            {
                PlayerExtenDataProxy.GetInstance().AddLevel();
            }
            else if (experience >= 1500 && experience < 3000 && currentLevel == 4)
            {
                PlayerExtenDataProxy.GetInstance().AddLevel();
            }
            else if (experience >= 3000 && experience < 5000 && currentLevel == 5)
            {
                PlayerExtenDataProxy.GetInstance().AddLevel();
            }

        }

        /// <summary>
        /// 升级操作
        /// 处理两项事宜：
        /// 1.所有的核心最大数值【例如：生命值】增加
        /// 2.对应的核心数值，加满为最大数值。
        /// 
        /// </summary>
        public void UpgradeOperation(LevelName levelName)
        {
            switch (levelName)
            {
                case LevelName.Level_0:
                    //定义一个方法
                    // +10  +10  +2  +1  +10
                    
                    UpgradeRuleOperation(10, 10, 2, 1, 10); 
                    break;
                case LevelName.Level_1:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case LevelName.Level_2:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case LevelName.Level_3:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case LevelName.Level_4:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case LevelName.Level_5:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case LevelName.Level_6:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case LevelName.Level_7:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case LevelName.Level_8:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case LevelName.Level_9:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case LevelName.Level_10:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                default:
                    break;
            }//switch_end
        }//UpgradeOperation_end

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxhp">最大生命值增量</param>
        /// <param name="maxmp">最大魔法值增量</param>
        /// <param name="maxATK">最大攻击力值增量</param>
        /// <param name="maxDEF">最大防御值增量</param>
        /// <param name="maxFEX">最大敏捷度值增量</param> 
        private void UpgradeRuleOperation(float maxhp, float maxmp, float maxATK, float maxDEF, float maxFEX)
        {
            // 1.所有的核心最大数值【例如：生命值】增加
            PlayerKernalDataProxy.GetInstance().IncreaseMaxHealth(maxhp);
            PlayerKernalDataProxy.GetInstance().IncreaseMaxMagic(maxmp);
            PlayerKernalDataProxy.GetInstance().IncreaseMaxATK(maxATK);
            PlayerKernalDataProxy.GetInstance().IncreaseMaxDEF(maxDEF);
            PlayerKernalDataProxy.GetInstance().IncreaseMaxDEX(maxFEX);

            // 2.对应的"生命数值" 、“魔法数值”，加满为最大数值。
            PlayerKernalDataProxy.GetInstance().IncreaseHealthValues(PlayerKernalDataProxy.GetInstance().GetMaxHealth());
            PlayerKernalDataProxy.GetInstance().IncreaseMagicValues(PlayerKernalDataProxy.GetInstance().GetMaxMagic());
        }
    }//class_end

    

}
