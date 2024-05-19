function scr_mod_cc_reset_skills()
{
    var _learned_skills = 0;
    var len = ds_list_size(global._cc_skills_list);
    for(var _i = 0; _i < len; _i++)
    {
        var _skill = ds_list_find_value(global._cc_skills_list, _i);
        if (_skill.is_open)
        {
            _learned_skills += 1;
        }
    }
    scr_msl_log(string(_learned_skills));
    scr_atr_incr("SP", _learned_skills);

    with (o_skill_category)
    {
        is_lock = 1
        var _size = array_length(skill)
        for (var i = 0; i < _size; i++)
        {
            with (skill[i])
            {
                if (!is_enemy_skill)
                {
                    is_lock = 1
                    is_open = 0
                }

            }
        }
    }

    scr_classInit("tiers")
    scr_classInit("perks")
    scr_tier_open("Basic Skills")
    scr_tier_free(o_skill_category_basic_skills)
    scr_skill_open_from_array1d(global.survival_tier1)
    with (o_skill_set_campfire_ico)
        is_open = 1

    with (o_skillConnectionsRender)
        event_user(0)

    var STR = scr_atr("STR")
    var AGL = scr_atr("AGL")
    var PRC = scr_atr("PRC")
    var Vitality = scr_atr("Vitality")
    var WIL = scr_atr("WIL")

    var _ap_spent = STR - 10 + AGL - 10 + PRC - 10 + WIL - 10 + Vitality - 10;
    scr_atr_incr("AP", _ap_spent);
    scr_msl_log(string(_ap_spent));

    scr_atr_set("STR", 10);
    scr_atr_set("AGL", 10);
    scr_atr_set("PRC", 10);
    scr_atr_set("Vitality", 10);
    scr_atr_set("WIL", 10);

    scr_atr_calc(o_player);
}