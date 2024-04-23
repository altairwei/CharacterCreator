function scr_mod_cc_npc_can_study_branch_trainer(argument0)
{
    if (!variable_global_exists(argument0)) return 0;
    _tier = variable_global_get(argument0)

    var _type = ds_map_find_value(global._cc_skill_map_type, argument0)
    if (__is_undefined(_type) || (ds_list_find_value(global.skill_tokens, _type) >= 2))
        return 0;
    if ((_tier != -4))
        return scr_skill_branch_can_study(_tier);
}
