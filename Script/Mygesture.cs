using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Mygesture : MonoBehaviour, KinectGestures.GestureListenerInterface
{
    private 火柴人A 发射子弹;
    public int playerIndex = 0;
    private void Start()
    {
        // 调用火柴人A中的方法
        发射子弹 = FindObjectOfType<火柴人A>();
    }
    //动作取消时调用
    public bool GestureCancelled(long userId, int userIndex, KinectGestures.Gestures gesture, KinectInterop.JointType joint)
    {
        return true;
    }
    //动作完成时调用
    public bool GestureCompleted(long userId, int userIndex, KinectGestures.Gestures gesture, KinectInterop.JointType joint, Vector3 screenPos)
    {
        if (userIndex != playerIndex)
            return false;
        if (gesture == KinectGestures.Gestures.Push)//判断如果完成的姿势是双手向上的姿势
        {
            print("检测到双手向上");
            // 检测到双手向上就调用fire函数

            if (发射子弹.score > 0)
            {
                发射子弹.fire(userIndex);
                发射子弹.score--;
                发射子弹.scoreText.text = "子弹数量" + 发射子弹.score;  //更新分数
            }
        }
        return true;
    }
    //动作进行时调用
    public void GestureInProgress(long userId, int userIndex, KinectGestures.Gestures gesture, float progress, KinectInterop.JointType joint, Vector3 screenPos)
    {
    }
    //检测到用户时调用
    public void UserDetected(long userId, int userIndex)
    {
        if (userIndex != playerIndex)
            return;
        print("检测到用户");
        KinectManager manager = KinectManager.Instance;//初始化KinectManager对象
        manager.DetectGesture(userId, KinectGestures.Gestures.Psi);//添加双手向上保持1秒的姿势检测

    }
    //丢失用户时调用
    public void UserLost(long userId, int userIndex)
    {
        print("丢失用户");
    }

}

