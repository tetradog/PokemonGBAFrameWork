﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonGBAFrameWork.Recursos
{
    ///<summary>
    ///Como no se pueden poner archivo de recursos en .netstandard pues irá por clases...
    ///</summary>
    public static class RecursosStrings
    {
        public static readonly string ASMCambiarPJKanto;
        public static readonly string ASMMTBW;
        public static readonly string ASMPokemonInCapturable;
        public static readonly string ASMShinyzer;
        public static readonly string ASMMensjaeObjetoRecividoConImagenEsmeraldaUSAYRojoFuego10USA;

        public static readonly string VarsBPEUSA;
        public static readonly string VarsBPR10USA;

        public static readonly string CPokemon;
        public static readonly string CTypes;
        static RecursosStrings()
        {
            StringBuilder str = new StringBuilder();
            StringBuilder c_pokemon;
            StringBuilder c_types;
            #region ASM Cambiar de PJ Kanto
            str.AppendLine(".text");
            str.AppendLine(".align 2");
            str.AppendLine(".thumb");
            str.AppendLine(".thumb_func");
            str.AppendLine("@hook from 0805CA4C via r0");

            str.AppendLine("main:");
            str.AppendLine("@flag check");
            str.AppendLine("checkFlag:");
            str.AppendLine("mov r0, #0xFF ");
            str.AppendLine("lsl r0, r0, #0x2");
            str.AppendLine("add r0, r0, #0xA @0x3FC + 0xA = @406");
            str.AppendLine("ldr r2, = (0x806E6D0 + 1)");
            str.AppendLine("push { r1, r3}");
            str.AppendLine("bl linker");
            str.AppendLine("pop { r1, r3}");
            str.AppendLine("cmp r0, #0x1");
            str.AppendLine("bne noCrash");

            str.AppendLine("setOW:");
            str.AppendLine("ldr r0, = (0x20370B8)");
            str.AppendLine("ldrb r0, [r0]");
            str.AppendLine("cmp r0, #0xFF");
            str.AppendLine("beq noCrash");
            str.AppendLine("mov r3, r0");
            str.AppendLine("noCrash:");
            str.AppendLine("mov r8, r3");
            str.AppendLine("lsl r4, r4, #0x10");
            str.AppendLine("lsr r4, r4, #0x10");
            str.AppendLine("lsl r5, r5, #0x10");
            str.AppendLine("ldr r0, = (0x805CA54 + 1)");
            str.AppendLine("bx r0");

            str.AppendLine("linker:");
            str.AppendLine("bx r2");
            str.AppendLine(".align 2");
            ASMCambiarPJKanto = str.ToString();
            str.Clear();
            #endregion
            #region ASM MT Black and White Sistem
            str.AppendLine(".text");
            str.AppendLine(".align 2");
            str.AppendLine(".thumb");
            str.AppendLine(".thumb_func");
            str.AppendLine("main:");
            str.AppendLine("cmp r5, #0x0");
            str.AppendLine("bne end");
            str.AppendLine("ldr r3, = (0x8OFFSET2 + 1)");
            str.AppendLine("bx r3");
            str.AppendLine("end:");
            str.AppendLine("mov r0, r7");
            str.AppendLine("mov r1, #0x8");
            str.AppendLine("mov r2, r4");
            str.AppendLine("ldr r6, = (0x8OFFSET1 + 1)");
            str.AppendLine("bl link");
            str.AppendLine("ldr r3, = (0x8OFFSET2 + 1)");
            str.AppendLine("bx r3");
            str.AppendLine("link:");
            str.AppendLine("bx r6");
            str.AppendLine(".align 2");


            ASMMTBW = str.ToString();
            str.Clear();
            #endregion
            #region ASM Pokemon incapturable
            str.AppendLine(".text");
            str.AppendLine(".align 2");
            str.AppendLine(".thumb");
            str.AppendLine(".thumb_func");
            str.AppendLine("main:");
            str.AppendLine("ldr r0, = (0x2022B4C)");
            str.AppendLine("ldr r1, [r0]");
            str.AppendLine("ldr r2, .VAR");
            str.AppendLine("ldrb r2, [r2]");
            str.AppendLine("cmp r2, #0x1");
            str.AppendLine("beq uncatchable");
            str.AppendLine("ldr r0, = (0x802D490 +1)");
            str.AppendLine("bx r0");
            str.AppendLine("uncatchable:");
            str.AppendLine("ldr r0, = (0x802D460 + 1)");
            str.AppendLine("bx r0");
            str.AppendLine(".align 2");
            str.AppendLine(".VAR:");
            str.AppendLine(".word 0x020270B8 + (0xVARIABLE* 2)");
            ASMPokemonInCapturable = str.ToString();
            str.Clear();
            #endregion
            #region ASM Shinyzer
            str.AppendLine("");
            str.AppendLine(" .text");
            str.AppendLine(".align 2");
            str.AppendLine(".thumb");
            str.AppendLine(".thumb_func");

            str.AppendLine("shiny_hack_main:");
            str.AppendLine("lsr r0, r4, #0x18");
            str.AppendLine("cmp r0, #0x3");
            str.AppendLine("bne return");
            str.AppendLine("ldr r0, .SHINY_COUNTER");
            str.AppendLine("ldrb r0, [r0]");
            str.AppendLine("cmp r0, #0x0");
            str.AppendLine("bne shiny_hack");

            str.AppendLine("return:");
            str.AppendLine("bx lr");

            str.AppendLine("shiny_hack:");
            str.AppendLine("push {r2-r5, lr");
            str.AppendLine("}");
            str.AppendLine("sub r3, r0, #0x1");
            str.AppendLine("ldr r0, .SHINY_COUNTER");
            str.AppendLine("strb r3, [r0]");
            str.AppendLine("ldrb r4, [r0, #0x1]");
            str.AppendLine("cmp r4, #0x0");
            str.AppendLine("bne is_trainer");
            str.AppendLine("add r4, r1, #0x0");

            str.AppendLine("no_trainer:");
            str.AppendLine("ldr r2, .RANDOM");
            str.AppendLine("bl branch_r2");
            str.AppendLine("mov r3, #0x7");
            str.AppendLine("and r0, r3");
            str.AppendLine("add r3, r0, #0x0");
            str.AppendLine("ldr r2, .RANDOM");
            str.AppendLine("bl branch_r2");
            str.AppendLine("lsl r5, r0, #0x10");
            str.AppendLine("orr r5, r0");
            str.AppendLine("eor r5, r3");
            str.AppendLine("eor r5, r4");
            str.AppendLine("push {r4 - r6}");
            str.AppendLine("lsr r1, r5, #0x10");
            str.AppendLine(" lsl r0, r5, #0x10");
            str.AppendLine("mvn r3, r3");
            str.AppendLine("lsr r3, r3, #0x10");
            str.AppendLine("ldr r4, .RND_MULTIPLIER");
            str.AppendLine("ldr r5, .RND_INCREMENT");

            str.AppendLine("rnd_loop:");
            str.AppendLine("add r6, r0, #0x0");
            str.AppendLine("mul r6, r4");
            str.AppendLine("add r6, r5");
            str.AppendLine("lsr r2, r6, #0x10");
            str.AppendLine("cmp r2, r1");
            str.AppendLine("beq rnd_end");
            str.AppendLine("add r0, #0x1");
            str.AppendLine("sub r3, #0x1");
            str.AppendLine("cmp r3, #0x0");
            str.AppendLine("bne rnd_loop");
            str.AppendLine("b not_found");

            str.AppendLine("rnd_end:");
            str.AppendLine("ldr r2, .RND_ADDRESS");
            str.AppendLine("str r6, [r2]");
            str.AppendLine("pop {r1, r5-r6}");
            str.AppendLine("str r5, [r7]");

            str.AppendLine("shiny_ret:");
            str.AppendLine("pop {r2-r5, pc}");

            str.AppendLine("not_found:");
            str.AppendLine("pop {r4-r6}");
            str.AppendLine("b no_trainer");

            str.AppendLine("is_trainer:");
            str.AppendLine("mov r5, #0x1");
            str.AppendLine("lsl r5, r3");
            str.AppendLine("and r4, r5");
            str.AppendLine("cmp r4, #0x0");
            str.AppendLine("beq trainer_ret");
            str.AppendLine("ldr r1, [r7]");

            str.AppendLine("trainer_ret:");
            str.AppendLine("b shiny_ret");

            str.AppendLine("branch_r2:");
            str.AppendLine("bx r2");

            str.AppendLine(".align 2");
            str.AppendLine(".RND_MULTIPLIER:");
            str.AppendLine(".word 0x41C64E6D");
            str.AppendLine(".RND_INCREMENT:");
            str.AppendLine(".word 0x00006073");
            str.AppendLine(".RND_ADDRESS:");
            str.AppendLine(".word 0x03005D80");
            str.AppendLine(".SHINY_COUNTER:");
            str.AppendLine(".word 0x020375DE");
            str.AppendLine(".RANDOM:");
            str.AppendLine(".word 0x0806F5CC|1");


            ASMShinyzer = str.ToString();
            str.Clear();
            #endregion
            #region ASM Mensaje Objeto Recivido con imagen Esmeralda USA y Rojo Fuego 10 USA
            str.AppendLine(".equ GAMECODE_BPRE, 0");
            str.AppendLine(".equ GAMECODE_BPEE, 1");
            str.AppendLine(".equ GAMECODE_AXVE, 2");

            str.AppendLine(".equ GAMECODE, #GAME");

            str.AppendLine(".THUMB");
            str.AppendLine(".ALIGN 2");

            str.AppendLine("CMP R4, #1");
            str.AppendLine("BNE END");

            str.AppendLine("MOV R0, R5");
            str.AppendLine("MOV R1, #3");
            str.AppendLine("BL BOX");

            str.AppendLine("PUSH {R0-R7}");
            str.AppendLine("LDR R0, .SCRIPT");
            str.AppendLine("LDR R0, [R0]");
            str.AppendLine("LDR R1, .SCRIPT1");
            str.AppendLine("LDR R2, .SCRIPT2");
            str.AppendLine("CMP R0, R1");
            str.AppendLine("BEQ LOAD");
            str.AppendLine("CMP R0, R2");
            str.AppendLine("BNE END_");

            str.AppendLine("LOAD:");
            str.AppendLine("LDR R0, .8007");
            str.AppendLine("LDRH R0, [R0]");
            str.AppendLine("LSL R0, R0, #3");
            str.AppendLine("LDR R5, .TABLE");
            str.AppendLine("ADD R5, R0");
            str.AppendLine("LDR R0, [R5]");
            str.AppendLine("LDR R1, .TILE");
            str.AppendLine("SWI 0x12");

            str.AppendLine("MOV R2, R1");
            str.AppendLine("LDR R0, [R5, #4]");
            str.AppendLine("LDR R1, .PAL");
            str.AppendLine("SWI 0x12");

            str.AppendLine("MOV R0, #0x7F");
            str.AppendLine("LSL R0, R0, #8");
            str.AppendLine("ADD R0, #0xFF");
            str.AppendLine("STRH R0, [R1, #0x1E]");

            str.AppendLine("MOV R0, R2");
            str.AppendLine("MOV R6, #0x12");
            str.AppendLine("LSL R6, R6, #5");
            str.AppendLine("MOV R5, #0");

            str.AppendLine("LOOP_:");
            str.AppendLine("LDRB R1, [R0, R5]");
            str.AppendLine("LDRB R2, [R0, R5]");
            str.AppendLine("MOV R3, #0x0F");
            str.AppendLine("MOV R4, #0xF0");
            str.AppendLine("AND R1, R3");
            str.AppendLine("AND R2, R4");
            str.AppendLine("CMP R1, #0");
            str.AppendLine("BNE LAST");

            str.AppendLine("MOV R1, #0x0F");

            str.AppendLine("LAST:");
            str.AppendLine("LSR R3, R2, #4");
            str.AppendLine("CMP R3, #0");
            str.AppendLine("BNE CONTROL");

            str.AppendLine("MOV R2, #0xF0");

            str.AppendLine("CONTROL:");
            str.AppendLine("ORR R2, R1");

            str.AppendLine("ADD R5, #1");
            str.AppendLine("CMP R5, #2");
            str.AppendLine("BNE BYTE");

            str.AppendLine("LSL R2, R2, #8");
            str.AppendLine("ORR R7, R2");
            str.AppendLine("STRH R7, [R0]");
            str.AppendLine("ADD R0, #2");
            str.AppendLine("MOV R5, #0");
            str.AppendLine("B COUNTER");

            str.AppendLine("BYTE:");
            str.AppendLine("MOV R7, R2");

            str.AppendLine("COUNTER:");
            str.AppendLine("SUB R6, #1");
            str.AppendLine("BPL LOOP_");

            str.AppendLine("MOV R1, #0xD");
            str.AppendLine("LSL R1, R1, #12");
            str.AppendLine("ADD R1, R1, #1");
            str.AppendLine("MOV R2, #2");
            str.AppendLine("MOV R3, #2");
            str.AppendLine("LDR R0, .RAW");
            str.AppendLine("LOOP:");
            str.AppendLine("STRH R1, [R0]");
            str.AppendLine("ADD R0, #2");
            str.AppendLine("ADD R1, #1");
            str.AppendLine("SUB R2, #1");
            str.AppendLine("BPL LOOP");
            str.AppendLine("MOV R2, #2");
            str.AppendLine("ADD R0, #0x3A");
            str.AppendLine("SUB R3, #1");
            str.AppendLine("BPL LOOP");
            str.AppendLine("END_:");
            str.AppendLine("POP {R0-R7");
            str.AppendLine("}");

            str.AppendLine("    END:");
            str.AppendLine("POP {R4, R5");
            str.AppendLine("}");
            str.AppendLine("POP {R0}");
            str.AppendLine("BX R0");

            str.AppendLine("BOX:");
            str.AppendLine("PUSH {R0}");
            str.AppendLine("LDR R0, .BOX");
            str.AppendLine("MOV R10, R0");
            str.AppendLine("POP");
            str.AppendLine("{ R0 }");
            str.AppendLine("BX R10");

            str.AppendLine(".ALIGN 2");
            str.AppendLine(".if GAMECODE==0");
            str.AppendLine(".BOX: .word 0x08003F20+1");
            str.AppendLine(".RAW: .word 0x02001C6E");
            str.AppendLine(".PAL: .word 0x02037798");
            str.AppendLine(".SCRIPT: .word 0x03000EC4");
            str.AppendLine(".SCRIPT1:	.word 0x081A6816");
            str.AppendLine(".SCRIPT2: .word 0x081A6820");
            str.AppendLine(".8007:	.word 0x020370C0");
            str.AppendLine(".TABLE:	.word 0x083D4294");
            str.AppendLine(".TILE:	.word 0x06008020");
            str.AppendLine(".elseif GAMECODE==1");
            str.AppendLine(".BOX: .word 0x08003658+1");
            str.AppendLine(".RAW: .word 0x02001C70");
            str.AppendLine(".PAL: .word 0x02037CB4");
            str.AppendLine(".SCRIPT: .word 0x03000E54");
            str.AppendLine(".SCRIPT1:	.word 0x08271C62");
            str.AppendLine(".SCRIPT2: .word 0x08271C85");
            str.AppendLine(".8007:	.word 0x020375E0");
            str.AppendLine(".TABLE:	.word 0x08614410");
            str.AppendLine(".TILE:	.word 0x06008020");
            str.AppendLine(".else");
            str.AppendLine(".fail 0");
            str.AppendLine(".endif");
            #endregion


            #region Vars BPE USA
            str.AppendLine("__aeabi_idiv = 0x82E7088 | 1");
            str.AppendLine("__aeabi_idivmod = 0x82E7088 | 1");
            str.AppendLine("__aeabi_uidiv = 0x82E7088 | 1");
            str.AppendLine("__aeabi_uidivmod = 0x82E7088 | 1");
            str.AppendLine("Random = 0x0806f5cc | 1");
            str.AppendLine("GetMonData = 0x0806a518 | 1");
            str.AppendLine("SetMonData = 0x0806acac | 1");
            str.AppendLine("CalculateMonStats = 0x08068d0c | 1");
            str.AppendLine("CalculateBoxMonChecksum = 0x08068c78 | 1");
            str.AppendLine("DecryptBoxMon = 0x0806a24c | 1");
            str.AppendLine("EncryptBoxMon = 0x0806a228 | 1");
            str.AppendLine("gPlayerParty = 0x20244ec");
            str.AppendLine("gSpecialVar_0x8004 = 0x020375e0");
            str.AppendLine("gSpecialVar_0x8005 = 0x020375e2");
            str.AppendLine("gSpecialVar_0x8006 = 0x020375e4");
            str.AppendLine("gScriptResult = 0x020375f0");
            VarsBPEUSA = str.ToString();
            str.Clear();
            #endregion
            #region Vars BPR 1.0 USA
            str.AppendLine(" __aeabi_idiv = 0x081E3B68 | 1");
            str.AppendLine(" __aeabi_idivmod = 0x081E3B68 | 1");
            str.AppendLine("__aeabi_uidiv = 0x081E3B68 | 1");
            str.AppendLine("__aeabi_uidivmod = 0x081E3B68 | 1");
            str.AppendLine("Random = 0x08044ec8 | 1");
            str.AppendLine("GetMonData = 0x0803fbe8 | 1");
            str.AppendLine("SetMonData = 0x0804037c | 1");
            str.AppendLine("CalculateMonStats = 0x0803e47c | 1");
            str.AppendLine("CalculateBoxMonChecksum = 0x0803e3e8 | 1");
            str.AppendLine("DecryptBoxMon = 0x0803f91c | 1");
            str.AppendLine("EncryptBoxMon = 0x0803f8f8 | 1");
            str.AppendLine("gPlayerParty = 0x02024284");
            str.AppendLine("gSpecialVar_0x8004 = 0x020370c0");
            str.AppendLine("gSpecialVar_0x8005 = 0x020370c2");
            str.AppendLine("gSpecialVar_0x8006 = 0x020370c4");
            str.AppendLine("gScriptResult = 0x020370d0");
            VarsBPR10USA = str.ToString();
            str.Clear();
            #endregion

            #region c_pokemon
            c_pokemon = new StringBuilder();
            c_pokemon.AppendLine("#ifndef GUARD_POKEMON_H");
            c_pokemon.AppendLine("#define GUARD_POKEMON_H");

            c_pokemon.AppendLine("#define MON_DATA_PERSONALITY        0");
            c_pokemon.AppendLine("#define MON_DATA_OT_ID              1");
            c_pokemon.AppendLine("#define MON_DATA_NICKNAME           2");
            c_pokemon.AppendLine("#define MON_DATA_LANGUAGE           3");
            c_pokemon.AppendLine("#define MON_DATA_SANITY_BIT1        4");
            c_pokemon.AppendLine("#define MON_DATA_SANITY_BIT2        5");
            c_pokemon.AppendLine("#define MON_DATA_SANITY_BIT3        6");
            c_pokemon.AppendLine("#define MON_DATA_OT_NAME            7");
            c_pokemon.AppendLine("#define MON_DATA_MARKINGS           8");
            c_pokemon.AppendLine("#define MON_DATA_CHECKSUM           9");
            c_pokemon.AppendLine("#define MON_DATA_10                10");
            c_pokemon.AppendLine("#define MON_DATA_SPECIES           11");
            c_pokemon.AppendLine("#define MON_DATA_HELD_ITEM         12");
            c_pokemon.AppendLine("#define MON_DATA_MOVE1             13");
            c_pokemon.AppendLine("#define MON_DATA_MOVE2             14");
            c_pokemon.AppendLine("#define MON_DATA_MOVE3             15");
            c_pokemon.AppendLine("#define MON_DATA_MOVE4             16");
            c_pokemon.AppendLine("#define MON_DATA_PP1               17");
            c_pokemon.AppendLine("#define MON_DATA_PP2               18");
            c_pokemon.AppendLine("#define MON_DATA_PP3               19");
            c_pokemon.AppendLine("#define MON_DATA_PP4               20");
            c_pokemon.AppendLine("#define MON_DATA_PP_BONUSES        21");
            c_pokemon.AppendLine("#define MON_DATA_COOL              22");
            c_pokemon.AppendLine("#define MON_DATA_BEAUTY            23");
            c_pokemon.AppendLine("#define MON_DATA_CUTE              24");
            c_pokemon.AppendLine("#define MON_DATA_EXP               25");
            c_pokemon.AppendLine("#define MON_DATA_HP_EV             26");
            c_pokemon.AppendLine("#define MON_DATA_ATK_EV            27");
            c_pokemon.AppendLine("#define MON_DATA_DEF_EV            28");
            c_pokemon.AppendLine("#define MON_DATA_SPD_EV            29");
            c_pokemon.AppendLine("#define MON_DATA_SPATK_EV          30");
            c_pokemon.AppendLine("#define MON_DATA_SPDEF_EV          31");
            c_pokemon.AppendLine("#define MON_DATA_FRIENDSHIP        32");
            c_pokemon.AppendLine("#define MON_DATA_SMART             33");
            c_pokemon.AppendLine("#define MON_DATA_POKERUS           34");
            c_pokemon.AppendLine("#define MON_DATA_MET_LOCATION      35");
            c_pokemon.AppendLine("#define MON_DATA_MET_LEVEL         36");
            c_pokemon.AppendLine("#define MON_DATA_MET_GAME          37");
            c_pokemon.AppendLine("#define MON_DATA_POKEBALL          38");
            c_pokemon.AppendLine("#define MON_DATA_HP_IV             39");
            c_pokemon.AppendLine("#define MON_DATA_ATK_IV            40");
            c_pokemon.AppendLine("#define MON_DATA_DEF_IV            41");
            c_pokemon.AppendLine("#define MON_DATA_SPD_IV            42");
            c_pokemon.AppendLine("#define MON_DATA_SPATK_IV          43");
            c_pokemon.AppendLine("#define MON_DATA_SPDEF_IV          44");
            c_pokemon.AppendLine("#define MON_DATA_IS_EGG            45");
            c_pokemon.AppendLine("#define MON_DATA_ALT_ABILITY       46");
            c_pokemon.AppendLine("#define MON_DATA_TOUGH             47");
            c_pokemon.AppendLine("#define MON_DATA_SHEEN             48");
            c_pokemon.AppendLine("#define MON_DATA_OT_GENDER         49");
            c_pokemon.AppendLine("#define MON_DATA_COOL_RIBBON       50");
            c_pokemon.AppendLine("#define MON_DATA_BEAUTY_RIBBON     51");
            c_pokemon.AppendLine("#define MON_DATA_CUTE_RIBBON       52");
            c_pokemon.AppendLine("#define MON_DATA_SMART_RIBBON      53");
            c_pokemon.AppendLine("#define MON_DATA_TOUGH_RIBBON      54");
            c_pokemon.AppendLine("#define MON_DATA_STATUS            55");
            c_pokemon.AppendLine("#define MON_DATA_LEVEL             56");
            c_pokemon.AppendLine("#define MON_DATA_HP                57");
            c_pokemon.AppendLine("#define MON_DATA_MAX_HP            58");
            c_pokemon.AppendLine("#define MON_DATA_ATK               59");
            c_pokemon.AppendLine("#define MON_DATA_DEF               60");
            c_pokemon.AppendLine("#define MON_DATA_SPD               61");
            c_pokemon.AppendLine("#define MON_DATA_SPATK             62");
            c_pokemon.AppendLine("#define MON_DATA_SPDEF             63");
            c_pokemon.AppendLine("#define MON_DATA_MAIL              64");
            c_pokemon.AppendLine("#define MON_DATA_SPECIES2          65");
            c_pokemon.AppendLine("#define MON_DATA_IVS               66");
            c_pokemon.AppendLine("#define MON_DATA_CHAMPION_RIBBON   67");
            c_pokemon.AppendLine("#define MON_DATA_WINNING_RIBBON    68");
            c_pokemon.AppendLine("#define MON_DATA_VICTORY_RIBBON    69");
            c_pokemon.AppendLine("#define MON_DATA_ARTIST_RIBBON     70");
            c_pokemon.AppendLine("#define MON_DATA_EFFORT_RIBBON     71");
            c_pokemon.AppendLine("#define MON_DATA_GIFT_RIBBON_1     72");
            c_pokemon.AppendLine("#define MON_DATA_GIFT_RIBBON_2     73");
            c_pokemon.AppendLine("#define MON_DATA_GIFT_RIBBON_3     74");
            c_pokemon.AppendLine("#define MON_DATA_GIFT_RIBBON_4     75");
            c_pokemon.AppendLine("#define MON_DATA_GIFT_RIBBON_5     76");
            c_pokemon.AppendLine("#define MON_DATA_GIFT_RIBBON_6     77");
            c_pokemon.AppendLine("#define MON_DATA_GIFT_RIBBON_7     78");
            c_pokemon.AppendLine("#define MON_DATA_FATEFUL_ENCOUNTER 79");
            c_pokemon.AppendLine("#define MON_DATA_OBEDIENCE         80");
            c_pokemon.AppendLine("#define MON_DATA_KNOWN_MOVES       81");
            c_pokemon.AppendLine("#define MON_DATA_RIBBON_COUNT      82");
            c_pokemon.AppendLine("#define MON_DATA_RIBBONS           83");
            c_pokemon.AppendLine("#define MON_DATA_ATK2              84");
            c_pokemon.AppendLine("#define MON_DATA_DEF2              85");
            c_pokemon.AppendLine("#define MON_DATA_SPD2              86");
            c_pokemon.AppendLine("#define MON_DATA_SPATK2            87");
            c_pokemon.AppendLine("#define MON_DATA_SPDEF2            88");

            c_pokemon.AppendLine("#define OT_ID_RANDOM_NO_SHINY 2");
            c_pokemon.AppendLine("#define OT_ID_PRESET 1");
            c_pokemon.AppendLine("#define OT_ID_PLAYER_ID 0");

            c_pokemon.AppendLine("#define MON_GIVEN_TO_PARTY      0x0");
            c_pokemon.AppendLine("#define MON_GIVEN_TO_PC         0x1");
            c_pokemon.AppendLine("#define MON_CANT_GIVE           0x2");

            c_pokemon.AppendLine("#define PLAYER_HAS_TWO_USABLE_MONS              0x0");
            c_pokemon.AppendLine("#define PLAYER_HAS_ONE_MON                      0x1");
            c_pokemon.AppendLine("#define PLAYER_HAS_ONE_USABLE_MON               0x2");

            c_pokemon.AppendLine("#define MON_MALE       0x00");
            c_pokemon.AppendLine("#define MON_FEMALE     0xFE");
            c_pokemon.AppendLine("#define MON_GENDERLESS 0xFF");

            c_pokemon.AppendLine("#define TYPE_NORMAL   0x00");
            c_pokemon.AppendLine("#define TYPE_FIGHTING 0x01");
            c_pokemon.AppendLine("#define TYPE_FLYING   0x02");
            c_pokemon.AppendLine("#define TYPE_POISON   0x03");
            c_pokemon.AppendLine("#define TYPE_GROUND   0x04");
            c_pokemon.AppendLine("#define TYPE_ROCK     0x05");
            c_pokemon.AppendLine("#define TYPE_BUG      0x06");
            c_pokemon.AppendLine("#define TYPE_GHOST    0x07");
            c_pokemon.AppendLine("#define TYPE_STEEL    0x08");
            c_pokemon.AppendLine("#define TYPE_MYSTERY  0x09");
            c_pokemon.AppendLine("#define TYPE_FIRE     0x0a");
            c_pokemon.AppendLine("#define TYPE_WATER    0x0b");
            c_pokemon.AppendLine("#define TYPE_GRASS    0x0c");
            c_pokemon.AppendLine("#define TYPE_ELECTRIC 0x0d");
            c_pokemon.AppendLine("#define TYPE_PSYCHIC  0x0e");
            c_pokemon.AppendLine("#define TYPE_ICE      0x0f");
            c_pokemon.AppendLine("#define TYPE_DRAGON   0x10");
            c_pokemon.AppendLine("#define TYPE_DARK     0x11");

            c_pokemon.AppendLine("#define NUMBER_OF_MON_TYPES     0x12");

            c_pokemon.AppendLine("#define PARTY_SIZE 6");
            c_pokemon.AppendLine("#define MAX_TOTAL_EVS 510");
            c_pokemon.AppendLine("#define NUM_STATS 6");
            c_pokemon.AppendLine("#define UNOWN_FORM_COUNT 28");
            c_pokemon.AppendLine("#define MAX_MON_LEVEL 100");


            c_pokemon.AppendLine("enum");
            c_pokemon.AppendLine("{");
            c_pokemon.AppendLine("    EGG_GROUP_NONE,");
            c_pokemon.AppendLine("    EGG_GROUP_MONSTER,");
            c_pokemon.AppendLine("    EGG_GROUP_WATER_1,");
            c_pokemon.AppendLine("    EGG_GROUP_BUG,");
            c_pokemon.AppendLine("    EGG_GROUP_FLYING,");
            c_pokemon.AppendLine("    EGG_GROUP_FIELD,");
            c_pokemon.AppendLine("    EGG_GROUP_FAIRY,");
            c_pokemon.AppendLine("    EGG_GROUP_GRASS,");
            c_pokemon.AppendLine("    EGG_GROUP_HUMAN_LIKE,");
            c_pokemon.AppendLine("    EGG_GROUP_WATER_3,");
            c_pokemon.AppendLine("    EGG_GROUP_MINERAL,");
            c_pokemon.AppendLine("    EGG_GROUP_AMORPHOUS,");
            c_pokemon.AppendLine("    EGG_GROUP_WATER_2,");
            c_pokemon.AppendLine("    EGG_GROUP_DITTO,");
            c_pokemon.AppendLine("    EGG_GROUP_DRAGON,");
            c_pokemon.AppendLine("    EGG_GROUP_UNDISCOVERED");
            c_pokemon.AppendLine("};");

            c_pokemon.AppendLine("enum");
            c_pokemon.AppendLine("{");
            c_pokemon.AppendLine("    NATURE_HARDY,");
            c_pokemon.AppendLine("    NATURE_LONELY,");
            c_pokemon.AppendLine("    NATURE_BRAVE,");
            c_pokemon.AppendLine("    NATURE_ADAMANT,");
            c_pokemon.AppendLine("    NATURE_NAUGHTY,");
            c_pokemon.AppendLine("    NATURE_BOLD,");
            c_pokemon.AppendLine("    NATURE_DOCILE,");
            c_pokemon.AppendLine("    NATURE_RELAXED,");
            c_pokemon.AppendLine("    NATURE_IMPISH,");
            c_pokemon.AppendLine("    NATURE_LAX,");
            c_pokemon.AppendLine("    NATURE_TIMID,");
            c_pokemon.AppendLine("    NATURE_HASTY,");
            c_pokemon.AppendLine("    NATURE_SERIOUS,");
            c_pokemon.AppendLine("    NATURE_JOLLY,");
            c_pokemon.AppendLine("    NATURE_NAIVE,");
            c_pokemon.AppendLine("    NATURE_MODEST,");
            c_pokemon.AppendLine("    NATURE_MILD,");
            c_pokemon.AppendLine("    NATURE_QUIET,");
            c_pokemon.AppendLine("    NATURE_BASHFUL,");
            c_pokemon.AppendLine("    NATURE_RASH,");
            c_pokemon.AppendLine("    NATURE_CALM,");
            c_pokemon.AppendLine("    NATURE_GENTLE,");
            c_pokemon.AppendLine("    NATURE_SASSY,");
            c_pokemon.AppendLine("    NATURE_CAREFUL,");
            c_pokemon.AppendLine("    NATURE_QUIRKY,");
            c_pokemon.AppendLine("};");

            c_pokemon.AppendLine("struct PokemonSubstruct0");
            c_pokemon.AppendLine("{");
            c_pokemon.AppendLine("    u16 species;");
            c_pokemon.AppendLine("    u16 heldItem;");
            c_pokemon.AppendLine("    u32 experience;");
            c_pokemon.AppendLine("    u8 ppBonuses;");
            c_pokemon.AppendLine("    u8 friendship;");
            c_pokemon.AppendLine("};");

            c_pokemon.AppendLine("struct PokemonSubstruct1");
            c_pokemon.AppendLine("{");
            c_pokemon.AppendLine("    u16 moves[4];");
            c_pokemon.AppendLine("    u8 pp[4];");
            c_pokemon.AppendLine("};");

            c_pokemon.AppendLine("struct PokemonSubstruct2");
            c_pokemon.AppendLine("{");
            c_pokemon.AppendLine("    u8 hpEV;");
            c_pokemon.AppendLine("    u8 attackEV;");
            c_pokemon.AppendLine("    u8 defenseEV;");
            c_pokemon.AppendLine("    u8 speedEV;");
            c_pokemon.AppendLine("    u8 spAttackEV;");
            c_pokemon.AppendLine("    u8 spDefenseEV;");
            c_pokemon.AppendLine("    u8 cool;");
            c_pokemon.AppendLine("    u8 beauty;");
            c_pokemon.AppendLine("    u8 cute;");
            c_pokemon.AppendLine("    u8 smart;");
            c_pokemon.AppendLine("    u8 tough;");
            c_pokemon.AppendLine("    u8 sheen;");
            c_pokemon.AppendLine("};");

            c_pokemon.AppendLine("struct PokemonSubstruct3");
            c_pokemon.AppendLine("{");
            c_pokemon.AppendLine(" /* 0x00 */ u8 pokerus;");
            c_pokemon.AppendLine(" /* 0x01 */ u8 metLocation;");

            c_pokemon.AppendLine(" /* 0x02 */ u16 metLevel:7;");
            c_pokemon.AppendLine(" /* 0x02 */ u16 metGame:4;");
            c_pokemon.AppendLine(" /* 0x03 */ u16 pokeball:4;");
            c_pokemon.AppendLine(" /* 0x03 */ u16 otGender:1;");

            c_pokemon.AppendLine(" /* 0x04 */ u32 hpIV:5;");
            c_pokemon.AppendLine(" /* 0x04 */ u32 attackIV:5;");
            c_pokemon.AppendLine(" /* 0x05 */ u32 defenseIV:5;");
            c_pokemon.AppendLine(" /* 0x05 */ u32 speedIV:5;");
            c_pokemon.AppendLine(" /* 0x05 */ u32 spAttackIV:5;");
            c_pokemon.AppendLine(" /* 0x06 */ u32 spDefenseIV:5;");
            c_pokemon.AppendLine(" /* 0x07 */ u32 isEgg:1;");
            c_pokemon.AppendLine(" /* 0x07 */ u32 altAbility:1;");

            c_pokemon.AppendLine(" /* 0x08 */ u32 coolRibbon:3;");
            c_pokemon.AppendLine(" /* 0x08 */ u32 beautyRibbon:3;");
            c_pokemon.AppendLine(" /* 0x08 */ u32 cuteRibbon:3;");
            c_pokemon.AppendLine(" /* 0x09 */ u32 smartRibbon:3;");
            c_pokemon.AppendLine(" /* 0x09 */ u32 toughRibbon:3;");
            c_pokemon.AppendLine(" /* 0x09 */ u32 championRibbon:1;");
            c_pokemon.AppendLine(" /* 0x0A */ u32 winningRibbon:1;");
            c_pokemon.AppendLine(" /* 0x0A */ u32 victoryRibbon:1;");
            c_pokemon.AppendLine(" /* 0x0A */ u32 artistRibbon:1;");
            c_pokemon.AppendLine(" /* 0x0A */ u32 effortRibbon:1;");
            c_pokemon.AppendLine(" /* 0x0A */ u32 giftRibbon1:1;");
            c_pokemon.AppendLine(" /* 0x0A */ u32 giftRibbon2:1;");
            c_pokemon.AppendLine(" /* 0x0A */ u32 giftRibbon3:1;");
            c_pokemon.AppendLine(" /* 0x0A */ u32 giftRibbon4:1;");
            c_pokemon.AppendLine(" /* 0x0B */ u32 giftRibbon5:1;");
            c_pokemon.AppendLine(" /* 0x0B */ u32 giftRibbon6:1;");
            c_pokemon.AppendLine(" /* 0x0B */ u32 giftRibbon7:1;");
            c_pokemon.AppendLine(" /* 0x0B */ u32 fatefulEncounter:4;");
            c_pokemon.AppendLine(" /* 0x0B */ u32 obedient:1;");
            c_pokemon.AppendLine("};");

            c_pokemon.AppendLine("union PokemonSubstruct");
            c_pokemon.AppendLine("{");
            c_pokemon.AppendLine("    struct PokemonSubstruct0 type0;");
            c_pokemon.AppendLine("    struct PokemonSubstruct1 type1;");
            c_pokemon.AppendLine("    struct PokemonSubstruct2 type2;");
            c_pokemon.AppendLine("    struct PokemonSubstruct3 type3;");
            c_pokemon.AppendLine("    u16 raw[6];");
            c_pokemon.AppendLine("};");

            c_pokemon.AppendLine("struct BoxPokemon");
            c_pokemon.AppendLine("{");
            c_pokemon.AppendLine("    u32 personality;");
            c_pokemon.AppendLine("    u32 otId;");
            c_pokemon.AppendLine("    u8 nickname[10];");
            c_pokemon.AppendLine("    u8 language;");
            c_pokemon.AppendLine("    u8 isBadEgg:1;");
            c_pokemon.AppendLine("    u8 hasSpecies:1;");
            c_pokemon.AppendLine("    u8 isEgg:1;");
            c_pokemon.AppendLine("    u8 unused:5;");
            c_pokemon.AppendLine("    u8 otName[7];");
            c_pokemon.AppendLine("    u8 markings;");
            c_pokemon.AppendLine("    u16 checksum;");
            c_pokemon.AppendLine("    u16 unknown;");

            c_pokemon.AppendLine("    union");
            c_pokemon.AppendLine("    {");
            c_pokemon.AppendLine("        u32 raw[12];");
            c_pokemon.AppendLine("        union PokemonSubstruct substructs[4];");
            c_pokemon.AppendLine("    } secure;");
            c_pokemon.AppendLine("};");

            c_pokemon.AppendLine("struct Pokemon");
            c_pokemon.AppendLine("{");
            c_pokemon.AppendLine("    struct BoxPokemon box;");
            c_pokemon.AppendLine("    u32 status;");
            c_pokemon.AppendLine("    u8 level;");
            c_pokemon.AppendLine("    u8 mail;");
            c_pokemon.AppendLine("    u16 hp;");
            c_pokemon.AppendLine("    u16 maxHP;");
            c_pokemon.AppendLine("    u16 attack;");
            c_pokemon.AppendLine("    u16 defense;");
            c_pokemon.AppendLine("    u16 speed;");
            c_pokemon.AppendLine("    u16 spAttack;");
            c_pokemon.AppendLine("    u16 spDefense;");
            c_pokemon.AppendLine("};");

            c_pokemon.AppendLine("struct PokemonStorage");
            c_pokemon.AppendLine("{");
            c_pokemon.AppendLine("    /*0x0000*/ u8 currentBox;");
            c_pokemon.AppendLine("    /*0x0001*/ struct BoxPokemon boxes[14][30];");
            c_pokemon.AppendLine("    /*0x8344*/ u8 boxNames[14][9];");
            c_pokemon.AppendLine("    /*0x83C2*/ u8 boxWallpapers[14];");
            c_pokemon.AppendLine("};");

            c_pokemon.AppendLine("struct UnknownPokemonStruct");
            c_pokemon.AppendLine("{");
            c_pokemon.AppendLine("    u16 species;");
            c_pokemon.AppendLine("    u16 heldItem;");
            c_pokemon.AppendLine("    u16 moves[4];");
            c_pokemon.AppendLine("    u8 level;");
            c_pokemon.AppendLine("    u8 ppBonuses;");
            c_pokemon.AppendLine("    u8 hpEV;");
            c_pokemon.AppendLine("    u8 attackEV;");
            c_pokemon.AppendLine("    u8 defenseEV;");
            c_pokemon.AppendLine("    u8 speedEV;");
            c_pokemon.AppendLine("    u8 spAttackEV;");
            c_pokemon.AppendLine("    u8 spDefenseEV;");
            c_pokemon.AppendLine("    u32 otId;");
            c_pokemon.AppendLine("    u32 hpIV:5;");
            c_pokemon.AppendLine("    u32 attackIV:5;");
            c_pokemon.AppendLine("    u32 defenseIV:5;");
            c_pokemon.AppendLine("    u32 speedIV:5;");
            c_pokemon.AppendLine("    u32 spAttackIV:5;");
            c_pokemon.AppendLine("    u32 spDefenseIV:5;");
            c_pokemon.AppendLine("    u32 gap:1;");
            c_pokemon.AppendLine("    u32 altAbility:1;");
            c_pokemon.AppendLine("    u32 personality;");
            c_pokemon.AppendLine("    u8 nickname[11];");
            c_pokemon.AppendLine("    u8 friendship;");
            c_pokemon.AppendLine("};");

            c_pokemon.AppendLine("#define BATTLE_STATS_NO 8");

            c_pokemon.AppendLine("struct BattlePokemon");
            c_pokemon.AppendLine("{");
            c_pokemon.AppendLine("    /*0x00*/ u16 species;");
            c_pokemon.AppendLine("    /*0x02*/ u16 attack;");
            c_pokemon.AppendLine("    /*0x04*/ u16 defense;");
            c_pokemon.AppendLine("    /*0x06*/ u16 speed;");
            c_pokemon.AppendLine("    /*0x08*/ u16 spAttack;");
            c_pokemon.AppendLine("    /*0x0A*/ u16 spDefense;");
            c_pokemon.AppendLine("    /*0x0C*/ u16 moves[4];");
            c_pokemon.AppendLine("    /*0x14*/ u32 hpIV:5;");
            c_pokemon.AppendLine("    /*0x14*/ u32 attackIV:5;");
            c_pokemon.AppendLine("    /*0x15*/ u32 defenseIV:5;");
            c_pokemon.AppendLine("    /*0x15*/ u32 speedIV:5;");
            c_pokemon.AppendLine("    /*0x16*/ u32 spAttackIV:5;");
            c_pokemon.AppendLine("    /*0x17*/ u32 spDefenseIV:5;");
            c_pokemon.AppendLine("    /*0x17*/ u32 isEgg:1;");
            c_pokemon.AppendLine("    /*0x17*/ u32 altAbility:1;");
            c_pokemon.AppendLine("    /*0x18*/ s8 statStages[BATTLE_STATS_NO];");
            c_pokemon.AppendLine("    /*0x20*/ u8 ability;");
            c_pokemon.AppendLine("    /*0x21*/ u8 type1;");
            c_pokemon.AppendLine("    /*0x22*/ u8 type2;");
            c_pokemon.AppendLine("    /*0x23*/ u8 unknown;");
            c_pokemon.AppendLine("    /*0x24*/ u8 pp[4];");
            c_pokemon.AppendLine("    /*0x28*/ u16 hp;");
            c_pokemon.AppendLine("    /*0x2A*/ u8 level;");
            c_pokemon.AppendLine("    /*0x2B*/ u8 friendship;");
            c_pokemon.AppendLine("    /*0x2C*/ u16 maxHP;");
            c_pokemon.AppendLine("    /*0x2E*/ u16 item;");
            c_pokemon.AppendLine("    /*0x30*/ u8 nickname[11];");
            c_pokemon.AppendLine("    /*0x3B*/ u8 ppBonuses;");
            c_pokemon.AppendLine("    /*0x3C*/ u8 otName[8];");
            c_pokemon.AppendLine("    /*0x44*/ u32 experience;");
            c_pokemon.AppendLine("    /*0x48*/ u32 personality;");
            c_pokemon.AppendLine("    /*0x4C*/ u32 status1;");
            c_pokemon.AppendLine("    /*0x50*/ u32 status2;");
            c_pokemon.AppendLine("    /*0x54*/ u32 otId;");
            c_pokemon.AppendLine("};");

            c_pokemon.AppendLine("enum");
            c_pokemon.AppendLine("{");
            c_pokemon.AppendLine("    STAT_STAGE_HP,       // 0");
            c_pokemon.AppendLine("    STAT_STAGE_ATK,      // 1");
            c_pokemon.AppendLine("    STAT_STAGE_DEF,      // 2");
            c_pokemon.AppendLine("    STAT_STAGE_SPEED,    // 3");
            c_pokemon.AppendLine("    STAT_STAGE_SPATK,    // 4");
            c_pokemon.AppendLine("    STAT_STAGE_SPDEF,    // 5");
            c_pokemon.AppendLine("    STAT_STAGE_ACC,      // 6");
            c_pokemon.AppendLine("    STAT_STAGE_EVASION,  // 7");
            c_pokemon.AppendLine("};");

            c_pokemon.AppendLine("enum");
            c_pokemon.AppendLine("{");
            c_pokemon.AppendLine("    STAT_HP,     // 0");
            c_pokemon.AppendLine("    STAT_ATK,    // 1");
            c_pokemon.AppendLine("    STAT_DEF,    // 2");
            c_pokemon.AppendLine("    STAT_SPD,    // 3");
            c_pokemon.AppendLine("    STAT_SPATK,  // 4");
            c_pokemon.AppendLine("    STAT_SPDEF,  // 5");
            c_pokemon.AppendLine("};");

            c_pokemon.AppendLine("struct BaseStats");
            c_pokemon.AppendLine("{");
            c_pokemon.AppendLine(" /* 0x00 */ u8 baseHP;");
            c_pokemon.AppendLine(" /* 0x01 */ u8 baseAttack;");
            c_pokemon.AppendLine(" /* 0x02 */ u8 baseDefense;");
            c_pokemon.AppendLine(" /* 0x03 */ u8 baseSpeed;");
            c_pokemon.AppendLine(" /* 0x04 */ u8 baseSpAttack;");
            c_pokemon.AppendLine(" /* 0x05 */ u8 baseSpDefense;");
            c_pokemon.AppendLine(" /* 0x06 */ u8 type1;");
            c_pokemon.AppendLine(" /* 0x07 */ u8 type2;");
            c_pokemon.AppendLine(" /* 0x08 */ u8 catchRate;");
            c_pokemon.AppendLine(" /* 0x09 */ u8 expYield;");
            c_pokemon.AppendLine(" /* 0x0A */ u16 evYield_HP:2;");
            c_pokemon.AppendLine(" /* 0x0A */ u16 evYield_Attack:2;");
            c_pokemon.AppendLine(" /* 0x0A */ u16 evYield_Defense:2;");
            c_pokemon.AppendLine(" /* 0x0A */ u16 evYield_Speed:2;");
            c_pokemon.AppendLine(" /* 0x0B */ u16 evYield_SpAttack:2;");
            c_pokemon.AppendLine(" /* 0x0B */ u16 evYield_SpDefense:2;");
            c_pokemon.AppendLine(" /* 0x0C */ u16 item1;");
            c_pokemon.AppendLine(" /* 0x0E */ u16 item2;");
            c_pokemon.AppendLine(" /* 0x10 */ u8 genderRatio;");
            c_pokemon.AppendLine(" /* 0x11 */ u8 eggCycles;");
            c_pokemon.AppendLine(" /* 0x12 */ u8 friendship;");
            c_pokemon.AppendLine(" /* 0x13 */ u8 growthRate;");
            c_pokemon.AppendLine(" /* 0x14 */ u8 eggGroup1;");
            c_pokemon.AppendLine(" /* 0x15 */ u8 eggGroup2;");
            c_pokemon.AppendLine(" /* 0x16 */ u8 ability1;");
            c_pokemon.AppendLine(" /* 0x17 */ u8 ability2;");
            c_pokemon.AppendLine(" /* 0x18 */ u8 safariZoneFleeRate;");
            c_pokemon.AppendLine(" /* 0x19 */ u8 bodyColor : 7;");
            c_pokemon.AppendLine("            u8 noFlip : 1;");
            c_pokemon.AppendLine("};");

            c_pokemon.AppendLine("struct BattleMove");
            c_pokemon.AppendLine("{");
            c_pokemon.AppendLine("    u8 effect;");
            c_pokemon.AppendLine("    u8 power;");
            c_pokemon.AppendLine("    u8 type;");
            c_pokemon.AppendLine("    u8 accuracy;");
            c_pokemon.AppendLine("    u8 pp;");
            c_pokemon.AppendLine("    u8 secondaryEffectChance;");
            c_pokemon.AppendLine("    u8 target;");
            c_pokemon.AppendLine("    u8 priority;");
            c_pokemon.AppendLine("    u8 flags;");
            c_pokemon.AppendLine("};");

            c_pokemon.AppendLine("#define FLAG_MAKES_CONTACT          0x1");
            c_pokemon.AppendLine("#define FLAG_PROTECT_AFFECTED       0x2");
            c_pokemon.AppendLine("#define FLAG_MAGICCOAT_AFFECTED     0x4");
            c_pokemon.AppendLine("#define FLAG_SNATCH_AFFECTED        0x8");
            c_pokemon.AppendLine("#define FLAG_MIRROR_MOVE_AFFECTED   0x10");
            c_pokemon.AppendLine("#define FLAG_KINGSROCK_AFFECTED     0x20");

            c_pokemon.AppendLine("struct SpindaSpot");
            c_pokemon.AppendLine("{");
            c_pokemon.AppendLine("    u8 x, y;");
            c_pokemon.AppendLine("    u16 image[16];");
            c_pokemon.AppendLine("};");

            c_pokemon.AppendLine("struct __attribute__((packed)) LevelUpMove");
            c_pokemon.AppendLine("{");
            c_pokemon.AppendLine("    u16 move:9;");
            c_pokemon.AppendLine("    u16 level:7;");
            c_pokemon.AppendLine("};");

            c_pokemon.AppendLine("enum");
            c_pokemon.AppendLine("{");
            c_pokemon.AppendLine("    GROWTH_MEDIUM_FAST,");
            c_pokemon.AppendLine("    GROWTH_ERRATIC,");
            c_pokemon.AppendLine("    GROWTH_FLUCTUATING,");
            c_pokemon.AppendLine("    GROWTH_MEDIUM_SLOW,");
            c_pokemon.AppendLine("    GROWTH_FAST,");
            c_pokemon.AppendLine("    GROWTH_SLOW");
            c_pokemon.AppendLine("};");

            c_pokemon.AppendLine("enum");
            c_pokemon.AppendLine("{");
            c_pokemon.AppendLine("    BODY_COLOR_RED,");
            c_pokemon.AppendLine("    BODY_COLOR_BLUE,");
            c_pokemon.AppendLine("    BODY_COLOR_YELLOW,");
            c_pokemon.AppendLine("    BODY_COLOR_GREEN,");
            c_pokemon.AppendLine("    BODY_COLOR_BLACK,");
            c_pokemon.AppendLine("    BODY_COLOR_BROWN,");
            c_pokemon.AppendLine("    BODY_COLOR_PURPLE,");
            c_pokemon.AppendLine("    BODY_COLOR_GRAY,");
            c_pokemon.AppendLine("    BODY_COLOR_WHITE,");
            c_pokemon.AppendLine("    BODY_COLOR_PINK");
            c_pokemon.AppendLine("};");

            c_pokemon.AppendLine("#define EVO_FRIENDSHIP       0x0001 // Pokémon levels up with friendship ≥ 220");
            c_pokemon.AppendLine("#define EVO_FRIENDSHIP_DAY   0x0002 // Pokémon levels up during the day with friendship ≥ 220");
            c_pokemon.AppendLine("#define EVO_FRIENDSHIP_NIGHT 0x0003 // Pokémon levels up at night with friendship ≥ 220");
            c_pokemon.AppendLine("#define EVO_LEVEL            0x0004 // Pokémon reaches the specified level");
            c_pokemon.AppendLine("#define EVO_TRADE            0x0005 // Pokémon is traded");
            c_pokemon.AppendLine("#define EVO_TRADE_ITEM       0x0006 // Pokémon is traded while it's holding the specified item");
            c_pokemon.AppendLine("#define EVO_ITEM             0x0007 // specified item is used on Pokémon");
            c_pokemon.AppendLine("#define EVO_LEVEL_ATK_GT_DEF 0x0008 // Pokémon reaches the specified level with attack > defense");
            c_pokemon.AppendLine("#define EVO_LEVEL_ATK_EQ_DEF 0x0009 // Pokémon reaches the specified level with attack = defense");
            c_pokemon.AppendLine("#define EVO_LEVEL_ATK_LT_DEF 0x000a // Pokémon reaches the specified level with attack < defense");
            c_pokemon.AppendLine("#define EVO_LEVEL_SILCOON    0x000b // Pokémon reaches the specified level with a Silcoon personality value");
            c_pokemon.AppendLine("#define EVO_LEVEL_CASCOON    0x000c // Pokémon reaches the specified level with a Cascoon personality value");
            c_pokemon.AppendLine("#define EVO_LEVEL_NINJASK    0x000d // Pokémon reaches the specified level (special value for Ninjask)");
            c_pokemon.AppendLine("#define EVO_LEVEL_SHEDINJA   0x000e // Pokémon reaches the specified level (special value for Shedinja)");
            c_pokemon.AppendLine("#define EVO_BEAUTY           0x000f // Pokémon levels up with beauty ≥ specified value");

            c_pokemon.AppendLine("struct Evolution");
            c_pokemon.AppendLine("{");
            c_pokemon.AppendLine("    u16 method;");
            c_pokemon.AppendLine("    u16 param;");
            c_pokemon.AppendLine("    u16 targetSpecies;");
            c_pokemon.AppendLine("};");

            c_pokemon.AppendLine("struct EvolutionData");
            c_pokemon.AppendLine("{");
            c_pokemon.AppendLine("    struct Evolution evolutions[5];");
            c_pokemon.AppendLine("};");

            c_pokemon.AppendLine("u32 GetMonData(struct Pokemon *mon, s32 field, u8* data);");
            c_pokemon.AppendLine("void SetMonData(struct Pokemon *mon, s32 field, const void *data);");

            c_pokemon.AppendLine("#endif // GUARD_POKEMON_H");
            CPokemon = c_pokemon.ToString();
            #endregion
            #region c_types
            c_types = new StringBuilder();
            c_types.AppendLine("#ifndef POKEAGB_TYPES_H_");
            c_types.AppendLine("#define POKEAGB_TYPES_H_");


            c_types.AppendLine("typedef unsigned char u8;");
            c_types.AppendLine("typedef unsigned short int u16;");
            c_types.AppendLine("typedef unsigned int u32;");
            c_types.AppendLine("typedef signed char s8;");
            c_types.AppendLine("typedef signed short int s16;");
            c_types.AppendLine("typedef signed int s32;");
            c_types.AppendLine("typedef volatile u8 vu8;");
            c_types.AppendLine("typedef volatile u16 vu16;");
            c_types.AppendLine("typedef volatile u32 vu32;");
            c_types.AppendLine("typedef volatile s8 vs8;");
            c_types.AppendLine("typedef volatile s16 vs16;");
            c_types.AppendLine("typedef volatile s32 vs32;");


            c_types.AppendLine("#endif /* POKEAGB_TYPES_H_ */");
            CTypes = c_types.ToString();
            #endregion
        }

    }
}
