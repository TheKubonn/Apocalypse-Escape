using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsInventory : MonoBehaviour
{
    public Sprite[] bigIcons;
    public Image bigIcon;
    public string[] titles;
    public Text title;
    public string[] descriptions;
    public Text description;
    public Button[] itemButtons;

    private int chosenItemNumber;
    private AudioSource audioPlayer;
    public AudioClip click, select;
    
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        
        bigIcon.sprite = bigIcons[0];
        title.text = titles[0];
        description.text = descriptions[0];
    }
    
    void Update()
    {
        
    }
    
    public void ChooseItem(int itemNumber)
    {
        bigIcon.sprite = bigIcons[itemNumber];
        title.text = titles[itemNumber];
        description.text = descriptions[itemNumber];
        audioPlayer.clip = click;
        audioPlayer.Play();
        chosenItemNumber = itemNumber;
    }
}
