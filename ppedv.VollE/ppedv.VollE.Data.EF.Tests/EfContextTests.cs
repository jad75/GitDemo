using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.VollE.Model;

namespace ppedv.VollE.Data.EF.Tests
{
    [TestClass]
    public class EfContextTests
    {
        [TestMethod]
        public void EfContext_can_create_database()
        {
            using (var con = new EfContext())
            {
                if (con.Database.Exists())
                    con.Database.Delete();

                con.Database.Create();

                Assert.IsTrue(con.Database.Exists());
            }
        }

        [TestMethod]
        public void EfContext_CRUD_Trainer()
        {
            var t = new Trainer() { Name = $"Fred_{Guid.NewGuid()}" };
            string newName = $"Wilma_{Guid.NewGuid()}";

            using (var con = new EfContext())
            {
                //INSERT
                con.Trainer.Add(t);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                //check INSERT / READ
                var loaded = con.Trainer.Find(t.Id);
                Assert.IsNotNull(loaded);
                Assert.AreEqual(t.Name, loaded.Name);

                //UPDATE
                loaded.Name = newName;
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                //check UPDATE
                var loaded = con.Trainer.Find(t.Id);
                Assert.AreEqual(newName, loaded.Name);

                //DELETE
                con.Trainer.Remove(loaded);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                //check DELETE
                var loaded = con.Trainer.Find(t.Id);
                Assert.IsNull(loaded);
            }
        }
    }
}
