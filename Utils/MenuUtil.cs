using System;

namespace FIFA_Helper.Utils {
    public class MenuUtil {

        public static String[] PadMenuItems(string[] menuItems) {
            int longestItem = 0;
            foreach (string menuItem in menuItems) {
                if (menuItem.Length > longestItem) {
                    longestItem = menuItem.Length;
                }
            }

            for (int i = 0; i < menuItems.Length; i++) {
                string menuItem = menuItems[i];
                menuItems[i] = menuItem.PadRight(longestItem);
            }

            return menuItems;
        }
    }
}
