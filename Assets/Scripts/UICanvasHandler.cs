using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICanvasHandler : MonoBehaviour
{
    TextMeshProUGUI ammoText;
    TextMeshProUGUI healthText;

    GameObject player;
    LifeHandler lifeHandler;
    Image shield;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        lifeHandler = player.GetComponent<LifeHandler>();

        ammoText = GameObject.Find("Ammo Text").GetComponent<TextMeshProUGUI>();
        healthText = GameObject.Find("Health Text").GetComponent<TextMeshProUGUI>();
        shield = GameObject.Find("Shield").GetComponent<Image>();

        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        if (lifeHandler.ShieldAvailable)
        {
            shield.enabled = true;
        }
        else
        {
            shield.enabled = false;
        }
        ammoText.text = "Ammo: " + lifeHandler.Ammo;
        healthText.text = "Health: " + lifeHandler.Health;
    }
}
