using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowData : MonoBehaviour
{
    public void showStats()
    {
        Debug.Log("Str: " + MainManager.Instance.player.GetStrength());
        Debug.Log("dex: " + MainManager.Instance.player.GetDexterity());
        Debug.Log("wis: " + MainManager.Instance.player.GetWisdom());
        Debug.Log("con: " + MainManager.Instance.player.GetConstitution());
        Debug.Log("int: " + MainManager.Instance.player.GetIntelligence());
        Debug.Log("cha: " + MainManager.Instance.player.GetCharisma());
        Debug.Log("Level: " + MainManager.Instance.player.GetLevel());
        Debug.Log("HP: " + MainManager.Instance.player.GetCurrentHp());
        Debug.Log("AC: " + MainManager.Instance.player.GetArmorClass());
        Debug.Log("initiative: " + MainManager.Instance.player.GetInitiative());
        Debug.Log("speed: " + MainManager.Instance.player.GetMaxSpeed());

    }
}
