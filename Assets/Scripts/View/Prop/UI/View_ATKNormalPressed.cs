/***
   *        Title: "英雄战神" 项目开发
   *    视图层：UI攻击虚拟按键,按压事件处理
   *      Description:
   *                [描述]
   *       Data:	[2018]
   *       Version: 0.1
 * */

using UnityEngine;
using System.Collections;
using Global;
using Control;
using Kernal;

namespace View
{
    public class View_ATKNormalPressed : StateMachineBehaviour
    {
       // private const 
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //
        //}

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            //Debug.Log("OnStateUpdate");
            if(UnityHelper.GetInstance().GetSmallTime(GlobalParameter.INTERVAL_TIME_0DOT2))//间隔时间0.2s
            {
                Debug.Log("OnStateUpdate");
//#if UNITY_ANDROID || UNITY_IPHONE
                Ctrl_HeroAttackInputByET.Instance.ResponseATKByNormal();
//#endif
            }

        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //
        //}

        // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
        //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //
        //}

        // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
        //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //
        //}
    }//Class_end


}
