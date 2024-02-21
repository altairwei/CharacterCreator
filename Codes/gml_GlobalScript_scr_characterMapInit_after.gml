global.skill_tokens = ds_list_create();
ds_list_add(global.skill_tokens, 0);
ds_list_add(global.skill_tokens, 0);
ds_map_add_list(global.saveDataMap, "skill_tokens", global.skill_tokens)