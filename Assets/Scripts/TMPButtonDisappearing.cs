using UnityEngine;
using UnityEngine.UI;

public class TMPButtonDisappearing : MonoBehaviour
{
    private Button testButton;

    private void Start()
    {
        // Get a reference to the Button component attached to the "TestButton" GameObject
        testButton = GameObject.Find("TestButton").GetComponent<Button>();

        // Attach the desired function to the button's click event
        testButton.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        // Disable the button's GameObject
        testButton.gameObject.SetActive(false);
    }
}
