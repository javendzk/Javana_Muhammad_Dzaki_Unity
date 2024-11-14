using UnityEngine;

public class Starter : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.LevelManager.LoadScene("ChooseWeapon");
            }
        }
    }
}