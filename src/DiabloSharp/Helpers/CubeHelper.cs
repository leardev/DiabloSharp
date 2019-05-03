using System.Collections.Generic;
using DiabloSharp.Models;

namespace DiabloSharp.Helpers
{
    internal static class CubeHelper
    {
        private static readonly HashSet<ItemId> _cubeItemIds;

        static CubeHelper()
        {
            _cubeItemIds = new HashSet<ItemId>
            {
                new ItemId("dovu-energy-trap", "Unique_Amulet_107_x1"),
                new ItemId("countess-julias-cameo", "Unique_Amulet_103_x1"),
                new ItemId("maras-kaleidoscope", "Unique_Amulet_015_x1"),
                new ItemId("overwhelming-desire", "Unique_Amulet_106_x1"),
                new ItemId("haunted-visions", "P6_Unique_Amulet_02"),
                new ItemId("rakoffs-glass-of-life", "Unique_Amulet_108_x1"),
                new ItemId("the-star-of-azkaranth", "Unique_Amulet_006_x1"),
                new ItemId("talisman-of-aranoch", "Unique_Amulet_012_x1"),
                new ItemId("the-ess-of-johan", "Unique_Amulet_104_x1"),
                new ItemId("haunt-of-vaxo", "Unique_Amulet_101_x1"),
                new ItemId("the-johnstone", "P6_Unique_Amulet_01"),
                new ItemId("wisdom-of-kalan", "P6_Unique_Amulet_03"),
                new ItemId("moonlight-ward", "Unique_Amulet_003_x1"),
                new ItemId("golden-gorget-of-leoric", "Unique_Amulet_105_x1"),
                new ItemId("kymbos-gold", "Unique_Amulet_002_p1"),
                new ItemId("xephirian-amulet", "Unique_Amulet_004_x1"),
                new ItemId("genzaniku", "Unique_Axe_1H_003_x1"),
                new ItemId("sky-splitter", "Unique_Axe_1H_005_p2"),
                new ItemId("the-burning-axe-of-sankis", "Unique_Axe_1H_007_x1"),
                new ItemId("hack", "Unique_Axe_1H_103_x1"),
                new ItemId("the-butchers-sickle", "Unique_Axe_1H_006_x1"),
                new ItemId("mordullus-promise", "P4_Unique_Axe_1H_102"),
                new ItemId("butchers-carver", "Unique_Axe_2H_001_x1"),
                new ItemId("cinder-switch", "Unique_Axe_2H_010_x1"),
                new ItemId("burst-of-wrath", "Unique_Axe_2H_103_x1"),
                new ItemId("lamentation", "Unique_BarbBelt_005_p1"),
                new ItemId("dread-iron", "P2_Unique_BarbBelt_001"),
                new ItemId("the-undisputed-champion", "P2_Unique_BarbBelt_006"),
                new ItemId("chilaniks-chain", "Unique_BarbBelt_101_x1"),
                new ItemId("pride-of-cassius", "Unique_BarbBelt_002_x1"),
                new ItemId("girdle-of-giants", "P61_Unique_BarbBelt_EQ"),
                new ItemId("fire-walkers", "Unique_Boots_007_p2"),
                new ItemId("illusory-boots", "Unique_Boots_103_x1"),
                new ItemId("fire-walkers", "Unique_Boots_007_x1"),
                new ItemId("lut-socks", "Unique_Boots_009_x1"),
                new ItemId("boots-of-disregard", "Unique_Boots_102_x1"),
                new ItemId("irontoe-mudsputters", "Unique_Boots_104_x1"),
                new ItemId("the-crudest-boots", "Unique_Boots_010_x1"),
                new ItemId("rivera-dancers", "P4_Unique_Boots_001"),
                new ItemId("nilfurs-boast", "P61_Unique_Boots_01"),
                new ItemId("ice-climbers", "Unique_Boots_008_x1"),
                new ItemId("the-crudest-boots", "P1_Unique_Boots_010"),
                new ItemId("bryners-journey", "P6_Necro_Unique_Boots_22"),
                new ItemId("steuarts-greaves", "P6_Necro_Unique_Boots_21"),
                new ItemId("steuarts-greaves", "P61_Necro_Unique_Boots_21"),
                new ItemId("yangs-recurve", "P61_Unique_Bow_104_x1"),
                new ItemId("the-ravens-wing", "Unique_Bow_008_x1"),
                new ItemId("leonine-bow-of-hashir", "Unique_Bow_103_x1"),
                new ItemId("cluckeye", "Unique_Bow_015_x1"),
                new ItemId("odysseys-end", "Unique_Bow_102_x1"),
                new ItemId("kridershot", "Unique_Bow_101_x1"),
                new ItemId("vambraces-of-sescheron", "P4_Unique_Bracer_106"),
                new ItemId("coils-of-the-first-spider", "P3_Unique_Bracer_107"),
                new ItemId("wraps-of-clarity", "P61_Unique_Bracer_103"),
                new ItemId("jerams-bracers", "P3_Unique_Bracer_106"),
                new ItemId("bracers-of-the-first-men", "P61_Unique_Bracer_105"),
                new ItemId("ranslors-folly", "P61_Unique_Bracer_108_x1"),
                new ItemId("gabriels-vambraces", "P3_Unique_Bracer_101"),
                new ItemId("warzechian-armguards", "Unique_Bracer_101_x1"),
                new ItemId("bindings-of-the-lesser-gods", "P4_Unique_Bracer_108"),
                new ItemId("strongarm-bracers", "Unique_Bracer_007_x1"),
                new ItemId("tragoul-coils", "P42_Unique_Bracer_SpikeTrap"),
                new ItemId("sanguinary-vambraces", "Unique_Bracer_105_x1"),
                new ItemId("drakons-lesson", "P4_Unique_Bracer_110"),
                new ItemId("gungdo-gear", "P2_Unique_Bracer_006"),
                new ItemId("nemesis-bracers", "Unique_Bracer_106_x1"),
                new ItemId("promise-of-glory", "Unique_Bracer_002_x1"),
                new ItemId("akkhans-manacles", "P4_Unique_Bracer_103"),
                new ItemId("custerian-wristguards", "Unique_Bracer_107_x1"),
                new ItemId("cesars-memento", "P61_Unique_Bracer_107"),
                new ItemId("reapers-wraps", "Unique_Bracer_103_x1"),
                new ItemId("bracers-of-destruction", "P61_Unique_Bracer_100"),
                new ItemId("ancient-parthan-defenders", "Unique_Bracer_102_x1"),
                new ItemId("pintos-pride", "P4_Unique_Bracer_105"),
                new ItemId("ashnagarrs-blood-bracer", "P4_Unique_Bracer_004"),
                new ItemId("lakumbas-ornament", "P4_Unique_Bracer_102"),
                new ItemId("spirit-guards", "P61_Unique_Bracer_109"),
                new ItemId("skulars-salvation", "P4_Unique_Bracer_101"),
                new ItemId("bracer-of-fury", "P61_Unique_Bracer_104"),
                new ItemId("the-dagger-of-darts", "P1_CeremonialDagger_norm_unique_02"),
                new ItemId("the-barber", "P5_Unique_Dagger_003_x1"),
                new ItemId("rhenho-flayer", "Unique_CeremonialDagger_102_x1"),
                new ItemId("the-spider-queens-grasp", "Unique_CeremonialDagger_004_x1"),
                new ItemId("deadly-rebirth", "Unique_CeremonialDagger_003_x1"),
                new ItemId("voos-juicer", "P4_Unique_Dagger_002"),
                new ItemId("the-gidbinn", "Unique_CeremonialDagger_002_x1"),
                new ItemId("sacred-harvester", "P1_CeremonialDagger_norm_unique_01"),
                new ItemId("last-breath", "P4_Unique_CeremonialDagger_008"),
                new ItemId("anessazi-edge", "Unique_CeremonialDagger_001_x1"),
                new ItemId("starmetal-kukri", "Unique_CeremonialDagger_101_x1"),
                new ItemId("goldskin", "Unique_Chest_001_x1"),
                new ItemId("shi-mizus-haori", "Unique_Chest_101_x1"),
                new ItemId("aquila-cuirass", "P4_Unique_Chest_012"),
                new ItemId("armor-of-the-kind-regent", "Unique_Chest_102_x1"),
                new ItemId("chaingmail", "Unique_Chest_010_x1"),
                new ItemId("heart-of-iron", "P4_Unique_Chest_018"),
                new ItemId("cindercoat", "Unique_Chest_006_x1"),
                new ItemId("bloodsong-mail", "P6_Necro_Unique_Chest_21"),
                new ItemId("requiem-cereplate", "P6_Necro_Unique_Chest_22"),
                new ItemId("the-cloak-of-the-garwulf", "Unique_Cloak_002_p1"),
                new ItemId("cloak-of-deception", "Unique_Cloak_102_x1"),
                new ItemId("beckon-sail", "Unique_Cloak_005_x1"),
                new ItemId("cape-of-the-dark-night", "Unique_Cloak_001_x1"),
                new ItemId("blackfeather", "Unique_Cloak_101_x1"),
                new ItemId("balance", "P61_Unique_CombatStaff_2H_001"),
                new ItemId("warstaff-of-general-quang", "Unique_CombatStaff_2H_102_x1"),
                new ItemId("incense-torch-of-the-grand-temple", "P61_Unique_CombatStaff_2H_003_x1"),
                new ItemId("the-flow-of-eternity", "P41_Unique_CombatStaff_2H_005"),
                new ItemId("flying-dragon", "Unique_CombatStaff_2H_009_x1"),
                new ItemId("burizado-kyanon", "Unique_XBow_011_x1"),
                new ItemId("wojahnni-assaulter", "P41_Unique_Xbow_102"),
                new ItemId("chanon-bolter", "Unique_Xbow_101_x1"),
                new ItemId("hellrack", "Unique_XBow_002_x1"),
                new ItemId("demon-machine", "Unique_XBow_001_x1"),
                new ItemId("pus-spitter", "Unique_XBow_012_x1"),
                new ItemId("manticore", "P61_Unique_XBow_001"),
                new ItemId("the-final-witness", "Unique_CruShield_107_x1"),
                new ItemId("piro-marella", "Unique_CruShield_101_x1"),
                new ItemId("guard-of-johanna", "Unique_Shield_103_x1"),
                new ItemId("hallowed-bulwark", "Unique_CruShield_103_x1"),
                new ItemId("jekangbord", "P61_Unique_CruShield_102_x1"),
                new ItemId("salvation", "Unique_CruShield_108_x1"),
                new ItemId("sublime-conviction", "Unique_CruShield_106_x1"),
                new ItemId("frydehrs-wrath", "P61_CruShield_norm_unique_01"),
                new ItemId("shield-of-fury", "P61_Unique_Shield_106_x1"),
                new ItemId("akarats-awakening", "Unique_CruShield_104_x1"),
                new ItemId("hellskull", "Unique_CruShield_105_x1"),
                new ItemId("unrelenting-phalanx", "P1_CruShield_norm_unique_02"),
                new ItemId("wizardspike", "Unique_Dagger_010_x1_210"),
                new ItemId("karleis-point", "P61_Unique_Dagger_101_x1"),
                new ItemId("eunjangdo", "Unique_Dagger_104_x1"),
                new ItemId("envious-blade", "Unique_Dagger_103_x1"),
                new ItemId("lord-greenstones-fan", "P61_Unique_Dagger_102_x1"),
                new ItemId("the-fist-of-azturrasq", "P61_Unique_Fist_009_x1"),
                new ItemId("scarbringer", "P61_Unique_Fist_013_x1"),
                new ItemId("jawbreaker", "Unique_Fist_101_x1"),
                new ItemId("fleshrake", "P41_Unique_Fist_007"),
                new ItemId("lions-claw", "P1_fistWeapon_norm_unique_01"),
                new ItemId("rabid-strike", "P43_Unique_Fist_003_x1"),
                new ItemId("vengeful-wind", "P4_fistWeapon_norm_unique_02"),
                new ItemId("kyoshiros-blade", "P4_Unique_Fist_102"),
                new ItemId("crystal-fist", "P41_Unique_Fist_008"),
                new ItemId("gyrfalcons-foote", "P61_Unique_Flail_1H_105_x1"),
                new ItemId("justinians-mercy", "Unique_Flail_1H_102_x1"),
                new ItemId("swiftmount", "Unique_Flail_1H_103_x1"),
                new ItemId("johannas-argument", "P1_flail1H_norm_unique_01"),
                new ItemId("darklight", "P42_Unique_Flail_1H_106_x1"),
                new ItemId("golden-scourge", "Unique_Flail_1H_101_x1"),
                new ItemId("kassars-retribution", "Unique_Flail_1H_104_x1"),
                new ItemId("inviolable-faith", "Unique_Flail_1H_107_x1"),
                new ItemId("golden-flense", "P61_Unique_Flail_2H_104"),
                new ItemId("the-mortal-drama", "Unique_Flail_2H_101_x1"),
                new ItemId("baleful-remnant", "Unique_Flail_2H_102_x1"),
                new ItemId("flail-of-the-ascended", "P4_Unique_Flail_2H_002"),
                new ItemId("akkhans-addendum", "P4_Unique_Flail_2H_001"),
                new ItemId("akkhans-leniency", "P4_flail2H_norm_unique_01"),
                new ItemId("fate-of-the-fell", "P61_Unique_Flail_2H_103_x1"),
                new ItemId("binding-of-the-lost", "P61_Unique_Belt_03"),
                new ItemId("fazulas-improbable-chain", "P4_Unique_Belt_07"),
                new ItemId("belt-of-the-trove", "P2_Unique_Belt_008"),
                new ItemId("sebors-nightmare", "Unique_Belt_108_p2"),
                new ItemId("string-of-ears", "P4_Unique_Belt_03"),
                new ItemId("sash-of-knives", "Unique_Belt_102_p2"),
                new ItemId("omnislash", "P2_Unique_Belt_04"),
                new ItemId("khassetts-cord-of-righteousness", "P42_Crusader_FoH_Belt"),
                new ItemId("sacred-harness", "P3_Unique_Belt_01"),
                new ItemId("haunting-girdle", "P2_Unique_Belt_03"),
                new ItemId("zoeys-secret", "P4_Unique_Belt_04"),
                new ItemId("hergbrashs-binding", "P4_Unique_Belt_06"),
                new ItemId("angel-hair-braid", "Unique_Belt_003_x1"),
                new ItemId("sebors-nightmare", "Unique_Belt_108_x1"),
                new ItemId("hwoj-wrap", "Unique_Belt_107_x1"),
                new ItemId("insatiable-belt", "Unique_Belt_103_x1"),
                new ItemId("omryns-chain", "P2_Unique_Belt_06"),
                new ItemId("bakuli-jungle-wraps", "P61_Unique_Belt_007"),
                new ItemId("dayntees-binding", "P61_Unique_Belt_01"),
                new ItemId("hellcat-waistguard", "P43_Unique_Belt_005_x1"),
                new ItemId("the-shame-of-delsere", "P4_Unique_Belt_02"),
                new ItemId("cord-of-the-sherma", "Unique_Belt_104_p2"),
                new ItemId("saffron-wrap", "Unique_Belt_001_x1"),
                new ItemId("string-of-ears", "Unique_Belt_008_x1"),
                new ItemId("harrington-waistguard", "Unique_Belt_105_x1"),
                new ItemId("hellcat-waistguard", "Unique_Belt_005_x1"),
                new ItemId("saffron-wrap", "P43_Unique_Belt_001_x1"),
                new ItemId("crashing-rain", "P2_Unique_Belt_01"),
                new ItemId("jangs-envelopment", "Unique_Belt_106_x1"),
                new ItemId("chain-of-shadows", "P4_Unique_Belt_01"),
                new ItemId("goldwrap", "Unique_Belt_010_x1"),
                new ItemId("cord-of-the-sherma", "Unique_Belt_104_x1"),
                new ItemId("thundergods-vigor", "Unique_BarbBelt_003_x1"),
                new ItemId("blessed-of-haull", "P2_Unique_Belt_05"),
                new ItemId("belt-of-transcendence", "P2_Unique_Belt_02"),
                new ItemId("kyoshiros-soul", "P4_Unique_Belt_05"),
                new ItemId("angel-hair-braid", "Unique_Belt_003_p1"),
                new ItemId("hunters-wrath", "P3_Unique_Belt_005"),
                new ItemId("razor-strop", "Unique_Belt_101_x1"),
                new ItemId("gladiator-gauntlets", "Unique_Gloves_011_x1"),
                new ItemId("st-archews-gage", "Unique_Gloves_101_p2"),
                new ItemId("frostburn", "P41_Unique_Gloves_002"),
                new ItemId("gloves-of-worship", "Unique_Gloves_103_x1"),
                new ItemId("tasker-and-theo", "Unique_Gloves_003_x1"),
                new ItemId("magefist", "P41_Unique_Gloves_014"),
                new ItemId("grasps-of-essence", "P6_Necro_Unique_Gloves_22"),
                new ItemId("moribund-gauntlets", "P6_Necro_Unique_Gloves_21"),
                new ItemId("liannas-wings", "P4_Unique_HandXBow_01"),
                new ItemId("fortress-ballista", "P4_Unique_HandXBow_02"),
                new ItemId("helltrapper", "Unique_HandXBow_102_x1"),
                new ItemId("the-demons-demise", "P42_handXbow_norm_unique_03"),
                new ItemId("dawn", "P4_Unique_HandXBow_001"),
                new ItemId("kmar-tenclip", "Unique_HandXBow_101_x1"),
                new ItemId("vallas-bequest", "P43_Unique_HandXBow_005"),
                new ItemId("calamity", "Unique_HandXBow_012_x1"),
                new ItemId("deathseers-cowl", "Unique_Helm_102_x1"),
                new ItemId("leorics-crown", "Unique_Helm_002_p1"),
                new ItemId("warhelm-of-kassar", "P4_Unique_Helm_102"),
                new ItemId("prides-fall", "Unique_Helm_103_x1"),
                new ItemId("skull-of-resonance", "Unique_Helm_004_x1"),
                new ItemId("visage-of-gunes", "P4_Unique_Helm_103"),
                new ItemId("broken-crown", "P2_Unique_Helm_001"),
                new ItemId("andariels-visage", "Unique_Helm_003_p2"),
                new ItemId("mask-of-scarlet-death", "P6_Necro_Unique_Helm_21"),
                new ItemId("fates-vow", "P61_Necro_Unique_Helm_22"),
                new ItemId("swamp-land-waders", "P41_Unique_Pants_001"),
                new ItemId("depth-diggers", "Unique_Pants_006_p1"),
                new ItemId("deaths-bargain", "Unique_Pants_102_x1"),
                new ItemId("hexing-pants-of-mr-yan", "Unique_Pants_101_x1"),
                new ItemId("pox-faulds", "Unique_Pants_007_p2"),
                new ItemId("hammer-jammers", "P4_Unique_Pants_002"),
                new ItemId("defiler-cuisses", "P61_Necro_Unique_Pants_22"),
                new ItemId("golemskin-breeches", "P61_Necro_Unique_Pants_21"),
                new ItemId("odyn-son", "Unique_Mace_1H_002_x1"),
                new ItemId("mad-monarchs-scepter", "Unique_Mace_1H_101_x1"),
                new ItemId("solanium", "Unique_Mace_1H_102_x1"),
                new ItemId("jaces-hammer-of-vigilance", "Unique_Mace_1H_103_x1"),
                new ItemId("sunder", "Unique_Mace_2H_006_x1"),
                new ItemId("arthefs-spark-of-life", "Unique_Mace_2H_003_x1"),
                new ItemId("schaefers-hammer", "Unique_Mace_2H_009_p2"),
                new ItemId("soulsmasher", "Unique_Mace_2H_104_x1"),
                new ItemId("skywarden", "Unique_Mace_2H_010_x1"),
                new ItemId("the-furnace", "Unique_Mace_2H_103_x1"),
                new ItemId("remorseless", "Unique_Mighty_1H_102_x1"),
                new ItemId("oathkeeper", "P4_Unique_Mighty_1H_104"),
                new ItemId("fjord-cutter", "P3_Unique_Mighty_1H_006"),
                new ItemId("dishonored-legacy", "Unique_Mighty_1H_103_x1"),
                new ItemId("blade-of-the-warlord", "P4_Unique_Mighty_1H_005"),
                new ItemId("bastions-revered", "Unique_Mighty_2H_004_p1"),
                new ItemId("blade-of-the-tribes", "P4_Unique_Mighty_2H_101"),
                new ItemId("fury-of-the-vanished-peak", "P61_Unique_Mighty_2H_006"),
                new ItemId("the-gavel-of-judgment", "P61_Unique_Mighty_2H_001"),
                new ItemId("madawcs-sorrow", "Unique_Mighty_2H_101_x1"),
                new ItemId("henris-perquisition", "P2_mojo_norm_unique_02"),
                new ItemId("vile-hive", "P4_Unique_Mojo_001"),
                new ItemId("wilkens-reach", "P4_Unique_Mojo_003"),
                new ItemId("uhkapian-serpent", "Unique_Mojo_008_x1"),
                new ItemId("homunculus", "P42_Unique_Mojo_004"),
                new ItemId("thing-of-the-deep", "P4_Unique_Mojo_002"),
                new ItemId("shukranis-triumph", "Unique_Mojo_102_x1"),
                new ItemId("gazing-demise", "P42_Unique_Mojo_003_x1"),
                new ItemId("iron-rose", "P6_Unique_Phylactery_04"),
                new ItemId("legers-disdain", "P61_Unique_Phylactery_03"),
                new ItemId("bone-ringer", "P6_Unique_Phylactery_02"),
                new ItemId("lost-time", "P61_Unique_Phylactery_01"),
                new ItemId("winter-flurry", "Unique_Orb_005_x1"),
                new ItemId("triumvirate", "P61_Unique_Orb_003"),
                new ItemId("mirrorball", "Unique_Orb_101_x1"),
                new ItemId("cosmic-strand", "Unique_Orb_004_x1"),
                new ItemId("etched-sigil", "P61_Unique_Orb_002"),
                new ItemId("primordial-soul", "P4_Unique_Orb_001"),
                new ItemId("the-oculus", "Unique_Orb_001_x1"),
                new ItemId("orb-of-infinite-depth", "P61_Unique_Orb_004"),
                new ItemId("light-of-grace", "Unique_Orb_103_x1"),
                new ItemId("mykens-ball-of-hate", "Unique_Orb_102_x1"),
                new ItemId("vigilance", "Unique_Polearm_001_x1"),
                new ItemId("standoff", "P61_Unique_Polearm_01"),
                new ItemId("bovine-bardiche", "Unique_Polearm_101_x1"),
                new ItemId("emimeis-duffel", "Unique_Quiver_103_x1"),
                new ItemId("sin-seekers", "P43_Unique_Quiver_001"),
                new ItemId("spines-of-seething-hatred", "Unique_Quiver_005_p1"),
                new ItemId("augustines-panacea", "P41_Unique_Quiver_001"),
                new ItemId("the-ninth-cirri-satchel", "Unique_Quiver_101_x1"),
                new ItemId("dead-mans-legacy", "P61_Unique_Quiver_007"),
                new ItemId("bombardiers-rucksack", "Unique_Quiver_102_x1"),
                new ItemId("holy-point-shot", "P5_Unique_Quiver_004_x1"),
                new ItemId("halo-of-karini", "P61_Unique_Ring_03"),
                new ItemId("ring-of-royal-grandeur", "Unique_Ring_107_x1"),
                new ItemId("hellfire-ring", "Unique_Ring_024_x1"),
                new ItemId("pandemonium-loop", "Unique_Ring_109_x1"),
                new ItemId("avarice-band", "Unique_Ring_108_x1"),
                new ItemId("skull-grasp", "P61_Unique_Ring_02"),
                new ItemId("obsidian-ring-of-the-zodiac", "Unique_Ring_023_p2"),
                new ItemId("the-tall-mans-finger", "Unique_Ring_101_x1"),
                new ItemId("band-of-hollow-whispers", "Unique_Ring_001_x1"),
                new ItemId("band-of-might", "P61_Unique_Ring_05"),
                new ItemId("broken-promises", "Unique_Ring_006_p2"),
                new ItemId("ring-of-emptiness", "P42_Unique_Ring_Haunt"),
                new ItemId("kredes-flame", "Unique_Ring_003_x1"),
                new ItemId("manald-heal", "P43_Unique_Ring_021_x1"),
                new ItemId("pandemonium-loop", "Unique_Ring_109_p2"),
                new ItemId("rechels-ring-of-larceny", "Unique_Ring_104_x1"),
                new ItemId("arcstone", "P2_Unique_Ring_03"),
                new ItemId("justice-lantern", "P4_Unique_Ring_03"),
                new ItemId("elusive-ring", "P4_Unique_Ring_02"),
                new ItemId("briggs-wrath", "P6_Unique_Ring_02"),
                new ItemId("circle-of-nailujs-evol", "P6_Unique_Ring_01"),
                new ItemId("band-of-the-rue-chambers", "Unique_Ring_106_x1"),
                new ItemId("bulkathoss-wedding-band", "Unique_Ring_020_x1"),
                new ItemId("rogars-huge-stone", "Unique_Ring_103_x1"),
                new ItemId("puzzle-ring", "Unique_Ring_004_x1"),
                new ItemId("wyrdward", "Unique_Ring_102_p2"),
                new ItemId("hellfire-ring", "Unique_Ring_024_104"),
                new ItemId("eternal-union", "Unique_Ring_007_p1"),
                new ItemId("unity", "Unique_Ring_010_x1"),
                new ItemId("krysbins-sentence", "P6_Unique_Ring_03"),
                new ItemId("oculus-ring", "Unique_Ring_017_p4"),
                new ItemId("halo-of-arlyse", "p2_Unique_Ring_Wizard_001"),
                new ItemId("lornelles-sunstone", "P6_Unique_Ring_04"),
                new ItemId("the-short-mans-finger", "P61_Unique_Ring_01"),
                new ItemId("nagelring", "Unique_Ring_018_p2"),
                new ItemId("convention-of-elements", "P2_Unique_Ring_04"),
                new ItemId("scythe-of-the-cycle", "P61_Unique_Scythe1H_03"),
                new ItemId("tragouls-corroded-fang", "P6_Unique_Scythe1H_02"),
                new ItemId("funerary-pick", "P6_Unique_Scythe1H_01"),
                new ItemId("maltorius-petrified-spike", "P61_Unique_Scythe2H_01"),
                new ItemId("reilenas-shadowhook", "P6_Unique_Scythe2H_03"),
                new ItemId("nayrs-black-death", "P61_Unique_Scythe2H_04"),
                new ItemId("bloodtide-blade", "P61_Unique_Scythe2H_02"),
                new ItemId("denial", "P61_Unique_Shield_007"),
                new ItemId("votoyias-spiker", "Unique_Shield_104_x1"),
                new ItemId("wall-of-man", "Unique_Shield_011_x1"),
                new ItemId("freeze-of-deflection", "Unique_Shield_004_x1"),
                new ItemId("defender-of-westmarch", "Unique_Shield_101_p2"),
                new ItemId("ivory-tower", "P2_Unique_Shield_002"),
                new ItemId("covens-criterion", "Unique_Shield_107_x1"),
                new ItemId("eberli-charo", "Unique_Shield_102_x1"),
                new ItemId("lefebvres-soliloquy", "P4_Unique_Shoulder_101"),
                new ItemId("pauldrons-of-the-skeleton-king", "Unique_Shoulder_103_x1"),
                new ItemId("fury-of-the-ancients", "P3_Unique_Shoulder_102"),
                new ItemId("homing-pads", "Unique_Shoulder_001_x1"),
                new ItemId("mantle-of-channeling", "P4_Unique_Shoulder_103"),
                new ItemId("death-watch-mantle", "Unique_Shoulder_002_p2"),
                new ItemId("spaulders-of-zakara", "Unique_Shoulder_102_x1"),
                new ItemId("vile-ward", "Unique_Shoulder_003_p1"),
                new ItemId("corpsewhisper-pauldrons", "P6_Necro_Unique_Shoulders_21"),
                new ItemId("razeths-volition", "P6_Necro_Unique_Shoulders_22"),
                new ItemId("spear-of-jairo", "P6_Unique_Spear_01"),
                new ItemId("scrimshaw", "Unique_Spear_004_p3"),
                new ItemId("arreats-law", "P3_Unique_Spear_001"),
                new ItemId("the-three-hundredth-spear", "P4_Unique_Spear_002"),
                new ItemId("the-minds-eye", "Unique_SpiritStone_002_x1"),
                new ItemId("madstone", "P1_Unique_SpiritStone_008"),
                new ItemId("gyana-na-kashu", "Unique_SpiritStone_004_x1"),
                new ItemId("eye-of-peshkov", "Unique_SpiritStone_103_x1"),
                new ItemId("kekegis-unbreakable-spirit", "Unique_SpiritStone_102_x1"),
                new ItemId("the-laws-of-seph", "Unique_SpiritStone_101_x1"),
                new ItemId("tzo-krins-gaze", "Unique_SpiritStone_007_x1"),
                new ItemId("the-smoldering-core", "Unique_Staff_103_x1"),
                new ItemId("valtheks-rebuke", "Unique_Staff_102_x1"),
                new ItemId("the-tormentor", "Unique_Staff_007_x1"),
                new ItemId("suwong-diviner", "Unique_Staff_104_x1"),
                new ItemId("ahavarion-spear-of-lycander", "Unique_Staff_101_x1"),
                new ItemId("wormwood", "P2_Unique_Staff_003"),
                new ItemId("staff-of-chiroptera", "P61_Unique_Staff_001"),
                new ItemId("maloths-focus", "Unique_Staff_006_x1"),
                new ItemId("the-grand-vizier", "P61_Unique_Staff_009"),
                new ItemId("rimeheart", "Unique_Sword_1H_109_x1"),
                new ItemId("sever", "Unique_Sword_1H_007_x1"),
                new ItemId("fulminator", "P3_Unique_Sword_1H_104"),
                new ItemId("sword-of-ill-will", "P4_Unique_Sword_1H_01"),
                new ItemId("deathwish", "P61_Unique_Sword_1H_112_x1"),
                new ItemId("thunderfury-blessed-blade-of-the-windseeker", "Unique_Sword_1H_101_x1"),
                new ItemId("skycutter", "Unique_Sword_1H_004_x1"),
                new ItemId("ingeom", "Unique_Sword_1H_113_x1"),
                new ItemId("azurewrath", "P3_Unique_Sword_1H_012"),
                new ItemId("shard-of-hate", "Unique_Sword_1H_Promo_02_x1"),
                new ItemId("the-twisted-sword", "Unique_Sword_1H_107_x1"),
                new ItemId("cams-rebuttal", "Unique_Sword_2H_102_x1"),
                new ItemId("scourge", "Unique_Sword_2H_004_x1"),
                new ItemId("blood-brother", "Unique_Sword_2H_103_x1"),
                new ItemId("stalgards-decimator", "Unique_Sword_2H_101_x1"),
                new ItemId("maximus", "Unique_Sword_2H_010_x1"),
                new ItemId("blade-of-prophecy", "P61_Unique_Sword_2H_007_x1"),
                new ItemId("faithful-memory", "P61_Unique_Sword_2H_012_x1"),
                new ItemId("the-grin-reaper", "Unique_VoodooMask_002_x1"),
                new ItemId("visage-of-giyua", "Unique_VoodooMask_008_x1"),
                new ItemId("carnevil", "Unique_VoodooMask_101_x1"),
                new ItemId("mask-of-jeram", "P61_Unique_VoodooMask_102_x1"),
                new ItemId("tiklandian-visage", "Unique_VoodooMask_001_x1"),
                new ItemId("quetzalcoatl", "Unique_VoodooMask_005_x1"),
                new ItemId("aether-walker", "P1_Wand_norm_unique_01"),
                new ItemId("fragment-of-destiny", "P4_Unique_Wand_010"),
                new ItemId("starfire", "P42_Unique_Wand_003_x1"),
                new ItemId("wand-of-woh", "P61_Unique_Wand_101_x1"),
                new ItemId("unstable-scepter", "P61_Wand_norm_unique_02"),
                new ItemId("sloraks-madness", "Unique_Wand_013_x1"),
                new ItemId("gesture-of-orpheus", "P2_Unique_Wand_002"),
                new ItemId("serpents-sparker", "Unique_Wand_102_x1"),
                new ItemId("archmages-vicalyke", "Unique_WizardHat_101_x1"),
                new ItemId("velvet-camaral", "Unique_WizardHat_102_x1"),
                new ItemId("crown-of-the-primus", "Unique_WizardHat_104_x1"),
                new ItemId("the-magistrate", "Unique_WizardHat_103_x1"),
                new ItemId("dark-mages-shade", "Unique_WizardHat_001_x1"),
                new ItemId("storm-crow", "Unique_WizardHat_004_x1"),
                new ItemId("the-swami", "P3_Unique_WizardHat_003")
            };
        }

        public static bool IsCube(ItemId itemId)
        {
            return _cubeItemIds.Contains(itemId);
        }
    }
}