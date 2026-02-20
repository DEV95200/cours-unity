using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int currentlifePoints;

    [SerializeField]
    private int maxLifePoints;

    [SerializeField]
    private TextMeshProUGUI currentLifePointsText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        currentlifePoints = maxLifePoints;
        currentlifePoints = Mathf.Clamp(currentlifePoints, 0, maxLifePoints);
        currentLifePointsText.SetText(currentlifePoints.ToString());
    }

    // Update is called once per frame
    public void TakeDamage(int damage = 1)

    {
        {
            // Mathf.Clamp permet de limiter la valeur entre deux bornes
            currentlifePoints = Mathf.Clamp(currentlifePoints - damage, 0, maxLifePoints);

            if (currentlifePoints == 0)
            {
                Debug.Log("Game over");
            }
        }
    }
}


