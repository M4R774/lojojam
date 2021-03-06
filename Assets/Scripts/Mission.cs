﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission
{
    // Case file
    public string title;
    public string description;
    public int difficulty;
    public string win_result;
    public string loss_result;
    public string picture_file_name;
    public Dictionary<string, int> item_modifiers;

    // Player input
    public List<GameObject> luggage = new List<GameObject>();

    // Mission outcome
    public List<GameObject> reward_items;

    // Outcome calculation parameters
    private int max_modifier = 3;
    private int max_items = 3;
    private int max_difficulty = 5;

    public Mission(string title_parameter, 
        string description_parameter, 
        int difficulty_parameter, 
        string win_result_parameter, 
        string loss_result_parameter,
        string picture_file_name_parameter,
        Dictionary<string, int> item_modifiers_parameter) 
    {
        title = title_parameter;
        description = description_parameter;
        difficulty = difficulty_parameter;
        win_result = win_result_parameter;
        loss_result = loss_result_parameter;
        picture_file_name = picture_file_name_parameter;
        item_modifiers = item_modifiers_parameter;
    }

    
    // Mission constructor without input parameters for testing purposes
    public Mission()
    {
        title = "testi missio ilman inputtia";
        description = "Koska mission constructeria kutsuttiin ilman input parametreja, luotiin tyhjä missio testaamista varten. Tehtävän vaikeustaso on 2.";
        difficulty = 2;
        win_result = "VOITIT PELIN!";
        loss_result = "hävisit pelin :(";
        picture_file_name = "testCaseImage.png";
        item_modifiers = new Dictionary<string, int>();  // empty
    }

    public void AddItemToLuggage(GameObject item_to_be_added)
    {
        if (luggage.Count < max_items)
        {
            luggage.Add(item_to_be_added);
        }
    }

    public void RemoveItemFromLuggage(GameObject item_to_be_removed)
    {
        if (luggage.Contains(item_to_be_removed))
        {
            luggage.Remove(item_to_be_removed);
        }
    }

    public float CalculateMissionFinalOdds()
    {
        float odds = (1 - (float) difficulty / (2 * max_difficulty)) + 
            SumOfModifiers() * (float) difficulty / (2 * max_difficulty) / 
            (max_modifier * max_items);

        return odds;
    }


    public string GetBestItem()
    {
        int BestItemModifier = - max_modifier;
        string BestItemName = "Guts";

        foreach(GameObject item_object in luggage)
        {   
            Item item = item_object.GetComponent<Item>();
            string name = item.GetName();
            // Debug.Log("Item name: " + name);
            item_modifiers.TryGetValue(name, out int modifier);

            if (modifier >= BestItemModifier) {
                BestItemName = name;
                BestItemModifier = modifier;
            }

        }
        return BestItemName;
    }

    public string GetWorstItem()
    {
        int WorstItemModifier = - max_modifier;
        string WorstItemName = "Nerves";

        foreach(GameObject item_object in luggage)
        {
            Item item = item_object.GetComponent<Item>();
            string name = item.GetName();
            item_modifiers.TryGetValue(name, out int modifier);

            if (modifier >= WorstItemModifier) {
                WorstItemName = name;
                WorstItemModifier = modifier;
            }

        }
        return WorstItemName;
    }

    public string GetMissionResultText(bool didWeWin)
    {
        if (didWeWin == true) {
            return win_result.Replace("$BEST_ITEM", GetBestItem()).Replace("$WORST_ITEM", GetWorstItem());
        } else {
            return loss_result.Replace("$BEST_ITEM", GetBestItem()).Replace("$WORST_ITEM", GetWorstItem());
        }
        
    }

    public int SumOfModifiers()
    {
        int sum = 0;
        foreach(GameObject item_object in luggage)
        {
            if (item_object != null)
            {
                Item item = item_object.GetComponent<Item>();
                string name = item.GetName();
                item_modifiers.TryGetValue(name, out int modifier);
                sum += modifier;
            }
        }
        if (luggage.Count < 3)
        {
            sum -= 3 - luggage.Count;
        }

        return sum;
    }
}
