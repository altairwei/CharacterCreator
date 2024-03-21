function scr_mod_cc_skill_branch_study_dialogue_trainer(argument0)
{
    _pos = argument0
    _skill = owner.skill_branch_array[_pos]
    scr_skill_branch_study(_skill)
    scr_gold_write_off(0)
    scr_characterGoldSpend("spentDialogues", 0)
    _type = ds_map_find_value(global.skill_map_type, _skill)
    ds_list_set(global.skill_tokens, _type, ds_list_find_value(global.skill_tokens, _type) + 1)
}