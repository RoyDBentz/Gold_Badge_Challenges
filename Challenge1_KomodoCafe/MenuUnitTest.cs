using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge1_KomodoCafe
{
    [TestClass]
    public class MenuUnitTest
    {
        MenuRepository _menuRepo = new MenuRepository();
        public readonly List<MenuItem> _menuItem = new List<MenuItem>();
        [TestMethod]
        public void ShouldAddMenuItem()
        {
            //AAA
            //Arange
            MenuItem menuTestItem = new MenuItem("1", "Meal", "Description", "Ingredients", 1.99d, "Alot");
            int startingCount = _menuRepo.GetAllMenuItems().Count();
            //Act
            _menuRepo.AddMenuItem(menuTestItem);
            //Assert
            int finalCount = _menuRepo.GetAllMenuItems().Count();
            Assert.IsTrue(startingCount < finalCount);
            // R
        }
        [TestMethod]
        public void ShouldRemoveMenuItem()
        {
            MenuItem menuTestItem = new MenuItem("1", "Meal", "Description", "Ingredients", 1.99d, "Alot");
            _menuRepo.AddMenuItem(menuTestItem);
            int startingCount = _menuRepo.GetAllMenuItems().Count();
            _menuRepo.RemoveMenuItem("Meal");
            int finalCount = _menuRepo.GetAllMenuItems().Count();

            Assert.IsTrue(startingCount > finalCount);
        }

        [TestMethod]
        public void ShouldGetMenuItemByMenuItemName()
        {
            MenuItem menuTestItem = new MenuItem("1", "Meal", "Description", "Ingredients", 1.99d, "Alot");
            _menuRepo.AddMenuItem(menuTestItem);

            MenuItem menuNamedItem = _menuRepo.GetMenuItemByName("Meal");

            Assert.AreEqual("Meal", menuNamedItem.MealName);
        }
    }

}
