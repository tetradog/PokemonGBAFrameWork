/*
 * Usuario: Pikachu240
 * Licencia GNU GPL V3
 */
using System;

namespace PokemonGBAFrameWork.ComandosScript
{
    /// <summary>
    /// Description of EndTrainterBattle2.
    /// </summary>
    public class EndTrainerBattle2 : Comando
    {
        public const byte ID = 0x5F;
        public const string NOMBRE = "EndTrainterBattle2";
        public const string DESCRIPCION = "Vuelve desde la batalla contra el entrenador sin acabar el mensaje";


        public EndTrainerBattle2()
        {

        }

        public EndTrainerBattle2(RomGba rom, int offset) : base(rom, offset)
        {
        }
        public EndTrainerBattle2(byte[] bytesScript, int offset) : base(bytesScript, offset)
        { }
        public unsafe EndTrainerBattle2(byte* ptRom, int offset) : base(ptRom, offset)
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
