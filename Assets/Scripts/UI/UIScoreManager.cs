using UnityEngine;
using UnityEngine.UI;

public class UIScoreManager : MonoBehaviour
{
    [SerializeField] Text scoreNumber;
    [SerializeField] Text itemNumber;


    void Start()
    {
        UpdateNumber(0, 0);
        LevelManager.Instance.OnScoreChanged += UpdateNumber;
    }

    void UpdateNumber(int scoreNumber, int itemNumber)
    {
        this.scoreNumber.text = scoreNumber.ToString();
        this.itemNumber.text = itemNumber.ToString();
    }

    void OnDestroy()
    {
        LevelManager.Instance.OnScoreChanged -= UpdateNumber;
    }
}
