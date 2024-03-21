function scr_mod_cc_npc_check_utility()
{
    if (!variable_global_exists("skill_tokens"))
    {
        return 0;
    }

    if (__is_undefined(global.skill_tokens))
    {
        return 0;
    }

    if ((ds_list_find_value(global.skill_tokens, 1) >= 2))
    {
        return 0;
    }

    return 1;
}
