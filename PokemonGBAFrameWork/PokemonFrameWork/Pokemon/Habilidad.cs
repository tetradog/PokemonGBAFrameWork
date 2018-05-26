﻿/*
 * Created by SharpDevelop.
 * User: Pikachu240
 * Date: 15/03/2017
 * Time: 17:52
 * 
 * Código bajo licencia GNU
 * créditos Wahackforo (los usuarios que han contribuido para hacer el mapa de la rom pokemon fire red 1.0)
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using Gabriel.Cat.S.Binaris;
using PokemonGBAFrameWork.Habilidad;
using System;
using System.Collections.Generic;

namespace PokemonGBAFrameWork
{
    /// <summary>
    /// Description of Habilidad.
    /// </summary>
    public class HabilidadCompleta:IElementoBinarioComplejo
    {

        public static readonly ElementoBinario Serializador = ElementoBinario.GetSerializador<HabilidadCompleta>();

        public Descripcion Descripcion { get; set; }
        public Nombre Nombre { get; set; }

        ElementoBinario IElementoBinarioComplejo.Serialitzer => Serializador;

        public HabilidadCompleta()
        {

            Descripcion = new Descripcion();
            Nombre = new Nombre();
        }


        public override string ToString()
        {
            return Nombre.ToString();
        }
        public static int GetTotal(RomGba rom)
        {
            return 78;
        }



        public static HabilidadCompleta GetHabilidad(RomGba rom, int index)
        {
            HabilidadCompleta habilidad = new HabilidadCompleta();
            habilidad.Nombre = Nombre.GetNombre(rom, index);
            habilidad.Descripcion = Descripcion.GetDescripcion(rom, index);
            return habilidad;
        }

        public static HabilidadCompleta[] GetHabilidades(RomGba rom)
        {
            HabilidadCompleta[] habilidades = new HabilidadCompleta[GetTotal(rom)];
            for (int i = 0; i < habilidades.Length; i++)
                habilidades[i] = GetHabilidad(rom, i);
            return habilidades;
        }

        public static void SetHabilidades(RomGba rom, IList<HabilidadCompleta> habilidades)
        {

            List<Nombre> nombres = new List<Nombre>();
            List<Descripcion> descripciones = new List<Descripcion>();
            for (int i = 0; i < habilidades.Count; i++)
            {
                nombres.Add(habilidades[i].Nombre);
                descripciones.Add(habilidades[i].Descripcion);
            }
            Nombre.SetNombre(rom, nombres);
            Descripcion.SetDescripcion(rom, descripciones);
        }



        public static void SetHabilidad(RomGba rom, int index, HabilidadCompleta habilidad)
        {
            Nombre.SetNombre(rom, index, habilidad.Nombre);
            Descripcion.SetDescripcion(rom, index, habilidad.Descripcion);
        }

    }
}
