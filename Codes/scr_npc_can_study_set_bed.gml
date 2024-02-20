function scr_npc_can_study_set_bed()
{
    with (o_skill_set_bed_ico)
    {
        if (!is_open)
        {
            return 1;
        }
    }
    return 0;
}
