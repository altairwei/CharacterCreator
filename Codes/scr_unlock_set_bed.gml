function scr_unlock_set_bed()
{
    with (o_skill_set_bed_ico)
    {
        is_lock = 0
        is_open = 1
        with (instance_create_depth(x, y, (depth - 1), o_skill_ico_open_effect))
        {
            owner = other.id
            sprite_index = other.sprite_index
        }
        event_user(8)
        event_user(6)
    }
    var list = ds_list_find_value(o_skill_fast_panel.skills, o_skill_fast_panel.set_number)
    var num = ds_list_find_index(list, -4)
    if (num >= 0)
    {
        with (scr_create_skill_on_start(o_skill_set_bed, num))
        {
            onStart_create = 1
            event_user(8)
        }
    }
    else
    {
        var _set_number = (o_skill_fast_panel.set_number + 1)
        repeat (o_skill_fast_panel.max_number - 1)
        {
            with (o_skill_fast_panel)
            {
                if (_set_number > (max_number - 1))
                    _set_number = 0
            }
            list = ds_list_find_value(o_skill_fast_panel.skills, _set_number)
            num = ds_list_find_index(list, -4)
            if (num >= 0)
            {
                ds_list_replace(list, num, 4088)
                break
            }
            else
                _set_number++
        }
    }
    var _sprite = o_skill_set_bed.sprite_index
    var _name = o_skill_set_bed.name
    var _offsetLeft = ((global.cameraWidth / 2) - 109)
    var _offsetTop = ((global.cameraHeight / 2) - 140)
    with (scr_guiCreateSimple(global.guiBaseContainerVisible, o_skill_unlock_alert))
    {
        textUnlock = "Learnt:"
        sprite = _sprite
        text = _name
        checkDialog = 0
        alarm[1] = 5
        timeDelay = (room_speed + alarm[1])
        scr_guiLayoutOffsetUpdate(id, _offsetLeft, _offsetTop)
    }
    audio_play_sound(snd_dialog_reward_window_st_1, 4, false)
    scr_gold_write_off(100)
    scr_characterGoldSpend("spentDialogues", 100)
}