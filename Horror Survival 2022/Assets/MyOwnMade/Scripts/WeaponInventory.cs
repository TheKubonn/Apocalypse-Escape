using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInventory : MonoBehaviour
{
    public Sprite[] bigIcons;
    public Image bigIcon;
    public string[] titles;
    public Text title;
    public string[] descriptions;
    public Text description;
    public Button[] weaponButtons;

    private int chosenWeaponNumber;
    private AudioSource audioPlayer;
    public AudioClip click, select;
    
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        
        bigIcon.sprite = bigIcons[0];
        title.text = titles[0];
        description.text = descriptions[0];
    }

    void OnEnable()
    {
        for (int i = 0; i < weaponButtons.Length; i++)
        {
            if (SaveScript.weaponsPickedUp[i] == false)
            {
                weaponButtons[i].image.color = new Color(1, 1, 1, 0.06f);
                weaponButtons[i].image.raycastTarget = false;
            }
            if (SaveScript.weaponsPickedUp[i])
            {
                weaponButtons[i].image.color = new Color(1, 1, 1, 1);
                weaponButtons[i].image.raycastTarget = true;
            }
        }
    }
    
    void Update()
    {
        
    }

    public void ChooseWeapon(int weaponNumber)
    {
        bigIcon.sprite = bigIcons[weaponNumber];
        title.text = titles[weaponNumber];
        description.text = descriptions[weaponNumber];
        audioPlayer.clip = click;
        audioPlayer.Play();
        chosenWeaponNumber = weaponNumber;
    }

    public void AssignWeapon()
    {
        SaveScript.weaponID = chosenWeaponNumber;
        audioPlayer.clip = select;
        audioPlayer.Play();
    }
}
