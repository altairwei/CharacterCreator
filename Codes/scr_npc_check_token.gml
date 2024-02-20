function scr_npc_check_token() //gml_Script_scr_npc_check_token
{
    if (!variable_global_exists(global.skill_tokens))
    {
        if (((global.skill_tokens[0] & global.skill_tokens[1]) >= 2))
        {
            return 0;
        }
    }
    return 1;
}