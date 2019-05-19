/***
   *      Title: "英雄战神" 项目开发
   *      公共层："连击"管理器
   *      Description:
   *                功能：查看敌人当前生命值
   *       Data:	[2018]
   *       Version: 0.1
 * */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Kernal;

public class ComboCountMgr : MonoBehaviour {
    public static ComboCountMgr Instance;              //本脚本实例
    private int ComboCount = 0;                               //连击次数
    private float ComboDelayTime = 3;                     //连击延迟时间
    //控件外观尺寸
    public float ComboCountPrefabLength = 2F;
    public float ComboCountPrefabHeight = 1F;
    public float _FloComboCountPrefabLength;         //当前实际长度
    public float _FloComboCountPrefabHeight;         //当前实际高度
    //控件
    private Text TxtDisplayComboCount;


    /// <summary>
    /// 恢复数值
    /// （作用：给其他脚本进行调用）
    /// </summary>
    public void ResetNumber()
    {
        //累加连击次数
        ++ComboCount;
        //延时时间不变
        ComboDelayTime = 3F;
        _FloComboCountPrefabHeight = ComboCountPrefabLength+1F;
        _FloComboCountPrefabLength = ComboCountPrefabHeight+1F;

    }

    void Awake()
    {
        Instance = this;
    }

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
