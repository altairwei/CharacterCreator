event_inherited()
depth_add = 0
idle_spr = spr
id_name = "npc_trainer"
occupation = "_mod_cc_trainer"
name = ds_map_find_value(global.npc_info, occupation)
subtype = "townee"
avatar = 5067
ds_list_clear(myfloor_list)
ds_list_add(myfloor_list, "T1", "T1", "T1", "T1")
myfloor_counter = "T1"
myfloor = "T1"
time_period_morning = do_animation
time_period_day = do_animation
time_period_evening = do_animation
time_period_night = do_animation
scr_set_hl()
show_town = 0
idle_state = 0
rumors = 0
chat = 1
skill_branch_array = global._cc_skillstier1_array
dialog_id = de2_dialog_open("trainer.de2")
topic = "topic0"
gold_k = irandom_range(100, 300)
