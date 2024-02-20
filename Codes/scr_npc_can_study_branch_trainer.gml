function scr_npc_can_study_branch_trainer(argument0) //gml_Script_scr_npc_can_study_branch_trainer
{
    _tier = -4
    switch argument0
    {
        case "learn_mace_t1":
            _tier = global.maces_tier1
            break
        case "learn_sword_t1":
            _tier = global.swords_tier1
            break
        case "learn_axe_t1":
            _tier = global.axes_tier1
            break
        case "learn_dagger_t1":
            _tier = global.daggers_tier1
            break
        case "learn_ranged_t1":
            _tier = global.bows_tier1
            break
        case "learn_spear_t1":
            _tier = global.polearms_tier1
            break
        case "learn_2hsword_t1":
            _tier = global.swords2h_tier1
            break
        case "learn_2haxe_t1":
            _tier = global.greataxes_tier1
            break
        case "learn_2hmace_t1":
            _tier = global.greatmaces_tier1
            break
        case "learn_shield_t1":
            _tier = global.shields_tier1
            break
        case "learn_staff_t1":
            _tier = global.staves_tier1
            break
        case "learn_athletics_t1":
            _tier = global.athletics_tier1
            break
        case "learn_combat_t1":
            _tier = global.combat_tier1
            break
        case "learn_dual_t1":
            _tier = global.dualwield_tier1
            break
        case "learn_magic_t1":
            _tier = global.magic_mastery_tier1
            break
        case "learn_armor_t1":
            _tier = global.armor_tier1
            break
        case "learn_pyro_t1":
            _tier = global.pyromancy_tier1
            break
        case "learn_geo_t1":
            _tier = global.geomancy_tier1
            break
        case "learn_electro_t1":
            _tier = global.electromancy_tier1
            break
    }

    var _type = ds_map_find_value(global.skill_map_type, _tier)
    if (__is_undefined(_type) || (global.skill_tokens[_type] >= 2))
        return 0;
    if ((_tier != -4))
        return scr_skill_branch_can_study(_tier);
}
