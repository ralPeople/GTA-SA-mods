           {$CLEO}

const
   KEY_REC = 82 // R
   REC_INTERVAL_MS = 100
   RECORD_STATE = 0@
   RECORD_INTERVAL = 32@
   KEY_RELEASE_TIMER = 33@
   IS_FILE_OPEN = 1@
   hFILE = 2@
   TIMING = 4@
   TOTAL_TIME = 5@
   PLAYER_VEHICLE = 6@
   FILE_PATH = "data\Paths\carrec900.rrr"   
end

RECORD_STATE = FALSE
KEY_RELEASE_TIMER = 500
IS_FILE_OPEN = FALSE
            
while true
    wait 0
    gosub @ToggleRecordState 
    if
        RECORD_STATE == True
    then
        if
            IS_FILE_OPEN == FALSE
        then
           gosub @OpenR3File
           RECORD_INTERVAL = 0
           TOTAL_TIME = 0
           TIMING = 0          
        end
        gosub @processRecord 
    else
        if
            IS_FILE_OPEN == TRUE
        then
           gosub @CloseR3File
         
        end           
    end    
end

:ToggleRecordState
if
    0256:   player $PLAYER_CHAR defined
then
    if
        00DF:   actor $PLAYER_ACTOR driving
    then
        if  and
            0AB0:  key_pressed KEY_REC
            0AB0:  key_pressed 16 // SHIFT
            KEY_RELEASE_TIMER >= 500            
        then
            if
                RECORD_STATE == TRUE
            then
                RECORD_STATE = FALSE
                IS_FILE_OPEN = TRUE // close file
                03E5: show_text_box 'CARREC2' // Car record OFF               
            else
                RECORD_STATE = TRUE
                IS_FILE_OPEN = FALSE // open file                
                03E5: show_text_box 'CARREC1' // Car record ON                                                      
            end
            KEY_RELEASE_TIMER = 0                  
        end
        return        
    end            
end
if
    RECORD_STATE == TRUE
then
    RECORD_STATE = FALSE
    IS_FILE_OPEN = TRUE // close file   
    03E5: show_text_box 'CARREC2' // Car record OFF     
end
return

:OpenR3File
if
    0A9A: hFILE = openfile FILE_PATH mode 0x6277  // "wb"
then
    IS_FILE_OPEN = TRUE
else
    RECORD_STATE = FALSE            
end    
return

:CloseR3File
0A9B: closefile hFILE
IS_FILE_OPEN = FALSE
return


:processRecord
if
    RECORD_STATE == TRUE
then    
    if
        002D:  RECORD_INTERVAL >= TIMING
    then
        RECORD_INTERVAL = 0
        005A: TOTAL_TIME += TIMING
        gosub @WriteRRR        
        // NEXT INFO STORING TIME
        0209: TIMING = random_int_in_ranges 0 50
        TIMING += REC_INTERVAL_MS                       
    end        
end    
return


:WriteRRR
0A9E: writefile hFILE size 4 from TOTAL_TIME

03C0: PLAYER_VEHICLE = actor $PLAYER_ACTOR car
0A97: PLAYER_VEHICLE = car PLAYER_VEHICLE struct


0A8E: 23@ = PLAYER_VEHICLE + 0x44 // velocity.x
0A8D: 23@ = read_memory 23@ size 4 virtual_protect 0
23@ *= 16383.5
008E: 23@ = float 23@ to_integer
0A9E: writefile hFILE size 2 from 23@
0A8E: 23@ = PLAYER_VEHICLE + 0x48 // velocity.y
0A8D: 23@ = read_memory 23@ size 4 virtual_protect 0
23@ *= 16383.5
008E: 23@ = float 23@ to_integer
0A9E: writefile hFILE size 2 from 23@
0A8E: 23@ = PLAYER_VEHICLE + 0x4C // velocity.z
0A8D: 23@ = read_memory 23@ size 4 virtual_protect 0
23@ *= 16383.5
008E: 23@ = float 23@ to_integer
0A9E: writefile hFILE size 2 from 23@

0A8E: 23@ = PLAYER_VEHICLE + 0x14 // pXYZ
0A8D: 23@ = read_memory 23@ size 4 virtual_protect 0  // xyz.right
gosub @WriteXYZ

23@ += 0x10   // xyz.top
gosub @WriteXYZ

0A8E: 23@ = PLAYER_VEHICLE + 0x494 // SteerAngle
0A8D: 23@ = read_memory 23@ size 4 virtual_protect 0
23@ *= 20.0
008E: 23@ = float 23@ to_integer
0A9E: writefile hFILE size 1 from 23@

0A8E: 23@ = PLAYER_VEHICLE + 0x49C // GasPedal
0A8D: 23@ = read_memory 23@ size 4 virtual_protect 0
23@ *= 100.0
008E: 23@ = float 23@ to_integer
0A9E: writefile hFILE size 1 from 23@

0A8E: 23@ = PLAYER_VEHICLE + 0x4A0 // BrakePedal
0A8D: 23@ = read_memory 23@ size 4 virtual_protect 0
23@ *= 100.0
008E: 23@ = float 23@ to_integer
0A9E: writefile hFILE size 1 from 23@

0A8E: 23@ = PLAYER_VEHICLE + 0x428 // Handbrake
0A8D: 23@ = read_memory 23@ size 1 virtual_protect 0
if
    08B7:   test 23@ bit 5 
then
    23@ = 1
else
    23@ = 0
end        
0A9E: writefile hFILE size 1 from 23@

03C0: PLAYER_VEHICLE = actor $PLAYER_ACTOR car 
00AA: store_car PLAYER_VEHICLE position_to 20@ 21@ 22@ 
0A9E: writefile hFILE size 12 from 20@

return

:WriteXYZ
0A8E: 24@ = 23@ + 0x0 // x
0A8D: 24@ = read_memory 24@ size 4 virtual_protect 0
24@ *= 127.0
008E: 24@ = float 24@ to_integer 
0A9E: writefile hFILE size 1 from 24@

0A8E: 24@ = 23@ + 0x4 // y
0A8D: 24@ = read_memory 24@ size 4 virtual_protect 0
24@ *= 127.0
008E: 24@ = float 24@ to_integer
0A9E: writefile hFILE size 1 from 24@

0A8E: 24@ = 23@ + 0x8 // z
0A8D: 24@ = read_memory 24@ size 4 virtual_protect 0
24@ *= 127.0
008E: 24@ = float 24@ to_integer
0A9E: writefile hFILE size 1 from 24@
return
