using UnityEngine;

public class AnimationUIHandler : MonoBehaviour
{
    public Animator animator; // 參考動畫控制器
    public GameObject uiElement; // 參考要顯示的 UI 元素

    void Start()
    {
        // 確保 UI 元素在開始時隱藏
        uiElement.SetActive(false);
    }

    public void PlayAnimation()
    {
        // 播放動畫
        animator.SetTrigger("PlayAnimation"); // 用你的觸發器名稱替換
    }

    // 這個方法應在動畫結束時被調用
    public void OnAnimationComplete()
    {
        // 顯示 UI 元素
        uiElement.SetActive(true);
    }
}