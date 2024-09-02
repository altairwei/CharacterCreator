// Copyright (C) 2024 Rémy Cases
// See LICENSE file for extended copyright information.
// This file is part of the repository CharacCreator from https://github.com/remyCases/CharacterCreator.

using ModShardLauncher;
using ModShardLauncher.Mods;
using UndertaleModLib.Models;

namespace CharacCreator;
public class CharacCreator : Mod
{
    public override string Author => "zizani";
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

        // add some dialog lines
        Msl.InjectTableDialogLocalization(
            new LocalizationSentence(
                id: "_mod_cc_greetings",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Hey, rookie! Need something?"},
                    {ModLanguage.Chinese, "嘿，菜鸟！需要什么吗？"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_greeting_free_skill",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Who are you?"},
                    {ModLanguage.Chinese, "你是谁？"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_greeting_teach_combat",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Can you teach me about combat?"},
                    {ModLanguage.Chinese, "你能教我战斗技巧吗？"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_greeting_respec",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "I want to do things differently (respec option)."},
                    {ModLanguage.Chinese, "我想用不同的方式来做事（敬重选项）。"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_respec_asking_for_money",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "This is a pricey request !"},
                    {ModLanguage.Chinese, "这是一个昂贵的要求！"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_greeting_end",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "No thanks!"},
                    {ModLanguage.Chinese, "不用了，谢谢！"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Sure! I'm quite experienced in the field of Weaponry and Utility skills, to say the least. I also have some knowledge of Sorcery magic. Since I owe Verren a favor, I will teach you a few skills. However, I won't teach you all of them. You can choose two skills from either Weaponry or Sorcery, and two from Utility. Which ones would you like to learn?"},
                    {ModLanguage.Chinese, "当然！至少可以说，我在兵器和常规技能方面很有经验。我还会一些咒术魔法。既然我欠维伦一个人情，我就教你一些技能。不过，我不会全部教你。你可以从兵器或咒法中选择两个技能，从常规技能中选择两个。你想学哪个？"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Weaponry."},
                    {ModLanguage.Chinese, "兵器。"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_sorcery",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Sorcery."},
                    {ModLanguage.Chinese, "咒法。"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_utility",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Utility."},
                    {ModLanguage.Chinese, "常规。"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_end",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Maybe next time!"},
                    {ModLanguage.Chinese, "下次再说吧！"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_choice",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Straight into action, eh?"},
                    {ModLanguage.Chinese, "立即行动，嗯？"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_sword",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Swords"},
                    {ModLanguage.Chinese, "学习单手刀剑"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_axe",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Axes"},
                    {ModLanguage.Chinese, "学习单手斧"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_mace",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Maces"},
                    {ModLanguage.Chinese, "学习单手锤棒"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_dagger",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Daggers"},
                    {ModLanguage.Chinese, "学习匕首"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_spear",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Spears"},
                    {ModLanguage.Chinese, "学习长柄刃器"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_staff",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Staves"},
                    {ModLanguage.Chinese, "学习长杖"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_thsword",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Two-Handed Swords"},
                    {ModLanguage.Chinese, "学习双手刀剑"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_thaxe",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Two-Handed Axes"},
                    {ModLanguage.Chinese, "学习双手斧"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_thmace",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Two-Handed Maces"},
                    {ModLanguage.Chinese, "学习双手锤棒"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_shield",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Shields"},
                    {ModLanguage.Chinese, "学习盾技"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_bow",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Ranged Weapons"},
                    {ModLanguage.Chinese, "学习远程兵器"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_sorcery_choice",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Magic, huh?"},
                    {ModLanguage.Chinese, "魔法，是吧？"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_sorcery_pyro",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Pyromancy"},
                    {ModLanguage.Chinese, "学习炎术"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_sorcery_geo",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Geomancy"},
                    {ModLanguage.Chinese, "学习地术"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_sorcery_eletro",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Electromancy"},
                    {ModLanguage.Chinese, "学习电术"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_utility_choice",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Cunning, aren't we?"},
                    {ModLanguage.Chinese, "我们很机灵吧？"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_utility_athletics",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Athletics"},
                    {ModLanguage.Chinese, "学习肢体活动"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_utility_warfare",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Warfare"},
                    {ModLanguage.Chinese, "学习搏斗"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_utility_dualwelding",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Dual Wielding"},
                    {ModLanguage.Chinese, "学习兵器双持"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_utility_armored",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Armored Combat"},
                    {ModLanguage.Chinese, "学习着甲"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_utility_mm",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Magic Mastery"},
                    {ModLanguage.Chinese, "学习驭法"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_utility_necromancy",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Occultism"},
                    {ModLanguage.Chinese, "学习死灵术"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_utility_druidism",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Druidism"},
                    {ModLanguage.Chinese, "学习德鲁伊"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_greeting_free_skill_lore",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Me? Just a retired mercenary with decades of experience under my belt. Due to an injury, I can no longer work as one. Now spend my days teaching greenhorns how to survive in the wilderness and triumph on the battlefield. I can teach you how to survive in the wilderness as well, but not for free of course!"},
                    {ModLanguage.Chinese, "我？我只是一个有着几十年经验的退休雇佣兵。由于受伤，我不能再当雇佣兵了。现在，我每天都在教新手如何在荒野中生存，如何在战场上取得胜利。我也可以教你如何在荒野中生存，当然不是免费的！"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_greeting_free_skill_accept",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Teach me how to survive in the wilderness. ~y~[1000 crowns]~/~"},
                    {ModLanguage.Chinese, "教我如何在荒野中生存。 ~y~[1000冠]~/~"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_greeting_free_skill_end",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Maybe next time!"},
                    {ModLanguage.Chinese, "下次再说吧！"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_greeting_free_skill_tutorial",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "First of all, you will need a knife or any sharp weapon to harvest the pelt and meat. And if you're lucky, you'll also get a hunting trophy. Just remember to cook the meat at a campfire to avoid food poisoning. You could also make a bedroll out of the pelts, some rope, and straw."},
                    {ModLanguage.Chinese, "首先，您需要一把刀或任何锋利的武器来收获皮毛和肉。如果幸运的话，你还能得到一个狩猎战利品。只是要记得在篝火上烤肉，以免食物中毒。您还可以用皮毛、绳子和稻草做一个床铺。"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_greeting_free_skill_thank",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Thank you!"},
                    {ModLanguage.Chinese, "谢谢！"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_greeting_free_skill_no_enougth_gold",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "*I should come back with more money*"},
                    {ModLanguage.Chinese, "*我应该带更多的钱回来*"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_respec_paying",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "I don't care how much it costs. ~y~[1000 crowns]~/~"},
                    {ModLanguage.Chinese, "我不在乎花多少钱。 ~y~[1000冠]~/~"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_respec_ending",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Nevermind."},
                    {ModLanguage.Chinese, "别在意。"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_respec",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Here you are !"},
                    {ModLanguage.Chinese, "给你！"}
                }
            )
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
