using UnityEngine;

public class ExitButtonHandler : MonoBehaviour
{
    public void OnExitButtonClicked()
    {
        GameManager.Instance.ExitToZEP();
    }
}
