﻿using Gabriel.Cat.S.Extension;
using Gabriel.Cat.S.Utilitats;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonGBAFrameWork
{
   public class DWord : IComparable, IComparable<DWord>
    {
        public const int LENGTH = 4;

        byte[] dWord;

        public DWord(uint dWord)
        {
            this.dWord = Serializar.GetBytes(dWord);
        }
        public DWord(RomData rom, int offsetDWord)
            : this(rom.Rom, offsetDWord)
        {
        }
        public DWord(RomGba rom, int offsetDWord)
            : this(rom.Data, offsetDWord)
        {
        }
        public DWord(BloqueBytes rom, int offsetDWord)
            : this(rom.Bytes, offsetDWord)
        {
        }
        public DWord(byte[] rom, int offsetDWord)
        {
            unsafe
            {
                fixed (byte* ptrRom = rom)
                {
                    dWord = new DWord(ptrRom + offsetDWord).dWord;
                }

            }
        }
        public unsafe DWord(byte* ptrRom, int offsetDWord)
            : this(ptrRom + offsetDWord)
        {
        }
        public unsafe DWord(byte* ptrRomPosicionado)
        {
            dWord = MetodosUnsafe.ReadBytes(ptrRomPosicionado, LENGTH);
        }
        public byte[] Data
        {
            get { return dWord; }
        }

        #region IComparable implementation
        public int CompareTo(object obj)
        {
            return CompareTo(obj as DWord);
        }
        #endregion
        #region IComparable implementation
        public int CompareTo(DWord other)
        {
            int compareTo;
            if (other != null)
            {
                compareTo = ((uint)this).CompareTo((uint)other);
            }
            else
                compareTo = (int)Gabriel.Cat.S.Utilitats.CompareTo.Inferior;

            return compareTo;
        }
        #endregion
        #region Equals and GetHashCode implementation
        public override bool Equals(object obj)
        {
            DWord other = obj as DWord;
            bool isEquals;
            if (other == null)
                isEquals = false;
            else
                isEquals = this.dWord.ArrayEqual(other.dWord);
            return isEquals;
        }
        public override string ToString()
        {
            return (Hex)((uint)this);
        }
        public override int GetHashCode()
        {
            int hashCode = 0;
            unchecked
            {
                if (dWord != null)
                    hashCode += 1000000007 * dWord.GetHashCode();
            }
            return hashCode;
        }

        public static void SetDWord(RomData rom, int offset, DWord dWord)
        {
            SetDWord(rom.Rom, offset, dWord);
        }
        public static void SetDWord(RomGba rom, int offset, DWord dWord)
        {
            SetDWord(rom.Data, offset, dWord);
        }
        public static void SetDWord(BloqueBytes datos, int offset, DWord dWord)
        {
            SetDWord(datos.Bytes, offset, dWord);
        }
        public static void SetDWord(byte[] datos, int offset, DWord dWord)
        {
            unsafe
            {
                fixed (byte* ptrDatos = datos)
                    SetDWord(ptrDatos, offset, dWord);

            }
        }
        public static unsafe void SetDWord(byte* ptrDatos, int offset, DWord dWord)
        {
            SetDWord(ptrDatos + offset, dWord);
        }
        public static unsafe void SetDWord(byte* ptrDatosPosicionados, DWord dWord)
        {
            MetodosUnsafe.WriteBytes(ptrDatosPosicionados, dWord);
        }


        public static bool operator ==(DWord lhs, DWord rhs)
        {
            bool iguales;
            if (ReferenceEquals(lhs, rhs))
                iguales = true;
            else if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
                iguales = false;
            else
                iguales = lhs.Equals(rhs);

            return iguales;

        }

        public static bool operator !=(DWord lhs, DWord rhs)
        {
            return !(lhs == rhs);
        }

        #endregion
        public static implicit operator byte[] (DWord dWord)
        {
            return dWord.dWord;
        }
        public static implicit operator uint(DWord dWord)
        {
            return Serializar.ToUInt(dWord.dWord);
        }
        public static implicit operator DWord(uint dWord)
        {
            return new DWord(dWord);
        }
        public static implicit operator Hex(DWord dWord)
        {
            return (Hex)dWord.dWord.ReverseArray();
        }
        public static implicit operator DWord(Hex dWord)
        {
            return new DWord((uint)dWord);
        }
    }
}
