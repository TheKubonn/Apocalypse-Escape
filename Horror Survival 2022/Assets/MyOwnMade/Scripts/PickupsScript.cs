using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupsScript : MonoBehaviour
{
    private RaycastHit hit;
    private int objID = 0;
    private AudioSource audioPlayer;

    public float pickupDisplayDistance = 3f;
    public LayerMask excludeLayers;
    public GameObject pickupPanel;
    public Image mainImage;
    public Sprite[] weaponIcons;
    public Text mainTitle;
    public string[] weaponTitles;
    
    void Start()
    {
        pickupPanel.SetActive(false);
        audioPlayer = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if (Physics.SphereCast(transform.position, 0.5f, transform.forward, out hit, 30, ~excludeLayers))
        {
            if (Vector3.Distance(transform.position, hit.transform.position) < pickupDisplayDistance)
            {
                if (hit.transform.gameObject.CompareTag("weapon"))
                {
                    // this is how to cast the enum to the int to recognize the weapon number
                    objID = (int)hit.transform.gameObject.GetComponent<WeaponType>().chooseWeapon;
                    pickupPanel.SetActive(true);
                    mainImage.sprite = weaponIcons[objID];
                    mainTitle.text = weaponTitles[objID];

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        SaveScript.weaponAmounts[objID]++;
                        Destroy(hit.transform.gameObject, 0.2f);
                        audioPlayer.Play();
                    }
                }
            }
            else
            {
                pickupPanel.SetActive(false);
            }
        }
    }
}
