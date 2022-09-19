using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ClickRestartMonoB : MonoBehaviour,IPointerClickHandler
{
    public EcsWorld World;

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("SampleScene");
    }
}
