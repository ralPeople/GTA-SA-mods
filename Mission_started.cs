{$CLEO .cs}
 
:MM
0A95: enable_thread_saving // Если не написать это, то при каждой загрузке этот скрипт будет срабатывать снова и снова!!!
thread 'MM' // !!! StartArmy - слишком много символов. Максимум - 7
2@ = Marker.CreateIconAndSphere(26, 2464.3972, -1666.9904, 15.4764)
 
:MM_LOOP
wait 0
if and
075C:   marker 2@ enabled
$ONMISSION == 0 // !!! другие миссии не должны быть запущенными. Всегда проверяйте этот флаг
0102:   actor $PLAYER_ACTOR in_sphere 2464.3972 -1666.9904 13.4764 radius 2.0 2.0 1.0 sphere 1 stopped_on_foot // sphere 1 необязательно, так как сферу генерирует команда CreateIconAndSphere
jf @MM_LOOP

Marker.Disable(2@)
Actor.SetImmunities($PLAYER_ACTOR, 1, 1, 1, 1, 1) // на всякий случай поставить иммунитеты
Player.CanMove($PLAYER_CHAR) = False
00BA: show_text_styled GXT 'SD_1' time 2000 style 2 
fade 0 1500 
wait 1500 
0A94: start_custom_mission "SD"
0A93: end_custom_thread
