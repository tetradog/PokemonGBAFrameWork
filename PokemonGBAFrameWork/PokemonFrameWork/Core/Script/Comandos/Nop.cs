﻿/*
 * Creado por SharpDevelop.
 * Usuario: Pikachu240
 * Fecha: 31/05/2017
 * Hora: 21:02
 * Licencia GNU GPL V3
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace PokemonGBAFrameWork
{
	/// <summary>
	/// Description of Nop.
	/// </summary>
	public class Nop:Comando
	{
		public const byte ID=0x0;
		public const int SIZE=1;
		
		public Nop(RomGba rom,int offset):base(rom,offset)
		{}
		public Nop(byte[] bytesScript,int offset):base(bytesScript,offset)
		{}
		public unsafe Nop(byte* ptRom,int offset):base(ptRom,offset)
		{}
		public override string Descripcion {
			get {
				return "No hace absolutamente nada";
			}
		}
		public override byte IdComando {
			get {
				return ID;
			}
		}
		public override string Nombre {
			get {
				return "Nop";
			}
		}
		public override int Size {
			get {
				return SIZE;
			}
		}

		
	}
	public class Nop1:Nop
	{
		public const byte ID=0x1;
		public Nop1(RomGba rom,int offset):base(rom,offset)
		{}
		public Nop1(byte[] bytesScript,int offset):base(bytesScript,offset)
		{}
		public unsafe Nop1(byte* ptRom,int offset):base(ptRom,offset)
		{}
		public override string Nombre {
			get {
				return "Nop1";
			}
		}
		public override byte IdComando {
			get {
				return ID;
			}
		}
	}
	public class Jumpram:Nop{
			public const byte ID=0xC;
		public Jumpram(RomGba rom,int offset):base(rom,offset)
		{}
		public Jumpram(byte[] bytesScript,int offset):base(bytesScript,offset)
		{}
		public unsafe Jumpram(byte* ptRom,int offset):base(ptRom,offset)
		{}
		public override string Nombre {
			get {
				return "Jumpram";
			}
		}
		public override byte IdComando {
			get {
				return ID;
			}
		}
		public override string Descripcion {
			get {
				return "Salta a la dirección por defecto de la memoria ram y ejecuta el script guardado allí";
			}
		}
	}
	public class Killscript:Nop{
			public const byte ID=0xD;
		public Killscript(RomGba rom,int offset):base(rom,offset)
		{}
		public Killscript(byte[] bytesScript,int offset):base(bytesScript,offset)
		{}
		public unsafe Killscript(byte* ptRom,int offset):base(ptRom,offset)
		{}
		public override string Nombre {
			get {
				return "Killscript";
			}
		}
		public override byte IdComando {
			get {
				return ID;
			}
		}
		public override string Descripcion {
			get {
				return "Acaba con el script y restaura la ram ";
			}
		}
	}
}
