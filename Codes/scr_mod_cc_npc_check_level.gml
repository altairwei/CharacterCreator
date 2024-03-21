function scr_mod_cc_npc_check_level(argument0)
{
    if ((scr_atr("LVL") > argument0))
    {
        return 0;
    }
    return 1;
}