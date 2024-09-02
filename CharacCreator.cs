// Copyright (C) 2024 Rémy Cases
// See LICENSE file for extended copyright information.
// This file is part of the repository CharacCreator from https://github.com/remyCases/CharacterCreator.

using ModShardLauncher;
using ModShardLauncher.Mods;
using UndertaleModLib.Models;

namespace CharacCreator;
public class CharacCreator : Mod
{
    public override string Author => "zizani, Altair & Pong";
    public override string Name => "Character Creator";
    public override string Description => "Create the character you always wanted to play !";
    public override string Version => "2.2.0";
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
ds_map_add(global._cc_skill_map_type, ""druidism_tier1"", 1)

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

        // localization
        CharacCreator_Localization.PatchDialogs();
        CharacCreator_Localization.PatchNames();

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
