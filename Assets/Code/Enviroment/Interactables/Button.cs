using UnityEngine;
using UnityEngine.Events;

public class VRButton : MonoBehaviour
{
    // Reference to the visual representation of the button
    [SerializeField] private GameObject buttonVisual;

    // The amount the button should move down when pressed
    [SerializeField] private float pressDepth = 0.1f;

    // The duration of the press animation
    [SerializeField] private float pressDuration = 0.1f;

    // Event to invoke when the button is pressed
    public UnityEvent onPressed;

    // Original local position of the button visual
    private Vector3 originalPosition;

    // Flag to prevent multiple presses
    private bool isPressed = false;

    private void Start()
    {
        if (buttonVisual == null)
        {
            Debug.LogError("[VRButton] Button Visual is not assigned.");
            return;
        }

        // Store the original position of the button
        originalPosition = buttonVisual.transform.localPosition;
        Debug.Log($"[VRButton] Initialized. Original Position: {originalPosition}");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[VRButton] OnTriggerEnter called by: {other.gameObject.name} on layer {LayerMask.LayerToName(other.gameObject.layer)}");

        // Check if the collider belongs to a hand (using layer "Player")
        // Ensure that "Player" layer is correctly set up and assigned to the player's hands
        if (((1 << other.gameObject.layer) & LayerMask.GetMask("Player")) != 0)
        {
            Debug.Log($"[VRButton] Collider {other.gameObject.name} is on the 'Player' layer.");
            if (!isPressed)
            {
                Debug.Log("[VRButton] Button is not pressed. Proceeding to press the button.");
                PressButton();
            }
            else
            {
                Debug.LogWarning("[VRButton] Button is already pressed. Ignoring press.");
            }
        }
        else
        {
            Debug.LogWarning($"[VRButton] Collider {other.gameObject.name} is NOT on the 'Player' layer. Ignoring.");
        }
    }

    private void PressButton()
    {
        isPressed = true;
        Debug.Log("[VRButton] PressButton() called. Button is now pressed.");

        // Animate the button press
        StartCoroutine(AnimateButtonPress());

        // Invoke the assigned event
        Debug.Log("[VRButton] Invoking onPressed event.");
        onPressed.Invoke();
    }

    private System.Collections.IEnumerator AnimateButtonPress()
    {
        Vector3 targetPosition = originalPosition - new Vector3(0, pressDepth, 0);
        float elapsed = 0f;

        Debug.Log($"[VRButton] Starting press animation. Moving to: {targetPosition}");

        // Move down
        while (elapsed < pressDuration)
        {
            buttonVisual.transform.localPosition = Vector3.Lerp(originalPosition, targetPosition, elapsed / pressDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        buttonVisual.transform.localPosition = targetPosition;
        Debug.Log("[VRButton] Press animation complete. Button is pressed down.");

        // Optional: Move back up after a short delay
        yield return new WaitForSeconds(0.2f);
        elapsed = 0f;

        Debug.Log("[VRButton] Starting release animation. Moving back to original position.");

        while (elapsed < pressDuration)
        {
            buttonVisual.transform.localPosition = Vector3.Lerp(targetPosition, originalPosition, elapsed / pressDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        buttonVisual.transform.localPosition = originalPosition;
        Debug.Log("[VRButton] Release animation complete. Button is back to original position.");

        isPressed = false;
        Debug.Log("[VRButton] Button is now ready to be pressed again.");
    }

    // Optional: Handle OnTriggerExit if needed
    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"[VRButton] OnTriggerExit called by: {other.gameObject.name} on layer {LayerMask.LayerToName(other.gameObject.layer)}");
        // Implement additional logic here if necessary
    }
}
