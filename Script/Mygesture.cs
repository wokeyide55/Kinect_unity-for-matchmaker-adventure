using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Mygesture : MonoBehaviour, KinectGestures.GestureListenerInterface
{
    private �����A �����ӵ�;
    public int playerIndex = 0;
    private void Start()
    {
        // ���û����A�еķ���
        �����ӵ� = FindObjectOfType<�����A>();
    }
    //����ȡ��ʱ����
    public bool GestureCancelled(long userId, int userIndex, KinectGestures.Gestures gesture, KinectInterop.JointType joint)
    {
        return true;
    }
    //�������ʱ����
    public bool GestureCompleted(long userId, int userIndex, KinectGestures.Gestures gesture, KinectInterop.JointType joint, Vector3 screenPos)
    {
        if (userIndex != playerIndex)
            return false;
        if (gesture == KinectGestures.Gestures.Push)//�ж������ɵ�������˫�����ϵ�����
        {
            print("��⵽˫������");
            // ��⵽˫�����Ͼ͵���fire����

            if (�����ӵ�.score > 0)
            {
                �����ӵ�.fire(userIndex);
                �����ӵ�.score--;
                �����ӵ�.scoreText.text = "�ӵ�����" + �����ӵ�.score;  //���·���
            }
        }
        return true;
    }
    //��������ʱ����
    public void GestureInProgress(long userId, int userIndex, KinectGestures.Gestures gesture, float progress, KinectInterop.JointType joint, Vector3 screenPos)
    {
    }
    //��⵽�û�ʱ����
    public void UserDetected(long userId, int userIndex)
    {
        if (userIndex != playerIndex)
            return;
        print("��⵽�û�");
        KinectManager manager = KinectManager.Instance;//��ʼ��KinectManager����
        manager.DetectGesture(userId, KinectGestures.Gestures.Psi);//���˫�����ϱ���1������Ƽ��

    }
    //��ʧ�û�ʱ����
    public void UserLost(long userId, int userIndex)
    {
        print("��ʧ�û�");
    }

}

