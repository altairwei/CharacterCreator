// Copyright (C) 2024 Rémy Cases
// See LICENSE file for extended copyright information.
// This file is part of the repository CharacCreator from .

using ModShardLauncher;
using ModShardLauncher.Mods;
using UndertaleModLib.Models;
using UndertaleModTool;
using System.Linq;

namespace CharacCreator;
public class CharacCreator : Mod
{
    public override string Author => "zizani";
    public override string Name => "Character Creator";
    public override string Description => "Create the character you ever wanted to play !";
    public override string Version => "v2.0.0";
    public override string TargetVersion => "0.8.2.10";

    public override void PatchMod()
    {
        Msl.AddCreditDisclaimerRoom(Name, Author);
        
        // find and store all skill trees
        Msl.LoadGML("gml_Object_o_dataLoader_Other_10")
            .MatchFrom("scr_skill_tier_init()")
            .InsertBelow(@"global._cc_skill_map_type = ds_map_create();
ds_map_add(global._cc_skill_map_type, ""swords_tier1"", 0)
ds_map_add(global._cc_skill_map_type, ""axes_tier1"", 0)
ds_map_add(global._cc_skill_map_type, ""maces_tier1"", 0)
ds_map_add(global._cc_skill_map_type, ""daggers_tier1"", 0)
ds_map_add(global._cc_skill_map_type, ""bows_tier1"", 0)
ds_map_add(global._cc_skill_map_type, ""polearms_tier1"", 0)
ds_map_add(global._cc_skill_map_type, ""swords2h_tier1"", 0)
ds_map_add(global._cc_skill_map_type, ""greataxes_tier1"", 0)
ds_map_add(global._cc_skill_map_type, ""greatmaces_tier1"", 0)
ds_map_add(global._cc_skill_map_type, ""shields_tier1"", 0)
ds_map_add(global._cc_skill_map_type, ""staves_tier1"", 0)
ds_map_add(global._cc_skill_map_type, ""pyromancy_tier1"", 0)
ds_map_add(global._cc_skill_map_type, ""geomancy_tier1"", 0)
ds_map_add(global._cc_skill_map_type, ""electromancy_tier1"", 0)
ds_map_add(global._cc_skill_map_type, ""athletics_tier1"", 1)
ds_map_add(global._cc_skill_map_type, ""combat_tier1"", 1)
ds_map_add(global._cc_skill_map_type, ""dualwield_tier1"", 1)
ds_map_add(global._cc_skill_map_type, ""magic_mastery_tier1"", 1)
ds_map_add(global._cc_skill_map_type, ""armor_tier1"", 1)
ds_map_add(global._cc_skill_map_type, ""necromancy_tier1"", 1)

var _cc_name_array = ds_map_keys_to_array(global._cc_skill_map_type);
var _cc_name_array_length = array_length(_cc_name_array);
var _cc_skillstier1_list = ds_list_create();

for (var _i = 0; _i < _cc_name_array_length; _i++)
{
if (variable_global_exists(_cc_name_array[_i]))
{
    ds_list_add(_cc_skillstier1_list, _cc_name_array[_i]);
}
}

var _cc_skillstier1_list_size = ds_list_size(_cc_skillstier1_list);
global._cc_skillstier1_array = array_create(_cc_skillstier1_list_size);
for (var _i = 0; _i < _cc_skillstier1_list_size; _i++)
{
global._cc_skillstier1_array[_i] = ds_list_find_value(_cc_skillstier1_list, _i);
}
ds_list_destroy(_cc_skillstier1_list);
")
            .Save();

        // add some dialog lines
        Msl.InjectTableDialogLocalization(
            new LocalizationSentence(
                id: "_mod_cc_greetings",
                sentence: "Hey, rookie! Need something?"),
            new LocalizationSentence(
                id: "_mod_cc_greeting_free_skill",
                sentence: "Who are you?"),
            new LocalizationSentence(
                id: "_mod_cc_greeting_teach_combat",
                sentence: "Can you teach me about combat?"),
            new LocalizationSentence(
                id: "_mod_cc_greeting_respec",
                sentence: "I want to do things differently (respec option)."),
            new LocalizationSentence(
                id: "_mod_cc_respec_asking_for_money",
                sentence: "This is a pricey request !"),
            new LocalizationSentence(
                id: "_mod_cc_greeting_end",
                sentence: "No thanks!"),
            new LocalizationSentence(
                id: "_mod_cc_training",
                sentence: "Sure! I'm quite experienced in the field of Weaponry and Utility skills, to say the least. I also have some knowledge of Sorcery magic. Since I owe Verren a favor, I will teach you a few skills. However, I won't teach you all of them. You can choose two skills from either Weaponry or Sorcery, and two from Utility. Which ones would you like to learn?"),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry",
                sentence: "Weaponry."),
            new LocalizationSentence(
                id: "_mod_cc_training_sorcery",
                sentence: "Sorcery."),
            new LocalizationSentence(
                id: "_mod_cc_training_utility",
                sentence: "Utility."),
            new LocalizationSentence(
                id: "_mod_cc_training_end",
                sentence: "Maybe next time!"),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_choice",
                sentence: "Straight into action, eh?"),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_sword",
                sentence: "Learn about Swords"),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_axe",
                sentence: "Learn about Axes"),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_mace",
                sentence: "Learn about Maces"),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_dagger",
                sentence: "Learn about Daggers"),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_spear",
                sentence: "Learn about Spears"),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_staff",
                sentence: "Learn about Staves"),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_thsword",
                sentence: "Learn about Two-Handed Swords"),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_thaxe",
                sentence: "Learn about Two-Handed Axes"),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_thmace",
                sentence: "Learn about Two-Handed Maces"),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_shield",
                sentence: "Learn about Shields"),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_bow",
                sentence: "Learn about Bows"),
            new LocalizationSentence(
                id: "_mod_cc_training_sorcery_choice",
                sentence: "Magic, huh?"),
            new LocalizationSentence(
                id: "_mod_cc_training_sorcery_pyro",
                sentence: "Learn about Pyromancy"),
            new LocalizationSentence(
                id: "_mod_cc_training_sorcery_geo",
                sentence: "Learn about Geomancy"),
            new LocalizationSentence(
                id: "_mod_cc_training_sorcery_eletro",
                sentence: "Learn about Electromancy"),
            new LocalizationSentence(
                id: "_mod_cc_training_utility_choice",
                sentence: "Cunning, aren't we?"),
            new LocalizationSentence(
                id: "_mod_cc_training_utility_athletics",
                sentence: "Learn about Athletics"),
            new LocalizationSentence(
                id: "_mod_cc_training_utility_warfare",
                sentence: "Learn about Warfare"),
            new LocalizationSentence(
                id: "_mod_cc_training_utility_dualwelding",
                sentence: "Learn about Dual Wielding"),
            new LocalizationSentence(
                id: "_mod_cc_training_utility_armored",
                sentence: "Learn about Armored Combat"),
            new LocalizationSentence(
                id: "_mod_cc_training_utility_mm",
                sentence: "Learn about Magic Mastery"),
            new LocalizationSentence(
                id: "_mod_cc_training_utility_necromancy",
                sentence: "Learn about Occultism"),
            new LocalizationSentence(
                id: "_mod_cc_greeting_free_skill_lore",
                sentence: "Me? Just a retired mercenary with decades of experience under my belt. Due to an injury, I can no longer work as one. Now spend my days teaching greenhorns how to survive in the wilderness and triumph on the battlefield. I can teach you how to survive in the wilderness as well, but not for free of course!"),
            new LocalizationSentence(
                id: "_mod_cc_greeting_free_skill_accept",
                sentence: "Teach me how to survive in the wilderness. ~y~[1000 crowns]~/~"),
            new LocalizationSentence(
                id: "_mod_cc_greeting_free_skill_end",
                sentence: "Maybe next time!"),
            new LocalizationSentence(
                id: "_mod_cc_greeting_free_skill_tutorial",
                sentence: "First of all, you will need a knife or any sharp weapon to harvest the pelt and meat. And if you're lucky, you'll also get a hunting trophy. Just remember to cook the meat at a campfire to avoid food poisoning. You could also make a bedroll out of the pelts, some rope, and straw."),
            new LocalizationSentence(
                id: "_mod_cc_greeting_free_skill_thank",
                sentence: "Thank you!"),
            new LocalizationSentence(
                id: "_mod_cc_greeting_free_skill_no_enougth_gold",
                sentence: "*I should come back with more money*"),
            new LocalizationSentence(
                id: "_mod_cc_respec_paying",
                sentence: "I don't care how much it costs. ~y~[1000 crowns]~/~"),
            new LocalizationSentence(
                id: "_mod_cc_respec_ending",
                sentence: "Nevermind."),
            new LocalizationSentence(
                id: "_mod_cc_respec",
                sentence: "Here you are !")
        ); 

        // change current characters
        Msl.LoadGML("gml_Object_o_dataLoader_Other_10")
            .MatchBelow("scr_classCreate", 5)
            .ReplaceBy(ModFiles, "gml_Object_o_dataLoader_Other_10.gml")
            .Save();

        // add more AP to compensate
        Msl.LoadGML("gml_GlobalScript_scr_characterMapInit")
            .MatchFrom("ds_map_add(global.characterDataMap, \"SP\", 2)")
            .InsertBelow("ds_map_replace(global.characterDataMap, \"AP\", ds_map_find_value(global.characterDataMap, \"AP\") + 3)") // add 3 SP at start (AP ig is SP in code)
            .Save(); // save it back
            
        // add new globals for the player
        Msl.LoadGML("gml_GlobalScript_scr_characterMapInit")
            .MatchFrom("global.characterDataMap =")
            .InsertBelow(ModFiles, "gml_GlobalScript_scr_characterMapInit_before.gml")
            .MatchFrom("\"Willpower25\"")
            .InsertBelow(ModFiles, "gml_GlobalScript_scr_characterMapInit_after.gml")
            .Save();
        
        // utility functions
        string[] functionNames = {
            "scr_mod_cc_npc_can_study_branch_trainer",
            "scr_mod_cc_npc_can_study_set_bed",
            "scr_mod_cc_npc_not_enougth_gold_set_bed",
            "scr_mod_cc_npc_check_combat",
            "scr_mod_cc_npc_check_token",
            "scr_mod_cc_npc_check_utility",
            "scr_mod_cc_skill_branch_study_dialogue_trainer",
            "scr_mod_cc_unlock_set_bed",
            "scr_mod_cc_reset_skills"
        };

        foreach(string functionName in functionNames)
        {
            if (DataLoader.data.Code.FirstOrDefault(t => t.Name.Content == functionName) == null)
            {
                Msl.AddFunction(ModFiles.GetCode(functionName + ".gml"), functionName);
            }
        }

        // add trainer npc
        UndertaleGameObject npcTrainer = Msl.AddObject(
            name:"o_npc_trainer",
            spriteName:"s_npc_merc_inn_fight",
            parentName:"o_npc_baker",
            isVisible:true,
            isAwake:true,
            collisionShapeFlags:CollisionShapeFlags.Circle
        );
        
        npcTrainer.ApplyEvent(ModFiles,
            new MslEvent("npc_trainer_create_0.gml", EventType.Create, 0)
        );

        // get the tavern room
        UndertaleRoom room = Msl.GetRoom("r_taverninside1floor");
        UndertaleRoom.Layer LayerTarget = Msl.GetLayer(room, UndertaleRoom.LayerType.Instances, "target");
        UndertaleRoom.Layer LayerNPC = Msl.GetLayer(room, UndertaleRoom.LayerType.Instances, "NPC");

        // add a target marker
        UndertaleRoom.GameObject gameObjectTargetTrainer = room.AddGameObject(
            LayerTarget, 
            "o_NPC_target", 
            Msl.AddCode(ModFiles.GetCode("taverninside_101_create.gml"), "gml_RoomCC_r_taverninside1floor_101_Create"),
            x:368,
            y:312
        );
        
        // save the target id and inject it in the creation code of the trainer
        uint tagertID = gameObjectTargetTrainer.InstanceID;
        string codeTrainer = string.Format(@ModFiles.GetCode("taverninside_100_create.gml"), tagertID);

        // create the trainer
        room.AddGameObject(
            LayerNPC, 
            "o_npc_trainer", 
            Msl.AddCode(codeTrainer, "gml_RoomCC_r_taverninside1floor_100_Create"),
            x:376,
            y:328
        );
    }
}
