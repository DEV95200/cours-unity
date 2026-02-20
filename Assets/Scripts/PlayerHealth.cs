using UnityEngine;
using TMPro;
using NUnit.Framework;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int currentlifePoints;

    [SerializeField]
    private int maxLifePoints;

    [SerializeField]
    private TextMeshProUGUI currentLifePointsText;

    [SerializeField]
    private bool inVulnerable = false;

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
        if (inVulnerable)
        {
            return;
        }
        inVulnerable = true;
        StartCoroutine(InvulnerableDuration());

        // Mathf.Clamp permet de limiter la valeur entre deux bornes
        currentlifePoints = Mathf.Clamp(currentlifePoints - damage, 0, maxLifePoints);
        currentLifePointsText.SetText(currentlifePoints.ToString());

        if (currentlifePoints == 0)
        {
            Debug.Log("Game over");
        }
    }

    IEnumerator InvulnerableDuration()
    {
        float duration = 5f;

        yield return new WaitForSeconds(duration);

        inVulnerable = false;
    }
}