function scr_mod_cc_npc_not_enougth_gold_set_bed()
{
    with (o_skill_set_bed_ico)
    {
        if (!is_open && !scr_npc_check_gold(1000))
        {
            return 1;
        }
    }
    return 0;
}