using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1_KomodoCafe
{
    public class MenuRepository
    {
        readonly List<MenuItem> _menuItem = new List<MenuItem>();
        // C           
        public void AddMenuItem(MenuItem menuItem)
        {
            _menuItem.Add(menuItem);           
        }
        // R
        public List<MenuItem> GetAllMenuItems()
        {
            return _menuItem;
        }
        // U

        // D
        public bool RemoveMenuItem(string name)
        {
            MenuItem menuItem = GetMenuItemByName(name);
            if (name== null)
            {
                return false;
            }
            int itemCount = _menuItem.Count;
            _menuItem.Remove(menuItem);

            if (itemCount > _menuItem.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public MenuItem GetMenuItemByName(string name)
        {
            foreach(MenuItem menuItem in _menuItem)
            {
                if (menuItem.MealName == name)
                {
                    return menuItem;
                }
            }
            return null;
        }

    }
}
