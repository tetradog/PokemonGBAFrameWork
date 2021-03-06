﻿/*
 * Creado por SharpDevelop.
 * Usuario: Pikachu240
 * Fecha: 02/06/2017
 * Hora: 15:32
 * Licencia GNU GPL V3
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace PokemonGBAFramework.Core.ComandosScript
{
	/// <summary>
	/// Description of GetPlayerPos.
	/// </summary>
	public class GetPlayerPos:Comando
	{
		public const byte ID = 0x42;

		public new const int SIZE = Comando.SIZE+Word.LENGTH+Word.LENGTH;
        public const string NOMBRE = "GetPlayerPos";
        public const string DESCRIPCION = "Obtiene las coordenadas X,Y del jugador";
		public GetPlayerPos() { }
        public GetPlayerPos(Word coordenadaX,Word coordenadaY)
		{
			CoordenadaX=coordenadaX;
			CoordenadaY=coordenadaY;
			
		}

		public GetPlayerPos(ScriptAndASMManager scriptManager,RomGba rom, int offset)  : base(scriptManager,rom, offset)
		{
		}

		public GetPlayerPos(ScriptAndASMManager scriptManager,byte[] bytesScript, int offset) : base(scriptManager,bytesScript, offset)
		{
		}

		public unsafe GetPlayerPos(ScriptAndASMManager scriptManager,byte* ptRom, int offset) : base(scriptManager,ptRom, offset)
		{
		}

		public override string Nombre {
			get {
                return NOMBRE;
			}
		}

		public override byte IdComando {
			get {
				return ID;
			}
		}

		public override string Descripcion {
			get {
                return DESCRIPCION;
			}
		}
		public override int Size {
			get {
				return SIZE;
			}
		}

        public Word CoordenadaX { get; set; }

        public Word CoordenadaY { get; set; }
        public override System.Collections.Generic.IList<Gabriel.Cat.S.Utilitats.Propiedad> GetParams()
		{
			return new Gabriel.Cat.S.Utilitats.Propiedad[]{ new Gabriel.Cat.S.Utilitats.Propiedad(this, nameof(CoordenadaX)), new Gabriel.Cat.S.Utilitats.Propiedad(this, nameof(CoordenadaY))};
		}
		protected unsafe override void CargarCamando(ScriptAndASMManager scriptManager,byte* ptrRom, int offsetComando)
		{
			CoordenadaX=new Word(ptrRom,offsetComando);
			offsetComando+=Word.LENGTH;
			CoordenadaY=new Word(ptrRom,offsetComando);
		}
		public override byte[] GetBytesTemp()
		{
			byte[] data=new byte[Size];
			data[0]=IdComando;
			Word.SetData(data,1,CoordenadaX);
 
			Word.SetData(data,3,CoordenadaY);
			return data;
		}
	}
}
