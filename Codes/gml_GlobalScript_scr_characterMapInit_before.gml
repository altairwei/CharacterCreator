global.skill_tokens = ds_map_find_value(global.saveDataMap, "skill_tokens")
if (__is_undefined(global.skill_tokens))
{
    global.skill_tokens = ds_list_create();
    ds_list_add(global.skill_tokens, 2);
    ds_list_add(global.skill_tokens, 2);
    ds_map_add_list(global.saveDataMap, "skill_tokens", global.skill_tokens)
}