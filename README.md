# Dota2 Overlay OffsetUpdater
	** Project abandoned ,Offsets will still be updated from time to time.**

Fetch latest offset from dataserver(using this repository).

Purpose: Dota 2 updates regularly and program structure also change from time to time. so this is the only way i can think of by manually updating offset and uploading to server(pastebin).

Todo: Stable Pattern Scan()

Note: Directory of program must be same as the directory of Dota2Overlay.exe
      Offset Updating is done maunally so please be patient.

**Usage: Run OffsetUpdater.exe and hit update.

**Manual Update:**
Config uses the syntax of the following..
 (BasePointer)0059B950 (offsets)0 28 38 70 170 0 1E4 
 
Most easiest way to update is using Cheat Engines Pointer Scan, just generate the Pointer map of VBE Address(to find the address there notes in https://github.com/skrixx68/Dota2-Overlay/blob/master/Dota2MemReader/Dota2MemReader.cpp#L149). after that do the normal pointer scan the address until you get a pointer with base address of engine2.dll with 4-6 offsets more info here https://wiki.cheatengine.org/index.php?title=Help_File:Pointer_scan. Good luck :)

Specific steps
1. Scan for addresses using Nature Prophet in a lobby (Not Visible = 06(radiant team) , 10(dire team) ; Visible = 14), should get at least 3 results.
2. Pointerscan these 3 addresses and find base address of engine2.dll that ends with 7 level of offsets, ending with 170 0 1E4.
3. Update latest_offsets.txt.
