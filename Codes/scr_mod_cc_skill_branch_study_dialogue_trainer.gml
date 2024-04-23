function scr_mod_cc_skill_branch_study_dialogue_trainer(argument0)
{
    if (!variable_global_exists(argument0)) return 0;
    _skill = variable_global_get(argument0)
    scr_skill_branch_study(_skill)
    scr_gold_write_off(0)
    scr_characterGoldSpend("spentDialogues", 0)
    _type = ds_map_find_value(global._cc_skill_map_type, argument0)
    ds_list_set(global.skill_tokens, _type, ds_list_find_value(global.skill_tokens, _type) + 1)
}