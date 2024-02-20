function scr_npc_check_level(argument0) //gml_Script_scr_npc_check_level
{
    if ((scr_atr("LVL") > argument0))
    {
        return 0;
    }
    return 1;
}