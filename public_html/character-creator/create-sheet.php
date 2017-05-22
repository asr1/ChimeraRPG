<?php

require __DIR__ . '/vendor/autoload.php';
use mikehaertl\pdftk\Pdf;

$data = json_decode($_GET['character']);

$fill_data = array(
    'NAME' => $data->name,
    'HEIGHT' => $data->height,
    'OCCUPATION' => $data->occupation,
    'CLASS' => $data->class,
    'WEIGHT' => $data->weight,
    'ASPIRATION' => $data->aspiration,
    'RACE' => $data->race,
    'AGE' => $data->age,
    'BACKGROUND' => $data->background,    
    'Armor Class' => $data->ac,
    'Reflex' => $data->reflex,
    'Will' => $data->will,
    'Fortitude' => $data->fort,
    'Movement' => $data->movement,
    'Init' => $data->initiative,
    'hp_total' => $data->hp,
    'ap_total' => $data->ap,
    'REGEN' => $data->apRegen,
    'NAME_2' => $data->name,
    'cha_score' => $data->attributes->CHA->score,
    'cha_mod' => $data->attributes->CHA->mod,
    'con_score' => $data->attributes->CON->score,
    'con_mod' => $data->attributes->CON->mod,
    'dex_score' => $data->attributes->DEX->score,
    'dex_mod' => $data->attributes->DEX->mod,
    'lck_score' => $data->attributes->LCK->score,
    'lck_mod' => $data->attributes->LCK->mod,
    'spd_score' => $data->attributes->SPD->score,
    'spd_mod' => $data->attributes->SPD->mod,
    'int_score' => $data->attributes->INT->score,
    'int_mod' => $data->attributes->INT->mod,
    'wis_score' => $data->attributes->WIS->score,
    'wis_mod' => $data->attributes->WIS->mod,
    'str_score' => $data->attributes->STR->score,
    'str_mod' => $data->attributes->STR->mod,
    'acrobatics_score' => $data->skills->Acrobatics->score,
    'acrobatics_mod' => $data->skills->Acrobatics->mod,
    'athletics_score' => $data->skills->Athletics->score,
    'athletics_mod' => $data->skills->Athletics->mod,
    'block_score' => $data->skills->Block->score,
    'block_mod' => $data->skills->Block->mod,
    'chemistry_score' => $data->skills->Chemistry->score,
    'chemistry_mod' => $data->skills->Chemistry->mod,
    'control_score' => $data->skills->Control->score,
    'control_mod' => $data->skills->Control->mod,
    'craft_score' => $data->skills->Craft->score,
    'craft_mod' => $data->skills->Craft->mod,
    'destruction_score' => $data->skills->Destruction->score,
    'destruction_mod' => $data->skills->Destruction->mod,
    'disguise_score' => $data->skills->Disguise->score,
    'disguise_mod' => $data->skills->Disguise->mod,
    'engineering_score' => $data->skills->Engineering->score,
    'engineering_mod' => $data->skills->Engineering->mod,
    'enhancement_score' => $data->skills->Enhancement->score,
    'enhancement_mod' => $data->skills->Enhancement->mod,
    'enlightenment_score' => $data->skills->Enlightenment->score,
    'enlightenment_mod' => $data->skills->Enlightenment->mod,
    'escape_score' => $data->skills->Escape->score,
    'escape_mod' => $data->skills->Escape->mod,
    'heavy_score' => $data->skills->Heavy_armor->score,
    'heavy_mod' => $data->skills->Heavy_armor->mod,
    'interaction_score' => $data->skills->Interaction->score,
    'interaction_mod' => $data->skills->Interaction->mod,
    'knowledge_score' => $data->skills->Knowledge->score,
    'knowledge_mod' => $data->skills->Knowledge->mod,
    'light_score' => $data->skills->Light_armor->score,
    'light_mod' => $data->skills->Light_armor->mod,
    'medicine_score' => $data->skills->Medicine->score,
    'medicine_mod' => $data->skills->Medicine->mod,
    'melee_score' => $data->skills->Melee_Weapon->score,
    'melee_mod' => $data->skills->Melee_Weapon->mod,
    'perception_score' => $data->skills->Perception->score,
    'perception_mod' => $data->skills->Perception->mod,
    'ranged_score' => $data->skills->Ranged->score,
    'ranged_mod' => $data->skills->Ranged->mod,
    'ride_score' => $data->skills->Ride_Drive->score,
    'ride_mod' => $data->skills->Ride_Drive->mod,
    'security_score' => $data->skills->Security->score,
    'security_mod' => $data->skills->Security->mod,
    'sense_score' => $data->skills->Sense_Motive->score,
    'sense_mod' => $data->skills->Sense_Motive->mod,
    'sleight_score' => $data->skills->Sleight_of_Hand->score,
    'sleight_mod' => $data->skills->Sleight_of_Hand->mod,
    'stealth_score' => $data->skills->Stealth->score,
    'stealth_mod' => $data->skills->Stealth->mod,
    'survival_score' => $data->skills->Survival->score,
    'survival_mod' => $data->skills->Survival->mod,
    'unarmed_score' => $data->skills->Unarmed_Combat->score,
    'unarmed_mod' => $data->skills->Unarmed_Combat->mod,
    'utility_score' => $data->skills->Utility->score,
    'utility_mod' => $data->skills->Utility->mod
);

$count = 1;
foreach($data->talents as $value) {
    $fill_data['t' . $count] = $value;
    $count = $count + 1;
}

$count = 1;
foreach($data->abilities as $value) {
    $fill_data['a' . $count] = $value->name;
    $fill_data['a' . $count . '_cost'] = $value->cost;
    $fill_data['a' . $count . '_effect'] = $value->effect;
    $fill_data['a' . $count . '_school'] = $value->school;
    $count = $count + 1;
}

$pdf = new Pdf(__DIR__ . '/data/Editable Character Sheet.pdf');
$pdf->fillForm($fill_data)
    ->needAppearances()
    ->saveAs($data->name . '_sheet.pdf');

echo $data->name . '_sheet.pdf';

?>