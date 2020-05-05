﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonGBAFramework.Core.Test.Batalla
{
    public delegate T GetIndividual<T>(RomGba rom, int pos);
    public delegate T GetAll<T>(RomGba rom);
    [TestClass]
    public abstract class BaseTest
    {
        #region Roms Individual
        [TestMethod]
        public void TestGetIndividualZafiroITA() => TestGetIndividual(Resource1.ZafiroITA);
        [TestMethod]
        public void TestGetIndividualEsmeraldaESP() => TestGetIndividual(Resource1.EsmeraldaESP);
        [TestMethod]
        public void TestGetIndividualEsmeraldaFRA() => TestGetIndividual(Resource1.EsmeraldaFRA);
        [TestMethod]
        public void TestGetIndividualEsmeraldaJAP() => TestGetIndividual(Resource1.EsmeraldaJAP);
        [TestMethod]
        public void TestGetIndividualVerdeHojaUSA11() => TestGetIndividual(Resource1.VerdeHojaUSA11);
        [TestMethod]
        public void TestGetIndividualRojoFuegoESP() => TestGetIndividual(Resource1.RojoFuegoESP);
        [TestMethod]
        public void TestGetIndividualRubiESP() => TestGetIndividual(Resource1.RubiESP);
        #endregion

        public abstract void TestGetIndividual(byte[] romData);

        protected void TestGetIndividual<T>(byte[] romData, GetIndividual<T> metodo)
        {
            RomGba rom = new RomGba(romData);
            Assert.IsNotNull(metodo(rom, 0));
        }
        #region Todos
        [TestMethod]
        public void TestGetTodosZafiroITA() => TestGetTodos(Resource1.ZafiroITA);
        [TestMethod]
        public void TestGetTodosEsmeraldaESP() => TestGetTodos(Resource1.EsmeraldaESP);
        [TestMethod]
        public void TestGetTodosEsmeraldaFRA() => TestGetTodos(Resource1.EsmeraldaFRA);
        [TestMethod]
        public void TestGetTodosEsmeraldaJAP() => TestGetTodos(Resource1.EsmeraldaJAP);
        [TestMethod]
        public void TestGetTodosVerdeHojaUSA11() => TestGetTodos(Resource1.VerdeHojaUSA11);
        [TestMethod]
        public void TestGetTodosRojoFuegoESP() => TestGetTodos(Resource1.RojoFuegoESP);
        [TestMethod]
        public void TestGetTodosRubiESP() => TestGetTodos(Resource1.RubiESP);
        #endregion
        public abstract void TestGetTodos(byte[] romData);

        protected void TestGetTodos<T>(byte[] romData, GetAll<T> metodo)
        {
            RomGba rom = new RomGba(romData);
            Assert.IsNotNull(metodo(rom));
        }
    }
}



