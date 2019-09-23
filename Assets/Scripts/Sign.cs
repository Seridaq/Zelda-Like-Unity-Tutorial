using UnityEngine.UI;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool isPlayerInRange;

    private PlayerControls controls;

    protected void Awake()
    {
        controls = new PlayerControls();
    }

    protected void OnEnable()
    {
        controls.Player.Enable();
    }

    protected void OnDisable()
    {
        controls.Player.Disable();
    }

    private void Update()
    {
        if (!isPlayerInRange)
            return;

        if (controls.Player.Activate.triggered)
        {
            dialogBox.SetActive((dialogBox.activeInHierarchy != true) ? true : false);
            dialogText.text = dialog;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}