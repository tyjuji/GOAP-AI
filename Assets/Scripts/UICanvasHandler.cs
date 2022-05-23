using TMPro;
using UnityEngine;

public class UICanvasHandler : MonoBehaviour
{
    TextMeshProUGUI ammoText;
    TextMeshProUGUI healthText;

    GameObject player;
    LifeHandler lifeHandler;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        //Debug.Log(player);
        lifeHandler = player.GetComponent<LifeHandler>();
        //Debug.Log(lifeHandler);

        ammoText = GameObject.Find("Ammo Text").GetComponent<TextMeshProUGUI>();
        //Debug.Log(ammoText);
        healthText = GameObject.Find("Health Text").GetComponent<TextMeshProUGUI>();

        ammoText.text = "lol";
        //Debug.Log(ammoText.text);
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }

    void UpdateText()
    {
        ammoText.text = "Ammo: " + lifeHandler.Ammo;
        healthText.text = "Health: " + lifeHandler.Health;
    }
}
