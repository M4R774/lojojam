﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Missions
{
    public static List<Mission> missions = new List<Mission>();
    
    private static System.Random rng = new System.Random();
    private static int mission_counter = 0;
    
    static Missions()
    {
        Mission mission = new Mission(
            "Rumble In The Jungle",
            "Our sources tell disturbing news from the deep jungle. Foreign intelligence agencies have sold guns to the enemies of our allies. Intercept the next shipment!",
            4,
            "Our agent tracked down and disarmed the arms dealers! Agent's $BEST_ITEM proved to be especially helpful. Local people were conflicted but they had no say in the matter.",
            "Few months later, lone traveller brings news that a foreigner had disappeared in bushes after a firefight. Only their $WORST_ITEM had been found...",
            "jungle3",
            new Dictionary<string, int>
            {
                {"Helmet", 2},
                {"Goggles", 0},
                {"Night Vision Goggles", 0},
                {"Radio", 1},
                {"Boots", 1},
                {"Snowshoes", -3},
                {"Camo pants", 2},
                {"Scope", 2},
                {"Poison Pill", -3},
                {"Salt Shaker", 0},
                {"Skis", -3},
                {"Pistol", 3},
                {"Shovel", 1},
                {"Sunhat", 3},
                {"Map", 2}
            }
        );
        missions.Add(mission);

        mission = new Mission(
            "Freight fright",
            "A giant container ship has spun out of control and blocked Suez Canal, a major passage of global trade. We need to do something! Although... Why does this keep happening?!",
            2,
            "After excruciating hours of digging sand with a tiny excavator, our agent, and his trusty $BEST_ITEM unblocked the ship and secured the billion-dollar merchandise aboard.",
            "Our agent was caught trying to bribe an official with their $WORST_ITEM and was promptly escorted out of the target country. Disappointing, clearly more anti-corruption training is needed for our personnel.",
            "desert",
            new Dictionary<string, int>
            {
                {"Helmet", 1},
                {"Goggles", 1},
                {"Night Vision Goggles", 1},
                {"Radio", 1},
                {"Boots", 2},
                {"Snowshoes", -2},
                {"Camo pants", 1},
                {"Scope", -1},
                {"Poison Pill", -2},
                {"Salt Shaker", 2},
                {"Skis", -2},
                {"Pistol", -1},
                {"Shovel", 3},
                {"Sunhat", 3},
                {"Map", 0}
            }
        );
        missions.Add(mission);

        mission = new Mission(
            "Everybody, get down!",
            "Large, international bank has bought a penetration-test from our agency into its main building in London City. Horrible idea, but they got deep pockets.",
            3,
            "Video footage from security cameras showed our agent marching to the desk and showing the clerk their $BEST_ITEM. Distraught teller filled agent’s briefcase with cash quickly. When shown the footage, the bank’s chair members were perplexed...",
            "A thorough research done, a careful plan and calm execution with no shots fired. A successful bank robbery! Or would have been if it were not for agent's $WORST_ITEM...",
            "bank",
            new Dictionary<string, int>
            {
                {"Helmet",     1},
                {"Goggles",             1},
                {"Night Vision Goggles", 1},
                {"Radio",               1},
                {"Boots",        0},
                {"Snowshoes",          -1},
                {"Camo pants",         -2},
                {"Scope",        2},
                {"Poison Pill",        -1},
                {"Salt Shaker",         1},
                {"Skis", -2},
                {"Pistol", 3},
                {"Shovel", 1},
                {"Sunhat", 0},
                {"Map", -1}
            }
        );
        missions.Add(mission);

        mission = new Mission(
            "Mayday, Mayday!",
            "A friendly agency lost their experimental flying aircraft over Siberian tundra. The aircraft must be found and recovered before hostile actors can get their hands on it!",
            4,
            "Travelling by helicopter, snowmobile and finally foot, our agent found the weird, crashed saucer. Steaming grey goo surrounded the vehicle but had completely disappeared by the time our agent had dragged the UFO-remains to nearest friendly base. Agent's $BEST_ITEM served its purpose.",
            "Horrible snowstorms had gathered over the crash zone. We quickly lost signal with our agent. Later in the spring, the UFO-remains were gone and agent's $WORST_ITEM was found hanging on top of a stick.",
            "siberia",
            new Dictionary<string, int>
            {
                {"Helmet",    -3},
                {"Goggles",             2},
                {"Night Vision Goggles", 2},
                {"Radio",               2},
                {"Boots",        3},
                {"Snowshoes",           3},
                {"Camo pants",          1},
                {"Scope",        1},
                {"Poison Pill",         0},
                {"Salt Shaker",         0},
                {"Skis",  3},
                {"Pistol", -1},
                {"Shovel", 2},
                {"Sunhat", -3},
                {"Map", 3}
            }
        );
        missions.Add(mission);

        mission = new Mission(
            "Miners deep in trouble!",
            "A large cobalt mine in Kongo has collapsed! Several miners are trapped (and rare metal production halted). Search and rescue!",
            2,
            "Great success! Our agent managed to squeeze in through the rubble and delivered supplies until the cave was cleared. Agent's $BEST_ITEM was surprisingly helpful.",
            "Oh no! Our agent got in too late because of failed $BEST_ITEM and the miners had already suffocated. However, this was only a minor inconvenience and electric car battery industry soon recovered.",
            "jungle3",
            new Dictionary<string, int>
            {
                {"Helmet",     0},
                {"Goggles",             3},
                {"Night Vision Goggles", 3},
                {"Radio",               3},
                {"Boots",        1},
                {"Snowshoes",          -3},
                {"Camo pants",          0},
                {"Scope",       -1},
                {"Poison Pill",        -3},
                {"Salt Shaker",        -1},
                {"Skis", -3},
                {"Pistol", -2},
                {"Shovel", 3},
                {"Sunhat", 2},
                {"Map", 1}
            }
        );
        missions.Add(mission);

        mission = new Mission(
            "Ailment in the Archives",
            "Our clerks discovered lately that old files have gone missing in the archives. Is it something ominous or just messy bookkeeping? Better investigate.",
            1,
            "It was tedious work, but our agent managed to connect the dots and uncovered a grand scheme of corruption: Janitor had sold access to the archive and high-profile targets had took advantage of it. Armed with $BEST_ITEM, our agent took out the dirty laundry.",
            "After tracking down a path of shred paper up and down the narrow corridors, you find a bored cat atop an empty shelf. It found agent's $BEST_ITEM interesting enough, however, and you managed to lure it back up.",
            "bank",
            new Dictionary<string, int>
            {
                {"Helmet",     0},
                {"Goggles",             0},
                {"Night Vision Goggles", 0},
                {"Radio",               0},
                {"Boots",        1},
                {"Snowshoes",           0},
                {"Camo pants",          0},
                {"Scope",        0},
                {"Poison Pill",        -3},
                {"Salt Shaker",         2},
                {"Skis",  0},
                {"Pistol", 0},
                {"Shovel", -1},
                {"Sunhat", 0},
                {"Map", 0}
            }
        );
        missions.Add(mission);

        mission = new Mission(
            "Presidential threat",
            "Disturbing call from the Whitehouse: The president is under a great threat, they say. Kidnapped?! Godspeed, agent.",
            1,
            "Turns out Mr. President had mixed up which button calls for international aid and which calls for Diet-Coke. Our agent and their $BEST_ITEM appeared sharp, however, and Mr. President was impressed.",
            "Turns out Mr. President had mixed up which button calls for international aid and which calls for Diet-Coke. Our agent and their $WORST_ITEM boarded the next flight home with a soda in hand.",
            "whitehouse",
            new Dictionary<string, int>
            {
                {"Helmet", 1},
                {"Goggles", 1},
                {"Night Vision Goggles", 2},
                {"Radio", 1},
                {"Boots", 1},
                {"Snowshoes", -3},
                {"Camo pants", 1},
                {"Scope", 0},
                {"Poison Pill", -3},
                {"Salt Shaker", -3},
                {"Skis", -3},
                {"Pistol", 2},
                {"Shovel", -3},
                {"Sunhat", -1},
                {"Map", 0}
            }
        );
        missions.Add(mission);

        mission = new Mission(
            "Presidential threat",
            "Disturbing call from the Whitehouse: The president is under a great threat, they say. Kidnapped?! Godspeed, agent.",
            5,
            "With $BEST_ITEM our agent managed to rescue Mr. President from the hands of the terrorist. God bless us all! ",
            "$WORST_ITEM failed our agent and Mr. President is dead. The Vice President will be helding a press conference for the public shortly. Dark times for our Empire...",
            "whitehouse",
            new Dictionary<string, int>
            {
                {"Helmet", 3},
                {"Goggles", 1},
                {"Night Vision Goggles", 1},
                {"Radio", 2},
                {"Boots", 2},
                {"Snowshoes", -3},
                {"Camo pants", 1},
                {"Scope", 2},
                {"Poison Pill", -3},
                {"Salt Shaker", 0},
                {"Skis", -3},
                {"Pistol", 3},
                {"Shovel", 1},
                {"Sunhat", -1},
                {"Map", 0}
            }
        );
        missions.Add(mission);

        mission = new Mission(
            "Suppress the Opposition",
            "New political party is threatening the cohesion of our Empire. \"Take care\" of the opposition leader to maintain the status quo. She was last seen in Siberia. You will departure at zero-seven-hundred hours. ",
            5,
            "The opposition leader could not escape from our agents $BEST_ITEM and was easily dealt with. Peace has returned to the Empire. ",
            "The tenuous $WORST_ITEM did not help our agent this time and the opposition leader escaped. The integrity of our Empire is compromised. ",
            "siberia",
            new Dictionary<string, int>
            {
                {"Helmet", -1},
                {"Goggles", 0},
                {"Night Vision Goggles", 2},
                {"Radio", -3},
                {"Boots", 1},
                {"Snowshoes", 3},
                {"Camo pants", 0},
                {"Scope", 3},
                {"Poison Pill", 3},
                {"Salt Shaker", 0},
                {"Skis", 3},
                {"Pistol", 3},
                {"Shovel", -3},
                {"Sunhat", -3},
                {"Map", 1}
            }
        );
        missions.Add(mission);

        mission = new Mission(
            "Tempest in a teacup",
            "Last month a microfilm containing plans for hi-tech submarine tracking system was stolen from our research facilities. Our intelligence reports that the microfilm is being sold at black market in Cairo, Egypt. Go there and retrieve the microfilm!",
            5,
            "Our agent was not the only one hunting the microfilm. A skirmish broke out with foreign agents, but luckily our agent was well prepared and with his $BEST_ITEM the situation stayed under control in this difficult environment.",
            "Our agent was not the only one hunting the microfilm. An especially attractive foreign spy seduced our agent and stole the microfilm. $WORST_ITEM did not help our agents broken heart. ",
            "desert",
            new Dictionary<string, int>
            {
                {"Helmet", 1},
                {"Goggles", 2},
                {"Night Vision Goggles", 2},
                {"Radio", 3},
                {"Boots", 1},
                {"Snowshoes", -3},
                {"Camo pants", 0},
                {"Scope", 0},
                {"Poison Pill", -3},
                {"Salt Shaker", -3},
                {"Skis", -3},
                {"Pistol", 2},
                {"Shovel", -1},
                {"Sunhat", 3},
                {"Map", 1}
            }
        );
        missions.Add(mission);

        missions.Shuffle();
    }

    public static Mission GetRandomMission()
    {
        return missions[Random.Range(0, missions.Count)];
    }

    public static Mission GetNextMission()
    {
        mission_counter++;
        if (mission_counter >= missions.Count)
        {
            mission_counter = 0;
        }
        return missions[mission_counter];
    }

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
