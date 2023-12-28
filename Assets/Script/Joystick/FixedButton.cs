using UnityEngine;
using UnityEngine.EventSystems;

public class FixedButton : MonoBehaviour,IPointerClickHandler
{
    public PlayerMovement player;

    public void SetPlayer(PlayerMovement player1)
    {
        player = player1;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }
}
