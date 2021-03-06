/*
 * Usuario: Pikachu240
 * Licencia GNU GPL V3
 */
using System;

namespace PokemonGBAFramework.Core.ComandosScript
{
    /// <summary>
    /// Description of CmdD5.
    /// </summary>
    public class CmdD5 : Comando
    {
        public const byte ID = 0xD5;
        public const string NOMBRE = "CmdD5";
        public const string DESCRIPCION= "Bajo investigacion.Podria actuar como nop.";
        public CmdD5()
        {

        }

        public CmdD5(ScriptAndASMManager scriptManager, RomGba rom, int offset)  : base(scriptManager,rom, offset)
        {
        }
        public CmdD5(ScriptAndASMManager scriptManager,byte[] bytesScript, int offset) : base(scriptManager,bytesScript, offset)
        { }
        public unsafe CmdD5(ScriptAndASMManager scriptManager,byte* ptRom, int offset) : base(scriptManager,ptRom, offset)
        { }
        public override string Descripcion
        {
            get
            {
                return DESCRIPCION;
            }
        }

        public override byte IdComando
        {
            get
            {
                return ID;
            }
        }
        public override string Nombre
        {
            get
            {
                return NOMBRE;
            }
        }



    }
}
