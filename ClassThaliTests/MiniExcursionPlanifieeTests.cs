using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassThali;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassThali.Tests
{
    [TestClass()]
    public class MiniExcursionPlanifieeTests
    {

        [TestMethod()]
        public void GetCodeTest()
        {
            MiniExcursionPlanifiee MEP = new MiniExcursionPlanifiee("1", new MiniExcursion(1,"Visite de l'ile au large de THAL",20), DateTime.Parse("14:00"));
            Assert.AreEqual("1", MEP.GetCode());
        }

        [TestMethod()]
        //Verifer que le nombre d'inscrit est egale a 0
        //Verifier le nombre d'inscrit
        //Verifier le nombre d'incrit apres l'ajout d'une nouvelle personne
        public void SetNombreInscritsTest()
        {
            MiniExcursionPlanifiee MEP1 = new MiniExcursionPlanifiee("1", new MiniExcursion(1, "Visite de l'ile au large de THAL", 20), DateTime.Parse("14:00"));
            Assert.AreEqual(0,MEP1.GetNombreInscrits());
            MEP1.SetNombreInscrits(1);
            Assert.AreEqual(1,MEP1.GetNombreInscrits());
            MEP1.SetNombreInscrits(2);
            Assert.AreEqual(3, MEP1.GetNombreInscrits());
        }

        [TestMethod()]
        public void EstCompleteTest()
        {
            MiniExcursionPlanifiee MEP1 = new MiniExcursionPlanifiee("1", new MiniExcursion(1, "Visite de l'ile au large de THAL", 20), DateTime.Parse("14:00"));
            MEP1.SetNombreInscrits(1);
            Assert.AreEqual(false, MEP1.EstComplete());
            MEP1.SetNombreInscrits(19);
            Assert.AreEqual(true, MEP1.EstComplete());
        }

        [TestMethod()]
        public void HeureRetourPrevueTest()
        {
            MiniExcursion ME = new MiniExcursion(1, "Visite de l'ile au large de THALI", 20);
            MiniExcursionPlanifiee MEP1 = new MiniExcursionPlanifiee("1", ME, DateTime.Parse("14:00"));
            Assert.AreEqual(DateTime.Parse("14:00"), MEP1.HeureRetourPrevue());
            Etape ET1 = new Etape(1, "Traversee aller", 10);
            Etape ET2 = new Etape(2, "Promenade sur l'ile", 60);
            Etape ET3 = new Etape(3, "Visite du phare", 30);
            List<Etape> etapesME = new List<Etape> { ET1, ET2, ET3 };
            ME.SetLesEtapes(etapesME);
            Assert.AreEqual(DateTime.Parse("15:40"), MEP1.HeureRetourPrevue());
        }
    }
}