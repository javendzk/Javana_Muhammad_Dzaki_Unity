using UnityEngine;

public class Starter : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GameManager.Instance != null)
            {
                foreach (Transform child in GameManager.Instance.transform)
                {
                    if (child.GetComponent<Canvas>() != null || child.GetComponent<UnityEngine.UI.Image>() != null)
                    {
                        child.gameObject.SetActive(true);
                    }
                }
                GameManager.Instance.LevelManager.LoadScene("ChooseWeapon");
            }
        }
    }
}