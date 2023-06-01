// This file was decompiled using SASCM.ini published by Seemann (http://sannybuilder.com/files/SASCM.rar) on 13.10.2007
{$CLEO .cm}

//-------------MAIN---------------
wait 0 
thread 'SDST' 
gosub @SDST_57 
if 
wasted_or_busted 
jf @SDST_42 
gosub @SDST_3630 

:SDST_42
wait 0 
$ONMISSION = 0 
mission_cleanup 
end_thread 

:SDST_57
wait 0 
increment_mission_attempts 
$ONMISSION = 1 
wait 1500 
016C: restart_if_wasted_at 2027.77 -1420.52 15.99 angle 137.0 town_number 0 
016D: restart_if_busted_at 1550.68 -1675.49 14.51 angle 90.0 town_number 0 
wait 0 
04E4: unknown_refresh_game_renderer_at 2258.581 -1694.609 
Model.Load(#MP5LNG)
Model.Load(#TEC9)
Model.Load(#BMYDJ)
Model.Load(#BMYPOL1)
Model.Load(#SWAT)
Model.Load(#LAPD1)
Model.Load(#COPCARLA)
038B: load_requested_models 
200@ = 1 
300@ = 1 
wait 0 

:SDST_192
wait 0 
if and
   Model.Available(#MP5LNG)
   Model.Available(#TEC9)
   Model.Available(#BMYDJ)
   Model.Available(#BMYPOL1)
   Model.Available(#LAPD1)
   Model.Available(#SWAT)
   Model.Available(#COPCARLA)
04EE:   animation "PED" loaded 
jf @SDST_192 
060A: create_decision_maker_type 2 store_to 57@ // decision\allowed\m_.ped files 
01EB: set_traffic_density_multiplier_to 0.0 
03DE: set_pedestrians_density_multiplier_to 0.0 
Actor.SetImmunities($PLAYER_ACTOR, 0, 0, 0, 0, 0)
Actor.PutAt($PLAYER_ACTOR, 2272.786, -1694.35, 13.6503)
Actor.Angle($PLAYER_ACTOR) = 75.7559
150@ = Actor.Create(Mission1, #BMYPOL1, 2271.66, -1691.341, 13.6605)
Actor.Angle(150@) = 89.0623
077A: set_actor 150@ acquaintance 1 to_actors_pedtype 0 // see ped.dat 
077A: set_actor 150@ acquaintance 1 to_actors_pedtype 25 // see ped.dat 
1@ = Actor.Create(Mission2, #BMYDJ, 2268.327, -1691.14, 13.6766)
Actor.Angle(1@) = 269.0623
077A: set_actor 1@ acquaintance 1 to_actors_pedtype 0 // see ped.dat 
077A: set_actor 1@ acquaintance 1 to_actors_pedtype 24 // see ped.dat 
Camera.SetPosition(2258.581, -1694.609, 13.7273, 0.0, 0.0, 0.0)
Camera.PointAt(2273.711, -1691.133, 13.6503, 2)
02A3: enable_widescreen 1 
04E4: unknown_refresh_game_renderer_at 2272.786 -1694.35 
fade 1 1500 
wait 1500 
0605: actor 150@ perform_animation_sequence "IDLE_CHAT" IFP_file "PED" 4.0 loop 0 0 0 0 time 6000 // versionA 
00BC: show_text_highpriority GXT 'SD_2' time 6000 flag 1 
wait 6000 
0605: actor 1@ perform_animation_sequence "IDLE_CHAT" IFP_file "PED" 4.0 loop 0 0 0 0 time 4000 // versionA 
00BC: show_text_highpriority GXT 'SD_3' time 4000 flag 1 
wait 4000 
0605: actor 150@ perform_animation_sequence "IDLE_CHAT" IFP_file "PED" 4.0 loop 0 0 0 0 time 4000 // versionA 
00BC: show_text_highpriority GXT 'SD_4' time 4000 flag 1 
wait 4000 
2@ = Actor.Create(Mission3, #SWAT, 2256.875, -1687.14, 20.5156)
0638: AS_actor 2@ stay_put 1 
Actor.Angle(2@) = 236.4321
01B2: give_actor 2@ weapon 29 ammo 9999 // Load the weapon model before using this 
Camera.SetPosition(2269.737, -1696.544, 13.6732, 0.0, 0.0, 0.0)
Camera.PointAt(2256.875, -1687.14, 20.5156, 2)
wait 0 
3@ = Car.Create(#COPCARLA, 2226.122, -1700.041, 13.7483)
Car.Angle(3@) = 356.8184
4@ = Actor.Create(Mission3, #LAPD1, 2225.031, -1699.538, 13.7561)
072A: put_actor 4@ into_car 3@ driverseat 
05D1: AS_actor 4@ drive_car 3@ to 2227.159 -1689.805 13.9931 speed 15.0 0 model #NULL 0 
wait 10 
7@ = Car.Create(#COPCARLA, 2311.054, -1667.247, 14.4263)
Car.Angle(7@) = 90.4496
5@ = Actor.Create(Mission3, #LAPD1, 2311.054, -1667.247, 14.4263)
072A: put_actor 5@ into_car 7@ driverseat 
05D1: AS_actor 5@ drive_car 7@ to 2297.946 -1667.528 14.8201 speed 15.0 0 model #NULL 0 
wait 10 
8@ = Car.Create(#COPCARLA, 2282.329, -1724.725, 13.5469)
Car.Angle(8@) = 269.1234
6@ = Actor.Create(Mission3, #LAPD1, 2282.329, -1724.725, 13.5469)
072A: put_actor 6@ into_car 8@ driverseat 
05D1: AS_actor 6@ drive_car 8@ to 2227.159 -1689.805 13.9931 speed 15.0 0 model #NULL 0 
wait 500 
077A: set_actor 2@ acquaintance 4 to_actors_pedtype 25 // see ped.dat 
05E2: AS_actor 2@ kill_actor 1@ 
wait 300 
0321: kill_actor 1@ 
jump @SDST_1124 

:SDST_1124
wait 0 
Camera.SetBehindPlayer
Camera.Restore
Player.CanMove($PLAYER_CHAR) = True
02A3: enable_widescreen 0 
00BC: show_text_highpriority GXT 'SD_5' time 4000 flag 1 
01B2: give_actor 150@ weapon 29 ammo 9999 // Load the weapon model before using this 
wait 500 
Actor.WeaponAccuracy(150@) = 55
Actor.WeaponAccuracy(2@) = 80
wait 0 
077A: set_actor 2@ acquaintance 4 to_actors_pedtype 24 // see ped.dat 
wait 100 
077A: set_actor 2@ acquaintance 4 to_actors_pedtype 0 // see ped.dat 
060B: set_actor 2@ decision_maker_to 65542 
wait 100 
077A: set_actor 150@ acquaintance 4 to_actors_pedtype 26 // see ped.dat 
0446: set_actor 150@ immune_to_headshots 0 
060B: set_actor 150@ decision_maker_to 57@ 
wait 100 
077A: set_actor 4@ acquaintance 4 to_actors_pedtype 0 // see ped.dat 
wait 100 
077A: set_actor 4@ acquaintance 4 to_actors_pedtype 24 // see ped.dat 
wait 100 
077A: set_actor 5@ acquaintance 4 to_actors_pedtype 0 // see ped.dat 
wait 100 
077A: set_actor 5@ acquaintance 4 to_actors_pedtype 24 // see ped.dat 
wait 100 
077A: set_actor 6@ acquaintance 4 to_actors_pedtype 0 // see ped.dat 
wait 100 
077A: set_actor 6@ acquaintance 4 to_actors_pedtype 24 // see ped.dat 
wait 100 
wait 0 
if 
   Actor.InCar(4@, 3@)
jf @SDST_1377 
0362: remove_actor 4@ from_car_and_place_at 2232.124 -1689.558 14.0113 

:SDST_1377
Actor.WeaponAccuracy(4@) = 80
Actor.Angle(4@) = 267.7694
Car.LockInCurrentPosition(3@) = True
0638: AS_actor 4@ stay_put 0 
if 
   Actor.InCar(5@, 7@)
jf @SDST_1427 

:SDST_1427
0362: remove_actor 5@ from_car_and_place_at 2297.767 -1672.124 14.6198 
Actor.WeaponAccuracy(5@) = 80
Actor.Angle(5@) = 179.435
Car.LockInCurrentPosition(7@) = True
0638: AS_actor 5@ stay_put 1 
if 
   Actor.InCar(6@, 8@)
jf @SDST_1517 
0362: remove_actor 6@ from_car_and_place_at 2296.264 -1721.359 13.5545 

:SDST_1517
Actor.WeaponAccuracy(6@) = 80
Actor.Angle(6@) = 359.1628
Car.LockInCurrentPosition(8@) = True
0638: AS_actor 6@ stay_put 1 
01B2: give_actor 4@ weapon 29 ammo 9999 // Load the weapon model before using this 
01B2: give_actor 5@ weapon 29 ammo 9999 // Load the weapon model before using this 
01B2: give_actor 6@ weapon 29 ammo 9999 // Load the weapon model before using this 
Actor.WeaponAccuracy(150@) = 100
Actor.Health(2@) = 10
wait 200 
Actor.WeaponAccuracy(150@) = 55
08AF: set_actor 150@ max_health_to 500 
Actor.Health(150@) = 500
05F5: AS_actor 150@ goto_point 2301.368 -1695.704 13.4084 mode 6 -2 ms // versionB 
00BC: show_text_highpriority GXT 'SD_6' time 4000 flag 1 
10@ = Marker.CreateAboveActor(150@)
07E0: set_marker 10@ type_to 1 
$HEALTH = Actor.Health(150@)
$HEALTH /= 5 
03C4: set_status_text $HEALTH type 1 GXT 'SD_11' // global_variable 

:SDST_1706
wait 0 
Actor.StorePos(150@, 201@, 202@, 203@)
if 
00EC:   actor $PLAYER_ACTOR 0 near_point 201@ 202@ radius 80.0 80.0 
jf @SDST_1769 
wait 1 
jump @SDST_1783 

:SDST_1769
200@ = 0 
jump @SDST_3462 

:SDST_1783
if 
   Actor.Dead(150@)
jf @SDST_1813 
300@ = 0 
jump @SDST_3462 

:SDST_1813
$HEALTH = Actor.Health(150@)
$HEALTH /= 5 
03C4: set_status_text $HEALTH type 1 GXT 'SD_11' // global_variable 
if 
00EC:   actor 150@ 0 near_point 2301.368 -1695.704 radius 2.0 2.0 
jf @SDST_1706 
11@ = Actor.Create(Mission3, #LAPD1, 2316.335, -1688.357, 14.1202)
01B2: give_actor 11@ weapon 29 ammo 9999 // Load the weapon model before using this 
077A: set_actor 11@ acquaintance 4 to_actors_pedtype 24 // see ped.dat 
077A: set_actor 11@ acquaintance 4 to_actors_pedtype 0 // see ped.dat 
05E2: AS_actor 11@ kill_actor 150@ 
Actor.WeaponAccuracy(11@) = 80
05F5: AS_actor 11@ goto_point 2316.222 -1693.465 13.5271 mode 6 -1 ms // versionB 
12@ = Actor.Create(Mission3, #LAPD1, 2333.925, -1688.967, 13.5214)
01B2: give_actor 12@ weapon 29 ammo 9999 // Load the weapon model before using this 
077A: set_actor 12@ acquaintance 4 to_actors_pedtype 24 // see ped.dat 
077A: set_actor 12@ acquaintance 4 to_actors_pedtype 0 // see ped.dat 
Actor.WeaponAccuracy(12@) = 80
05E2: AS_actor 12@ kill_actor 150@ 
05F5: AS_actor 12@ goto_point 2333.97 -1694.31 13.38 mode 6 -1 ms // versionB 
13@ = Actor.Create(Mission3, #LAPD1, 2334.069, -1701.458, 13.505)
01B2: give_actor 13@ weapon 29 ammo 9999 // Load the weapon model before using this 
077A: set_actor 13@ acquaintance 4 to_actors_pedtype 24 // see ped.dat 
077A: set_actor 13@ acquaintance 4 to_actors_pedtype 0 // see ped.dat 
Actor.WeaponAccuracy(13@) = 80
05E2: AS_actor 13@ kill_actor 150@ 
05F5: AS_actor 13@ goto_point 2333.9 -1697.249 13.4247 mode 6 -1 ms // versionB 
wait 100 
05D3: AS_actor 150@ goto_point 2366.092 -1695.6 13.4284 mode 6 -2 ms // versionA 

:SDST_2186
wait 0 
04ED: load_animation "SWAT" 
if 
04EE:   animation "SWAT" loaded 
jf @SDST_2186 

:SDST_2217
wait 0 
$HEALTH = Actor.Health(150@)
$HEALTH /= 5 
03C4: set_status_text $HEALTH type 1 GXT 'SD_11' // global_variable 
Actor.StorePos(150@, 201@, 202@, 203@)
if 
00EC:   actor $PLAYER_ACTOR 0 near_point 201@ 202@ radius 80.0 80.0 
jf @SDST_2311 
wait 1 
jump @SDST_2325 

:SDST_2311
200@ = 0 
jump @SDST_3462 

:SDST_2325
if 
   Actor.Dead(150@)
jf @SDST_2355 
300@ = 0 
jump @SDST_3462 

:SDST_2355
if 
00EC:   actor 150@ 0 near_point 2366.092 -1695.6 radius 1.0 1.0 
jf @SDST_2217 
05D3: AS_actor 150@ goto_point 2389.104 -1695.573 13.5239 mode 6 -2 ms // versionA 

:SDST_2417
wait 0 
$HEALTH = Actor.Health(150@)
$HEALTH /= 5 
03C4: set_status_text $HEALTH type 1 GXT 'SD_11' // global_variable 
Actor.StorePos(150@, 201@, 202@, 203@)
if 
00EC:   actor $PLAYER_ACTOR 0 near_point 201@ 202@ radius 80.0 80.0 
jf @SDST_2511 
wait 1 
jump @SDST_2525 

:SDST_2511
200@ = 0 
jump @SDST_3462 

:SDST_2525
if 
   Actor.Dead(150@)
jf @SDST_2555 
300@ = 0 
jump @SDST_3462 

:SDST_2555
if 
00EC:   actor 150@ 0 near_point 2389.104 -1695.573 radius 1.0 1.0 
jf @SDST_2417 
30@ = Actor.Create(Mission3, #LAPD1, 2370.727, -1691.617, 13.6424)
01B2: give_actor 30@ weapon 29 ammo 9999 // Load the weapon model before using this 
Actor.WeaponAccuracy(30@) = 80
077A: set_actor 30@ acquaintance 4 to_actors_pedtype 0 // see ped.dat 
077A: set_actor 30@ acquaintance 4 to_actors_pedtype 24 // see ped.dat 
Actor.Angle(30@) = 179.0828
0605: actor 30@ perform_animation_sequence "SWT_BREACH_03" IFP_file "SWAT" 1000.0 loop 0 1 1 0 time -1 // versionA 
060B: set_actor 30@ decision_maker_to 57@ 
31@ = Actor.Create(Mission3, #LAPD1, 2371.897, -1700.529, 13.6185)
01B2: give_actor 31@ weapon 29 ammo 9999 // Load the weapon model before using this 
Actor.WeaponAccuracy(31@) = 80
077A: set_actor 31@ acquaintance 4 to_actors_pedtype 0 // see ped.dat 
077A: set_actor 31@ acquaintance 4 to_actors_pedtype 24 // see ped.dat 
Actor.Angle(31@) = 357.6571
0605: actor 31@ perform_animation_sequence "SWT_BREACH_01" IFP_file "SWAT" 1000.0 loop 0 1 1 0 time -1 // versionA 
060B: set_actor 31@ decision_maker_to 57@ 
32@ = Actor.Create(Mission3, #LAPD1, 2409.985, -1699.341, 13.7757)
01B2: give_actor 32@ weapon 29 ammo 9999 // Load the weapon model before using this 
Actor.WeaponAccuracy(32@) = 80
077A: set_actor 35@ acquaintance 4 to_actors_pedtype 0 // see ped.dat 
077A: set_actor 35@ acquaintance 4 to_actors_pedtype 24 // see ped.dat 
Actor.Angle(35@) = 358.032
060B: set_actor 35@ decision_maker_to 57@ 
0605: actor 35@ perform_animation_sequence "SWT_BREACH_03" IFP_file "SWAT" 1000.0 loop 0 1 1 0 time -1 // versionA 
36@ = Actor.Create(Mission3, #LAPD1, 2414.893, -1692.336, 13.79)
01B2: give_actor 36@ weapon 29 ammo 9999 // Load the weapon model before using this 
Actor.WeaponAccuracy(33@) = 80
077A: set_actor 36@ acquaintance 4 to_actors_pedtype 0 // see ped.dat 
077A: set_actor 36@ acquaintance 4 to_actors_pedtype 24 // see ped.dat 
060B: set_actor 36@ decision_maker_to 57@ 
Actor.Angle(36@) = 178.9137
0605: actor 36@ perform_animation_sequence "SWT_BREACH_01" IFP_file "SWAT" 1000.0 loop 0 1 1 0 time -1 // versionA 
00BC: show_text_highpriority GXT 'SD_12' time 3000 flag 1 
wait 1000 

:SDST_3090
wait 0 
Actor.StorePos(150@, 201@, 202@, 203@)
$HEALTH = Actor.Health(150@)
$HEALTH /= 5 
03C4: set_status_text $HEALTH type 1 GXT 'SD_11' // global_variable 
:Master
wait 0
if and
   not Actor.Dead(30@)
   not Actor.Dead(31@)
   not Actor.Dead(35@)
   not Actor.Dead(36@)
jf @Master
jump @SDST_3280
if 
00EC:   actor $PLAYER_ACTOR 0 near_point 201@ 202@ radius 40.0 40.0 
jf @SDST_3215 
wait 0 
jump @SDST_3229 

:SDST_3215
200@ = 0 
jump @SDST_3462 

:SDST_3229
if 
   Actor.Dead(150@)
jf @SDST_3266 
300@ = 0 
jump @SDST_3462 
jump @SDST_3273 

:SDST_3266
jump @SDST_3090 

:SDST_3273
jump @SDST_3090 

:SDST_3280
wait 0 
0151: remove_status_text $HEALTH 
0850: AS_actor 150@ follow_actor $PLAYER_ACTOR 
Marker.Disable(10@)
00BC: show_text_highpriority GXT 'SD_13' time 3000 flag 1 
018A: $CHECKPOINT = create_checkpoint_at 2452.117 -1667.621 13.4787 
03BC: 151@ = create_sphere_at 2452.117 -1667.621 13.4787 radius 6.0 
wait 0 
if and
00EC:   actor 150@ 0 near_point 2452.117 -1667.621 radius 6.0 6.0 
00EC:   actor $PLAYER_ACTOR 0 near_point 2452.117 -1667.621 radius 6.0 6.0 
00EC:   actor $PLAYER_ACTOR 0 near_point 201@ 202@ radius 15.0 15.0 
jf @SDST_3462 
jump @SDST_3553 

:SDST_3462
wait 0 
if 
  200@ == 0 
jf @SDST_3512 
00BC: show_text_highpriority GXT 'SD_10' time 6000 flag 1 
Actor.DestroyWithFade(150@)
jump @SDST_3630 

:SDST_3512
if 
  300@ == 0 
jf @SDST_3553 
00BC: show_text_highpriority GXT 'SD_9' time 6000 flag 1 
jump @SDST_3630 

:SDST_3553
wait 0 
gosub @SDST_3674 
01E3: show_text_1number_styled GXT 'M_PASSS' number 100000 time 5000 style 1  // –…CC…• ‹‘ЊO‡­E­A!~n~~w~$~1~~n~~w~Y‹A„E­…E +
0998: add_respect 3 
Player.Money($PLAYER_CHAR) += 300000
0394: play_music 1 
return 
wait 0 
Player.ClearWantedLevel($PLAYER_CHAR)
00BC: show_text_highpriority GXT 'SW_5' time 5000 flag 1 

:SDST_3630
wait 0 
gosub @SDST_3674 
00BA: show_text_styled GXT 'M_FAIL' time 5000 style 1  // ~r~–…CC…• ЊPO‹A‡E­A!
0A92: create_custom_thread "SDSTART.CS"  
return 

:SDST_3674
wait 0 
Model.Destroy(#COPCARLA)
Model.Destroy(#TEC9)
Model.Destroy(#MP5LNG)
Model.Destroy(#LAPD1)
if 
Marker.Disable(10@)
jf @SDST_3719 
Marker.Disable(10@)

:SDST_3719
0151: remove_status_text $HEALTH 
Marker.Disable($CHECKPOINT)
03BD: destroy_sphere 151@ 
return 
