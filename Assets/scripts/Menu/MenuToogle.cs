using UnityEngine;

public class MenuToogle : MonoBehaviour
{

    public KeyCode toggleKey = KeyCode.Escape;
    public GameObject MidgameMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MidgameMenu.SetActive(false); // Hide the menu at the start
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(toggleKey)) // Check if the key is pressed
        {
            MidgameMenu.SetActive(!MidgameMenu.activeSelf); // Show/hide the menu
        }
    }
}
