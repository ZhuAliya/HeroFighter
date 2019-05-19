/***
   *        Title: "英雄战神" 项目开发
   *        公共层：进行游戏的存盘与调用
   *        Description:
             实现原理：对于“模型层”核心类，做“对象持久化”处理。       
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using System.Collections;
using Kernal;
using Model;

namespace Global
{
    public class SaveAndLoading : MonoBehaviour
    {
        private static SaveAndLoading _Instance;
        /*  数据持久化路径   */
        //全局参数对象路径
        private static string _FileNameByGlobalParameterData = Application.persistentDataPath + "/GlobalParaData.xml";
        //玩家核心数据对象路径
        private static string _FileNameByKernalData = Application.persistentDataPath + "/KernalParaData.xml";
        //玩家扩展数据对象路径
        private static string _FileNameByExtendData = Application.persistentDataPath + "/ExtendParaData.xml";
        //玩家背包数据对象路径
        private static string _FileNameByPackageData = Application.persistentDataPath + "/PackageParaData.xml";
        //模型层代理类
        private PlayerKernalDataProxy _PlayerKernalDataProxy;
        private PlayerExtenDataProxy _PlayerExtenDataProxy;
        private PlayerPackageDataProxy _PlayerPackageDataProxy;




        /// <summary>
        /// 得到本脚本的实例
        /// </summary>
        /// <returns></returns>
        public static SaveAndLoading GetInstance()
        {
            if(_Instance == null)
            {
                _Instance = new GameObject("_SaveAndLoading").AddComponent<SaveAndLoading>();
            }
            return _Instance;
        }

        #region  存储游戏进度
        /// <summary>
        ///  存储游戏进度
        /// </summary>
        /// <returns></returns>
        public void SaveGameProcess()
        {
            _PlayerKernalDataProxy = PlayerKernalDataProxy.GetInstance();
            _PlayerExtenDataProxy = PlayerExtenDataProxy.GetInstance();
            _PlayerPackageDataProxy = PlayerPackageDataProxy.GetInstance();

            //存储游戏全局参数
            StoreToXML_GlobalParaData();
            //存储玩家核心数据
            StoreToXML_KenalParaData();
            //存储玩家扩展数据
            StoreToXML_ExtendParaData();
            //存储玩家背包数据
            StoreToXML_PackageParaData();
        }

        #endregion
         //存储游戏全局参数
        private void StoreToXML_GlobalParaData()
        {
            string playerName = GlobalParaMgr.PlayerName;
            ScenesEnum scenesName = GlobalParaMgr.NextScenesName;
            GlobalParameterData GPD = new GlobalParameterData(scenesName, playerName);
            //对象序列化
            string s = XmlOperation.GetInstance().SerializeObject(GPD, typeof(GlobalParameterData));
            //创建XML文件，且写入
            if(!string.IsNullOrEmpty(_FileNameByGlobalParameterData))
            {
                XmlOperation.GetInstance().CreateXML(_FileNameByGlobalParameterData, s);
            }
            Log.Write(GetType() + "StoreToXML_GlobalParaData/xml Path=" + _FileNameByGlobalParameterData);
        }

        /// <summary>
        /// 存储玩家核心数据
        /// </summary>
        private void StoreToXML_KenalParaData()
        {
            //数据准备
            float health =_PlayerKernalDataProxy.Health;
            float magic =_PlayerKernalDataProxy.Magic;
            float attack =_PlayerKernalDataProxy.Attack;
            float def =_PlayerKernalDataProxy.Defence;
            float dex =_PlayerKernalDataProxy.Dexterity;

            float maxHealth =_PlayerKernalDataProxy.MaxHealth;
            float maxMagic =_PlayerKernalDataProxy.MaxMagic;
            float maxAttack =_PlayerKernalDataProxy.MaxAttack;
            float maxDEF =_PlayerKernalDataProxy.MaxDefence;
            float maxDEX =_PlayerKernalDataProxy.MaxDexterity;

            float attackProp = _PlayerKernalDataProxy.AttackByProp;
            float defenceProp = _PlayerKernalDataProxy.DefenceByProp;
            float dexterityProp = _PlayerKernalDataProxy.DexterityByProp;

            //实例化“类”
            PlayerKernalData PKD = new PlayerKernalData(health, magic, attack, def, dex, maxHealth, maxMagic, maxAttack, maxDEF, maxDEX,
                                                                                    attackProp, defenceProp, dexterityProp);
            //对象序列化
            string s = XmlOperation.GetInstance().SerializeObject(PKD, typeof(PlayerKernalData));
            //创建XML文件，且写入
            if (!string.IsNullOrEmpty(_FileNameByKernalData))
            {
                XmlOperation.GetInstance().CreateXML(_FileNameByKernalData, s);
            }
        }

        //存储玩家扩展数据
        private void StoreToXML_ExtendParaData()
        {
            //数据准备
            int exp = _PlayerExtenDataProxy.Experience;
            int killNum = _PlayerExtenDataProxy.KillNumber;
            int level = _PlayerExtenDataProxy.Level;
            int gold = _PlayerExtenDataProxy.Gold;
            int diamond = _PlayerExtenDataProxy.Diamonds;

            //实例化“类”
            PlayerExtenData PED = new PlayerExtenData(exp, killNum, level, gold, diamond);
            //对象序列化
            string s = XmlOperation.GetInstance().SerializeObject(PED, typeof(PlayerExtenData));
            //创建XML文件，且写入
            if (!string.IsNullOrEmpty(_FileNameByExtendData))
            {
                XmlOperation.GetInstance().CreateXML(_FileNameByExtendData, s);
            }
        }

        //存储玩家背包数据
        private void StoreToXML_PackageParaData()
        {
            //数据准备
            int bloodBottleNum = _PlayerPackageDataProxy.BloodBottleNum;
            int magicBottleNum = _PlayerPackageDataProxy.MagicBottleNum;
            int atkNum = _PlayerPackageDataProxy.PropATKNum;
            int defNum = _PlayerPackageDataProxy.PropDEFNum;
            int dexNum = _PlayerPackageDataProxy.PropDEXNum;

            //实例化“类”
            PlayerPackageData PPD = new PlayerPackageData(bloodBottleNum, magicBottleNum, atkNum, defNum, dexNum);
            //对象序列化
            string s = XmlOperation.GetInstance().SerializeObject(PPD, typeof(GlobalParameterData));
            //创建XML文件，且写入
            if (!string.IsNullOrEmpty(_FileNameByPackageData))
            {
                XmlOperation.GetInstance().CreateXML(_FileNameByPackageData, s);
            }
        }

        #region  提取游戏进度
        /// <summary>
        /// 提取游戏全局参数数据
        /// </summary>
        /// <returns></returns>
        public bool LoadingGame_GlobalParameter()
        {
            //读取游戏的全局参数
            ReadFromXML_GlobalParaData();
            return true;
        }

        /// <summary>
        /// 提取游戏玩家数据
        /// </summary>
        /// <returns></returns>
        public bool LoadingGame_PlayerData()
        {
            //读玩家核心数据
            ReadFromXML_PlayerExtendData();
            //读玩家扩展数据
            ReadFromXML_PlayerExtendData();
            //读玩家背包 数据
            ReadFromXML_PlayerPackageData();
            return true;

        }

        //读取游戏的全局参数
       private void ReadFromXML_GlobalParaData()
        {
            GlobalParameterData dpd = null;
            //参数检查
            if(string.IsNullOrEmpty(_FileNameByGlobalParameterData))
            {
                Debug.LogError(GetType() + "ReadFromXML_GlobalParaData() / _FileNameByGlobalParameterData is Null!!" );
                return;
            }

            try
            {
                //读取XML数据
                string strTemp = XmlOperation.GetInstance().LoadXML(_FileNameByGlobalParameterData);
                //反序列化
                dpd = XmlOperation.GetInstance().DeserializeObject(strTemp, typeof(GlobalParameterData)) as GlobalParameterData;
                //赋值
                GlobalParaMgr.PlayerName = dpd.PlayerName;
                GlobalParaMgr.NextScenesName = dpd.NextScenesName;
                GlobalParaMgr.CurGameType = CurrentGameType.Continue;
            }
            catch
            {

                Debug.LogError(GetType() + "/ReadFromXML_GlobalParaData()/读取游戏的全局参数,不成功，请检查！");
            }
        }

        /// <summary>
        /// 读玩家核心数据
        /// </summary>
        private void ReadFromXML_PlayerKernalData()
        {
            PlayerKernalData pkd = null;

            //参数检查
            if (string.IsNullOrEmpty(_FileNameByKernalData))
            {
                Debug.LogError(GetType() + "ReadFromXML_PlayerKernalData() / _FileNameByKernalData is Null!!");
                return;
            }

            try
            {
                //读取XML数据
                string strTemp = XmlOperation.GetInstance().LoadXML(_FileNameByKernalData);
                //反序列化
                pkd = XmlOperation.GetInstance().DeserializeObject(strTemp, typeof(PlayerKernalData)) as PlayerKernalData;
                //赋值
                PlayerKernalDataProxy._Instance.Health = pkd.Health;
                PlayerKernalDataProxy._Instance.Magic = pkd.Magic;
                PlayerKernalDataProxy._Instance.Attack = pkd.Attack;
                PlayerKernalDataProxy._Instance.Defence = pkd.Defence;
                PlayerKernalDataProxy._Instance.Dexterity = pkd.Dexterity;

                PlayerKernalDataProxy._Instance.MaxHealth = pkd.MaxHealth;
                PlayerKernalDataProxy._Instance.MaxMagic = pkd.MaxMagic;
                PlayerKernalDataProxy._Instance.MaxAttack = pkd.MaxAttack;
                PlayerKernalDataProxy._Instance.MaxDefence = pkd.MaxDefence;
                PlayerKernalDataProxy._Instance.MaxDexterity = pkd.MaxDexterity;

                PlayerKernalDataProxy._Instance.AttackByProp = pkd.AttackByProp;
                PlayerKernalDataProxy._Instance.DefenceByProp = pkd.DefenceByProp;
                PlayerKernalDataProxy._Instance.DexterityByProp = pkd.DexterityByProp;
            }
            catch
            {

                Debug.LogError(GetType() + "/ReadFromXML_PlayerKernalData()/读取玩家的核心参数_FileNameByKernalData,不成功，请检查！");
            }
        }

        //读玩家扩展数据
        private void ReadFromXML_PlayerExtendData()
        {
            PlayerExtenData ped = null;
            //参数检查
            if (string.IsNullOrEmpty(_FileNameByExtendData))
            {
                Debug.LogError(GetType() + "ReadFromXML_PlayerExtendData() / _FileNameByExtendData is Null!!");
                return;
            }

            try
            {
                //读取XML数据
                string strTemp = XmlOperation.GetInstance().LoadXML(_FileNameByExtendData);
                //反序列化
                ped = XmlOperation.GetInstance().DeserializeObject(strTemp, typeof(PlayerExtenData)) as PlayerExtenData;
                //赋值
                PlayerExtenDataProxy._Instance.Experience = ped.Experience;
                PlayerExtenDataProxy._Instance.KillNumber = ped.KillNumber;
                PlayerExtenDataProxy._Instance.Level = ped.Level;
                PlayerExtenDataProxy._Instance.Gold = ped.Gold;
                PlayerExtenDataProxy._Instance.Diamonds = ped.Diamonds;   
            }
            catch
            {
                Debug.LogError(GetType() + "/ReadFromXML_PlayerExtendData()/读取游戏的扩展参数_FileNameByExtendData,不成功，请检查！");
            }
        }

        //读玩家背包数据
        private void ReadFromXML_PlayerPackageData()
        {
            PlayerPackageData ppd = null;
            //参数检查
            if (string.IsNullOrEmpty(_FileNameByPackageData))
            {
                Debug.LogError(GetType() + "ReadFromXML_PlayerPackageData() / _PlayerPackageDataProxy is Null!!");
                return;
            }

            try
            {
                //读取XML数据
                string strTemp = XmlOperation.GetInstance().LoadXML(_FileNameByPackageData);
                //反序列化
                ppd = XmlOperation.GetInstance().DeserializeObject(strTemp, typeof(PlayerPackageData)) as PlayerPackageData;
                //赋值
                PlayerPackageDataProxy.GetInstance().BloodBottleNum = ppd.BloodBottleNum;
                PlayerPackageDataProxy.GetInstance().MagicBottleNum = ppd.MagicBottleNum;
                PlayerPackageDataProxy.GetInstance().PropATKNum = ppd.PropATKNum;
                PlayerPackageDataProxy.GetInstance().PropDEFNum = ppd.PropDEFNum;
                PlayerPackageDataProxy.GetInstance().PropDEXNum = ppd.PropDEXNum;
            }
            catch
            {

                Debug.LogError(GetType() + "/ReadFromXML_PlayerPackageData()/读取游戏的背包参数_FileNameByPackageData,不成功，请检查！");
            }
        }
        #endregion
    }//Class_end
}

