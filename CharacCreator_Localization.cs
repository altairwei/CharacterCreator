using ModShardLauncher;
using ModShardLauncher.Mods;

namespace CharacCreator;

public static class CharacCreator_Localization
{
    public static void PatchDialogs()
    {
        // add some dialog lines
        Msl.InjectTableDialogLocalization(
            new LocalizationSentence(
                id: "_mod_cc_greetings",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Hey, rookie! Need something?"},
                    {ModLanguage.Chinese, "嘿，菜鸟！需要什么吗？"},
                    {ModLanguage.Russian, "Привет, новичок! Тебе что-нибудь нужно?"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_greeting_free_skill",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Who are you?"},
                    {ModLanguage.Chinese, "你是谁？"},
                    {ModLanguage.Russian, "Кто ты?"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_greeting_teach_combat",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Can you teach me about combat?"},
                    {ModLanguage.Chinese, "你能教我战斗技巧吗？"},
                    {ModLanguage.Russian, "Можешь научить меня сражаться?"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_greeting_respec",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "I want to do things differently (respec option)."},
                    {ModLanguage.Chinese, "我想做点改变（重新分配技能点）。"},
                    {ModLanguage.Russian, "Я хочу сделать все по-другому (перераспределить способности)."}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_respec_asking_for_money",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "This is a pricey request !"},
                    {ModLanguage.Chinese, "这是一个昂贵的要求！"},
                    {ModLanguage.Russian, "Это дорогостоящий запрос!"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_greeting_end",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "No thanks!"},
                    {ModLanguage.Chinese, "不用了，谢谢！"},
                    {ModLanguage.Russian, "Нет, спасибо!"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Sure! I'm quite experienced in the field of Weaponry and Utility skills, to say the least. I also have some knowledge of Sorcery magic. Since I owe Verren a favor, I will teach you a few skills. However, I won't teach you all of them. You can choose two skills from either Weaponry or Sorcery, and two from Utility. Which ones would you like to learn?"},
                    {ModLanguage.Chinese, "当然！至少可以说，我在兵器和常规技能方面很有经验。我还会一些咒术魔法。既然我欠维伦一个人情，我就教你一些技能。不过，我不会全部教你。你可以从兵器或咒法中选择两个技能，从常规技能中选择两个。你想学哪个？"},
                    {ModLanguage.Russian, "Конечно! Я довольно опытен в области оружия и навыков. У меня также есть некоторые знания в магии. Поскольку я должен Веренну услугу, я научу тебя нескольким способностям. Однако я не буду обучать тебя всему. Ты можешь выбрать две способности из владения оружием или магии и два из навыков. Какие бы ты хотел изучить?"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Weaponry."},
                    {ModLanguage.Chinese, "兵器。"},
                    {ModLanguage.Russian, "Оружие."}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_sorcery",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Sorcery."},
                    {ModLanguage.Chinese, "咒法。"},
                    {ModLanguage.Russian, "Магия."}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_utility",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Utility."},
                    {ModLanguage.Chinese, "常规。"},
                    {ModLanguage.Russian, "Навыки."}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_end",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Maybe next time!"},
                    {ModLanguage.Chinese, "下次再说吧！"},
                    {ModLanguage.Russian, "Может быть в следующий раз!"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_choice",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Straight into action, eh?"},
                    {ModLanguage.Chinese, "立即行动，嗯？"},
                    {ModLanguage.Russian, "Прямо к делу, да?"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_sword",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Swords"},
                    {ModLanguage.Chinese, "学习单手刀剑"},
                    {ModLanguage.Russian, "Изучить владение Мечом"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_axe",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Axes"},
                    {ModLanguage.Chinese, "学习单手斧"},
                    {ModLanguage.Russian, "Изучить владение Топором"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_mace",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Maces"},
                    {ModLanguage.Chinese, "学习单手锤棒"},
                    {ModLanguage.Russian, "Изучить владение Булавой"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_dagger",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Daggers"},
                    {ModLanguage.Chinese, "学习匕首"},
                    {ModLanguage.Russian, "Изучить владение Кинжалами"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_spear",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Spears"},
                    {ModLanguage.Chinese, "学习长柄刃器"},
                    {ModLanguage.Russian, "Изучить владение Копьём"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_staff",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Staves"},
                    {ModLanguage.Chinese, "学习长杖"},
                    {ModLanguage.Russian, "Изучить владение Посохом"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_thsword",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Two-Handed Swords"},
                    {ModLanguage.Chinese, "学习双手刀剑"},
                    {ModLanguage.Russian, "Изучить владение Двуручным Мечом"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_thaxe",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Two-Handed Axes"},
                    {ModLanguage.Chinese, "学习双手斧"},
                    {ModLanguage.Russian, "Изучить владение Двуручным Топором"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_thmace",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Two-Handed Maces"},
                    {ModLanguage.Chinese, "学习双手锤棒"},
                    {ModLanguage.Russian, "Изучить владение Двуручной Буловой"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_shield",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Shields"},
                    {ModLanguage.Chinese, "学习盾技"},
                    {ModLanguage.Russian, "Изучить владение Щитом"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_weaponry_bow",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Ranged Weapons"},
                    {ModLanguage.Chinese, "学习远程兵器"},
                    {ModLanguage.Russian, "Изучить Стрельбу"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_sorcery_choice",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Magic, huh?"},
                    {ModLanguage.Chinese, "魔法，是吧？"},
                    {ModLanguage.Russian, "Магия, да?"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_sorcery_pyro",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Pyromancy"},
                    {ModLanguage.Chinese, "学习炎术"},
                    {ModLanguage.Russian, "Изучить Пироманию"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_sorcery_geo",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Geomancy"},
                    {ModLanguage.Chinese, "学习地术"},
                    {ModLanguage.Russian, "Изучить Геомантию"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_sorcery_eletro",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Electromancy"},
                    {ModLanguage.Chinese, "学习电术"},
                    {ModLanguage.Russian, "Изучить Электромантию"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_utility_choice",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Cunning, aren't we?"},
                    {ModLanguage.Chinese, "我们很机灵吧？"},
                    {ModLanguage.Russian, "Хитрый, да?"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_utility_athletics",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Athletics"},
                    {ModLanguage.Chinese, "学习肢体活动"},
                    {ModLanguage.Russian, "Изучить Атлетику"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_utility_warfare",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Warfare"},
                    {ModLanguage.Chinese, "学习搏斗"},
                    {ModLanguage.Russian, "Изучить Ведение Боя"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_utility_dualwelding",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Dual Wielding"},
                    {ModLanguage.Chinese, "学习兵器双持"},
                    {ModLanguage.Russian, "Изучить владение Парным Оружием"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_utility_armored",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Armored Combat"},
                    {ModLanguage.Chinese, "学习着甲"},
                    {ModLanguage.Russian, "Изучить навыки Ношения Брони"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_utility_mm",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Magic Mastery"},
                    {ModLanguage.Chinese, "学习驭法"},
                    {ModLanguage.Russian, "Изучить Искусство Магии"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_utility_necromancy",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Occultism"},
                    {ModLanguage.Chinese, "学习死灵术"},
                    {ModLanguage.Russian, "Изучить Оккультизм"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_training_utility_druidism",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Learn about Druidism"},
                    {ModLanguage.Chinese, "学习德鲁伊"},
                    {ModLanguage.Russian, "Изучить Друидизм"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_greeting_free_skill_lore",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Me? Just a retired mercenary with decades of experience under my belt. Due to an injury, I can no longer work as one. Now spend my days teaching greenhorns how to survive in the wilderness and triumph on the battlefield. I can teach you how to survive in the wilderness as well, but not for free of course!"},
                    {ModLanguage.Chinese, "我？我只是一个有着几十年经验的退休雇佣兵。由于受伤，我不能再当雇佣兵了。现在，我每天都在教新手如何在荒野中生存，如何在战场上取得胜利。我也可以教你如何在荒野中生存，当然不是免费的！"},
                    {ModLanguage.Russian, "Я? Просто бывший наемник с многолетним опытом. Из-за травмы я больше не могу работать наемником. Теперь я провожу свои дни, обучая новичков выживанию в дикой природе и победе на поле боя. Я могу научить тебя выживанию в дикой природе, но, конечно, не бесплатно!"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_greeting_free_skill_accept",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Teach me how to survive in the wilderness. ~y~[1000 crowns]~/~"},
                    {ModLanguage.Chinese, "教我如何在荒野中生存。 ~y~[1000冠]~/~"},
                    {ModLanguage.Russian, "Научи меня выживать в дикой природе. ~y~[1000 крон]~/~"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_greeting_free_skill_end",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Maybe next time!"},
                    {ModLanguage.Chinese, "下次再说吧！"},
                    {ModLanguage.Russian, "Может быть в следующий раз!"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_greeting_free_skill_tutorial",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "First of all, you will need a knife or any sharp weapon to harvest the pelt and meat. And if you're lucky, you'll also get a hunting trophy. Just remember to cook the meat at a campfire to avoid food poisoning. You could also make a bedroll out of the pelts, some rope, and straw."},
                    {ModLanguage.Chinese, "首先，您需要一把刀或任何锋利的武器来收获皮毛和肉。如果幸运的话，你还能得到一个狩猎战利品。只是要记得在篝火上烤肉，以免食物中毒。您还可以用皮毛、绳子和稻草做一个床铺。"},
                    {ModLanguage.Russian, "Прежде всего, вам понадобится нож или любое острое оружие, чтобы собрать шкуру и мясо. Если повезет, вы также получите трофей охоты. Не забудьте приготовить мясо на костре, чтобы избежать отравления. Вы также можете сделать спальный мешок из шкур, веревки и соломы."}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_greeting_free_skill_thank",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Thank you!"},
                    {ModLanguage.Chinese, "谢谢！"},
                    {ModLanguage.Russian, "Спасибо!"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_greeting_free_skill_no_enougth_gold",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "*I should come back with more money*"},
                    {ModLanguage.Chinese, "*我应该带更多的钱回来*"},
                    {ModLanguage.Russian, "*Мне нужно вернуться с большим количеством денег*"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_respec_paying",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "I don't care how much it costs. ~y~[1000 crowns]~/~"},
                    {ModLanguage.Chinese, "我不在乎花多少钱。 ~y~[1000冠]~/~"},
                    {ModLanguage.Russian, "Мне все равно, сколько это стоит. ~y~[1000 крон]~/~"}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_respec_ending",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Nevermind."},
                    {ModLanguage.Chinese, "别在意。"},
                    {ModLanguage.Russian, "Неважно."}
                }
            ),
            new LocalizationSentence(
                id: "_mod_cc_respec",
                sentence: new Dictionary<ModLanguage, string>() {
                    {ModLanguage.English, "Here you are !"},
                    {ModLanguage.Chinese, "给你！"},
                    {ModLanguage.Russian, "Вот, держи!"}
                }
            )
        ); 
    }
    public static void PatchNames()
    {
        Msl.InjectTableOccupationNamesLocalization(
            new LocalizationOccupationName(
                id: "_mod_cc_trainer",
                name: new Dictionary<ModLanguage, string>{
                    {ModLanguage.English, "Old Mercenary"},
                    {ModLanguage.Chinese, "老佣兵"},
                    {ModLanguage.Russian, "Старый наёмник"},
                }
            )
        );
    }
}