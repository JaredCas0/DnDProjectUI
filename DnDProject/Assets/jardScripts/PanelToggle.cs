using UnityEngine;
using UnityEngine.UI;

public class PanelToggle : MonoBehaviour
{
    public GameObject panelToToggle; // Reference to the panel to toggle
    public RectTransform minimizedPosition; // Reference to the minimized position of the panel
    public RectTransform maximizedPosition; // Reference to the maximized position of the panel
    public RectTransform minimizeButton; // Reference to the minimize button's RectTransform
    public Image minimizeIcon; // Reference to the icon on the minimize button
    private bool isPanelActive = true; // Flag to track if the panel is active
    private Vector2 originalButtonPosition; // Original position of the minimize button
    private Quaternion originalButtonRotation; // Original rotation of the minimize button

    private void Start()
    {
        originalButtonPosition = minimizeButton.anchoredPosition; // Store the original position of the minimize button
        originalButtonRotation = minimizeButton.localRotation; // Store the original rotation of the minimize button
    }

    public void TogglePanel()
    {
        isPanelActive = !isPanelActive; // Toggle the flag

        if (isPanelActive)
        {
            panelToToggle.SetActive(true); // Activate the panel
            panelToToggle.GetComponent<RectTransform>().anchoredPosition = maximizedPosition.anchoredPosition; // Set the panel to the maximized position
            minimizeButton.anchoredPosition = originalButtonPosition; // Reset the minimize button to its original position
            minimizeIcon.rectTransform.localRotation = originalButtonRotation; // Reset the rotation of the minimize button icon
        }
        else
        {
            panelToToggle.SetActive(false); // Deactivate the panel
            panelToToggle.GetComponent<RectTransform>().anchoredPosition = minimizedPosition.anchoredPosition; // Set the panel to the minimized position
            minimizeButton.anchoredPosition += new Vector2(0, -320); // Move the minimize button lower
            minimizeIcon.rectTransform.localRotation = Quaternion.Euler(0, 0, 180); // Flip the rotation of the minimize button icon upside down
        }
    }

}
