/***
   *        Title: "英雄战神" 项目开发
   *    视图层：UI攻击虚拟按键CD冷却特效
   *      Description:
   *                [描述]
   *       Data:	[2018]
   *       Version: 0.1
 * */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class View_ATKButtonCDEffect : MonoBehaviour {
    public Text TxtCountDownNumber;                     //数字大招倒计时控件
    public float FloCDTime = 2F;                               //冷却时间
    public Image ImgCircle;                                       //外部圆圈转到特效(精灵)
    public GameObject GoWhiteAndBlack;                 //黑白精灵
    public KeyCode keyCode;                                     //键盘输入

    private float _FloTimerDelta = 0F;                        //时间累积数值
    private bool _IsStartTimer = false;                          //开始时间计时
    private Button _BtnSelf;                                         //本脚本所挂按钮

    public bool _Enable = false;                                    //是否启用

	void Start () {
        //得到本按钮
        _BtnSelf = this.gameObject.GetComponent<Button>();
        //一开始时不显示“控件倒计时”
        TxtCountDownNumber.enabled = false;
        //测试禁用
       // DisableSelf();
        //默认启用
        EnableSelf();

        //_BtnSelf.interactable = true;                               //启用按钮
        //不启用黑白精灵
       // GoWhiteAndBlack.SetActive(false);
	}
	

	void Update () {
        //是否启用(本控件)
        if(_Enable)
        {
            //支持键盘输入
            if (Input.GetKeyDown(keyCode))
            {
                _IsStartTimer = true;
                //显示“控件倒计时”
                TxtCountDownNumber.enabled = true;
            }

            if (_IsStartTimer)
            {
                GoWhiteAndBlack.SetActive(true);                   //启用黑白精灵
                _FloTimerDelta += Time.deltaTime;                  //时间数值累加
                //控件倒计时显示
                TxtCountDownNumber.text = Mathf.Round(FloCDTime - _FloTimerDelta).ToString();
                ImgCircle.fillAmount = _FloTimerDelta / FloCDTime;  //给Circle控件赋值
                _BtnSelf.interactable = false;                               //禁用按钮
                //超过规定CD时限
                if (_FloTimerDelta >= FloCDTime)
                {
                    TxtCountDownNumber.enabled = false;//超过规定CD时限，“控件倒计时”不显示
                    _IsStartTimer = false;
                    ImgCircle.fillAmount = 1;
                    _FloTimerDelta = 0F;
                    GoWhiteAndBlack.SetActive(false);                   //禁用黑白精灵
                    _BtnSelf.interactable = true;                               //启用按钮
                }
            }
        }
     
	}//Update_end

    //响应用户点击
    public void ResponseBtnClick() 
    {
        _IsStartTimer = true;
        //显示“控件倒计时”
        TxtCountDownNumber.enabled = true;
    }

    /// <summary>
    /// 关于按钮的启用，启用本控件
    /// </summary>
    public void EnableSelf()
    {
        _Enable = true;
        GoWhiteAndBlack.SetActive(false);                   //禁用黑白精灵
        _BtnSelf.interactable = true;                               //启用按钮
    }

    /// <summary>
    /// 禁用本控件
    /// </summary>
    public void DisableSelf()
    {
        _Enable = false;
        GoWhiteAndBlack.SetActive(true);                   //启用黑白精灵
        _BtnSelf.interactable = false;                               //启用按钮
    }
}//class_end
