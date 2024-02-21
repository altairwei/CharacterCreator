event_inherited()
depth_add = 0
idle_spr = spr
name = "Old Mercenary"
id_name = "npc_trainer"
occupation = "trainer"
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
skill_branch_array = [global.swords_tier1, global.axes_tier1, global.maces_tier1, global.daggers_tier1, global.polearms_tier1, global.staves_tier1, global.swords2h_tier1, global.greataxes_tier1, global.greatmaces_tier1, global.shields_tier1, global.bows_tier1, global.athletics_tier1, global.combat_tier1, global.dualwield_tier1, global.armor_tier1, global.magic_mastery_tier1, global.pyromancy_tier1, global.geomancy_tier1, global.electromancy_tier1]
dialog_id = de2_dialog_open("trainer.de2")
topic = "topic0"
gold_k = irandom_range(100, 300)
