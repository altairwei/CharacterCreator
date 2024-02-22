function scr_npc_check_combat() //gml_Script_scr_npc_check_combat
{
    if (!variable_global_exists("skill_tokens"))
    {
        return 0;
    }

    if (__is_undefined(global.skill_tokens))
    {
        return 0;
    }

    if ((ds_list_find_value(global.skill_tokens, 0) >= 2))
    {
        return 0;
    }
    
    return 1;
}