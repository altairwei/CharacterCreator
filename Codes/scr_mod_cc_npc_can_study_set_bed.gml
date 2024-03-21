function scr_mod_cc_npc_can_study_set_bed()
{
    if (!scr_npc_check_gold(1000))
        return 0;

    with (o_skill_set_bed_ico)
    {
        if (!is_open)
        {
            return 1;
        }
    }
    return 0;
}
