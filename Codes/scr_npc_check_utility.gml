function scr_npc_check_utility() //gml_Script_scr_npc_check_utility
{
    if (!variable_global_exists(global.skill_tokens))
    {
        if ((global.skill_tokens[1] >= 2))
        {
            return 0;
        }
    }
    return 1;
}
