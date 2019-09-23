using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    public Vector2 newMaxPosition;
    public Vector2 newMinPosition;
    public Vector3 playerChange;
    public bool needText;
    public string placeName;
    public Text placeText;

    private CameraMovement cam;

    private void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            cam.minPosition = newMinPosition;
            cam.maxPosition = newMaxPosition;

            other.transform.position += playerChange;

            if(needText)
            {
                StartCoroutine(PlaceNameCo());
            }
        }
    }

    private IEnumerator PlaceNameCo()
    {
        placeText.text = placeName;
        placeText.gameObject.SetActive(true);

        yield return new WaitForSeconds(4f);
        placeText.gameObject.SetActive(false);
    }
}
