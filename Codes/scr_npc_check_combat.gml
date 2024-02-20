function scr_npc_check_combat() //gml_Script_scr_npc_check_combat
{
    if (!variable_global_exists(global.skill_tokens))
    {
        if ((global.skill_tokens[0] >= 2))
        {
            return 0;
        }
    }
    return 1;
}