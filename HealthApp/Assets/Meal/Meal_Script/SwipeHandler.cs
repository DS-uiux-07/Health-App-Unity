using UnityEngine;
using UnityEngine.EventSystems; // 필수

// IDragHandler가 추가되었습니다! (이게 있어야 작동함)
public class SwipeHandler : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [Header("연결할 화면들")]
    public GameObject currentScreen; // 현재 화면
    public GameObject leftTargetScreen;  // 왼쪽으로 밀면 나올 화면
    public GameObject rightTargetScreen; // 오른쪽으로 밀면 나올 화면

    private float startX;

    public void OnBeginDrag(PointerEventData eventData)
    {
        startX = eventData.position.x;
        Debug.Log("드래그 시작!"); // 테스트용 로그
    }

    // ★ 중요: 내용은 없어도 이 함수가 있어야 드래그로 인정됩니다!
    public void OnDrag(PointerEventData eventData)
    {
        // 공란 (기능 없음)
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        float endX = eventData.position.x;
        float difference = endX - startX;

        Debug.Log("드래그 끝! 차이: " + difference);

        // 차이가 50 이상이면 화면 전환
        if (difference < -50 && leftTargetScreen != null)
        {
            currentScreen.SetActive(false);
            leftTargetScreen.SetActive(true);
        }
        else if (difference > 50 && rightTargetScreen != null)
        {
            currentScreen.SetActive(false);
            rightTargetScreen.SetActive(true);
        }
    }
}