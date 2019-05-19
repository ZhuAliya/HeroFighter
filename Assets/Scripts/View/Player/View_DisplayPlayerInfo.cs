/***
   *        Title: "英雄战神" 项目开发
   *        视图层：显示玩家信息
   *      Description:
   *             显示玩家的各种信息：等级/生命值/魔法值/攻击力......   
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Global;
using Model;

public class View_DisplayPlayerInfo : MonoBehaviour {
    //屏幕上信息显示
    public Text TxtPlayerName;                                                                          //玩家的姓名
    public Text TxtPlayerNameByDetailPanel;                                                     //详细面板玩家姓名

    public Slider SliHP;                                                                                        //生命值
    public Slider SliMP;                                                                                        //魔法值
    public Text TxtCurrentLevelByScreen;                                                          //当前等级
    public Text TxtCurHPByScreen;                                                                    //当前的生命值
    public Text TxtMaxHPByScreen;                                                                  //最大生命值
    public Text TxtCurMPByScreen;                                                                   //当前的魔法值
    public Text TxtMaxMPByScreen;                                                                   //最大的魔法值
    public Text TxtEXPByScreen;                                                                       //经验数值
    public Text TxtGoldByScreen;                                                                       //金币
    public Text TxtDiamondsByScreen;                                                             //钻石


    //玩家详细信息
    public Text TxtCurHP;                                                                                   //玩家的生命值
    public Text TxtMaxHP;                                                                                   //最大生命值
    public Text TxtCurMP;                                                                                   //当前魔法数值
    public Text TxtMaxMp;                                                                                   //最大魔法数值 
    public Text TxtCurATK;                                                                                  //攻击力
    public Text TxtMaxATK;                                                                                 //最大攻击力
    public Text TxtCurDEF;                                                                                 //防御力
    public Text TxtMaxDEF;                                                                                //最大防御力
    public Text TxtCurDEX;                                                                                 //敏捷度
    public Text TxtMaxDEX;                                                                                //最大敏捷度
    public Text TxtLevel;                                                                                       //等级
    public Text TxtKillNum;                                                                                  //杀敌数量
    public Text TxtEXP;                                                                                       //经验数值
    public Text TxtGold;                                                                                      //金币数量
    public Text TxtDiamonds;                                                                            //钻石数量
    //常量
    public const float WAIT_FOR_SECONDS_ON_START= 0.3F;                           //start方法等待时间

    void Awake()
    {
        //核心数值事件注册
        PlayerKernalData.evePlayerKernalData += DisplayHP;
        PlayerKernalData.evePlayerKernalData += DisplayMaxHP;
        PlayerKernalData.evePlayerKernalData += DisplayMP;
        PlayerKernalData.evePlayerKernalData += DisplayMaxMP;
        PlayerKernalData.evePlayerKernalData += DisplayATK;
        PlayerKernalData.evePlayerKernalData += DisplayMaxATK;
        PlayerKernalData.evePlayerKernalData += DisplayDEF;
        PlayerKernalData.evePlayerKernalData += DisplayMaxDEF;
        PlayerKernalData.evePlayerKernalData += DisplayDEX;
        PlayerKernalData.evePlayerKernalData += DisplayMaxDEX;

        //扩展数值事件注册
        PlayerExtenData.evePlayerExtenalData += DisplayExp;
        PlayerExtenData.evePlayerExtenalData += DisplayKillNumber;
        PlayerExtenData.evePlayerExtenalData += DisplayLevel;
        PlayerExtenData.evePlayerExtenalData += DisplayGold;
        PlayerExtenData.evePlayerExtenalData += DisplayDiamonds;
    }

    IEnumerator Start () {
        //等待时间
        //这个start一定要在Ctrl_HeroProperty脚本的Start方法后执行，所以延迟处理。因为要最早开始Ctrl_HeroProperty脚本中start()的数据初始化。
        yield return new WaitForSeconds(WAIT_FOR_SECONDS_ON_START); 
         //显示所有的初始值 
        PlayerKernalDataProxy.GetInstance().DisplayAllOriginalValues();
        PlayerExtenDataProxy.GetInstance().DisplayAllOriginalValues();
        //玩家的姓名
         if(!string.IsNullOrEmpty(GlobalParaMgr.PlayerName))
        {
            TxtPlayerName.text = GlobalParaMgr.PlayerName;
            TxtPlayerNameByDetailPanel.text = GlobalParaMgr.PlayerName;
        }
    }


    #region  事件注册的方法
    /* 核心数值*/
    /// <summary>
    /// 显示当前生命值
    /// </summary>
    /// <param name="kv"></param>
    private void DisplayHP(KeyValuesUpdate kv)
    {
        if (kv.Key.Equals("Health"))
        {
            if(TxtCurHPByScreen && TxtCurHP)
            {
                TxtCurHPByScreen.text = kv.Values.ToString();
                TxtCurHP.text = kv.Values.ToString();
                //slider滑动条处理
                SliHP.value = (float)kv.Values;
            }           
        }
    }

    /// <summary>
    /// 显示当前最大生命值
    /// </summary>
    /// <param name="kv"></param>
    private void DisplayMaxHP(KeyValuesUpdate kv)
    {
        if(TxtMaxHPByScreen && TxtMaxHP)
        {
            if (kv.Key.Equals("MaxHealth"))
            {
                TxtMaxHPByScreen.text = kv.Values.ToString();
                TxtMaxHP.text = kv.Values.ToString();
                //slider滑动条处理
                SliHP.maxValue = (float)kv.Values;
                SliHP.minValue = 0;
            }

        }
       
    }

    /// <summary>
    /// 显示当前魔法数值
    /// </summary>
    /// <param name="kv"></param>
    private void DisplayMP(KeyValuesUpdate kv)
    {
        if(TxtCurMPByScreen && TxtCurMP)
        {
            if (kv.Key.Equals("Magic"))
            {
                TxtCurMPByScreen.text = kv.Values.ToString();
                TxtCurMP.text = kv.Values.ToString();
                //滑动条
                SliMP.value = (float)kv.Values;
            }
        }
       
    }

    /// <summary>
    /// 显示最大魔法数值
    /// </summary>
    /// <param name="kv"></param>
    private void DisplayMaxMP(KeyValuesUpdate kv)
    {
        if(TxtMaxMPByScreen && TxtMaxMp)
        {
            if (kv.Key.Equals("MaxMagic"))
            {
                TxtMaxMPByScreen.text = kv.Values.ToString();
                TxtMaxMp.text = kv.Values.ToString();
                //滑动条
                SliMP.maxValue = (float)kv.Values;
                SliMP.minValue =0;
            }
        }
      
    }

    /// <summary>
    /// 显示当前的攻击力
    /// </summary>
    /// <param name="kv"></param>
    private void DisplayATK(KeyValuesUpdate kv)
    {
        if(TxtCurATK)
        {
            if (kv.Key.Equals("Attack"))
            {
                TxtCurATK.text = kv.Values.ToString();
            }
        }        
    }

    /// <summary>
    /// 显示当前最大攻击力
    /// </summary>
    /// <param name="kv"></param>
    private void DisplayMaxATK(KeyValuesUpdate kv)
    {
        if (kv.Key.Equals("MaxAttack"))
        {
            TxtMaxATK.text = kv.Values.ToString();
        }
    }

    /// <summary>
    /// 显示当前防御力
    /// </summary>
    /// <param name="kv"></param>
    private void DisplayDEF(KeyValuesUpdate kv)
    {
        if(TxtCurDEF)
        {
            if (kv.Key.Equals("Defence"))
            {
                TxtCurDEF.text = kv.Values.ToString();
            }
        }     
    }

    /// <summary>
    /// 显示当前最大防御力
    /// </summary>
    /// <param name="kv"></param>
    private void DisplayMaxDEF(KeyValuesUpdate kv)
    {
        if(TxtMaxDEF)
        {
            if (kv.Key.Equals("MaxDefence"))
            {
                TxtMaxDEF.text = kv.Values.ToString();
            }
        }      
    }

    /// <summary>
    /// 显示当前敏捷度
    /// </summary>
    /// <param name="kv"></param>
    private void DisplayDEX(KeyValuesUpdate kv)
    {
        if(TxtCurDEX)
        {
            if (kv.Key.Equals("Dexterity"))
            {
                TxtCurDEX.text = kv.Values.ToString();
            }
        }        
    }

    /// <summary>
    /// 显示最大敏捷度
    /// </summary>
    /// <param name="kv"></param>
    private void DisplayMaxDEX(KeyValuesUpdate kv)
    {
        if(TxtMaxDEX)
        {
            if (kv.Key.Equals("MaxDexterity"))
            {
                TxtMaxDEX.text = kv.Values.ToString();
            }
        }       
    }

    /* 扩展数值*/
    /// <summary>
    /// 经验值
    /// </summary>
    /// <param name="kv"></param>
    void DisplayExp(KeyValuesUpdate kv)
    {
        if(TxtEXPByScreen&&TxtEXP)
        {
            if (kv.Key.Equals("Experience"))
            {
                TxtEXP.text = kv.Values.ToString();
                TxtEXPByScreen.text = kv.Values.ToString();
            }
        }     
    }

    /// <summary>
    /// 杀敌数量
    /// </summary>
    /// <param name="kv"></param>
    void DisplayKillNumber(KeyValuesUpdate kv)
    {
        if(TxtKillNum)
        {
            if (kv.Key.Equals("KillNumber"))
            {
                TxtKillNum.text = kv.Values.ToString();
            }
        }        
    }

    /// <summary>
    /// 等级
    /// </summary>
    /// <param name="kv"></param>
    //void DisplayLevel(KeyValuesUpdate kv)
    //{
    //    if(TxtLevel)
    //    {
    //        if (kv.Key.Equals("Level"))
    //        {
    //            TxtLevel.text = kv.Values.ToString();
    //        }
    //    }      
    //}
    void DisplayLevel(KeyValuesUpdate kv)
    {
        if (kv.Key.Equals("Level"))
        {
            if (TxtCurrentLevelByScreen && TxtLevel)
            {
                TxtCurrentLevelByScreen.text = kv.Values.ToString();
                TxtLevel.text = kv.Values.ToString();
            }
        }
    }

    /// <summary>
    /// 金币
    /// </summary>
    /// <param name="kv"></param>
    void DisplayGold(KeyValuesUpdate kv)
    {
        if(TxtGoldByScreen&& TxtGold)
        {
            if (kv.Key.Equals("Gold"))
            {
                TxtGold.text = kv.Values.ToString();
                TxtGoldByScreen.text = kv.Values.ToString();
            }
        }      
    }

    /// <summary>
    /// 钻石
    /// </summary>
    /// <param name="kv"></param>
    void DisplayDiamonds(KeyValuesUpdate kv)
    {
        if (kv.Key.Equals("Diamonds"))
        {
            if(TxtDiamondsByScreen && TxtDiamonds)
            {
                TxtDiamonds.text = kv.Values.ToString();
                TxtDiamondsByScreen.text = kv.Values.ToString();
            }
        }
    }
    #endregion
}
