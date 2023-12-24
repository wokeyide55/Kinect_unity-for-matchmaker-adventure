using UnityEngine;
using TMPro;

public class 火柴人B : MonoBehaviour
{
    public int userIndex; //选择角色
    public TextMeshProUGUI scoreText; // 用于显示分数的TextMeshProUGUI组件
    public int score = 10; // 记录子弹数量的变量
    public GameObject 子弹A;
    public GameObject 子弹B;
    public Transform 发射点;
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (userIndex == 0)
        {
            if (other.CompareTag("objA")) // A对应的物体的标签为"objA"
            {
                Destroy(other.gameObject); // 碰撞到的物体消失
                score++; // 分数加一
                scoreText.text = "子弹数量" + score; // 更新分数显示
            }
        }
        if (userIndex == 1)
        {
            if (other.CompareTag("objB")) // B对应的物体的标签为"objB"
            {
                Destroy(other.gameObject); // 碰撞到的物体消失
                score++; // 分数加一
                scoreText.text = "收集数量" + score; // 更新分数显示
            }
        }
    }

    public void fireB(int userIndex)
    {
        GameObject 子弹对象 = Instantiate(子弹B, 发射点.position, 发射点.rotation);
        Rigidbody2D rb = 子弹对象.GetComponent<Rigidbody2D>();
        rb.velocity = 发射点.right * 10f; //子弹速度

        //检测碰撞
        子弹对象.AddComponent<projectController>();
    }

    // Update is called once per frame

}
